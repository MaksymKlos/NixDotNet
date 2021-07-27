using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessSuperiorMvc.BLL.Dto.People.Users;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;
using FitnessSuperiorMvc.BLL.Services;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.Services;
using FitnessSuperiorMvc.WEB.ViewModels.Services.Sport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Services;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;
        private readonly TrainingProgramsService _trainingProgramsService;

        private readonly FoodService _foodService;
        private readonly MealPlanService _mealPlanService;
        private readonly NutritionProgramService _nutritionProgramService;

        private readonly FitnessAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ListController(ExerciseService exerciseService, SetOfExercisesService setOfExercisesService, TrainingProgramsService trainingProgramsService, FitnessAppContext context, UserManager<IdentityUser> userManager, FoodService foodService, MealPlanService mealPlanService, NutritionProgramService nutritionProgramService)
        {
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _trainingProgramsService = trainingProgramsService;
            _context = context;
            _userManager = userManager;
            _foodService = foodService;
            _mealPlanService = mealPlanService;
            _nutritionProgramService = nutritionProgramService;
        }

        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> ExercisesInComplex()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Trainers.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var exercises =_context.AddingExercises
                .Include(e=>e.ExerciseDto)
                .Where(a=>a.TrainerDto==user)
                .Select(a=>a.ExerciseDto)
                .ToList();
            return View(exercises);
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> AddExerciseToComplex(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await _context.Trainers.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var exercise = _exerciseService.GetById(id);
            var exercises = await _context.AddingExercises
                .Include(e => e.ExerciseDto)
                .FirstOrDefaultAsync(a=>a.ExerciseDto == exercise);
            if (exercises == null)
            {
                user.AddingExercises.Add(new AddingExercises() { ExerciseDto = exercise });
                _context.Update(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ExercisesInComplex");
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> RemoveExerciseFromComplex(int id)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Trainers.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var removingExercise = _context.AddingExercises
                .Include(e => e.ExerciseDto)
                .Where(t => t.TrainerDto == user).FirstOrDefault(a => a.ExerciseDto.Id == id);
            if (removingExercise != null)
            {
                user.AddingExercises.Remove(removingExercise);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ExercisesInComplex");
        }

        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> ComplexesInProgram()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Trainers.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var complexes = _context.AddingComplexes
                .Include(e => e.SetOfExercisesDto)
                .Where(t => t.TrainerDto == user)
                .Select(s => s.SetOfExercisesDto)
                .ToList();
            return View(complexes);
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> AddComplexToProgram(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await _context.Trainers.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var complex = _setOfExercisesService.GetById(id);
            var complexes = await _context.AddingComplexes
                .Include(e => e.SetOfExercisesDto)
                .FirstOrDefaultAsync(a => a.SetOfExercisesDto == complex);
            if (complexes == null)
            {
                user.AddingComplexes.Add(new AddingComplexes(){SetOfExercisesDto = complex});
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("ComplexesInProgram");
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> RemoveComplexFromProgram(int id)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Trainers.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var removingComplex = _context.AddingComplexes
                .Include(e => e.SetOfExercisesDto)
                .Where(t => t.TrainerDto == user).FirstOrDefault(a => a.SetOfExercisesDto.Id == id);
            if (removingComplex != null)
            {
                user.AddingComplexes.Remove(removingComplex);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ComplexesInProgram");
        }

        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> FoodInMealPlan()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Nutritionists.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var exercises = _context.AddingFood
                .Include(f => f.FoodDto)
                .Where(n => n.NutritionistDto == user)
                .Select(f => f.FoodDto)
                .ToList();
            return View(exercises);
        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> AddFoodToMealPlan(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await _context.Nutritionists.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var food = _foodService.GetById(id);
            var foods = await _context.AddingFood
                .Include(f => f.FoodDto)
                .FirstOrDefaultAsync(a => a.FoodDto == food);
            if (foods == null)
            {
                user.AddingFood.Add(new AddingFood() { FoodDto = food });
                _context.Update(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("FoodInMealPlan");
        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> RemoveFoodFromMealPlan(int id)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Nutritionists.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var removingFood = _context.AddingFood
                .Include(f => f.FoodDto)
                .Where(n => n.NutritionistDto == user).FirstOrDefault(a => a.FoodDto.Id == id);
            if (removingFood != null)
            {
                user.AddingFood.Remove(removingFood);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("FoodInMealPlan");
        }

        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> MealPlansInProgram()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Trainers.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var complexes = _context.AddingComplexes
                .Include(e => e.SetOfExercisesDto)
                .Where(t => t.TrainerDto == user)
                .Select(s => s.SetOfExercisesDto)
                .ToList();
            return View(complexes);
        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> AddMealPlanToProgram(int id)
        {

            var userId = _userManager.GetUserId(User);
            var user = await _context.Nutritionists.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var mealPlan = _mealPlanService.GetById(id);
            var mealPlans = await _context.AddingMealPlans
                .Include(f=>f.MealPlanDto)
                .FirstOrDefaultAsync(a => a.MealPlanDto == mealPlan);
            if (mealPlans == null)
            {
                user.AddingMealPlans.Add(new AddingMealPlans() {MealPlanDto  = mealPlan });
                _context.Update(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MealPlansInProgram");
        }
        [HttpGet]
        [Authorize(Roles = "Nutritionist")]
        public async Task<IActionResult> RemoveMealPlanFromProgram(int id)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Nutritionists.FirstOrDefaultAsync(u => u.IdentityId == userId);
            var removingMealPlan = _context.AddingMealPlans
                .Include(m => m.MealPlanDto)
                .Where(n => n.NutritionistDto == user).FirstOrDefault(a => a.MealPlanDto.Id == id);
            if (removingMealPlan != null)
            {
                user.AddingMealPlans.Remove(removingMealPlan);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ComplexesInProgram");
        }
    }
}
