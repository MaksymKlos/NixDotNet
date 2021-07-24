using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;

namespace FitnessSuperiorMvc.BLL.Dto.People.Staff
{
    public class NutritionistDto:PersonDto
    {
        public string Education { get; set; }
        public int WorkExperience { get; set; }
        public string AgeSpecialization { get; set; }
        public virtual ICollection<NutritionProgramDto> NutritionPrograms { get; set; } =
            new List<NutritionProgramDto>();

        public NutritionistDto()
        {
            
        }
    }
}
