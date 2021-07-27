using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSuperiorMvc.WEB.ViewModels.Services.Nutrition
{
    public class NutritionProgramViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
        [Required]
        public string TypeOfDiet { get; set; }
    }
}
