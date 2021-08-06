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
        //[Range(0,double.MaxValue)]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Calories; Maximum Two Decimal Points.")]
        public double Calories { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        [DataType(DataType.Currency)]
        public int Proteins { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public int Fats { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public int Carbohydrates { get; set; }
        [Required]
        [MaxLength(300)]
        public string BeneficialFeatures { get; set; }
    }
}
