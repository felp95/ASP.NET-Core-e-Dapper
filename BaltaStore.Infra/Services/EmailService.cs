using BaltaStore.Domain.StoreContext.Services;

namespace BaltaStore.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string @from, string subject, string body)
        {
            throw new System.NotImplementedException();
        }
    }
}
