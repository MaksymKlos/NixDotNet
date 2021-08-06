using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.Nutrition
{
    public class NutritionProgram: IProgram, IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
        public string TypeOfDiet { get; set; }
        public virtual ICollection<MealPlan> MealPlans { get; set; }
    }
}
