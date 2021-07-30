using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.ViewModels.Services.Nutrition
{
    public class NutritionProgramViewModel
    {
        [Required]
        [Remote("IsNameOfNutritionProgramInUse", "Validation", ErrorMessage = "Name is already exist!")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
        public string TypeOfDiet { get; set; }
    }
}
