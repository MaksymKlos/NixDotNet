using System.ComponentModel.DataAnnotations;

namespace FitnessSuperiorMvc.BLL.Interfaces
{
    internal interface IKey
    {
        [Key]
        public int Id { get; set; }
    }
}
