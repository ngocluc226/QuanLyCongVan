using DTO;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Xceed.Words.NET;

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
            _aiEndpoint = ConfigurationManager.AppSettings["AI_Endpoint"];
            _aiModel = ConfigurationManager.AppSettings["AI_Model"];

            string rawKeys = ConfigurationManager.AppSettings["AI_ApiKey"];
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

        /// <summary>
        /// Hàm gọi AI kiểm tra thể thức văn bản hành chính trực tiếp từ tệp tin Word thô
        /// </summary>
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
            if (extension != ".docx")
            {
                throw new Exception("Vui lòng tải lên tệp tin Word định dạng (.docx) để thực hiện kiểm tra.");
            }

            StringBuilder wordContentBuilder = new StringBuilder();

            // --- GIAI ĐOẠN 1: ĐỌC VĂN BẢN THÔ (AN TOÀN TUYỆT ĐỐI - KHÔNG SỬ DỤNG ĐỊNH DẠNG LỖI) ---
            try
            {
                using (DocX document = DocX.Load(filePath))
                {
                    int paragraphIndex = 1;
                    foreach (var paragraph in document.Paragraphs)
                    {
                        string text = paragraph.Text?.Trim();
                        if (string.IsNullOrEmpty(text)) continue;

                        wordContentBuilder.AppendLine($"[Dòng {paragraphIndex}]: {text}");
                        paragraphIndex++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong quá trình đọc nội dung tệp Word: " + ex.Message);
            }

            string fullWordText = wordContentBuilder.ToString();
            if (string.IsNullOrEmpty(fullWordText))
            {
                throw new Exception("Tệp tin Word trống hoặc không có nội dung văn bản để kiểm tra!");
            }

            // --- GIAI ĐOẠN 2: TINH CHỈNH PROMPT THÔNG MINH CHO AI TỰ ĐỌC HIỂU CẤU TRÚC ---
            string systemPrompt = @"Bạn là Chuyên gia Kiểm tra Văn bản Hành chính Việt Nam. Nhiệm vụ của bạn là rà soát nội dung dữ liệu văn bản thô trích xuất từ file Word để kết luận xem có tuân thủ quy chuẩn hình thức theo Nghị định 30/2020/NĐ-CP hay không.

            QUY TẮC KHẢO SÁT CHỮ VÀ VỊ TRÍ (PHÂN TÍCH THÔNG MINH):
            1. QUỐC HIỆU & TIÊU NGỮ: 
               - Phải tồn tại dòng chữ: 'CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM' nằm ở các dòng đầu tiên (thường là Dòng 1 hoặc Dòng 2). Cụm từ này bắt buộc phải viết IN HOA toàn bộ. Nếu viết thường hoặc thiếu -> Lỗi nặng.
               - Ngay dưới Quốc hiệu phải có dòng Tiêu ngữ: 'Độc lập - Tự do - Hạnh phúc'. Quy chuẩn: Phải viết hoa các chữ cái đầu cụm từ và cách nhau bằng dấu gạch ngang có khoảng trống.
            2. CƠ QUAN BAN HÀNH: Xuất hiện ở các dòng đầu tiên, nằm ở khu vực đối xứng phía bên trái của Quốc hiệu (Ví dụ: tên công ty, ủy ban, bộ ban ngành). Nếu các dòng đầu trống trơn -> Thiếu cơ quan ban hành.
            3. HỌ TÊN NGƯỜI KÝ VÀ CHỨC VỤ:
               - Ở nhóm các dòng cuối cùng của văn bản, bắt buộc phải xuất hiện chức vụ của người có thẩm quyền ký (Ví dụ: GIÁM ĐỐC, HIỆU TRƯỞNG, CHỦ TỊCH,...) viết IN HOA.
               - Ngay phía dưới chức danh đó, phải ghi rõ Họ và tên đầy đủ của người ký (Ví dụ: Nguyễn Văn A). Nếu có chức danh mà hoàn toàn trống phần họ tên bên dưới -> Báo lỗi nghiêm trọng.

            YÊU CẦU ĐẦU RA (JSON THUẦN CHUẨN DTO):
            Bạn bắt buộc phải phân tích ngữ cảnh và trả về duy nhất một đối tượng JSON cấu trúc chính xác sau (Không bao bọc ký tự markdown):
            - DiemSo (int): Thang điểm từ 0 đến 100. Trừ thẳng tay 25 điểm cho mỗi lỗi vi phạm nghiêm trọng ở trên (Thiếu quốc hiệu viết hoa, thiếu tiêu ngữ, thiếu tên người ký cuối trang). Văn bản phải đạt từ 80 điểm trở lên mới tính là Hợp lệ.
            - HopLe (bool): true nếu DiemSo >= 80, ngược lại là false.
            - DanhSachLoi (array string): Liệt kê chi tiết dòng nào sai hoặc thiếu thành phần gì (Ví dụ: 'Văn bản chưa có cụm Quốc hiệu viết IN HOA ở đầu trang', 'Phần cuối văn bản thiếu Họ tên người ký cụ thể'). Nếu hoàn toàn chuẩn xác, để mảng rỗng [].
            - DeXuatChinhSua (string): Lời khuyên tổng quan cụ thể để người soạn thảo hoàn thiện lại văn bản.";

            var requestPayload = new
            {
                model = _aiModel,
                max_tokens = 1500,
                messages = new object[] {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = $"Hãy rà soát và đánh giá thể thức của nội dung file Word hành chính sau đây:\n\n{fullWordText}" }
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

            // --- GIAI ĐOẠN 4: ĐẨY DỮ LIỆU ĐẦU RA ---
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
    }
}