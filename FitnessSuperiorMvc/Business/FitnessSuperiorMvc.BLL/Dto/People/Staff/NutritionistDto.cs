using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Community;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;
using FitnessSuperiorMvc.BLL.Services;

namespace FitnessSuperiorMvc.BLL.Dto.People.Staff
{
    public class NutritionistDto:PersonDto
    {
        public string Education { get; set; }
        public int WorkExperience { get; set; }
        public string AgeSpecialization { get; set; }

        public virtual ICollection<NutritionProgramDto> NutritionPrograms { get; set; } =
            new List<NutritionProgramDto>();
        public virtual ICollection<AddingFood> AddingFood { get; set; } = new List<AddingFood>();
        public virtual ICollection<AddingMealPlans> AddingMealPlans { get; set; } = new List<AddingMealPlans>();
        public List<Feedback> Feedback { get; set; }

        public NutritionistDto() { }
    }
}
