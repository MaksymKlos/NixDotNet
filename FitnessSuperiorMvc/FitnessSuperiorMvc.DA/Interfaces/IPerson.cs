using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessSuperiorMvc.DA.Interfaces
{
    internal interface IPerson
    {
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string SecondName { get; set; }
    }
}
