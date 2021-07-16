using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF;
using Models.BusinessModels.Services;
using Models.Dto.FitnessProgram;
using Models.Dto.Person;
using Models.ViewModels;
using Services;

namespace FitnessSuperiorMvc.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly FitnessAppContext _db = new FitnessAppContext();
        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;

        public WorkoutController(
            ExerciseService exerciseService,
            SetOfExercisesService setOfExercisesService)
        {
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
        }
        [HttpGet]
        public IActionResult CreateExercise()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExercise(string name, string muscleGroups)
        {
            _exerciseService.CreateExercise(new Exercise(name, muscleGroups));
            return View();
        }

        [HttpGet]
        public IActionResult CreateComplex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateComplex(string name, string muscleGroups,string sets)
        {
            _setOfExercisesService.CreateSet(new SetOfExercises(name, muscleGroups, new List<Exercise>()));
            return View();
        }

        [HttpGet]
        public IActionResult CreateProgram()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProgram(
            string name,
            string description,
            string price,
            string destination,
            string type,
            string skill,
            string age,
            string sets)
        {
            decimal finalPrice = price == null ? 0 : decimal.Parse(price);
            int ageRestriction = age == null ? 0 : int.Parse(age);
            TrainerDto tr = _db.Trainers.ToList().Find(t => t.Id == 2);
            _db.TrainingPrograms.Add(new TrainingProgramDto(
                name,
                description,
                finalPrice,
                destination,
                type,
                skill,
                ageRestriction,
                tr));
            _db.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult ExistingExercises(int page = 1)
        {
            var exerciseView = new ExistingProgramsViewModel<ExerciseDto>()
            {
                WorkoutPerPage = 5,
                ExistingPrograms = _exerciseService.GetAllExercises(),
                CurrentPage = page
            };
            return View(exerciseView);
        }

        [HttpGet]
        public IActionResult ExistingComplexes(int page = 1)
        {
            var exerciseView = new ExistingProgramsViewModel<SetOfExercisesDto>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = _setOfExercisesService.GetAllSets(),
                CurrentPage = page
            };
            return View(exerciseView);
        }


        [HttpGet]
        public IActionResult ExistingPrograms(int page = 1)
        {
            var programView = new ExistingProgramsViewModel<TrainingProgramDto>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = _db.TrainingPrograms,
                CurrentPage = page
            };
            return View(programView);
        }

        public IActionResult MyPrograms()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
