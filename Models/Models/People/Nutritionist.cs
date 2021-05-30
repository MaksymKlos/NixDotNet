using System;
using System.Collections.Generic;
using System.Text;
using Models.Services;

namespace Models.People
{
    public class Nutritionist:Staff
    {
        #region Properties

        public string AgeSpecialization { get;}
        public string Options { get;}


        #endregion
        #region Constructors
        public Nutritionist(
            string login,
            string name,
            DateTime birthDate,
            string email,
            DateTime startWorkDate,
            string education,
            string ageSpecialization,
            string options) 
            : base(login, name, birthDate, email, startWorkDate, education)
        {
            if (string.IsNullOrWhiteSpace(ageSpecialization))
            {
                throw new ArgumentException("Age specialization can't be empty or null.", nameof(ageSpecialization));
            }
            if (string.IsNullOrWhiteSpace(options))
            {
                throw new ArgumentException("Options can't be empty or null.", nameof(options));
            }

            AgeSpecialization = ageSpecialization;
            Options = options;
        }
        #endregion
        #region Methods

        private NutritionProgram CreateNutritionProgram(
            string programName,
            string programDescription,
            Nutritionist specialist,
            string typeOfDiet,
            ICollection<MealPlan> mealPlans)
        {
            return new NutritionProgram(
                programName,
                programDescription,
                specialist,
                typeOfDiet,
                mealPlans);
        }

        private MealPlan CreateMealPlan(string name, ICollection<Food> food)
        {
            return new MealPlan(name, food);
        }

        #endregion
    }
}
