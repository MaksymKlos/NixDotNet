using System;

namespace Models.Business.People
{
    public class VipUser:Client
    {
        public override string Status { get;} = "VIP";

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
