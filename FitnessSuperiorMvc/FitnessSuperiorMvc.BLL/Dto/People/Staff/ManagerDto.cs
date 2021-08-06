using System;

namespace FitnessSuperiorMvc.BLL.Dto.People.Staff
{
    public class ManagerDto:StaffDto
    {
        /// <summary>
        /// Admin, manager, etc.
        /// </summary>
        public string Position { get; set; }
        public ManagerDto(string name, string secondName, DateTime birthDate) : base(name, secondName, birthDate)
        {
        }
        
    }
}
