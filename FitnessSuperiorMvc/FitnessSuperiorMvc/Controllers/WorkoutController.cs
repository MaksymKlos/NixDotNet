using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.WEB.ViewModels;
using FitnessSuperiorMvc.WEB.ViewModels.Page;
using FitnessSuperiorMvc.WEB.ViewModels.Services.Sport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly FitnessAppContext _db = new FitnessAppContext();
        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;
        private readonly IMapper _mapper;

        public WorkoutController(
            ExerciseService exerciseService,
            SetOfExercisesService setOfExercisesService,
            IMapper mapper)
        {
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CreateExercise()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExercise(ExerciseViewModel exerciseViewModel)
        {
            if (ModelState.IsValid)
            {
                _exerciseService.Create(_mapper.Map<ExerciseDto>
                (
                    new Exercise(exerciseViewModel.Name, exerciseViewModel.MuscleGroups)
                ));
                
                return RedirectToAction("SuccessfulCreation","Validation",new{type = "exercise",name= exerciseViewModel.Name});
                
            }

            return View();


        }

        [HttpGet]
        public async Task<IActionResult> ExerciseView(int id)
        {
            var exercise = Task.Run(() => _exerciseService.GetById(id));
            return View(await exercise);
        }
        [HttpGet]
        public IActionResult CreateComplex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateComplex(string name, string muscleGroups)
        {
            //List<Exercise> ex = new List<Exercise>()
            //{
            //    _mapper.Map<Exercise>(_exerciseService.GetById(11))
            //};
            //_setOfExercisesService.Create(_mapper.Map<SetOfExercisesDto>
            //(
            //    new SetOfExercises(name, muscleGroups, ex)
            //));
            return RedirectToAction("AddExercise","List",new {name,muscleGroups});
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
        public async Task<IActionResult> ExistingExercises(int page = 1)
        {
            var getData = Task.Run(() => _exerciseService.GetAll());
            var exerciseView = new PaginationViewModel<ExerciseDto>()
            {
                WorkoutPerPage = 5,
                ExistingPrograms =  await getData,
                CurrentPage = page
            };
            return View(exerciseView);
        }

        //[HttpGet]
        //public IActionResult AddExercise()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult ExistingComplexes(int page = 1)
        {
            var exerciseView = new PaginationViewModel<SetOfExercisesDto>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = _setOfExercisesService.GetAll(),
                CurrentPage = page
            };
            return View(exerciseView);
        }


        [HttpGet]
        public IActionResult ExistingPrograms(int page = 1)
        {
            var programView = new PaginationViewModel<TrainingProgramDto>()
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
