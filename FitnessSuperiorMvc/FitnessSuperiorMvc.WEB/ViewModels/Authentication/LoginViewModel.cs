using System.ComponentModel.DataAnnotations;
using FitnessSuperiorMvc.WEB.ViewModels.Interfaces;

namespace FitnessSuperiorMvc.WEB.ViewModels.Authentication
{
    public class LoginViewModel:IViewModel
    {
        [Required(ErrorMessage = "Login can't be empty")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Login must be from 6 to 20")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Confirm { get; set; }
    }
}
