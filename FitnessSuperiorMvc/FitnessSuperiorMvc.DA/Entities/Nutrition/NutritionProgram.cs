using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.Nutrition
{
    public class NutritionProgram: IProgram, IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string Destination { get; set; }
        public string TypeOfDiet { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; }
        public Nutritionist Nutritionist { get; set; }

        public NutritionProgram()
        {
            MealPlans = new List<MealPlan>();
        }
    }
}
