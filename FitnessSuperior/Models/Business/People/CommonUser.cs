using System;

namespace Models.Business.People
{
    public class CommonUser:Client
    {
        public override string Status { get;} = "Regular";

        public CommonUser()
        {
            
        }
        public CommonUser(string login, string name, DateTime birthDate, string email) : base(login, name, birthDate, email)
        {
        }
    }
}
