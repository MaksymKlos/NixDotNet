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
        private readonly FitnessAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ListController(ExerciseService exerciseService, SetOfExercisesService setOfExercisesService, TrainingProgramsService trainingProgramsService, FitnessAppContext context, UserManager<IdentityUser> userManager)
        {
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _trainingProgramsService = trainingProgramsService;
            _context = context;
            _userManager = userManager;
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
        public async Task<IActionResult> ComplexesInProgram(TrainingProgramViewModel model)
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

    }
}
