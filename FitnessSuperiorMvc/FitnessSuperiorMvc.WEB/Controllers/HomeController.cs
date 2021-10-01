using System;
using FitnessSuperiorMvc.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FitnessSuperiorMvc.BLL.BusinessModels;
using FitnessSuperiorMvc.Services.Interaction;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageCreator _messageCreator;
        private readonly EmailSenderService _emailSender;

        public HomeController(IMessageCreator messageCreator, EmailSenderService emailSender)
        {
            _messageCreator = messageCreator;
            _emailSender = emailSender;
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
                var mail = _messageCreator.CreateMailMessage(email, name, subject, message);
                _emailSender.PushEmail(mail);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            
            return View();
        }
    }
}
