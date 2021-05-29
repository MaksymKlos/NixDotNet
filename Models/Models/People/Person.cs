using System;
using System.Collections.Generic;
using System.Text;

namespace Models.People
{
    public class Person:IPersonData
    {
        #region Fields
        private readonly DateTime _birthDate;

        private string _secondName;
        private string _phoneNumber;
        #endregion
        #region Properties
        public int PersonId { get; set; }
        public string Login { get; private set; }
        public string Name { get; set; }
        /// <summary>
        /// Returns the user's age based on their date of birth.
        /// </summary>
        public int Age => CalculateYears(_birthDate);
        public string Email { get; }

        public string SecondName
        {
            get
            {
                if (_secondName != null)
                {
                    throw new ArgumentNullException(nameof(_secondName), "Second name has not assigned the value.");
                }
                return _secondName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Second name can't be empty or null.", nameof(value));
                }
                _secondName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                if (_phoneNumber != null)
                {
                    throw new ArgumentNullException(nameof(_secondName), "Second name has not assigned the value.");
                }
                return _phoneNumber;

            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Phone number can't be empty or null.", nameof(value));
                }
                _phoneNumber = value;
            }
        }

        #endregion
        #region Constructors

        public Person(string login, string name, DateTime birthDate, string email)
        {
            ChangeLogin(login);
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birthDate));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email can't be empty or null.", nameof(email));
            }
            if (!People.CheckEmailAvailability(email))
            {
                throw new ArgumentException("This email is already in use,", nameof(email));
            }
            Name = name;
            _birthDate = birthDate;
            Email = email;
            People.AddPerson(this);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Counts the years elapsed from the start date.
        /// </summary>
        /// <param name="startDate">Starting point</param>
        /// <returns></returns>
        private protected int CalculateYears(DateTime startDate)
        {
            DateTime now = DateTime.Today;
            int year = now.Year - startDate.Year;
            if (startDate > now.AddYears(-year)) year--;
            return year;
        }
        /// <summary>
        /// Allows the user to change their login.
        /// </summary>
        /// <param name="login">Unique login</param>
        public void ChangeLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("Login can't be empty or null.", nameof(login));
            }

            if (!People.CheckLoginAvailability(login))
            {
                throw new ArgumentException("This login is already in use,", nameof(login));
            }
            Login = login;
        }
        #endregion

    }
}
