using System;
using System.Net.Mail;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public class EmailSender
    {
        private readonly ISecretesStorage _secretes;

        public EmailSender() {}
        public EmailSender(ISecretesStorage secretes)
        {
            _secretes = secretes;
        }

        public void PushEmail(string email, string name, string subject, string message)
        {
            var mailMessage = CreateMailMessage(email, name, subject, message);
            try
            {
                using SmtpClient smtpClient = new SmtpClient(_secretes.Host, _secretes.Port)
                {
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential(_secretes.EmailAddress, _secretes.EmailPassword),
                };
                smtpClient.Send(mailMessage);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        private MailMessage CreateMailMessage(string email, string name, string subject, string message)
        {
            if (_secretes == null) throw new ArgumentNullException(nameof(_secretes), "Secrets are null");
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
