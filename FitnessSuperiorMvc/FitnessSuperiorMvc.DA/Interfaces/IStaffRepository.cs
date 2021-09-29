using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;

namespace FitnessSuperiorMvc.DA.Interfaces
{
    public interface IStaffRepository
    {
        List<Exercise> GetExercises(Trainer user);
        List<Food> GetFood(Nutritionist user);
        void DeleteExercises(Trainer user);
        void DeleteFood(Nutritionist user);
        void AddAddingExercises(Exercise exercise, Trainer user);
        void AddAddingFood(Food food, Nutritionist user);
        void RemoveAddingExercises(int id, Trainer user);
        void RemoveAddingFood(int id, Nutritionist user);
        List<SetOfExercises> GetComplexes(Trainer user);
        List<MealPlan> GetMealPlans(Nutritionist user);
        void DeleteComplex(Trainer user);
        void DeleteMealPlan(Nutritionist user);
        void AddAddingComplexes(SetOfExercises complex, Trainer user);
        void AddAddingMealPlan(MealPlan mealPlan, Nutritionist user);
        void RemoveAddingComplexes(int id, Trainer user);
        void RemoveAddingMealPlans(int id, Nutritionist user);
    }
}