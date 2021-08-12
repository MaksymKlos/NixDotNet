using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.Services.People;
using FitnessSuperiorMvc.Services.Programs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    public class ListController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;
        private readonly TrainingProgramsService _trainingProgramsService;


        private readonly FoodService _foodService;
        private readonly MealPlanService _mealPlanService;
        private readonly NutritionProgramService _nutritionProgramService;

        private readonly TrainerService _trainerService;
        private readonly NutritionistService _nutritionistService;
        private readonly UserService _userService;

        private readonly FitnessAppContext _context;

        public ListController(
            UserManager<IdentityUser> userManager,
            ExerciseService exerciseService,
            SetOfExercisesService setOfExercisesService,
            FoodService foodService,
            MealPlanService mealPlanService,
            TrainerService trainerService,
            NutritionistService nutritionistService, FitnessAppContext context, UserService userService, TrainingProgramsService trainingProgramsService, NutritionProgramService nutritionProgramService)
        {
            _userManager = userManager;
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _foodService = foodService;
            _mealPlanService = mealPlanService;
            _trainerService = trainerService;
            _nutritionistService = nutritionistService;
            _context = context;
            _userService = userService;
            _trainingProgramsService = trainingProgramsService;
            _nutritionProgramService = nutritionProgramService;
        }
        [HttpGet]
        public async Task<IActionResult> ExercisesInComplex()
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _trainerService.GetByIdentityId(userId));
            var exercises =await Task.Run(()=>_exerciseService.GetAddingExercises(user,_context));
            return View(exercises);
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> AddExerciseToComplex(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _trainerService.GetByIdentityId(userId));
            var exercise = await Task.Run(()=>_exerciseService.GetById(id));
            await Task.Run(() => _exerciseService.AddAddingExercises(exercise, user,_context));
            return RedirectToAction("ExercisesInComplex");
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> RemoveExerciseFromComplex(int id)
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _trainerService.GetByIdentityId(userId));
            await Task.Run(()=>_exerciseService.RemoveAddingExercises(id,user,_context));
            return RedirectToAction("ExercisesInComplex");
        }

        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> ComplexesInProgram()
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _trainerService.GetByIdentityId(userId));
            var complexes = await Task.Run(() => _setOfExercisesService.GetAddingComplexes(user,_context));
            return View(complexes);
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> AddComplexToProgram(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _trainerService.GetByIdentityId(userId));
            var complex = await Task.Run(()=>_setOfExercisesService.GetById(id, _context));
            await Task.Run(() => _setOfExercisesService.AddAddingComplexes(complex, user, _context));
            return RedirectToAction("ComplexesInProgram");
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> RemoveComplexFromProgram(int id)
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _trainerService.GetByIdentityId(userId));
            await Task.Run(() => _setOfExercisesService.RemoveAddingComplexes(id, user, _context));
            return RedirectToAction("ComplexesInProgram");
        }
        [HttpGet]
        public async Task<IActionResult> FoodInMealPlan()
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _nutritionistService.GetByIdentityId(userId));
            var food = await Task.Run(() => _foodService.GetAddingFood(user, _context));
            return View(food);
        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> AddFoodInMealPlan(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _nutritionistService.GetByIdentityId(userId));
            var food = await Task.Run(() => _foodService.GetById(id));
            await Task.Run(() => _foodService.AddAddingFood(food, user, _context));
            return RedirectToAction("FoodInMealPlan");
        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> RemoveFoodFromMealPlan(int id)
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _nutritionistService.GetByIdentityId(userId));
            await Task.Run(() => _foodService.RemoveAddingFood(id, user, _context));
            return RedirectToAction("FoodInMealPlan");
        }

        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> MealPlansInProgram()
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _nutritionistService.GetByIdentityId(userId));
            var mealPlans = await Task.Run(() => _mealPlanService.GetAddingMealPlans(user, _context));
            return View(mealPlans);
        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> AddMealPlanToProgram(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _nutritionistService.GetByIdentityId(userId));
            var mealPlan = await Task.Run(() => _mealPlanService.GetById(id, _context));
            await Task.Run(() => _mealPlanService.AddAddingMealPlans(mealPlan, user, _context));
            return RedirectToAction("MealPlansInProgram");
        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> RemoveMealPlanFromProgram(int id)
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _nutritionistService.GetByIdentityId(userId));
            await Task.Run(() => _mealPlanService.RemoveAddingMealPlan(id, user, _context));
            return RedirectToAction("MealPlansInProgram");
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddTrainingProgramToUser(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _userService.GetByIdentityId(userId));
            
            var program = await Task.Run(() => _trainingProgramsService.GetById(id, _context));
            user.TrainingPrograms.Add(program);
            await Task.Run(() => _userService.Update(user));

            return RedirectToAction("MyPrograms","Workout");
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RemoveTrainingProgramInUser(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _userService.GetByIdentityId(userId));

            var program = await Task.Run(() => _trainingProgramsService.GetById(id, _context));
            user.TrainingPrograms.Remove(program);
            await Task.Run(() => _userService.Update(user));

            return RedirectToAction("MyPrograms", "Workout");
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddNutritionProgramToUser(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _userService.GetByIdentityId(userId));

            var program = await Task.Run(() => _nutritionProgramService.GetById(id, _context));
            user.NutritionPrograms.Add(program);
            await Task.Run(() => _userService.Update(user));

            return RedirectToAction("MyPrograms", "Nutrition");
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RemoveNutritionProgramInUser(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _userService.GetByIdentityId(userId));

            var program = await Task.Run(() => _nutritionProgramService.GetById(id, _context));
            user.NutritionPrograms.Remove(program);
            await Task.Run(() => _userService.Update(user));

            return RedirectToAction("MyPrograms", "Nutrition");
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddTrainingProgramToCalendar(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _userService.GetByIdentityId(userId));

            var program = await Task.Run(() => _trainingProgramsService.GetById(id, _context));
            user.TrainingPrograms.Remove(program);
            await Task.Run(() => _userService.Update(user));

            return RedirectToAction("MyPrograms", "Workout");
        }
    }
}
