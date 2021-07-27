using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;

namespace FitnessSuperiorMvc.BLL.Services
{
    public class AddingMealPlans
    {
        public int AddingMealPlansId { get; set; }
        public MealPlanDto MealPlanDto { get; set; }
        public NutritionistDto NutritionistDto { get; set; }
        public int NutritionistDtoId { get; set; }
    }
}
