using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Dto.FitnessProgram;

namespace FitnessSuperiorMvc.Controllers
{
    public class ResourcesController : Controller
    {
        public IActionResult Workout()
        {
            return View();
        }
        public IActionResult Nutrition()
        {
            return View();
        }
        public IActionResult Rest()
        {
            return View();
        }
    }
}
