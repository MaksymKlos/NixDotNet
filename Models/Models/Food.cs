using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Food
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Type { get; set; }
        public double Calorie { get; set; }
        public string BeneficialFeatures { get; set; }

        public Food(int name, string type, double calorie, string beneficialFeatures)
        {
            Name = name;
            Type = type;
            Calorie = calorie;
            BeneficialFeatures = beneficialFeatures;
        }
    }
}
