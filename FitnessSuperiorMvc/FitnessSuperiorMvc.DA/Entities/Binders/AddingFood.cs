
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;

namespace FitnessSuperiorMvc.DA.Entities.Bridging
{
    public class AddingFood
    {
        public int AddingFoodId { get; set; }
        public Food FoodDto { get; set; }
        public Nutritionist NutritionistDto { get; set; }
        public int NutritionistDtoId { get; set; }
    }
}
