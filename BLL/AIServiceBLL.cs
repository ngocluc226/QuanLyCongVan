using DTO;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
        // ĐỒNG BỘ MỚI: Đọc trực tiếp từ file App.config thay vì gán cứng trong code
        private readonly string _aiEndpoint = ConfigurationManager.AppSettings["AI_Endpoint"];
        private readonly string _apiKey = ConfigurationManager.AppSettings["AI_ApiKey"];
        private readonly string _aiModel = ConfigurationManager.AppSettings["AI_Model"];
        public async Task<KetQuaKiemTraAI> KiemTraTheThucVanBanAsync(string filePath)
        {
            // Kiểm tra an toàn xem file cấu hình có bị thiếu tham số không
            if (string.IsNullOrEmpty(_aiEndpoint) || string.IsNullOrEmpty(_apiKey))
            {
                throw new Exception("Lỗi hệ thống: Chưa cấu hình thông số AI_Endpoint hoặc AI_ApiKey trong tệp App.config!");
            }
            if (string.IsNullOrEmpty(_aiEndpoint) || string.IsNullOrEmpty(_apiKey) || string.IsNullOrEmpty(_aiModel))
            {
                throw new Exception("Lỗi hệ thống: Chưa cấu hình đầy đủ Endpoint, ApiKey hoặc Model trong tệp App.config!");
            }
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Không tìm thấy tệp tin dự thảo cần kiểm tra!");

            string extension = Path.GetExtension(filePath).ToLower();
            string mimeType = "image/jpeg";
            if (extension == ".png") mimeType = "image/png";

            string jsonPayload = "";

            // --- GIAI ĐOẠN 1: ĐỌC FILE VÀ ĐÓNG GÓI PAYLOAD ---
            try
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string base64Image = Convert.ToBase64String(fileBytes);

                string systemPrompt = @"Bạn là Chuyên gia Kiểm tra Văn bản Hành chính Việt Nam. 
                Nhiệm vụ của bạn là kiểm tra HÌNH ẢNH văn bản được cung cấp và đối chiếu nghiêm ngặt với Nghị định 30/2020/NĐ-CP theo các quy chuẩn kỹ thuật sau:
                1. CĂN LỀ:Lề trên: 20-25mm, Lề dưới: 20-25mm, Lề trái: 30-35mm (để đóng gáy), Lề phải: 15-20mm.
                2. PHÔNG CHỮ: Phải dùng duy nhất phông chữ Times New Roman cho toàn bộ văn bản.
                3. QUỐC HIỆU & TIÊU NGỮ: 
                   - Dòng 1 'CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM': Chữ in hoa, cỡ chữ 12-13, đứng, đậm.
                   - Dòng 2 'Độc lập - Tự do - Hạnh phúc': Chữ in thường, cỡ chữ 13-14, đứng, đậm, chữ cái đầu các từ phải viết hoa. 
                    Có đường kẻ ngang màu đen bên dưới, nét liền, độ dài bằng độ dài dòng chữ.
                4. TÊN CƠ QUAN & SỐ HIỆU: Đặt góc trái, cỡ 12-13. Số và ký hiệu văn bản phải đúng dạng.
                5. ĐỊA DANH & NGÀY THÁNG: Đặt góc phải, ngang hàng với Số hiệu, chữ in thường, cỡ 13-14, nghiêng.
                6. TRÍCH YẾU NỘI DUNG: Chữ in thường, cỡ 13-14, đứng, đậm, đặt ngay dưới tên loại văn bản.
                7. THẨM QUYỀN & CON DẤU: Chức vụ người ký viết hoa, in bài (cỡ 13-14, đứng, đậm). Con dấu đóng phải rõ ràng, đóng trùm lên khoảng 1/3 chữ ký về phía bên trái.

                YÊU CẦU ĐẦU RA: Bạn BẮT BUỘC phải trả về dữ liệu dưới cấu trúc một đối tượng JSON thuần túy, bao gồm các trường:
                - DiemSo (int): Thang điểm từ 0 đến 100 dựa trên mức độ vi phạm.
                - HopLe (bool): true nếu DiemSo >= 80, ngược lại là false.
                - DanhSachLoi (array string): Liệt kê chi tiết, cụ thể từng lỗi thể thức, font, lề phát hiện được từ ảnh.
                - DeXuatChinhSua (string): Lời khuyên ngắn gọn để nhân viên sửa lại cho đúng quy chuẩn.";

                string userPrompt = "Hãy phân tích hình ảnh đính kèm và kiểm tra thể thức văn bản hành chính này.";

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

                jsonPayload = JsonConvert.SerializeObject(requestPayload);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khởi tạo dữ liệu tệp tin: " + ex.Message);
            }

            // --- GIAI ĐOẠN 2: KẾT NỐI MẠNG VÀ GỌI API ---
            string responseString = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
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
                        // Ném lỗi này ra và KHÔNG cho khối catch bên dưới nuốt mất
                        throw new InvalidOperationException($"Máy chủ AI từ chối kết nối (Mã lỗi: {response.StatusCode}). Chi tiết: {errDetail}");
                    }
                }
            }
            catch (Exception ex) when (!(ex is InvalidOperationException))
            {
                // KỸ THUẬT MỚI: Chỉ bắt lỗi mạng thật (WebException, TaskCanceledException do Timeout,...)
                // Nếu là InvalidOperationException do sai Key/hết tiền phía trên ném ra, catch này sẽ BỎ QUA để đẩy thẳng lên UI.
                throw new Exception("Cần kiểm tra và kết nối lại mạng để thực hiện chức năng này!");
            }

            // --- GIAI ĐOẠN 3: GIẢI MÃ JSON KẾT QUẢ ĐẦU RA ---
            try
            {
                var openRouterResponse = JsonConvert.DeserializeAnonymousType(responseString, new
                {
                    choices = new[] { new { message = new { content = "" } } }
                });

                string aiJsonContent = openRouterResponse.choices[0].message.content.Trim();

                // BẢO VỆ CHỐNG LỖI FORMAT: Loại bỏ ký tự bọc khối ```json của Markdown nếu AI lỡ tay sinh ra
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
            catch (Exception ex)
            {
                // Giúp bạn debug xem cấu trúc JSON trả về bị sai lệch ở trường nào
                throw new Exception("AI phản hồi cấu trúc không tương thích DTO: " + ex.Message);
            }
        }
    }
}