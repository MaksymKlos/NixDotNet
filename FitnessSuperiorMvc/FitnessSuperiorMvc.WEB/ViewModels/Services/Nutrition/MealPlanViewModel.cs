using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.ViewModels.Services.Nutrition
{
    public class MealPlanViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The length of sting must be from 5 to 50")]
        [Remote("IsNameOfMealPlanInUse", "Validation", ErrorMessage = "Name is already exist!")]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }
}
