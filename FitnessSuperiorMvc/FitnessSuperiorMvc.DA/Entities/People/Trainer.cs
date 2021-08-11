using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Entities.Binders;
using FitnessSuperiorMvc.DA.Entities.Interaction;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.People
{
    public class Trainer: IPerson, IStaff, IKey
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string SecondName { get; set; }
        public string Education { get; set; }
        public int WorkExperience { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
        public string Specialization { get; set; }
        public string WorkWithGender { get; set; }
        public ICollection<TrainingProgram> TrainingPrograms { get; set; }
        public ICollection<SetOfExercises> SetOfExercises { get; set; }
        public ICollection<AddingExercises> AddingExercises { get; set; }
        public ICollection<AddingComplexes> AddingComplexes { get; set; }

        public Trainer()
        {
            TrainingPrograms = new List<TrainingProgram>();
            SetOfExercises = new List<SetOfExercises>();
            AddingExercises = new List<AddingExercises>();
            AddingComplexes = new List<AddingComplexes>();
        }
    }
}
