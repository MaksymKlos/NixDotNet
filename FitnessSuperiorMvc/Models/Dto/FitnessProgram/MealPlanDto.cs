using System;
using System.Collections.Generic;
using System.Text;
using Models.Interfaces;

namespace Models.Dto.FitnessProgram
{
    public class MealPlanDto:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public virtual ICollection<FoodDto> Food { get; set; }
    }
}
