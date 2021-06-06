using System;
using System.Collections.Generic;
using System.Text;
using Models.Dto.Person;

namespace Models.Dto.FitnessProgram
{
    public class NutritionProgramDto:FitnessProgramDto<NutritionistDto>
    {
        public string TypeOfDiet { get; set; }
        public virtual ICollection<MealPlanDto> MealPlans { get; set; }
    }
}
