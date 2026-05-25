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

        private readonly string[] _apiKeys;
        private int _currentKeyIndex = 0;
        private readonly object _keyLock = new object();

        private AIServiceBLL()
        {
            _aiEndpoint = ConfigurationManager.AppSettings["AI_Endpoint"];
            _aiModel = ConfigurationManager.AppSettings["AI_Model"];

            string rawKeys = ConfigurationManager.AppSettings["AI_ApiKeys"];
            if (!string.IsNullOrEmpty(rawKeys))
            {
                _apiKeys = rawKeys.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

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

        public async Task<KetQuaKiemTraAI> KiemTraTheThucVanBanAsync(string filePath)
        {
            string activeApiKey = GetNextApiKey();

            if (string.IsNullOrEmpty(_aiEndpoint) || string.IsNullOrEmpty(activeApiKey) || string.IsNullOrEmpty(_aiModel))
            {
                throw new Exception("Lỗi hệ thống: Chưa cấu hình đầy đủ Endpoint, danh sách ApiKey hoặc Model trong App.config!");
            }
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Không tìm thấy tệp tin tài liệu cần kiểm tra!");

            string extension = Path.GetExtension(filePath).ToLower().Trim();
            string mimeType = "image/png"; // Ép sang PNG để đảm bảo chất lượng ảnh ghép không bị vỡ chữ
            string base64Image = "";

            // --- GIAI ĐOẠN 1: XỬ LÝ ĐA TRANG VÀ GHÉP ẢNH TỰ ĐỘNG ---
            try
            {
                if (extension == ".pdf")
                {
                    using (var pdfDocument = PdfiumViewer.PdfDocument.Load(filePath))
                    {
                        int pageCount = pdfDocument.PageCount;
                        if (pageCount == 0)
                            throw new Exception("File PDF không có nội dung hoặc bị lỗi cấu trúc!");

                        if (pageCount == 1)
                        {
                            // Nếu chỉ có 1 trang, render bình thường
                            using (var img = pdfDocument.Render(0, 300, 300, true))
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
                            // NẾU CÓ NHIỀU TRANG: Tiến hành lấy trang đầu (0) và trang cuối (pageCount - 1)
                            using (var firstPage = pdfDocument.Render(0, 300, 300, true))
                            using (var lastPage = pdfDocument.Render(pageCount - 1, 300, 300, true))
                            {
                                // Tính toán kích thước tổng để tạo một bức ảnh dọc ghép 2 trang lại
                                int combinedWidth = Math.Max(firstPage.Width, lastPage.Width);
                                int combinedHeight = firstPage.Height + lastPage.Height + 20; // Cộng thêm 20px khoảng cách phân đoạn

                                using (var combinedImage = new Bitmap(combinedWidth, combinedHeight))
                                using (var g = Graphics.FromImage(combinedImage))
                                {
                                    g.Clear(Color.White); // Đổ nền trắng cho ảnh ghép

                                    // Vẽ trang đầu tiên lên nửa trên
                                    g.DrawImage(firstPage, 0, 0);

                                    // Vẽ một đường chỉ phân tách nhỏ giữa 2 trang để AI phân biệt vùng dữ liệu
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

                // Loại bỏ ký tự ngắt dòng thừa trong chuỗi Base64
                base64Image = base64Image.Replace("\r", "").Replace("\n", "");

                // --- GIAI ĐOẠN 2: CẬP NHẬT PROMPT ĐỌC ẢNH GHÉP HAI TRANG ---
                string systemPrompt = @"Bạn là hệ thống Vision AI kiểm soát thể thức văn bản hành chính Việt Nam theo Nghị định 30/2020/NĐ-CP.
                Hình ảnh gửi lên có thể là một bức ảnh được ghép dọc từ TRANG ĐẦU TIÊN và TRANG CUỐI CÙNG của một văn bản nhiều trang (ngăn cách bởi một đường kẻ xám).
                Hãy rà soát kỹ lưỡng các vùng thông tin theo quy trình sau:

                1. KIỂM TRA PHẦN ĐẦU VĂN BẢN (Nằm ở nửa trên của bức ảnh ghép):
                   - QUỐC HIỆU: Góc trên bên phải phải có 'CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM' (in hoa, đậm).
                   - TIÊU NGỮ: Ngay dưới Quốc hiệu phải có 'Độc lập - Tự do - Hạnh phúc' (đậm, đứng, có nét gạch chân liền phía dưới).
                   - CƠ QUAN BAN HÀNH: Góc trên bên trái phải có tên tổ chức hoặc cơ quan ban hành văn bản.
                   Nếu thiếu một trong các thành phần đầu này -> BÁO LỖI NGHIÊM TRỌNG.

                2. KIỂM TRA PHẦN CUỐI VĂN BẢN (Nằm ở nửa dưới của bức ảnh ghép):
                   - HỌ TÊN NGƯỜI KÝ: Phải xuất hiện rõ ràng họ tên đầy đủ bằng chữ in thường/in hoa của người có thẩm quyền ký ở dưới cùng bên phải. Nếu chỉ có chức vụ hoặc chữ ký mà không ghi rõ họ tên chữ bên dưới -> BÁO LỖI NGHIÊM TRỌNG.
                   - CHỮ KÝ VÀ CON DẤU: Phải có hình ảnh con dấu pháp lý màu đỏ (hoặc dấu số). Con dấu bắt buộc phải đóng trùm lên khoảng 1/3 chữ ký về phía bên trái. Nếu đóng lệch hẳn ra ngoài hoặc đè kín hoàn toàn chữ ký là SAI.

                YÊU CẦU ĐẦU RA (JSON THUẦN):
                Bạn bắt buộc phải kiểm tra và trả về cấu trúc đối tượng JSON chính xác sau:
                - DiemSo (int): Thang điểm từ 0 đến 100. Trừ thẳng tay 25 điểm cho mỗi thành phần bị thiếu ở trên. Thiếu 1 thành phần cốt lõi thì điểm tối đa chỉ là 75 (Không hợp lệ).
                - HopLe (bool): true nếu DiemSo >= 80, ngược lại là false.
                - DanhSachLoi (array string): Nếu thiếu thành phần nào, bắt buộc phải ghi rõ câu cảnh báo vào đây (Ví dụ: 'Văn bản thiếu cụm Quốc hiệu ở góc trên bên phải', 'Thiếu họ tên người ký ở phần cuối văn bản'). Nếu đầy đủ hoàn toàn, để mảng rỗng [].
                - DeXuatChinhSua (string): Hướng dẫn bổ sung thành phần cụ thể.";

                string userPrompt = "Thực hiện phân tích hình ảnh văn bản. Lưu ý đây là ảnh ghép giữa trang đầu và trang cuối của tài liệu, hãy quét kỹ cả hai vùng trên và dưới.";

                var requestPayload = new
                {
                    model = _aiModel,
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

                // --- GIAI ĐOẠN 4: TRẢ KẾT QUẢ DTO ---
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