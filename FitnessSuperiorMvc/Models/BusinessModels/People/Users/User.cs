using System;
using System.Collections.Generic;
using System.Text;
using FitnessSuperiorMvc.BLL.BusinessModels.Services;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Nutrition;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People.Users
{
    public class User:Person
    {
        private decimal _balance;

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

        public List<TrainingProgram> TrainingPrograms { get; set; } = new List<TrainingProgram>();
        public List<NutritionProgram> NutritionPrograms { get; set; } = new List<NutritionProgram>();
        public User(string name, string secondName, DateTime birthDate):base(name, secondName, birthDate)
        {

        }

    }
}
