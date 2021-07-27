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
        /// Number of kcal per day.
        /// </summary>
        public double Calories => CalculateCalories();
        /// <summary>
        /// Food contains in meal plan.
        /// </summary>
        public List<Food> Food { get; set; }

        /// <summary>
        /// Meal plan creation.
        /// </summary>
        /// <param name="name">Meal plan name.</param>
        /// <param name="food">Food contains in meal plan.</param>
        public MealPlan(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }
            Name = name;
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
