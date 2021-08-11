using System.Threading.Tasks;
using AutoMapper;
using FitnessSuperiorMvc.BLL.Dto.Programs.Nutrition;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.Services.People;
using FitnessSuperiorMvc.Services.Programs;
using FitnessSuperiorMvc.WEB.ViewModels.Page;
using FitnessSuperiorMvc.WEB.ViewModels.Services.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [Authorize]
    public class NutritionController : Controller
    {
        private readonly FoodService _foodService;
        private readonly MealPlanService _mealPlanService;
        private readonly NutritionProgramService _nutritionProgramService;

        private readonly NutritionistService _nutritionistService;
        private readonly FitnessAppContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public NutritionController(FitnessAppContext context, FoodService foodService, MealPlanService mealPlanService, NutritionProgramService nutritionProgramService, UserManager<IdentityUser> userManager, IMapper mapper, NutritionistService nutritionistService)
        {
            _context = context;
            _foodService = foodService;
            _mealPlanService = mealPlanService;
            _nutritionProgramService = nutritionProgramService;
            _userManager = userManager;
            _mapper = mapper;
            _nutritionistService = nutritionistService;
        }
        [HttpGet]
        public async Task<IActionResult> FoodView(int id, string returnUrl)
        {
            var food = Task.Run(() => _foodService.GetById(id));
            ViewBag.ReturnUrl = returnUrl;
            return View(await food);
        }
        [HttpGet]
        public async Task<IActionResult> MealPlanView(int id, string returnUrl)
        {
            var complex = await Task.Run(() => _mealPlanService.GetById(id, _context));

            ViewBag.ReturnUrl = returnUrl;
            return View(complex);
        }
        [HttpGet]
        public async Task<IActionResult> NutritionProgramView(int id, string returnUrl)
        {
            var programFromDb = await Task.Run(() => _nutritionProgramService.GetById(id, _context));

            ViewBag.ReturnUrl = returnUrl;
            return View(programFromDb);
        }
        [HttpGet]
        [Authorize(Roles= "Nutritionist")]
        public IActionResult CreateFood()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Nutritionist")]
        public IActionResult CreateFood(FoodViewModel model)
        {
            if (!ModelState.IsValid) return View();
                _foodService.Create(_mapper.Map<Food>
                (
                        new FoodDto(
                            model.Name,
                            model.Calories,
                            model.BeneficialFeatures,
                            model.Proteins,
                            model.Fats,
                            model.Carbohydrates)
                ));
            return RedirectToAction("SuccessfulCreation", "Validation", new { type = "food", name = model.Name });

        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public IActionResult CreateMealPlan()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> CreateMealPlan(MealPlanViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _nutritionistService.GetByIdentityId(userId));

            var food = await Task.Run(() => _foodService.GetAddingFood(user, _context));
            var mealDto = new MealPlanDto(model.Name, model.Description);
            MealPlan mealPlan = _mapper.Map<MealPlan>(mealDto);
            mealPlan.Food = food;
            mealPlan.Author = user;
            _mealPlanService.Create(mealPlan);
            _foodService.DeleteAddingFood(user, _context);
            return RedirectToAction("SuccessfulCreation", "Validation", new { type = "meal plan", name = model.Name });

        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public IActionResult CreateProgram()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> CreateProgram(NutritionProgramViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _nutritionistService.GetByIdentityId(userId));

            var mealPlans = await Task.Run(() => _nutritionProgramService.GetAddingMealPlans(user, _context));

            var programDto = new NutritionProgramDto(
                model.Name,
                model.Description,
                model.Destination,
                model.Price,
                model.TypeOfDiet);
            NutritionProgram nutritionProgram = _mapper.Map<NutritionProgram>(programDto);
            nutritionProgram.MealPlans = mealPlans;
            nutritionProgram.Nutritionist = user;
            _nutritionProgramService.Create(nutritionProgram);
            _nutritionProgramService.DeleteAddingMealPlans(user, _context);
            return RedirectToAction("SuccessfulCreation", "Validation",
                new { type = "nutrition program", name = model.Name });
        }
        public IActionResult ExistingFood(int page = 1)
        {
            var programView = new PaginationViewModel<Food>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = _foodService.GetAll(),
                CurrentPage = page
            };
            return View(programView);
        }
        public IActionResult ExistingMealPlans(int page = 1)
        {
            var programView = new PaginationViewModel<MealPlan>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = _mealPlanService.GetAll(),
                CurrentPage = page
            };
            return View(programView);
        }
        public IActionResult ExistingPrograms(int page = 1)
        {
            var programView = new PaginationViewModel<NutritionProgram>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = _nutritionProgramService.GetAll(),
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
