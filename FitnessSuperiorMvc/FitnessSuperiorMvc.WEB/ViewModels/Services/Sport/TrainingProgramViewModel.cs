using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace FitnessSuperiorMvc.WEB.ViewModels.Services.Sport
{
    public class TrainingProgramViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The length of sting must be from 6 to 50")]
        [Remote("IsNameOfTrainingProgramInUse", "Validation", ErrorMessage = "Name is already exist!")]
        public string Name { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 6, ErrorMessage = "The length of sting must be from 6 to 300")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Destination { get; set; }
        public string TypeOfProgram { get; set; }
        public string RequiredSkillLevel { get; set; }
        [RegularExpression(@"\d*",ErrorMessage = "Value must be an integer.")]
        [Range(0, 18, ErrorMessage = "Accommodation invalid (0-18).")]
        public int AgeRestriction { get; set; }
    }
}
