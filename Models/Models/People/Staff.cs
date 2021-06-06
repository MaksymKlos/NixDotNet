using System;
using System.Collections.Generic;
using System.Text;
using Models.Interaction;

namespace Models.People
{
    public class Staff:Person
    {
        #region Fields
        private readonly DateTime _startWorkDate;
        //private List<Feedback> _feedback = new List<Feedback>();
        #endregion

        #region Properties
        public string Education { get; }
        public int WorkExperience => CalculateYears(_startWorkDate);

        //public virtual ICollection<Feedback> Feedback
        //{
        //    get
        //    {
        //        if (_feedback != null)
        //        {
        //            return _feedback;
        //        }

        //        throw new ArgumentNullException(nameof(_feedback), "Feedback has not assigned a value.");
        //    }
        //}

        #endregion

        #region Constructors
        public Staff(string login,
                    string name,
                    DateTime birthDate,
                    string email,
                    DateTime startWorkDate,
                    string education)
                    : base(login, name, birthDate, email)
        {
            if (startWorkDate < DateTime.Parse("01.01.1900") || startWorkDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date.", nameof(startWorkDate));
            }
            if (string.IsNullOrWhiteSpace(education))
            {
                throw new ArgumentException("Education can't be empty or null.", nameof(education));
            }

            _startWorkDate = startWorkDate;
            Education = education;
        }
        #endregion
        #region Methods
        //public void AddFeedback(Feedback feedback)
        //{
        //    if (feedback!=null)
        //    {
        //        _feedback.Add(feedback);
        //    }
        //}
        #endregion
    }
}
