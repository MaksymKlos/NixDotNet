using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using Microsoft.EntityFrameworkCore;

namespace FitnessSuperiorMvc.BLL.BusinessModels
{
    public class Binder
    {
        private readonly FitnessAppContext _context;

        public Binder(FitnessAppContext context)
        {
            _context = context;
        }

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

        public List<Food> GetFoodFromMealPlan(int id)
        {
            var food = _context.MealPlans
                .Include(e => e.Food)
                .FirstOrDefault(c => c.Id == id)
                ?.Food.ToList();
            return food;
        }
        public Nutritionist GetNutritionistOfComplex(int id)
        {
            var nutritionist = _context.MealPlans
                .Include(c => c.Author)
                .Where(c => c.Id == id)
                .Select(t => t.Author)
                .First();
            return nutritionist;
        }

        public List<MealPlan> GetMealPlansOfProgram(int id)
        {
            var mealPlans = _context.NutritionPrograms
                .Include(e => e.MealPlans)
                .FirstOrDefault(c => c.Id == id)
                ?.MealPlans.ToList();
            return mealPlans;
        }
        public Nutritionist GetNutritionistOfProgram(int id)
        {
            var nutritionist = _context.NutritionPrograms
                .Include(c => c.Nutritionist)
                .Where(c => c.Id == id)
                .Select(t => t.Nutritionist)
                .First();
            return nutritionist;
        }
        public List<TrainingProgram> GetTrainingPrograms(int id)
        {
            var program = _context.UsersDto
                .Include(u => u.TrainingPrograms)
                .FirstOrDefault(p => p.Id == id)
                ?.TrainingPrograms.ToList();

            return program;
        }
        public List<NutritionProgram> GetNutritionPrograms(int id)
        {
            var program = _context.UsersDto
                .Include(u => u.NutritionPrograms)
                .FirstOrDefault(p => p.Id == id)
                ?.NutritionPrograms.ToList();
            return program;
        }
    }
}
