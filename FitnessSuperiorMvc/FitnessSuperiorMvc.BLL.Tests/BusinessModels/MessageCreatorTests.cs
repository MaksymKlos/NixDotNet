using System;
using System.Net.Mail;
using FitnessSuperiorMvc.BLL.BusinessModels;
using FitnessSuperiorMvc.DA.Entities.Configuration;
using Moq;
using NUnit.Framework;

namespace FitnessSuperiorMvc.BLL.Tests.BusinessModels
{
    [TestFixture]
    public class MessageCreatorTests
    {
        private MessageCreator _messageCreator;
        private Mock<ISecretesStorage> _secretStorage;

        [SetUp]
        public void SetUp()
        {
            _secretStorage = new Mock<ISecretesStorage>();
            _messageCreator = new MessageCreator(_secretStorage.Object);
        }

        [Test]
        [TestCase(null)]
        [TestCase("  ")]
        [TestCase("")]
        public void CreateMailMessage_ReceiverAddressIsEmptyOrWhiteSpace_ReturnsArgumentException(string email)
        {
            _secretStorage.Setup(ss => ss.EmailAddress).Returns(email);
            Assert.That(() => _messageCreator.CreateMailMessage(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()), Throws.ArgumentException);
        }
        [Test]
        public void CreateMailMessage_ReceiverAddressFormatIsIncorrect_ReturnsFormatException()
        {
            _secretStorage.Setup(ss => ss.EmailAddress).Returns("test");
            Assert.That(() => _messageCreator.CreateMailMessage(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Throws.Exception.TypeOf<FormatException>());
        }
        [Test]
        public void CreateMailMessage_WhenCalledWithValidData_ReturnsMailMessage()
        {
            _secretStorage.Setup(ss=>ss.EmailAddress).Returns("abc@gmail.com");
            Assert.That(() => _messageCreator.CreateMailMessage(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()), Is.TypeOf<MailMessage>());
        }

    }
}
