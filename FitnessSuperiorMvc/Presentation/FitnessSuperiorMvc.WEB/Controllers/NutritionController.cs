using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Nutrition;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.Services;
using FitnessSuperiorMvc.WEB.ViewModels;
using FitnessSuperiorMvc.WEB.ViewModels.Page;
using FitnessSuperiorMvc.WEB.ViewModels.Services.Nutrition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [Authorize]
    public class NutritionController : Controller
    {
        private readonly FitnessAppContext _context;

        private readonly FoodService _foodService;
        private readonly MealPlanService _mealPlanService;
        private readonly NutritionProgramService _nutritionProgramService;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public NutritionController(FitnessAppContext context, FoodService foodService, MealPlanService mealPlanService, NutritionProgramService nutritionProgramService, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _context = context;
            _foodService = foodService;
            _mealPlanService = mealPlanService;
            _nutritionProgramService = nutritionProgramService;
            _userManager = userManager;
            _mapper = mapper;
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
            var mealPlan = Task.Run(() => _mealPlanService.GetById(id));
            ViewBag.ReturnUrl = returnUrl;
            return View(await mealPlan);
        }
        [HttpGet]
        public async Task<IActionResult> NutritionProgramView(int id, string returnUrl)
        {
            var program = Task.Run(() => _nutritionProgramService.GetById(id));
            ViewBag.ReturnUrl = returnUrl;
            return View(await program);
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
            _foodService.Create(_mapper.Map<FoodDto>(
            new Food(model.Name,model.Calories,model.BeneficialFeatures,model.Proteins,model.Fats,model.Carbohydrates)
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
            var user = await _context.Nutritionists.FirstOrDefaultAsync(u => u.IdentityId == userId);


            var adding = _context.AddingFood
                .Include(f => f.FoodDto)
                .Where(n => n.NutritionistDto == user);

            var food = await adding
                .Select(f => f.FoodDto)
                .ToListAsync();
            MealPlan mealPlan = new MealPlan(model.Name, model.Description) {Food = _mapper.Map<List<Food>>(food)};
            MealPlanDto mealPlanDto = _mapper.Map<MealPlanDto>(mealPlan);
            mealPlanDto.Author = user;

            _mealPlanService.Create(mealPlanDto);
            foreach (var addingFood in adding)
            {
                _context.AddingFood.Remove(addingFood);
            }
            await _context.SaveChangesAsync();
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
            var user = await _context.Nutritionists.FirstOrDefaultAsync(u => u.IdentityId == userId);

            var adding = _context.AddingMealPlans
                .Include(m => m.MealPlanDto)
                .Where(t => t.NutritionistDto == user);

            var mealPlans = await adding
                .Select(m => m.MealPlanDto)
                .ToListAsync();
            var program = _mapper.Map<NutritionProgramDto>
            (
                new NutritionProgram(model.Name,
                    model.Description,
                    model.Destination,
                    model.Price,
                    model.TypeOfDiet)
            );
            program.MealPlans = mealPlans;
            program.Nutritionist = user;
            _nutritionProgramService.Create(program);
            foreach (var addingMealPlans in adding)
            {
                _context.AddingMealPlans.Remove(addingMealPlans);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("SuccessfulCreation", "Validation",
                new { type = "nutrition program", name = model.Name });
        }
        public IActionResult ExistingFood(int page = 1)
        {
            var programView = new PaginationViewModel<FoodDto>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = _foodService.GetAll(),
                CurrentPage = page
            };
            return View(programView);
        }
        public IActionResult ExistingMealPlans(int page = 1)
        {
            var programView = new PaginationViewModel<MealPlanDto>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = _mealPlanService.GetAll(),
                CurrentPage = page
            };
            return View(programView);
        }
        public IActionResult ExistingPrograms(int page = 1)
        {
            var programView = new PaginationViewModel<NutritionProgramDto>()
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
