using System;
using System.Collections.Generic;
using Models.Business.Services;

namespace Models.Business.People
{
    public class Client:Person
    {
        #region Properties
        public decimal Balance { get; set; }
        public ICollection<TrainingProgram> TrainingPrograms { get; set; }
        public ICollection<NutritionProgram> NutritionPrograms { get; set; }
        public virtual string Status { get; }
        #endregion

        #region Constructors

        public Client()
        {
            
        }
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
