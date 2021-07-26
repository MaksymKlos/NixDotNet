using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.WEB.ViewModels;
using FitnessSuperiorMvc.WEB.ViewModels.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [Authorize]
    public class NutritionController : Controller
    {
        private readonly FitnessAppContext _db = new FitnessAppContext();
        
        public IActionResult CreateFood()
        {
            return View();
        }
        public IActionResult CreateMealPlan()
        {
            return View();
        }
        public IActionResult CreateProgram()
        {
            return View();
        }
        public IActionResult ExistingPrograms(int page = 1)
        {
            var programView = new PaginationViewModel<NutritionProgramDto>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = _db.NutritionPrograms,
                CurrentPage = page
            };
            return View(programView);
        }
        public IActionResult MyPrograms()
        {
            return View();
        }
    }
}
