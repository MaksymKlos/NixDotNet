using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSuperiorMvc.WEB.ViewModels.Services.Nutrition
{
    public class FoodViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Calories { get; set; }
        [Required]
        public int Proteins { get; set; }
        [Required]
        public int Fats { get; set; }
        [Required]
        public int Carbohydrates { get; set; }
        [Required]
        public string BeneficialFeatures { get; set; }
    }
}
