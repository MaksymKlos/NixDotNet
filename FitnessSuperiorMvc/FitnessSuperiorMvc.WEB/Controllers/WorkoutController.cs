using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FitnessSuperiorMvc.BLL.Dto.Programs.Sport;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.Services.People;
using FitnessSuperiorMvc.Services.Programs;
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

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public WorkoutController(
            IMapper mapper,
            UserManager<IdentityUser> userManager,
            ExerciseService exerciseService,
            SetOfExercisesService setOfExercisesService, 
            TrainingProgramsService trainingProgramsService,
            TrainerService trainerService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _trainingProgramsService = trainingProgramsService;
            _trainerService = trainerService;
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
            var complex = await Task.Run(() => _setOfExercisesService.GetById(id));
            
            ViewBag.ReturnUrl = returnUrl;
            return View(complex);
        }
        [HttpGet]
        public async Task<IActionResult> TrainingProgramView(int id, string returnUrl)
        {
            var programFromDb = await Task.Run(() => _trainingProgramsService.GetById(id));
            
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

            var exercises = await Task.Run(() => _setOfExercisesService.GetAddingExercises(user));
            var setDto = new SetOfExercisesDto(model.Name, model.MuscleGroups, model.Description);
            SetOfExercises set = _mapper.Map<SetOfExercises>(setDto);
            set.Exercises = exercises;
            set.Author = user;
            _setOfExercisesService.Create(set);
            _setOfExercisesService.DeleteAddingExercises(user);
            return RedirectToAction("SuccessfulCreation", "Validation", new { type = "set of exercises", name = model.Name });
        }
    }
}
