using System;
using System.Collections.Generic;
using System.Text;
using Models.Interfaces;

namespace Models.Dto.Person
{
    public class UserDto:PersonDto,IRole
    {
        public string Status { get; set; }

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
