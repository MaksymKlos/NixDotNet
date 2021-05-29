using System;
using System.Collections.Generic;
using System.Text;

namespace Models.People
{
    public class Nutritionist:Staff
    {
        #region Properties

        public string TypeOfDiet { get; }



        #endregion
        #region Constructors

        #endregion
        public Nutritionist(string login, string name, DateTime birthDate, string email, DateTime startWorkDate, string education) : base(login, name, birthDate, email, startWorkDate, education)
        {
        }

        #region Methods

        

        #endregion
    }
}
