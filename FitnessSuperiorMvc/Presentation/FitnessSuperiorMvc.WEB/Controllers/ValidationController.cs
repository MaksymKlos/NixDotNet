using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [AllowAnonymous]
    public class ValidationController : Controller
    {
        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;
        private readonly TrainingProgramsService _trainingProgramsService;
        private readonly SecurityContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ValidationController(ExerciseService exerciseService, SetOfExercisesService setOfExercisesService, TrainingProgramsService trainingProgramsService, SecurityContext context, UserManager<IdentityUser> userManager)
        {
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _trainingProgramsService = trainingProgramsService;
            _context = context;
            _userManager = userManager;
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsNameOfExerciseInUse(string name)
        {
            var exercise = Task.Run(() => _exerciseService.GetAll().FirstOrDefault(ex => ex.Name == name));
            if (await exercise == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Exercise with name {name} is already exist");
            }
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsNameOfComplexInUse(string name)
        {
            var exercise = Task.Run(() => _setOfExercisesService.GetAll().FirstOrDefault(ex => ex.Name == name));
            if (await exercise == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Exercise with name {name} is already exist");
            }
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUserLoginInUse(string login)
        {
            IdentityUser identityUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == login);
            if (identityUser == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Login {login} is already exist");
            }
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUserEmailInUse(string email)
        {
            IdentityUser identityUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (identityUser == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already exist");
            }
        }

        [HttpGet]
        public IActionResult SuccessfulCreation(string type, string name)
        {
            ViewBag.Success = $"{type} called \'{name}\'";
            return View();
        }
    }
}
