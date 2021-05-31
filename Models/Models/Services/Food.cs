using System;

namespace Models.Services
{
    public class Food
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get;}
        public double Calories { get;}
        public string BeneficialFeatures { get;}
        #endregion

        #region Constructors

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

        public override string ToString() => $"{Name}";


        #endregion
    }
}
