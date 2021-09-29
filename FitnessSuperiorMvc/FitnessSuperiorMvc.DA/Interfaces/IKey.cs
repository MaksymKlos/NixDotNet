using System.ComponentModel.DataAnnotations;

namespace FitnessSuperiorMvc.DA.Interfaces
{
    public interface IKey
    {
        [Key]
        public int Id { get; set; }
    }
}
