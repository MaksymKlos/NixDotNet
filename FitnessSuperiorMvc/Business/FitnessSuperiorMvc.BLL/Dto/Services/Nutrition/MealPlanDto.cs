using System.Collections.Generic;

using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.BLL.Dto.Services.Nutrition
{
    public class MealPlanDto:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public NutritionistDto Author { get; set; }
        public virtual ICollection<FoodDto> Food { get; set; }

        public MealPlanDto()
        {
            
        }
    }
}
