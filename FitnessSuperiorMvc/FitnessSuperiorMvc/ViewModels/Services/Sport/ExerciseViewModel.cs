using System.ComponentModel.DataAnnotations;
using FitnessSuperiorMvc.WEB.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FitnessSuperiorMvc.WEB.ViewModels.Services.Sport
{
    public class ExerciseViewModel:IViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The length of sting must be from 6 to 50")]
        [Remote("IsNameOfExerciseInUse", "Validation", ErrorMessage = "Name is already exist!")]
        [Display(Name = "Exercise name")]
        
        public string Name { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "The length of sting must be from 1 to 300")]
        [Display(Name = "Active muscles")]
        public string MuscleGroups { get; set; }
    }
}
