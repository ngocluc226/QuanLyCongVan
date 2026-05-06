using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BLL
{
    public class EmailService
    {
        // Cấu hình tài khoản email hệ thống (Vui lòng thay đổi Email và App Password thực tế của bạn)
        private const string SystemEmail = "your-email@gmail.com";
        private const string AppPassword = "your-app-password"; // Mật khẩu ứng dụng (App Password) của Gmail
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587;

        public static void SendMailToLeader(string toEmail, string soDi, string trichYeu)
        {
            Task.Run(() =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(toEmail)) return;

                    var fromAddress = new MailAddress(SystemEmail, "Hệ Thống Quản Lý Công Văn");
                    var toAddress = new MailAddress(toEmail);
                    string subject = $"[Hệ Thống QLCV] Trình duyệt công văn đi số: {soDi}";
                    string body = $"Kính gửi Lãnh đạo,\n\nCó một công văn đi mới đang chờ phê duyệt.\nSố đi: {soDi}\nTrích yếu: {trichYeu}\n\nVui lòng đăng nhập hệ thống để xem chi tiết và phê duyệt.\n\nTrân trọng,\nHệ thống QLCV.";

                    var smtp = new SmtpClient
                    {
                        Host = SmtpHost,
                        Port = SmtpPort,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, AppPassword)
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    // Log error nếu gửi mail bị lỗi
                    Console.WriteLine("Lỗi gửi mail: " + ex.Message);
                }
            });
        }
    }
}