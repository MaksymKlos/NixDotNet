using System;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.BLL.Dto.Programs.Nutrition
{
    /// <summary>
    /// Represents food.
    /// </summary>
    public class FoodDto:IKey
    {
        public int Id { get; set; }
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
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        public string BeneficialFeatures { get; }
        /// <summary>
        /// Food creation.
        /// </summary>
        /// <param name="name">Product name.</param>
        /// <param name="calories">The number of kcal in 100 grams of the product.</param>
        /// <param name="beneficialFeatures">Beneficial properties of food.</param>
        /// <param name="proteins">Proteins per 100 grams.</param>
        /// <param name="fats">Fats per 100 grams.</param>
        /// <param name="carbohydrates">Carbohydrates per 100 grams.</param>
        public FoodDto(string name, double calories, string beneficialFeatures, double proteins, double fats, double carbohydrates)
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
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }
    }
}
