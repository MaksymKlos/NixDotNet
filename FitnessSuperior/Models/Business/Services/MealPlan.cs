using System;
using System.Collections.Generic;

namespace Models.Business.Services
{
    public class MealPlan
    {
        #region Fields
        private readonly ICollection<Food> _food;
        #endregion

        #region Properties

        public string Name { get; }
        public double Calories => CalculateCalories();

        public ICollection<Food> Food => _food;


        #endregion

        #region Constructors

        public MealPlan(string name, ICollection<Food> food)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }
            _food = food?? throw new ArgumentNullException(nameof(food), "Food can't be null");
            Name = name;
        }


        #endregion

        #region Methods

        internal void AddFood(Food food)
        {
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food), "Food can't be null");
            }
            _food.Add(food);
        }

        private double CalculateCalories()
        {
            double cal = 0;
            foreach (var food in _food)
            {
                cal += food.Calories;
            }

            return cal;
        }
        #endregion
    }
}
