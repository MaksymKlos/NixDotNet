using System;
using System.Net.Mail;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public class EmailSender
    {
        private readonly ISecretesStorage _secretes;
        private readonly IClientService _clientService;


        public EmailSender() {}
        public EmailSender(ISecretesStorage secretes, IClientService clientService)
        {
            _secretes = secretes;
            _clientService = clientService;
        }

        public void PushEmail(string email, string name, string subject, string message)
        {
            var mailMessage = CreateMailMessage(email, name, subject, message);
            try
            {
                var smtpClient = _clientService.CreateSmtpClient(
                    _secretes.EmailAddress, _secretes.EmailPassword, _secretes.Host, _secretes.Port);
                smtpClient.Send(mailMessage);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        private MailMessage CreateMailMessage(string email, string name, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage { From = new MailAddress(_secretes.EmailAddress) };
            mailMessage.To.Add(_secretes.EmailAddress);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"<b style=\"color: red;\">Sender name:</b> {name}<br/><hr/>" +
                               $"<b>Sender email:</b> {email}<br/>" +
                               $"<b>Text of message:</b> {message}";
            return mailMessage;
        }
        
    }
}
