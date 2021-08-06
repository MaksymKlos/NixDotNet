using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using Microsoft.EntityFrameworkCore;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public class AddingController
    {
        private readonly FitnessAppContext _context = new FitnessAppContext();

        public List<Exercise> GetExercises(Trainer user)
        {
            var exercises = _context.AddingExercises
                .Include(e => e.ExerciseDto)
                .Where(a => a.TrainerDto == user)
                .Select(a => a.ExerciseDto)
                .ToList();
            return exercises;
        }

        public void DeleteExercises(Trainer user)
        {
            var addingExercises = _context.AddingExercises
                .Include(e => e.ExerciseDto)
                .Where(t => t.TrainerDto == user);
            foreach (var addingExercise in addingExercises)
            {
                _context.AddingExercises.Remove(addingExercise);
            }

            _context.SaveChangesAsync();
        }
    }
}
