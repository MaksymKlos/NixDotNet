using System;
using System.Collections.Generic;

namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Nutrition
{
    /// <summary>
    /// Meal plan for the day.
    /// </summary>
    public class MealPlan
    {
        #region Properties
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
        public List<Food> Food { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Meal plan creation.
        /// </summary>
        /// <param name="name">Meal plan name.</param>
        /// <param name="food">Food contains in meal plan.</param>
        public MealPlan(string name, List<Food> food)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }
            Food = food ?? throw new ArgumentNullException(nameof(food), "Food can't be null");
            Name = name;
        }
        #endregion

        #region Methods
        private double CalculateCalories()
        {
            double cal = 0;
            foreach (var food in Food)
            {
                cal += food.Calories;
            }

            return cal;
        }
        #endregion
    }
}
