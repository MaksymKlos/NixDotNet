using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.ViewModels.Services.Nutrition
{
    public class FoodViewModel
    {
        [Required]
        [MaxLength(50)]
        [Remote("IsNameOfFoodInUse", "Validation", ErrorMessage = "Name is already exist!")]
        public string Name { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public double Calories { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public int Proteins { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public int Fats { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public int Carbohydrates { get; set; }
        [Required]
        [MaxLength(300)]
        public string BeneficialFeatures { get; set; }
    }
}
