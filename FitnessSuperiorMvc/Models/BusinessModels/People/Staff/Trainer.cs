using System;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People.Staff
{
    public class Trainer:Staff
    {
        public string Specialization { get; set; }
        public string WorkWithGender { get; set; }


        public Trainer(string name, string secondName, DateTime birthDate) : base(name, secondName, birthDate)
        {
        }
    }
}
