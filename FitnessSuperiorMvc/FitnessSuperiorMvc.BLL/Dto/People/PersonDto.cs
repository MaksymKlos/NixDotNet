using System;
namespace FitnessSuperiorMvc.BLL.Dto.People
{
    /// <summary>
    /// Represents all persons.
    /// </summary>
    public class PersonDto
    {
        /// <summary>
        /// Person date of birth.
        /// </summary>
        private readonly DateTime _birthDate;


        /// <summary>
        /// Person name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Returns the user's age based on their date of birth.
        /// </summary>
        public int Age => CalculateYears(_birthDate);
        /// <summary>
        /// Person surname.
        /// </summary>
        public string SecondName { get; }
        /// <summary>
        /// Connection with Identity.
        /// </summary>
        public string IdentityId { get; set; }


        /// <summary>
        /// Default constructor.
        /// </summary>
        protected internal PersonDto() { }
        /// <summary>
        /// Create person.
        /// </summary>
        /// <param name="name">Person name.</param>
        /// <param name="secondName">Person surname.</param>
        /// <param name="birthDate">Person birth date.</param>
        public PersonDto(string name, string secondName, DateTime birthDate)
        {
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birthDate));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(secondName))
            {
                throw new ArgumentException("Surname can't be empty or null.", nameof(secondName));
            }
            _birthDate = birthDate;
            Name = name;
            SecondName = secondName;
        }

        /// <summary>
        /// Counts the years elapsed from the start date.
        /// </summary>
        /// <param name="startDate">Starting point.</param>
        /// <returns></returns>
        private protected int CalculateYears(DateTime startDate)
        {
            DateTime now = DateTime.Today;
            int year = now.Year - startDate.Year;
            if (startDate > now.AddYears(-year)) year--;
            return year;
        }
        
    }
}
