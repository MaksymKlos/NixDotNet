using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    public class ResourcesController : Controller
    {
        [HttpGet]
        public IActionResult Workout()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Nutrition()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Rest()
        {
            return View();
        }
    }
}
