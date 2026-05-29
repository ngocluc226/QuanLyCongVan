using DTO;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using PdfiumViewer;

namespace BLL
{
    public class AIServiceBLL
    {
        private static AIServiceBLL _Instance;
        public static AIServiceBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new AIServiceBLL();
                return _Instance;
            }
        }

        private readonly string _aiEndpoint;
        private readonly string _aiModel;

        // Cấu trúc phục vụ cơ chế xoay tua đa API Key bảo mật
        private readonly string[] _apiKeys;
        private int _currentKeyIndex = 0;
        private readonly object _keyLock = new object();

        private AIServiceBLL()
        {
            // Đọc trực tiếp từ tệp cấu hình App.config của dự án chạy chính (UI)
            _aiEndpoint = ConfigurationManager.AppSettings["AI_Endpoint"];
            _aiModel = ConfigurationManager.AppSettings["AI_Model"];

            // Khớp chính xác tên thẻ "AI_ApiKey" trong file cấu hình XML của bạn
            string rawKeys = ConfigurationManager.AppSettings["AI_ApiKey"];
            if (!string.IsNullOrEmpty(rawKeys))
            {
                _apiKeys = rawKeys.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        /// <summary>
        /// Hàm bổ trợ lấy Key hoạt động tiếp theo theo cơ chế xoay tua vòng tròn (Round-Robin)
        /// </summary>
        private string GetNextApiKey()
        {
            if (_apiKeys == null || _apiKeys.Length == 0) return null;

            lock (_keyLock)
            {
                string selectedKey = _apiKeys[_currentKeyIndex].Trim();
                _currentKeyIndex = (_currentKeyIndex + 1) % _apiKeys.Length;
                return selectedKey;
            }
        }

        /// <summary>
        /// Hàm gọi AI kiểm tra thể thức văn bản hành chính hỗ trợ cả ảnh và PDF nhiều trang
        /// </summary>
        public async Task<KetQuaKiemTraAI> KiemTraTheThucVanBanAsync(string filePath)
        {
            // Lấy API Key chiến lược cho lượt gọi này
            string activeApiKey = GetNextApiKey();

            // 1. Chốt chặn an toàn dữ liệu cấu hình hệ thống
            if (string.IsNullOrEmpty(_aiEndpoint) || string.IsNullOrEmpty(activeApiKey) || string.IsNullOrEmpty(_aiModel))
            {
                throw new Exception("Lỗi hệ thống: Chưa cấu hình đầy đủ Endpoint, danh sách ApiKey hoặc Model trong App.config!");
            }
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Không tìm thấy tệp tin tài liệu cần kiểm tra!");

            string extension = Path.GetExtension(filePath).ToLower().Trim();
            string mimeType = "image/png"; // Sử dụng PNG để giữ nguyên độ sắc nét khi nén chuỗi Base64
            string base64Image = "";

            // --- GIAI ĐOẠN 1: XỬ LÝ ĐA TRANG VÀ GHÉP ẢNH TỰ ĐỘNG (DPI THU GỌN CHỐNG QUÁ TẢI TOKEN) ---
            try
            {
                if (extension == ".pdf")
                {
                    using (var pdfDocument = PdfiumViewer.PdfDocument.Load(filePath))
                    {
                        int pageCount = pdfDocument.PageCount;
                        if (pageCount == 0)
                            throw new Exception("File PDF không có nội dung hoặc bị lỗi cấu trúc dữ liệu!");

                        // TỐI ƯU: Sử dụng 200 DPI giúp ảnh nhẹ hơn gấp 4 lần so với 400 DPI, giải quyết triệt để lỗi PaymentRequired
                        if (pageCount == 1)
                        {
                            using (var img = pdfDocument.Render(0, 200, 200, true))
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Png);
                                    base64Image = Convert.ToBase64String(ms.ToArray());
                                }
                            }
                        }
                        else
                        {
                            // NẾU CÓ NHIỀU TRANG: Tiến hành render trang đầu (0) và trang cuối (pageCount - 1) để quét thể thức
                            using (var firstPage = pdfDocument.Render(0, 200, 200, true))
                            using (var lastPage = pdfDocument.Render(pageCount - 1, 200, 200, true))
                            {
                                int combinedWidth = Math.Max(firstPage.Width, lastPage.Width);
                                int combinedHeight = firstPage.Height + lastPage.Height + 20;

                                using (var combinedImage = new Bitmap(combinedWidth, combinedHeight))
                                using (var g = Graphics.FromImage(combinedImage))
                                {
                                    g.Clear(Color.White); // Tạo nền trắng sạch cho ảnh ghép

                                    // Vẽ trang đầu tiên lên nửa trên
                                    g.DrawImage(firstPage, 0, 0);

                                    // Vẽ đường kẻ phân tách nhỏ giữa 2 trang giúp AI nhận diện vùng biên
                                    using (Pen p = new Pen(Color.LightGray, 2))
                                    {
                                        g.DrawLine(p, 0, firstPage.Height + 10, combinedWidth, firstPage.Height + 10);
                                    }

                                    // Vẽ trang cuối cùng lên nửa dưới
                                    g.DrawImage(lastPage, 0, firstPage.Height + 20);

                                    using (var ms = new MemoryStream())
                                    {
                                        combinedImage.Save(ms, ImageFormat.Png);
                                        base64Image = Convert.ToBase64String(ms.ToArray());
                                    }
                                }
                            }
                        }
                    }
                }
                else if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".webp")
                {
                    mimeType = extension == ".png" ? "image/png" : (extension == ".webp" ? "image/webp" : "image/jpeg");
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    base64Image = Convert.ToBase64String(fileBytes);
                }
                else
                {
                    throw new Exception($"Định dạng tệp {extension} không hỗ trợ! Hệ thống chỉ nhận tệp tài liệu PDF hoặc file ảnh dạng PNG, JPG, JPEG, WEBP.");
                }

                // Làm sạch chuỗi Base64 trước khi đóng gói
                base64Image = base64Image.Replace("\r", "").Replace("\n", "");

                // --- GIAI ĐOẠN 2: THIẾT LẬP CHIẾN LƯỢC PROMPT SOI CHỮ CHỐNG ĐOÁN BỪA ---
                string systemPrompt = @"Bạn là hệ thống Vision AI kiểm soát thể thức văn bản hành chính Việt Nam theo Nghị định 30/2020/NĐ-CP.
                Hình ảnh gửi lên có thể là một bức ảnh được ghép dọc từ TRANG ĐẦU TIÊN và TRANG CUỐI CÙNG của một văn bản nhiều trang (ngăn cách bởi một đường kẻ xám).
                Nhiệm vụ của bạn là rà soát trực quan HÌNH ẢNH văn bản và phát hiện các thành phần bị THIẾU. Tuyệt đối không tự suy diễn, ảo giác hoặc bỏ qua lỗi.

                QUY TẮC XÁC MINH CÓ CHỨNG CỨ (BẮT BUỘC):
                Bạn chỉ được công nhận một thành phần tồn tại nếu bạn trực tiếp NHÌN THẤY và ĐỌC ĐƯỢC chữ của thành phần đó trên ảnh. Hãy quét kỹ từng góc:

                1. KIỂM TRA PHẦN ĐẦU VĂN BẢN (Nằm ở nửa trên của bức ảnh ghép):
                   - QUỐC HIỆU (Góc trên cùng bên phải): Phải đọc được dòng chữ 'CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM' (in hoa, đậm). Nếu góc này trắng trơn hoặc là chữ của tiêu đề khác -> Thiếu Quốc hiệu.
                   - TIÊU NGỮ (Ngay dưới Quốc hiệu): Phải đọc được cụm từ 'Độc lập - Tự do - Hạnh phúc' (đậm, đứng) và phải nhìn thấy nét gạch chân liền phía dưới. Nếu không có chữ hoặc thiếu nét gạch -> Thiếu Tiêu ngữ.
                   - CƠ QUAN BAN HÀNH (Góc trên cùng bên trái): Phải xuất hiện tên cơ quan hoặc tổ chức ban hành văn bản (Ví dụ: 'BỘ...', 'ỦY BAN...', 'CÔNG TY...', 'TRƯỜNG...'). Nếu góc này trống không -> Thiếu Cơ quan ban hành.

                2. KIỂM TRA PHẦN CUỐI VĂN BẢN (Nằm ở nửa dưới của bức ảnh ghép):
                   - HỌ TÊN NGƯỜI KÝ (Góc dưới cùng bên phải): Phải đọc được họ và tên đầy đủ của người ký đặt ở dưới cùng (Ví dụ: 'Nguyễn Văn A'). Nếu chỉ có hình chữ ký hoặc chỉ có chức vụ mà hoàn toàn không có dòng chữ tên người cụ thể -> Thiếu Họ tên người ký.
                   - CHỮ KÝ VÀ CON DẤU: Phải có hình ảnh con dấu pháp lý màu đỏ (hoặc dấu số). Con dấu bắt buộc phải đóng trùm lên khoảng 1/3 chữ ký về phía bên trái. Nếu đóng lệch hẳn ra ngoài hoặc đè kín hoàn toàn chữ ký là SAI quy chuẩn.

                3. PHÔNG CHỮ CHỦ ĐẠO: Phần nội dung chính của văn bản phải đồng bộ sử dụng phông chữ Times New Roman (hoặc phông có chân chuẩn văn phòng). Bỏ qua các ràng buộc đo đạc lề chính xác bằng milimet (mm) do đặc thù file chụp/scan.

                YÊU CẦU ĐẦU RA (JSON THUẦN CHUẨN DTO):
                Bạn bắt buộc phải kiểm tra và trả về cấu trúc đối tượng JSON chính xác sau, không chứa ký tự bao bọc Markdown:
                - DiemSo (int): Thang điểm từ 0 đến 100. Hãy trừ thẳng tay 25 điểm cho mỗi thành phần cốt lõi bị thiếu ở trên. Nếu thiếu một trong bốn yếu tố bắt buộc, điểm tối đa chỉ là 75 (Mặc định không hợp lệ).
                - HopLe (bool): true nếu DiemSo >= 80, ngược lại là false.
                - DanhSachLoi (array string): Nếu thiếu hoặc sai thành phần nào, bắt buộc phải ghi rõ câu cảnh báo vào đây (Ví dụ: 'Văn bản thiếu cụm Quốc hiệu ở góc trên bên phải', 'Thiếu họ tên người ký ở góc dưới bên phải'). Nếu đầy đủ hoàn toàn, để mảng rỗng [].
                - DeXuatChinhSua (string): Hướng dẫn nhanh để người dùng bổ sung thành phần cụ thể.";

                string userPrompt = "Thực hiện phân tích hình ảnh văn bản. Hãy đọc quét thật kỹ toàn bộ hai vùng trên và dưới của ảnh ghép trước khi đưa ra danh sách lỗi hình thức.";

                var requestPayload = new
                {
                    model = _aiModel,
                    max_tokens = 1500,
                    messages = new object[] {
                        new { role = "system", content = systemPrompt },
                        new {
                            role = "user",
                            content = new object[] {
                                new { type = "text", text = userPrompt },
                                new {
                                    type = "image_url",
                                    image_url = new { url = $"data:{mimeType};base64,{base64Image}" }
                                }
                            }
                        }
                    },
                    response_format = new { type = "json_object" }
                };

                string jsonPayload = JsonConvert.SerializeObject(requestPayload);

                // --- GIAI ĐOẠN 3: KẾT NỐI MẠNG VÀ GỌI API ---
                string responseString = "";
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {activeApiKey}");
                    client.Timeout = TimeSpan.FromSeconds(35);

                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(_aiEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        responseString = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        string errDetail = await response.Content.ReadAsStringAsync();
                        throw new InvalidOperationException($"Máy chủ AI từ chối kết nối (Mã lỗi: {response.StatusCode}). Chi tiết: {errDetail}");
                    }
                }

                // --- GIAI ĐOẠN 4: KHỬ DẤU Markdown CHUỖI VÀ ĐẨY RA DTO ---
                var openRouterResponse = JsonConvert.DeserializeAnonymousType(responseString, new
                {
                    choices = new[] { new { message = new { content = "" } } }
                });

                string aiJsonContent = openRouterResponse.choices[0].message.content.Trim();

                if (aiJsonContent.StartsWith("```"))
                {
                    int firstLineBreak = aiJsonContent.IndexOf('\n');
                    int lastBackticks = aiJsonContent.LastIndexOf("```");
                    if (firstLineBreak != -1 && lastBackticks > firstLineBreak)
                    {
                        aiJsonContent = aiJsonContent.Substring(firstLineBreak, lastBackticks - firstLineBreak).Trim();
                    }
                }

                return JsonConvert.DeserializeObject<KetQuaKiemTraAI>(aiJsonContent);
            }
            catch (Exception ex) when (!(ex is InvalidOperationException) && !(ex is FileNotFoundException))
            {
                if (ex.Message.Contains("DTO") || ex.Message.Contains("JSON"))
                {
                    throw new Exception("AI phản hồi cấu trúc không tương thích hệ thống: " + ex.Message);
                }
                throw new Exception("Hệ thống mất kết nối mạng hoặc lỗi xử lý tệp: " + ex.Message);
            }
        }
    }
}