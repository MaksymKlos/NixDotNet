using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.Controllers
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
