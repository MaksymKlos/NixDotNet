using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using Microsoft.EntityFrameworkCore;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public class Binder
    {
        private readonly FitnessAppContext _context = new FitnessAppContext();

        public List<Exercise> GetExercisesFromComplex(int id)
        {
            var exercises = _context.SetOfExercises
                .Include(e => e.Exercises)
                .FirstOrDefault(c => c.Id == id)
                ?.Exercises.ToList();
            return exercises;
        }
        public Trainer GetTrainerOfComplex(int id)
        {
            var trainer = _context.SetOfExercises
                .Include(c => c.Author)
                .Where(c => c.Id == id)
                .Select(t => t.Author)
                .First();
            return trainer;
        }

        public List<SetOfExercises> GetComplexFromProgram(int id)
        {
            var sets = _context.TrainingPrograms
                .Include(e => e.SetsOfExercises)
                .FirstOrDefault(c => c.Id == id)
                ?.SetsOfExercises.ToList();
            return sets;
        }
        public Trainer GetTrainerOfProgram(int id)
        {
            var trainer = _context.TrainingPrograms
                .Include(c => c.Trainer)
                .Where(c => c.Id == id)
                .Select(t => t.Trainer)
                .First();
            return trainer;
        }
    }
}
