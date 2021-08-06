using System;
using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.Dto.Interaction;

namespace FitnessSuperiorMvc.BLL.Dto.People.Staff
{
    /// <summary>
    /// Represents all staff.
    /// </summary>
    public class StaffDto:PersonDto
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
        public ICollection<FeedBackDto> Feedback { get; set; } = new List<FeedBackDto>();
        /// <summary>
        /// Create staff.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="secondName">User surname.</param>
        /// <param name="birthDate">User birth date.</param>
        public StaffDto(string name, string secondName, DateTime birthDate) : base(name, secondName, birthDate)
        {
        }
    }
}
