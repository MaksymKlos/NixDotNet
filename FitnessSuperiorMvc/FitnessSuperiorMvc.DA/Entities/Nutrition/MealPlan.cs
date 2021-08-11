using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.Nutrition
{
    public class MealPlan:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Calories { get; set; }
        public ICollection<Food> Food { get; set; }
        public ICollection<NutritionProgram> NutritionPrograms { get; set; }
        public Nutritionist Author { get; set; }

        public MealPlan()
        {
            Food = new List<Food>();
            NutritionPrograms = new List<NutritionProgram>();
        }
    }
}
