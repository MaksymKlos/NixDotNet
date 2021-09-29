using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;

namespace FitnessSuperiorMvc.DA.Interfaces
{
    public interface IFitnessServicesRepository
    {
        List<Exercise> GetExercisesFromComplex(int id);
        Trainer GetTrainerOfComplex(int id);
        List<SetOfExercises> GetComplexFromProgram(int id);
        Trainer GetTrainerOfProgram(int id);
        List<Food> GetFoodFromMealPlan(int id);
        Nutritionist GetNutritionistOfComplex(int id);
        List<MealPlan> GetMealPlansOfProgram(int id);
        Nutritionist GetNutritionistOfProgram(int id);
        List<TrainingProgram> GetTrainingPrograms(int id);
        List<NutritionProgram> GetNutritionPrograms(int id);
    }
}