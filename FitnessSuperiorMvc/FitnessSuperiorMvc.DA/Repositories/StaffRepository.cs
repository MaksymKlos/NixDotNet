using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.Binders;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessSuperiorMvc.DA.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly FitnessAppContext _context;

        public StaffRepository(FitnessAppContext context)
        {
            _context = context;
        }
        public List<Exercise> GetExercises(Trainer user)
        {
            var exercises = _context.AddingExercises
                .Include(e => e.ExerciseDto)
                .Where(a => a.TrainerDto == user)
                .Select(a => a.ExerciseDto)
                .ToList();
            return exercises;
        }
        public List<Food> GetFood(Nutritionist user)
        {
            var food = _context.AddingFood
                .Include(e => e.FoodDto)
                .Where(a => a.NutritionistDto == user)
                .Select(a => a.FoodDto)
                .ToList();
            return food;
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

            _context.SaveChanges();
        }
        public void DeleteFood(Nutritionist user)
        {
            var addingFood= _context.AddingFood
                .Include(e => e.FoodDto)
                .Where(t => t.NutritionistDto == user);
            foreach (var adding in addingFood)
            {
                _context.AddingFood.Remove(adding);
            }

            _context.SaveChanges();
        }

        public void AddAddingExercises(Exercise exercise, Trainer user)
            {
            var exercises = _context.AddingExercises
                .Include(e => e.ExerciseDto)
                .FirstOrDefault(a => a.ExerciseDto == exercise);

            if (exercises != null) return;

            user.AddingExercises.Add(new AddingExercises() { ExerciseDto = exercise });
            _context.Update(user);
            _context.SaveChanges();
        }
        public void AddAddingFood(Food food, Nutritionist user)
        {
            var addingFood = _context.AddingFood
                .Include(e => e.FoodDto)
                .FirstOrDefault(a => a.FoodDto == food);

            if (addingFood != null) return;

            user.AddingFood.Add(new AddingFood() { FoodDto = food });
            _context.Update(user);
            _context.SaveChanges();
        }
        public void RemoveAddingExercises(int id, Trainer user)
        {
            var removingExercise = _context.AddingExercises
                .Include(e => e.ExerciseDto)
                .Where(t => t.TrainerDto == user).FirstOrDefault(a => a.ExerciseDto.Id == id);

            if (removingExercise == null) return;

            user.AddingExercises.Remove(removingExercise);
            _context.SaveChanges();
        }
        public void RemoveAddingFood(int id, Nutritionist user)
        {
            var removingFood = _context.AddingFood
                .Include(e => e.FoodDto)
                .Where(t => t.NutritionistDto == user).FirstOrDefault(a => a.FoodDto.Id == id);
            
            if (removingFood == null) return;

            user.AddingFood.Remove(removingFood);
            _context.SaveChanges();
        }
        public List<SetOfExercises> GetComplexes(Trainer user)
        {
            var complexes = _context.AddingComplexes
                .Include(e => e.SetOfExercisesDto)
                .Where(t => t.TrainerDto == user)
                .Select(a => a.SetOfExercisesDto)
                .ToList();
            return complexes;
        }
        public List<MealPlan> GetMealPlans(Nutritionist user)
        {
            var mealPlans = _context.AddingMealPlans
                .Include(e => e.MealPlanDto)
                .Where(t => t.NutritionistDto == user)
                .Select(a => a.MealPlanDto)
                .ToList();
            return mealPlans;
        }

        public void DeleteComplex(Trainer user)
        {
            var addingComplexes = _context.AddingComplexes
                .Include(e => e.SetOfExercisesDto)
                .Where(t => t.TrainerDto == user);
            foreach (var addingComplex in addingComplexes)
            {
                _context.AddingComplexes.Remove(addingComplex);
            }

            _context.SaveChanges();
        }
        public void DeleteMealPlan(Nutritionist user)
        {
            var addingMealPlans = _context.AddingMealPlans
                .Include(e => e.MealPlanDto)
                .Where(t => t.NutritionistDto == user);
            foreach (var addingMealPlan in addingMealPlans)
            {
                _context.AddingMealPlans.Remove(addingMealPlan);
            }

            _context.SaveChanges();
        }
        public void AddAddingComplexes(SetOfExercises complex, Trainer user)
        {
            var complexes = _context.AddingComplexes
                .Include(e => e.SetOfExercisesDto)
                .FirstOrDefault(a => a.SetOfExercisesDto == complex);

            if (complexes != null) return;

            user.AddingComplexes.Add(new AddingComplexes() { SetOfExercisesDto = complex });
            _context.Update(user);
            _context.SaveChanges();
        }
        public void AddAddingMealPlan(MealPlan mealPlan, Nutritionist user)
        {
            var mealPlans = _context.AddingMealPlans
                .Include(e => e.MealPlanDto)
                .FirstOrDefault(a => a.MealPlanDto == mealPlan);

            if (mealPlans != null) return;

            user.AddingMealPlans.Add(new AddingMealPlans() { MealPlanDto = mealPlan });
            _context.Update(user);
            _context.SaveChanges();
        }
        public void RemoveAddingComplexes(int id, Trainer user)
        {
            var removingComplex = _context.AddingComplexes
                .Include(e => e.SetOfExercisesDto)
                .Where(t => t.TrainerDto == user).FirstOrDefault(a => a.SetOfExercisesDto.Id == id);

            if (removingComplex == null) return;

            user.AddingComplexes.Remove(removingComplex);
            _context.SaveChanges();
        }
        public void RemoveAddingMealPlans(int id, Nutritionist user)
        {
            var removingMealPlan = _context.AddingMealPlans
                .Include(e => e.MealPlanDto)
                .Where(t => t.NutritionistDto == user).FirstOrDefault(a => a.MealPlanDto.Id == id);

            if (removingMealPlan == null) return;

            user.AddingMealPlans.Remove(removingMealPlan);
            _context.SaveChanges();
        }
    }
}
