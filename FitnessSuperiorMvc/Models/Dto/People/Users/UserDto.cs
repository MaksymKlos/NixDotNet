using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.BLL.Dto.People.Users
{
    public class UserDto:PersonDto
    {
        [Column(TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; }
        public virtual ICollection<TrainingProgramDto> TrainingPrograms { get; set; } = new List<TrainingProgramDto>();

        public virtual ICollection<NutritionProgramDto> NutritionPrograms { get; set; } =
            new List<NutritionProgramDto>();

        public UserDto()
        {
            
        }

    }
}
