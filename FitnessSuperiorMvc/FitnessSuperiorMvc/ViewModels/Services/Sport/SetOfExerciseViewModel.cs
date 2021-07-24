using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessSuperiorMvc.WEB.ViewModels.Services.Sport
{
    public class SetOfExerciseViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The length of sting must be from 6 to 50")]
        [Remote("IsNameOfComplexInUse", "Validation", ErrorMessage = "Name is already exist!")]
        [Display(Name = "Exercise name")]

        public string Name { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "The length of sting must be from 1 to 300")]
        [Display(Name = "Active muscles")]
        public string MuscleGroups { get; set; }
    }
}
