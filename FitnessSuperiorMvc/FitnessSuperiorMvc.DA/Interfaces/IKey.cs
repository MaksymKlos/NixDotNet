using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessSuperiorMvc.DA.Interfaces
{
    internal interface IKey
    {
        [Key]
        public int Id { get; set; }
    }
}
