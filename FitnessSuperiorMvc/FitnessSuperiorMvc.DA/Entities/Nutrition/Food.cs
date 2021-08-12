using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.Nutrition
{
    public class Food:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public string BeneficialFeatures { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; }

        public Food()
        {
            MealPlans = new List<MealPlan>();
        }
    }
}
