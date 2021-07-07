using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF;
using Models.Dto.FitnessProgram;
using Models.ViewModels;

namespace FitnessSuperiorMvc.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly FitnessAppContext _db = new FitnessAppContext();
        public IActionResult CreateProgram()
        {
            return View();
        }
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
