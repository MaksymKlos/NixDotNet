using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    public class CommunityController : Controller
    {
        [HttpGet]
        public IActionResult MyReview()
        {
            return View();
        }
    }
}
