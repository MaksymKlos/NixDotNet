using System;
using System.Collections.Generic;
using System.Text;
using Models.Interfaces;

namespace Models.Dto.Person
{
    public class TrainerDto:PersonDto
    {
        public string Education { get; set; }
        public int WorkExperience { get; set; }
        public string Specialization { get; set; }
        public string WorkWithGender { get; set; }

        public TrainerDto(
            string login,
            string name,
            int age,
            string email,
            string education,
            int workExperience,
            string specialization,
            string workWithGender)
            : base(login, name, age, email)
        {
            Education = education;
            WorkExperience = workExperience;
            Specialization = specialization;
            WorkWithGender = workWithGender;
        }
    }
}
