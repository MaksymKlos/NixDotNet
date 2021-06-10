using System;
using System.Collections.Generic;
using System.Text;
using Models.Business.Services;
using Models.Dto.FitnessProgram;
using Models.Interfaces;

namespace Models.Dto.Person
{
    public class UserDto:PersonDto,IRole
    {
        public string Status { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<TrainingProgram> TrainingPrograms { get; set; }
        public virtual ICollection<NutritionProgram> NutritionPrograms { get; set; }

        public UserDto()
        {
            
        }
        public UserDto(
            string login,
            string name,
            int age,
            string email,
            string status)
            : base(login, name,  age, email)
        {
            Status = status;
        }
    }
}
