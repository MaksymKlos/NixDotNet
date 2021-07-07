using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSuperiorMvc.Controllers
{
    public class CommunityController : Controller
    {
        public IActionResult MyReview()
        {
            return View();
        }
    }
}
