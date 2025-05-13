using EgyptMart.Services.Auth.Classes;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EgyptMart.Services.Auth.ProviderServices
{
    public class EmailService(IOptions<MailSettings> mailSettings) : IEmailService
    {
        private readonly MailSettings _mailSettings = mailSettings.Value;


        public async Task SendEmail(string toEmail, string subject, string body)
        {
            var mailMessage = new MimeMessage();

            mailMessage.From.Add(MailboxAddress.Parse(_mailSettings.EmailId));
            mailMessage.To.Add(MailboxAddress.Parse(toEmail));
            mailMessage.Subject = subject;
            mailMessage.MessageId = _mailSettings.Name;
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smpt = new SmtpClient();
            smpt.Connect(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smpt.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
            await smpt.SendAsync(mailMessage);
            await smpt.DisconnectAsync(true);
        }
    }
}
