using System;
using System.Collections.Generic;

namespace FitnessSuperiorMvc.BLL.Dto.Programs.Nutrition
{
    public class NutritionProgramDto:FitnessProgramDto
    {
        /// <summary>
        /// Program type (muscle gain, weight loss).
        /// </summary>
        public string TypeOfDiet { get; }

        public virtual ICollection<MealPlanDto> MealPlans { get; set; } = new List<MealPlanDto>();
        public NutritionProgramDto(string name, string description, string destination, decimal price, string typeOfDiet) : base(name, description, destination, price)
        {
            if (string.IsNullOrWhiteSpace(typeOfDiet))
            {
                throw new ArgumentException("The type of diet can't be empty or null.", nameof(typeOfDiet));
            }
            TypeOfDiet = typeOfDiet switch
            {
                "loss" => "Weight loss",
                "gain" => "Muscle gain",
                _ => typeOfDiet
            };
        }
    }
}
