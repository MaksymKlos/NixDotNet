using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FitnessSuperiorMvc.WEB.Attributes;
using FitnessSuperiorMvc.WEB.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace FitnessSuperiorMvc.WEB.ViewModels.Authentication
{
    public class RegisterViewModel:IViewModel
    {
        [Required(ErrorMessage = "Login can't be empty")]
        [StringLength(40, MinimumLength = 7, ErrorMessage = "Login must be from 7 to 40")]
        [Remote("IsUserLoginInUse", "Validation", ErrorMessage = "Login is already exist!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Name can't be empty")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Name must be from 2 to 40")]
        
        public string Name { get; set; }

        [StringLength(40, MinimumLength = 2, ErrorMessage = "Name must be from 2 to 40")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [EmailAddress]
        [Remote("IsUserEmailInUse", "Validation", ErrorMessage = "Email is already exist!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Birth date can't be empty")]
        [DataType(DataType.DateTime)]
        [DisplayName("Birth date")]
        [DateRange("01.01.1900")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Phone can't be empty")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Role { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
       
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,30}$",
            ErrorMessage = "The password must have at least one lowercase letter, one uppercase letter, one number, and one special character. Length from 8 to 30 symbols")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)]
        
        public string ConfirmPassword { get; set; }
    }
}
