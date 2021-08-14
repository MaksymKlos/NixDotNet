using System;
using System.Linq;
using System.Net.Mail;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.Interaction;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public class EmailSender
    {
        private readonly FitnessAppContext _context;
        private string _email;
        private string _password;
        
        public EmailSender(FitnessAppContext context)
        {
            _context = context;
            SetMailAndPassword();
        }

        public void PushEmail(string email, string name, string subject, string message)
        {
            var mailMessage = CreateMailMessage(email, name, subject, message);
            try
            {
                using SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential(_email, _password),
                };
                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private void SetMailAndPassword()
        {
            Mailer mailer = _context.Mailer.FirstOrDefault();
            if (mailer == null) throw new ArgumentNullException(nameof(mailer),"Mail data is null.");
            _email = mailer.Email;
            _password = mailer.Password;
        }

        private MailMessage CreateMailMessage(string email, string name, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage { From = new MailAddress(_email) };
            mailMessage.To.Add(_email);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"<b style=\"color: red;\">Sender name:</b> {name}<br/><hr/>" +
                               $"<b>Sender email:</b> {email}<br/>" +
                               $"<b>Text of message:</b> {message}";
            return mailMessage;
        }
        
    }
}
