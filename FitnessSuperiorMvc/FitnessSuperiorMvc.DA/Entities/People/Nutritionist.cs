using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Entities.Interaction;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.People
{
    public class Nutritionist: IPerson, IStaff, IKey
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string SecondName { get; set; }
        public string Education { get; set; }
        public int WorkExperience { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
        public string AgeSpecialization { get; set; }
        public virtual ICollection<NutritionProgram> NutritionPrograms { get; set; }
    } 
}
