using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using FitnessSuperiorMvc.DA.Entities.Configuration;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public interface IMessageCreator
    {
        MailMessage CreateMailMessage(string userEmail, string name, string subject, string message);
    }

    public class MessageCreator : IMessageCreator
    {
        private readonly ISecretesStorage _secretesStorage;

        private const string EmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                            + "@"
                                            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

        private string ReceiverAddress
        {
            get
            {
                var receiverAddress = _secretesStorage.EmailAddress;
                if (string.IsNullOrWhiteSpace(receiverAddress))
                {
                    throw new ArgumentException("Address can't be null or white spaced.", nameof(receiverAddress));
                }
                if (!Regex.IsMatch(receiverAddress, EmailPattern))
                {
                    throw new FormatException("Email is incorrect.");
                }
                return receiverAddress;
            }
        }

        public MessageCreator(ISecretesStorage secretesStorage)
        {
            _secretesStorage = secretesStorage;
        }
        public MailMessage CreateMailMessage(string userEmail, string name, string subject, string message)
        {
            var mailMessage = new MailMessage ();

            mailMessage.From = new MailAddress(ReceiverAddress);
            mailMessage.To.Add(ReceiverAddress);

            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"<b style=\"color: red;\">Sender name:</b> {name}<br/><hr/>" +
                               $"<b>Sender email:</b> {userEmail}<br/>" +
                               $"<b>Text of message:</b> {message}";
            return mailMessage;
        }
    }
}
