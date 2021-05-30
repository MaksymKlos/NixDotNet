using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interaction
{
    public class Feedback:IPersonData
    {
        #region Fields

        private string _name;
        private string _secondName;
        

        #endregion

        #region Properties
        public int FeedbackId { get; set; }
        public int PersonId { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be empty or null.", nameof(value));
                }

                _name = value;
            }
        }

        public string SecondName
        {
            get => _secondName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Second name can't be empty or null.", nameof(value));
                }

                _secondName = value;
            }
        }

        public string Email { get; }
        #endregion

        #region Constructors

        public Feedback(int personId, string name, string secondName, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email can't be empty or null.", nameof(email));
            }
            PersonId = personId;
            Name = name;
            SecondName = secondName;
            Email = email;
        }
        

        #endregion
    }
}
