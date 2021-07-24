using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People.Staff
{
    public class Nutritionist:Staff
    {
        public string AgeSpecialization { get; set; }

        public Nutritionist(string name, string secondName, DateTime birthDate) : base( name, secondName, birthDate)
        {
        }
    }
}
