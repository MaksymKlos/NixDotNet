using System.Net.Mail;
using FitnessSuperiorMvc.DA.Repositories;
using FitnessSuperiorMvc.Services.Interaction;
using Moq;
using NUnit.Framework;

namespace FitnessSuperiorMvc.BLL.Tests.BusinessModels
{
    [TestFixture]
    public class EmailSenderTests
    {
        private Mock<IClientRepository> _clientRepository;

        private EmailSenderService _emailSenderService;
        private MailMessage _mailMessage;

        [SetUp]
        public void SetUp()
        {
            _mailMessage = new MailMessage();
            _clientRepository = new Mock<IClientRepository>();
            _emailSenderService = new EmailSenderService(_clientRepository.Object);
        }

        [Test]
        public void PushEmail_MailMessageIsNull_ShouldReturnArgumentNullException()
        {
            Assert.That(() => _emailSenderService.PushEmail(null), Throws.ArgumentNullException);
            _clientRepository.Verify(cs=>cs.SendEmail(_mailMessage),Times.Never);
        }

        [Test]
        public void PushEmail_WhenCalled_ShouldSendEmail()
        {
            _emailSenderService.PushEmail(_mailMessage);
            _clientRepository.Verify(cs=>cs.SendEmail(_mailMessage));
        }
    }
}
