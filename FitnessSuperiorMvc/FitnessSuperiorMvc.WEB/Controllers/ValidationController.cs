using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using FitnessSuperiorMvc.Services.Programs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [AllowAnonymous]
    public class ValidationController : Controller
    {
        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;
        private readonly TrainingProgramsService _trainingProgramsService;

        private readonly FoodService _foodService;
        private readonly MealPlanService _mealPlanService;
        private readonly NutritionProgramService _nutritionProgramService;

        private readonly UserManager<IdentityUser> _userManager;

        public ValidationController(
            UserManager<IdentityUser> userManager,
            ExerciseService exerciseService,
            SetOfExercisesService setOfExercisesService,
            TrainingProgramsService trainingProgramsService,
            FoodService foodService,
            MealPlanService mealPlanService,
            NutritionProgramService nutritionProgramService)
        {
            _userManager = userManager;
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _trainingProgramsService = trainingProgramsService;
            _foodService = foodService;
            _mealPlanService = mealPlanService;
            _nutritionProgramService = nutritionProgramService;
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsNameOfExerciseInUse(string name)
        {
            var exercise = Task.Run(() => _exerciseService
                .GetAll()
                .FirstOrDefault(ex => ex.Name == name));
            return await exercise == null ? Json(true) : Json($"Exercise with name {name} is already exist");
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsNameOfComplexInUse(string name)
        {
            var complex = Task.Run(() => _setOfExercisesService
                .GetAll()
                .FirstOrDefault(ex => ex.Name == name));
            return await complex == null ? Json(true) : Json($"Set of exercises with name {name} is already exist");
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsNameOfTrainingProgramInUse(string name)
        {
            var program = Task.Run(() => _trainingProgramsService
                .GetAll()
                .FirstOrDefault(p => p.Name == name));
            return await program == null ? Json(true) : Json($"Training program with name {name} is already in exist");
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsNameOfFoodInUse(string name)
        {
            var food = Task.Run(() => _foodService
                .GetAll()
                .FirstOrDefault(p => p.Name == name));
            return await food == null ? Json(true) : Json($"Food with name {name} is already in exist");
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsNameOfMealPlanInUse(string name)
        {
            var mealPlan = Task.Run(() => _mealPlanService
                .GetAll()
                .FirstOrDefault(p => p.Name == name));
            return await mealPlan == null ? Json(true) : Json($"Meal plan with name {name} is already in exist");
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsNameOfNutritionProgramInUse(string name)
        {
            var program = Task.Run(() => _nutritionProgramService
                .GetAll()
                .FirstOrDefault(p => p.Name == name));
            return await program == null ? Json(true) : Json($"Nutrition program with name {name} is already in exist");
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUserLoginInUse(string login)
        {
            IdentityUser identityUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == login);
            return identityUser == null ? Json(true) : Json($"Login {login} is already exist");
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUserEmailInUse(string email)
        {
            IdentityUser identityUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
            return identityUser == null ? Json(true) : Json($"Email {email} is already exist");
        }

        [HttpGet]
        public IActionResult SuccessfulCreation(string type, string name)
        {
            ViewBag.Success = $"{type} called \'{name}\'";
            return View();
        }
    }
}
