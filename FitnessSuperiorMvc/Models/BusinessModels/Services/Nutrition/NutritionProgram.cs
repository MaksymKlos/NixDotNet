﻿using System;
using System.Collections.Generic;
using System.Text;
using FitnessSuperiorMvc.BLL.BusinessModels.People.Staff;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Community;


namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Nutrition
{
    public class NutritionProgram:FitnessProgram
    {
        public override string ProgramName { get; }
        public override string ProgramDescription { get; }
        public override decimal Price { get; }
        public override List<Feedback> Feedback { get; set; } = new List<Feedback>();

        /// <summary>
        /// Program nutritionist.
        /// </summary>
        public Nutritionist Nutritionist { get; set; }
        /// <summary>
        /// Program type (muscle gain, weight loss).
        /// </summary>
        public string TypeOfDiet { get; set; }

        /// <summary>
        /// Meal plans that make up the program.
        /// </summary>
        public List<MealPlan> MealPlans { get; set; } = new List<MealPlan>();
        /// <summary>
        /// Create training program.
        /// </summary>
        /// <param name="programName">Program name.</param>
        /// <param name="programDescription">Program description.</param>
        /// <param name="nutritionist">Program nutritionist.</param>
        /// <param name="typeOfDiet">Program type (muscle gain, weight loss).</param>
        /// <param name="price"> Program price.</param>
        public NutritionProgram(string programName, string programDescription, decimal price, Nutritionist nutritionist, string typeOfDiet)
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
            Nutritionist = nutritionist ?? throw new ArgumentNullException(nameof(nutritionist), "Nutritionist can't be null");
            if (price > 0)
            {
                Price = price;
            }
            TypeOfDiet = typeOfDiet;
            ProgramName = programName;
            ProgramDescription = programDescription;
        }
    }
}
