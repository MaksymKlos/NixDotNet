using System;
using System.Net.Mail;
using FitnessSuperiorMvc.DA.Entities.Configuration;

namespace FitnessSuperiorMvc.DA.Repositories
{
    public interface IClientRepository
    {
        void SendEmail(MailMessage mailMessage);
    }

    public class ClientRepository : IClientRepository
    {
        private readonly ISecretesStorage _secretes;
        public ClientRepository(ISecretesStorage secretes)
        {
            _secretes = secretes;
        }
        
        public void SendEmail(MailMessage mailMessage)
        {
            var smtpClient = CreateSmtpClient();
            if (smtpClient == null)
            {
                throw new ArgumentNullException("Smtp client is null.", nameof(smtpClient));
            }

            smtpClient.Send(mailMessage);
        }
        private SmtpClient CreateSmtpClient()
        {
            using var smtpClient = new SmtpClient(_secretes.Host, _secretes.Port)
            {
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential(_secretes.EmailAddress, _secretes.EmailPassword),
            };
            return smtpClient;
        }
    }
}
