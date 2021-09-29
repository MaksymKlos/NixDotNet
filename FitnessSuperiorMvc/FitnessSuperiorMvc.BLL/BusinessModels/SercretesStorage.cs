using System;
using Microsoft.Extensions.Configuration;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public interface ISecretesStorage
    {
        string EmailAddress { get; }
        string EmailPassword { get; }
        string Host { get;}
        int Port { get; }
    }

    public class SecretesStorage : ISecretesStorage
    {
        private readonly IConfiguration _configuration;

        public string EmailAddress
        {
            get
            {
                var email = _configuration["email_address"];
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentException("Email is empty or white space", nameof(email));
                return email;
            }
        }

        public string EmailPassword
        {
            get
            {
                var password = _configuration["email_password"];
                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("Password is empty or white space", nameof(password));
                return password;
            }
        }

        public string Host
        {
            get
            {
                var host = _configuration["host"];
                if (string.IsNullOrWhiteSpace(host))
                    throw new ArgumentException("Host is empty or white space", nameof(host));
                return host;

            }
        }

        public int Port
        {
            get
            {
                if(!int.TryParse(_configuration["port"], out var port))
                {
                    throw new ArgumentException("Failed to convert type", nameof(port));
                }
                return port;
            }
        }

        public SecretesStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    }
}
