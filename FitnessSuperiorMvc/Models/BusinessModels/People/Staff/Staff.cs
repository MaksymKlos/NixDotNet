using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People.Staff
{
    public class Staff:Person
    {
        private DateTime _startWorkDate;
        public string Education { get; set; }

        public int WorkExperience => CalculateYears(_startWorkDate);

        public Staff( string name, string secondName, DateTime birthDate) : base( name, secondName, birthDate)
        {
        }
        public void SetDate(DateTime startWorkDate)
        {
            _startWorkDate = startWorkDate;
        }
    }
}
