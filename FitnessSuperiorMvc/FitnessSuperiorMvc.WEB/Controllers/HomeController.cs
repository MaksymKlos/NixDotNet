using System;
using FitnessSuperiorMvc.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.Mail;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _userName = "fitnesssuperiorapp@gmail.com";
        private readonly string _password = "12345Qwerty*";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ContactUs(string email, string name, string subject, string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage {From = new MailAddress(_userName) };
                mailMessage.To.Add(_userName);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = $"<b>Sender name:</b> {name}<br/>" +
                                   $"<b>Sender email:</b> {email}<br/>" +
                                   $"<b>Text of message:</b> {message}";
                

                using SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true, Credentials = new System.Net.NetworkCredential(_userName, _password),
                };
                smtpClient.Send(mailMessage);
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View();
        }
    }
}
