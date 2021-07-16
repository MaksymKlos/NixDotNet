using System;
using System.Collections.Generic;
using System.Text;
using Models.Interfaces;

namespace Models.Dto.FitnessProgram
{
    public class FoodDto:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public string BeneficialFeatures { get; set; }

        public FoodDto(string name, double calories, string beneficialFeatures)
        {
            Name = name;
            Calories = calories;
            BeneficialFeatures = beneficialFeatures;
        }
    }
}
