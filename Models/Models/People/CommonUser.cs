using System;
using System.Collections.Generic;
using System.Text;

namespace Models.People
{
    public class CommonUser:Client
    {
        private protected override string Status { get;} = "Regular";

        public CommonUser(string login, string name, DateTime birthDate, string email) : base(login, name, birthDate, email)
        {
        }
    }
}
