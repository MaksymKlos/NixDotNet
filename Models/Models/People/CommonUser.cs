using System;
using System.Collections.Generic;
using System.Text;

namespace Models.People
{
    public class CommonUser:Client
    {
        public CommonUser(string login, string name, DateTime birthDate, string email, DateTime startWorkDate, string education) : base(login, name, birthDate, email, startWorkDate, education)
        {
        }
    }
}
