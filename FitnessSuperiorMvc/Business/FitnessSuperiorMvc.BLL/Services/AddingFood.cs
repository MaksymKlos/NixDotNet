using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;

namespace FitnessSuperiorMvc.BLL.Services
{
    public class AddingFood
    {
        public int AddingFoodId { get; set; }
        public FoodDto FoodDto { get; set; }
        public NutritionistDto NutritionistDto { get; set; }
        public int NutritionistDtoId { get; set; }
    }
}
