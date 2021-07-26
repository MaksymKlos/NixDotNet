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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace FitnessSuperiorMvc.WEB.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly FitnessAppContext _context;
        private readonly ExerciseService _exerciseService;
        private readonly SetOfExercisesService _setOfExercisesService;
        private readonly TrainingProgramsService _trainingProgramsService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public WorkoutController(
            ExerciseService exerciseService,
            SetOfExercisesService setOfExercisesService,
            IMapper mapper, UserManager<IdentityUser> userManager, FitnessAppContext context, TrainingProgramsService trainingProgramsService)
        {
            _exerciseService = exerciseService;
            _setOfExercisesService = setOfExercisesService;
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
            _trainingProgramsService = trainingProgramsService;
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
                if (string.IsNullOrWhiteSpace(exerciseViewModel.YoutubeUrl))
                {
                    _exerciseService.Create(_mapper.Map<ExerciseDto>
                    (
                        new Exercise(exerciseViewModel.Name, exerciseViewModel.MuscleGroups, exerciseViewModel.Description)
                    ));
                }
                else
                {
                    _exerciseService.Create(_mapper.Map<ExerciseDto>
                    (
                        new Exercise(exerciseViewModel.Name, exerciseViewModel.MuscleGroups, exerciseViewModel.Description, exerciseViewModel.YoutubeUrl)
                    ));
                }
                
                
                return RedirectToAction("SuccessfulCreation","Validation",new{type = "exercise",name= exerciseViewModel.Name});
                
            }

            return View();


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
            var exercise = Task.Run(() => _exerciseService.GetById(id));
            ViewBag.ReturnUrl = returnUrl;
            return View(await exercise);
        }
        [HttpGet]
        public async Task<IActionResult> TrainingProgramView(int id, string returnUrl)
        {
            var exercise = Task.Run(() => _exerciseService.GetById(id));
            ViewBag.ReturnUrl = returnUrl;
            return View(await exercise);
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
            var user = await _context.Trainers.FirstOrDefaultAsync(u => u.IdentityId == userId);

            var adding = _context.AddingExercises
                .Include(e => e.ExerciseDto)
                .Where(t => t.TrainerDto == user);

            var exercises = await adding
                .Select(a => a.ExerciseDto)
                .ToListAsync();
            SetOfExercisesDto setDto = _mapper.Map<SetOfExercisesDto>(new SetOfExercises(model.Name, model.MuscleGroups, model.Description));
            setDto.Exercises = exercises;
            setDto.Author = user;
            _setOfExercisesService.Create(setDto);
            foreach (var addingExercise in adding)
            {
                _context.AddingExercises.Remove(addingExercise);
            }
            await _context.SaveChangesAsync();
            string type = "set of exercises";
            return RedirectToAction("SuccessfulCreation", "Validation", new { type, model.Name });
        }

        [HttpGet]
        public IActionResult CreateProgram()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram(TrainingProgramViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var userId = _userManager.GetUserId(User);
            var user = await _context.Trainers.FirstOrDefaultAsync(u => u.IdentityId == userId);

            var adding = _context.AddingComplexes
                .Include(e => e.SetOfExercisesDto)
                .Where(t => t.TrainerDto == user);

            var complexes = await adding
                .Select(a => a.SetOfExercisesDto)
                .ToListAsync();
            var complex = _mapper.Map<TrainingProgramDto>
            (
                new TrainingProgram(model.Name,
                    model.Description,
                    model.Destination,
                    model.TypeOfProgram,
                    model.RequiredSkillLevel,
                    model.AgeRestriction,
                    model.Price)
            );
            complex.SetsOfExercises = complexes;
            complex.Trainer = user;
            _trainingProgramsService.Create(complex);
            foreach (var addingComplex in adding)
            {
                _context.AddingComplexes.Remove(addingComplex);
            }
            return RedirectToAction("SuccessfulCreation", "Validation",
                new {type = "training program", name = model.Name});

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
                ExistingPrograms = _context.TrainingPrograms,
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
