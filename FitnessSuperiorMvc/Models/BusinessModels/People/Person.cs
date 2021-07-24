using System;
using System.Reflection.Metadata;
using FitnessSuperiorMvc.BLL.BusinessModels.People.Users;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People
{
    public class Person
    {
        #region Fields
        private readonly DateTime _birthDate;

        #endregion
        #region Properties
        public string Name { get; }
        /// <summary>
        /// Returns the user's age based on their date of birth.
        /// </summary>
        public int Age => CalculateYears(_birthDate);

        public string SecondName { get; }

        public string Role { get; set; }
        public string IdentityId { get; set; }

        #endregion
        #region Constructors

        public Person()
        {
            
        }
        public Person(string name, string secondName, DateTime birthDate)
        {
            _birthDate = birthDate;
            Name = name;
            SecondName = secondName;
        }
        //public Person(string login, string name, DateTime birthDate, string email)
        //{
        //    ChangeLogin(login);
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        throw new ArgumentException("Name can't be empty or null.", nameof(name));
        //    }

        //    if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
        //    {
        //        throw new ArgumentException("Impossible date of birth.", nameof(birthDate));
        //    }

        //    if (string.IsNullOrWhiteSpace(email))
        //    {
        //        throw new ArgumentException("Email can't be empty or null.", nameof(email));
        //    }
        //    if (!People.CheckEmailAvailability(email))
        //    {
        //        throw new ArgumentException("This email is already in use,", nameof(email));
        //    }
        //    Name = name;
        //    _birthDate = birthDate;
        //    Email = email;
        //    People.AddPerson(this);
        //}
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

        #endregion

    }
}
