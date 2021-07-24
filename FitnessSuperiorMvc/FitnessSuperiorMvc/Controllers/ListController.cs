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
using Services;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    public class ListController : Controller
    {
        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;
        private readonly TrainingProgramsService _trainingProgramsService;
        private readonly FitnessAppContext _context;
        public ListController(ExerciseService exerciseService, SetOfExercisesService setOfExercisesService, TrainingProgramsService trainingProgramsService, FitnessAppContext context)
        {
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _trainingProgramsService = trainingProgramsService;
            _context = context;
        }

        public AddingExercises GetAddingExercises()
        {
            //var t = Session["AddingExercise"];
            //AddingExercises addingExercises = (AddingExercises)Session["AddingExercise"];
            return null;
        }

        [HttpGet]
        public IActionResult AddExercise(int id)
        {
            //ClaimsPrincipal user = User;
            //var name = User.Identity.Name;
            //AddingExercises addingExercises = new AddingExercises();
            //if (id != 0)
            //{
            //    addingExercises.Exercises = new List<ExerciseDto> {_exerciseService.GetById(id)};
            //}
            string action = "AddExercise";
            string controller = "List";
            return RedirectToAction("GetCurrentUser", "Account",new{action,controller, id});
        }

        [HttpPost]
        public IActionResult AddExercise(UserDto user, int id)
        {
           
            //ClaimsPrincipal user = User;
            //var name = User.Identity.Name;
            //AddingExercises addingExercises = new AddingExercises();
            //if (id != 0)
            //{
            //    addingExercises.Exercises = new List<ExerciseDto> {_exerciseService.GetById(id)};
            //}
            return RedirectToAction("GetCurrentUser", "Account");
        }

    }
}
