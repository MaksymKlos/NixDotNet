using System;
using System.Collections.Generic;

namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Nutrition
{
    /// <summary>
    /// Meal plan for the day.
    /// </summary>
    public class MealPlan
    {
        /// <summary>
        /// Meal plan name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Meal plan description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Number of kcal per day.
        /// </summary>
      
        public double Calories => CalculateCalories();

        /// <summary>
        /// Food in meal plan.
        /// </summary>
        public List<Food> Food { get; set; } = new List<Food>();
        /// <summary>
        /// Meal plan creation.
        /// </summary>
        /// <param name="name">Meal plan name.</param>
        /// <param name="description">Meal plan description.</param>
        public MealPlan(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description can't be empty or null.", nameof(description));
            }
            Name = name;
            Description = description;
        }


        private double CalculateCalories()
        {
            double cal = 0;
            foreach (var food in Food)
            {
                cal += food.Calories;
            }

            return cal;
        }
    }
}
