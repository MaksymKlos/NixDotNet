using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Models.Interfaces;

namespace Models.Dto.Person
{
    public class PersonDto:IPersonDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        [JsonPropertyName("FirstName")]
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public PersonDto()
        {
            
        }
        public PersonDto(
            string login,
            string name,
            int age,
            string email)

        {
            Login = login;
            Name = name;
            Age = age;
            Email = email;
        }
    }
}
