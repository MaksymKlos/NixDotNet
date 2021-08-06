
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;

namespace FitnessSuperiorMvc.DA.Entities.Bridging
{
    public class AddingMealPlans
    {
        public int AddingMealPlansId { get; set; }
        public MealPlan MealPlanDto { get; set; }
        public Nutritionist NutritionistDto { get; set; }
        public int NutritionistDtoId { get; set; }
    }
}
