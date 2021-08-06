using System;
using System.Collections.Generic;
using System.Text;
using FitnessSuperiorMvc.BLL.Dto.Programs.Nutrition;

namespace FitnessSuperiorMvc.BLL.Dto.People.Staff
{
    /// <summary>
    /// Represents nutritionists.
    /// </summary>
    public class NutritionistDto:StaffDto
    {
        /// <summary>
        /// Age at which nutritionist specializes, e.g. "up to 18 y.o" if it's a child nutritionist.
        /// </summary>
        public string AgeSpecialization { get; set; }
        /// <summary>
        /// Programs created by this nutritionist.
        /// </summary>
        public virtual ICollection<NutritionProgramDto> NutritionPrograms { get; set; } = new List<NutritionProgramDto>();
        public NutritionistDto(string name, string secondName, DateTime birthDate) : base(name, secondName, birthDate)
        {
        }
    }
}
