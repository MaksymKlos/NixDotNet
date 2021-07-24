using System;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People.Staff
{
    /// <summary>
    /// Represents main staff(admins, moderators, etc.)
    /// </summary>
    public class Manager:Person
    {
        /// <summary>
        /// Admin, manager, etc.
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Create manager.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="secondName">User surname.</param>
        /// <param name="birthDate">User birth date.</param>
        public Manager(string name, string secondName, DateTime birthDate) : base(name, secondName, birthDate)
        {
        }
    }
}
