using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessSuperiorMvc.Services.People;
using FitnessSuperiorMvc.Services.Programs;
using Microsoft.AspNetCore.Identity;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    public class ListController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;

        private readonly FoodService _foodService;
        private readonly MealPlanService _mealPlanService;

        private readonly TrainerService _trainerService;
        private readonly NutritionistService _nutritionService;

        public ListController(
            UserManager<IdentityUser> userManager,
            ExerciseService exerciseService,
            SetOfExercisesService setOfExercisesService,
            FoodService foodService,
            MealPlanService mealPlanService,
            TrainerService trainerService,
            NutritionistService nutritionService)
        {
            _userManager = userManager;
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _foodService = foodService;
            _mealPlanService = mealPlanService;
            _trainerService = trainerService;
            _nutritionService = nutritionService;
        }
        [HttpGet]
        public async Task<IActionResult> ExercisesInComplex()
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _trainerService.GetByIdentityId(userId));
            var exercises =await Task.Run(()=>_setOfExercisesService.GetAddingExercises(user));
            return View(exercises);
        }
    }
}
