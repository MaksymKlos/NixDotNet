using System.ComponentModel.DataAnnotations;

namespace FitnessSuperiorMvc.WEB.ViewModels.Authentication
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Role { get; set; }
    }
}
