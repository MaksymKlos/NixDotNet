using System;
using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Community;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People.Staff
{
    /// <summary>
    /// Represents all staff.
    /// </summary>
    public class Staff:Person
    {
        /// <summary>
        /// Estimated career start time.
        /// </summary>
        private DateTime _startWorkDate;
        /// <summary>
        /// Staff education.
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// Field access property.
        /// </summary>
        public DateTime StartWorkDate
        {
            set => _startWorkDate = value;
        }
        /// <summary>
        /// Work experience based on the date of the start of work.
        /// </summary>
        public int WorkExperience => CalculateYears(_startWorkDate);
        /// <summary>
        /// Staff reviews.
        /// </summary>
        public List<Feedback> Feedback { get; set; }
        /// <summary>
        /// Create staff.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="secondName">User surname.</param>
        /// <param name="birthDate">User birth date.</param>
        public Staff( string name, string secondName, DateTime birthDate) : base( name, secondName, birthDate)
        {
        }

    }
}
