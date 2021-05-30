using System;
using System.Collections.Generic;
using System.Text;

namespace Models.People
{
    public class VipUser:Client
    {
        private protected override string Status { get;} = "VIP";

        public VipUser(
            string login,
            string name,
            DateTime birthDate,
            string email)
            : base(login, name, birthDate, email)
        {
        }
    }
}
