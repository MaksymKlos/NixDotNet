using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    public class CommunityController : Controller
    {
        public IActionResult MyReview()
        {
            return View();
        }
    }
}
