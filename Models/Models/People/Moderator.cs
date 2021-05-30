using System;
using System.Collections.Generic;
using System.Text;

namespace Models.People
{
    public class Moderator:Staff
    {
        public Moderator(
            string login,
            string name,
            DateTime birthDate,
            string email,
            DateTime startWorkDate,
            string education)
            : base(login, name, birthDate, email, startWorkDate, education)
        {
        }
        private void ResponseOnComment()
        {
            //Todo: Implement logic here
        }

        private void BanUser()
        {
            //Todo: Implement logic here
        }
    }
}
