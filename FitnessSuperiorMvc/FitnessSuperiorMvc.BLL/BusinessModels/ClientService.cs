using System.Net.Mail;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public interface IClientService
    {
        SmtpClient CreateSmtpClient(string address, string password, string host, int port);
    }

    public class ClientService : IClientService
    {
        public SmtpClient CreateSmtpClient(string address, string password, string host, int port)
        {
            using SmtpClient smtpClient = new SmtpClient(host, port)
            {
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential(address, password),
            };
            return smtpClient;
        }
    }
}
