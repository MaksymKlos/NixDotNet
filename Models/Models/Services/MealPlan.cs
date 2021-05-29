using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Services
{
    public class MealPlan
    {
        #region Fields
        private readonly ICollection<Food> _food;
        #endregion

        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }

        public ICollection<Food> Food => _food;


        #endregion

        #region Constructors



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

        #endregion
    }
}
