﻿using System;
using System.Collections.Generic;
using Models.Business.People;

namespace Models.Business.Services
{
    public class NutritionProgram:FitnessProgram<Nutritionist>
    {
        #region Fields

        private ICollection<MealPlan> _mealPlans;

        #endregion

        #region Properties
        public override string Name { get; }
        public override string Description { get; }
        public override Nutritionist Specialist { get; }
        public override decimal Price { get; } = 0;
        public override string Destination { get; } = "General";
        public string TypeOfDiet { get; }

        public ICollection<MealPlan> MealPlans
        {
            get
            {
                if (_mealPlans != null)
                {
                    return _mealPlans;
                }

                throw new ArgumentNullException(nameof(_mealPlans), "Meal plans has not assigned a value");
            }
            set => _mealPlans = value ?? throw new ArgumentNullException(nameof(value), "MealPlans can't be null");
        }

        #endregion

        #region Constructors

        public NutritionProgram(
            string programName,
            string programDescription,
            Nutritionist specialist,
            string typeOfDiet,
            ICollection<MealPlan> mealPlans)
        {
            if (string.IsNullOrWhiteSpace(programName))
            {
                throw new ArgumentException("The name of program can't be empty or null.", nameof(programName));
            }
            if (string.IsNullOrWhiteSpace(programDescription))
            {
                throw new ArgumentException("The description of program can't be empty or null.", nameof(programDescription));
            }
            if (string.IsNullOrWhiteSpace(typeOfDiet))
            {
                throw new ArgumentException("The type of diet can't be empty or null.", nameof(typeOfDiet));
            }
            Specialist = specialist ?? throw new ArgumentNullException(nameof(specialist), "Specialist can't be null");
            MealPlans = mealPlans;
            Name = programName;
            Description = programDescription;
            Specialist = specialist;
            TypeOfDiet = typeOfDiet;
        }
        public NutritionProgram(string programName,
            string programDescription,
            Nutritionist specialist,
            string typeOfDiet,
            ICollection<MealPlan> mealPlans,
            decimal price)
        :this(programName, programDescription, specialist, typeOfDiet, mealPlans)
        {
            if (string.IsNullOrWhiteSpace(programName))
            {
                throw new ArgumentException("The name of program can't be empty or null.", nameof(programName));
            }
            if (string.IsNullOrWhiteSpace(programDescription))
            {
                throw new ArgumentException("The description of program can't be empty or null.", nameof(programDescription));
            }
            if (string.IsNullOrWhiteSpace(typeOfDiet))
            {
                throw new ArgumentException("The type of diet can't be empty or null.", nameof(typeOfDiet));
            }
            if (price < 0)
            {
                throw new ArgumentException("Price can't be less than 0.", nameof(price));
            }
            Specialist = specialist ?? throw new ArgumentNullException(nameof(specialist), "Specialist can't be null");
            if (price > 0)
            {
                Price = price;
                Destination = "Personal";
            }
            MealPlans = mealPlans;
            Name = programName;
            Description = programDescription;
            Specialist = specialist;
            TypeOfDiet = typeOfDiet;
        }


        #endregion

        #region Methods
        public override string GetInfoAboutProgram()
        {
            return $"Program name: {Name}\n" +
                   $"Program description: {Description}\n" +
                   $"Trainer: {Specialist.Name}\n" +
                   $"Price: {Price}\n" +
                   $"Destination: {Destination}\n" +
                   $"Type of diet: {TypeOfDiet}\n";
        }
        #endregion

    }
}
