using System;
using Models.Dto.FitnessProgram;

namespace Models.BusinessModels.Services
{
    public class Food
    {
        #region Properties
        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The number of kcal in 100 grams of the product.
        /// </summary>
        public double Calories { get; }
        /// <summary>
        /// Beneficial properties of food.
        /// </summary>
        public string BeneficialFeatures { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Food creation.
        /// </summary>
        /// <param name="name">Product name.</param>
        /// <param name="calories">The number of kcal in 100 grams of the product.</param>
        /// <param name="beneficialFeatures">Beneficial properties of food.</param>
        public Food(string name, double calories, string beneficialFeatures)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null", nameof(name));
            }
            if (calories < 0)
            {
                throw new ArgumentException("Calories can't be less than 0", nameof(calories));
            }
            if (string.IsNullOrWhiteSpace(beneficialFeatures))
            {
                throw new ArgumentException("Beneficial features can't be empty or null");
            }
            Name = name;
            Calories = calories;
            BeneficialFeatures = beneficialFeatures;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Transform model to modelDto.
        /// </summary>
        /// <param name="food"></param>
        public static explicit operator FoodDto(Food food)
        {
            return new FoodDto(food.Name, food.Calories, food.BeneficialFeatures);
        }
        #endregion

    }
}
 