using System.Collections.Generic;
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
    }
}
