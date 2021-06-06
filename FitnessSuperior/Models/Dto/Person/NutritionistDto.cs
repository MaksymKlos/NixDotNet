using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto.Person
{
    public class NutritionistDto:PersonDto
    {
        public string Education { get; set; }
        public int WorkExperience { get; set; }
        public string AgeSpecialization { get; set; }
        public string Options { get; set; }

        public NutritionistDto(
            string login,
            string name,
            int age,
            string email,
            string education,
            int workExperience,
            string ageSpecialization,
            string options)
            : base(login, name, age, email)
        {
            Education = education;
            WorkExperience = workExperience;
            AgeSpecialization = ageSpecialization;
            Options = options;
        }
    }
}
