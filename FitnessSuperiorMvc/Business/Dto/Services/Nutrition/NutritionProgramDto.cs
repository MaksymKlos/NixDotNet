using System.Collections.Generic;

namespace FitnessSuperiorMvc.BLL.Dto.Services.Nutrition
{
    public class NutritionProgramDto:FitnessProgramDto
    {
        public string TypeOfDiet { get; set; }
        public virtual ICollection<MealPlanDto> MealPlans { get; set; }

        public NutritionProgramDto(
            string name,
            string description,
            decimal price,
            string destination,
            string typeOfDiet)
            : base(name, description, price, destination)
        {
            TypeOfDiet = typeOfDiet;
        }
    }
}
