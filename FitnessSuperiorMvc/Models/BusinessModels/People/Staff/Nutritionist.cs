using System;
using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People.Staff
{
    /// <summary>
    /// Represents nutritionists.
    /// </summary>
    public class Nutritionist:Staff
    {
        /// <summary>
        /// Age at which nutritionist specializes, e.g. "up to 18 y.o" if it's a child nutritionist.
        /// </summary>
        public string AgeSpecialization { get; set; }

        /// <summary>
        /// Programs created by this nutritionist.
        /// </summary>
        public virtual List<NutritionProgramDto> NutritionPrograms { get; set; } = new List<NutritionProgramDto>();
        /// <summary>
        /// Create nutritionist.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="secondName">User surname.</param>
        /// <param name="birthDate">User birth date.</param>
        public Nutritionist(string name, string secondName, DateTime birthDate) : base( name, secondName, birthDate)
        {
        }
    }
}
