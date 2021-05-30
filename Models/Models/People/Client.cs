using System;
using System.Collections.Generic;
using System.Text;
using Models.Services;

namespace Models.People
{
    public class Client:Person
    {
        #region Properties
        public decimal Balance { get; set; }
        public virtual ICollection<TrainingProgram> TrainingPrograms { get; set; }
        public virtual ICollection<NutritionProgram> NutritionPrograms { get; set; }
        private protected virtual string Status { get;}
        #endregion

        #region Constructors
        public Client(
            string login,
            string name,
            DateTime birthDate,
            string email)
            : base(login, name, birthDate, email)
        {

        }
        #endregion
    }
}
