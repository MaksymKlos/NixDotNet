using System;
using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.BusinessModels.Services;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Nutrition;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People.Users
{
    /// <summary>
    /// Represents users.
    /// </summary>
    public class User:Person
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
        public List<TrainingProgram> TrainingPrograms { get; set; } = new List<TrainingProgram>();
        /// <summary>
        /// Nutrition programs to which the user is subscribed.
        /// </summary>
        public List<NutritionProgram> NutritionPrograms { get; set; } = new List<NutritionProgram>();
        /// <summary>
        /// Create user.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="secondName">User surname.</param>
        /// <param name="birthDate">User birth date.</param>
        public User(string name, string secondName, DateTime birthDate):base(name, secondName, birthDate)
        {

        }

    }
}
