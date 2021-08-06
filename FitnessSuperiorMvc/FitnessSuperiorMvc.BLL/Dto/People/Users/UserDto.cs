using System;
using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.Dto.Programs.Nutrition;
using FitnessSuperiorMvc.BLL.Dto.Programs.Sport;

namespace FitnessSuperiorMvc.BLL.Dto.People.Users
{
    /// <summary>
    /// Represents users.
    /// </summary>
    public class UserDto:PersonDto
    {
        /// <summary>
        /// User account balance.
        /// </summary>
        private decimal _balance;
        /// <summary>
        /// Balance field access property.
        /// </summary>
        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid value.", nameof(value));
                }

                _balance = value;
            }
        }
        /// <summary>
        /// Training programs to which the user is subscribed.
        /// </summary>
        public ICollection<TrainingProgramDto> TrainingPrograms { get; set; } = new List<TrainingProgramDto>();
        /// <summary>
        /// Nutrition programs to which the user is subscribed.
        /// </summary>
        public ICollection<NutritionProgramDto> NutritionPrograms { get; set; } = new List<NutritionProgramDto>();
        /// <summary>
        /// Create user.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="secondName">User surname.</param>
        /// <param name="birthDate">User birth date.</param>
        public UserDto(string name, string secondName, DateTime birthDate) : base(name, secondName, birthDate)
        {
        }
    }
}
