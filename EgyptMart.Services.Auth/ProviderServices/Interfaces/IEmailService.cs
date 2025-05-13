namespace EgyptMart.Services.Auth.ProviderServices
{
    public interface IEmailService
    {
        public Task SendEmail(string toEmail, string subject, string body);
    }
}
