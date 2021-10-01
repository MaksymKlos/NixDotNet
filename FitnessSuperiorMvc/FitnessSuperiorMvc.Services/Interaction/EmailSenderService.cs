using System;
using System.Net.Mail;
using FitnessSuperiorMvc.DA.Repositories;

namespace FitnessSuperiorMvc.Services.Interaction
{
    public class EmailSenderService
    {
        private readonly IClientRepository _clientRepository;
        
        public EmailSenderService(
            IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void PushEmail(MailMessage mailMessage)
        {
            if (mailMessage == null)
            {
                throw new ArgumentNullException(nameof(mailMessage), "Mail message is null.");
            }
            _clientRepository.SendEmail(mailMessage);
        }

    }
}
