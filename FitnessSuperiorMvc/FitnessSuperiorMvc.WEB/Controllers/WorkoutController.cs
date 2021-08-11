using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FitnessSuperiorMvc.BLL.Dto.Programs.Sport;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.Services.People;
using FitnessSuperiorMvc.Services.Programs;
using FitnessSuperiorMvc.WEB.ViewModels.Page;
using FitnessSuperiorMvc.WEB.ViewModels.Services.Sport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;
        private readonly TrainingProgramsService _trainingProgramsService;

        private readonly TrainerService _trainerService;
        private readonly UserService _userService;
        private readonly FitnessAppContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public WorkoutController(
            IMapper mapper,
            UserManager<IdentityUser> userManager,
            ExerciseService exerciseService,
            SetOfExercisesService setOfExercisesService, 
            TrainingProgramsService trainingProgramsService,
            TrainerService trainerService,
            FitnessAppContext context,
            UserService userService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _trainingProgramsService = trainingProgramsService;
            _trainerService = trainerService;
            _context = context;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> ExerciseView(int id, string returnUrl)
        {

            var exercise = Task.Run(() => _exerciseService.GetById(id));
            ViewBag.ReturnUrl = returnUrl;
            return View(await exercise);
        }
        [HttpGet]
        public async Task<IActionResult> ComplexView(int id, string returnUrl)
        {
            var complex = await Task.Run(() => _setOfExercisesService.GetById(id, _context));
            
            ViewBag.ReturnUrl = returnUrl;
            return View(complex);
        }
        [HttpGet]
        public async Task<IActionResult> TrainingProgramView(int id, string returnUrl)
        {
            var programFromDb = await Task.Run(() => _trainingProgramsService.GetById(id, _context));
            
            ViewBag.ReturnUrl = returnUrl;
            return View(programFromDb);
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public IActionResult CreateExercise()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Trainer")]
        public IActionResult CreateExercise(ExerciseViewModel exerciseViewModel)
        {
            if (!ModelState.IsValid) return View();
            if (string.IsNullOrWhiteSpace(exerciseViewModel.YoutubeUrl))
            {
                _exerciseService.Create(_mapper.Map<Exercise>
                (
                new ExerciseDto(
                    exerciseViewModel.Name,
                    exerciseViewModel.MuscleGroups,
                    exerciseViewModel.Description))
                );
            }
            else
            {
                _exerciseService.Create(_mapper.Map<Exercise>
                    (
                    new ExerciseDto(
                        exerciseViewModel.Name,
                        exerciseViewModel.MuscleGroups,
                        exerciseViewModel.Description,
                        exerciseViewModel.YoutubeUrl))
                    );
            }
            return RedirectToAction("SuccessfulCreation", "Validation", new { type = "exercise", name = exerciseViewModel.Name });
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public IActionResult CreateComplex()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateComplex(SetOfExerciseViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _trainerService.GetByIdentityId(userId));

            var exercises = await Task.Run(() => _exerciseService.GetAddingExercises(user,_context));
            var setDto = new SetOfExercisesDto(model.Name, model.MuscleGroups, model.Description);
            SetOfExercises set = _mapper.Map<SetOfExercises>(setDto);
            set.Exercises = exercises;
            set.Author = user;
            _setOfExercisesService.Create(set);
            _exerciseService.DeleteAddingExercises(user, _context);
            return RedirectToAction("SuccessfulCreation", "Validation", new { type = "set of exercises", name = model.Name });
        }
        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public IActionResult CreateProgram()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateProgram(TrainingProgramViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _trainerService.GetByIdentityId(userId));

            var complexes = await Task.Run(() => _trainingProgramsService.GetAddingComplexes(user,_context));

            var programDto = new TrainingProgramDto(
                model.Name,
                model.Description,
                model.Destination,
                model.Price,
                model.TypeOfProgram,
                model.RequiredSkillLevel,
                model.AgeRestriction);
            TrainingProgram trainingProgram = _mapper.Map<TrainingProgram>(programDto);
            trainingProgram.SetsOfExercises = complexes;
            trainingProgram.Trainer = user;
            _trainingProgramsService.Create(trainingProgram);
            _trainingProgramsService.DeleteAddingComplexes(user,_context);
            return RedirectToAction("SuccessfulCreation", "Validation",
                new { type = "training program", name = model.Name });

        }
        [HttpGet]
        public async Task<IActionResult> ExistingExercises(int page = 1)
        {
            var getData = Task.Run(() => _exerciseService.GetAll());
            var exerciseView = new PaginationViewModel<Exercise>()
            {
                WorkoutPerPage = 5,
                ExistingPrograms = await getData,
                CurrentPage = page
            };
            return View(exerciseView);
        }
        [HttpGet]
        public async Task<IActionResult> ExistingComplexes(int page = 1)
        {
            var getData = Task.Run(() => _setOfExercisesService.GetAll());
            var exerciseView = new PaginationViewModel<SetOfExercises>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = await getData,
                CurrentPage = page
            };
            return View(exerciseView);
        }
        [HttpGet]
        public async Task<IActionResult> ExistingPrograms(int page = 1)
        {
            var getData = Task.Run(() => _trainingProgramsService.GetAll());
            var programView = new PaginationViewModel<TrainingProgram>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = await getData,
                CurrentPage = page
            };
            return View(programView);
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> MyPrograms(int page)
        {
            var userId = _userManager.GetUserId(User);
            var user = await Task.Run(() => _userService.GetByIdentityId(userId));
            var programs = Task.Run(() => _trainingProgramsService.GetTrainingPrograms(user.Id,_context));
            var programView = new PaginationViewModel<TrainingProgram>()
            {
                WorkoutPerPage = 3,
                ExistingPrograms = await programs,
                CurrentPage = page
            };
            return View(programView);
        }
        [HttpGet]
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
