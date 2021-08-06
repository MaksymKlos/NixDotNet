using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.Sport
{
    public class TrainingProgram:IProgram, IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
        public string TypeOfProgram { get; set; }
        public string RequiredSkillLevel { get; set; }
        public int AgeRestriction { get; set; }

        public virtual ICollection<SetOfExercises> SetsOfExercises { get; set; }
        public Trainer Trainer { get; set; }
    }
}
