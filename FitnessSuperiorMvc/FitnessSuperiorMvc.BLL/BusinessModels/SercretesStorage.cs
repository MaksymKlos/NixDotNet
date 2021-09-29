using Microsoft.Extensions.Configuration;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public interface ISecretesStorage
    {
        string EmailAddress { get; set; }
        string EmailPassword { get; set; }
        string Host { get; set; }
        int Port { get; set; }
        void SetSecretData();
    }

    public class SecretesStorage : ISecretesStorage
    {
        private readonly IConfiguration _configuration;

        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public SecretesStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SetSecretData()
        {
            EmailAddress = _configuration["email_address"];
            EmailPassword = _configuration["email_password"];
            Host = _configuration["host"];
            if (int.TryParse(_configuration["port"], out var port))
            {
                Port = port;
            }
        }
    }
}
