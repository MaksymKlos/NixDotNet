using System.Collections;
using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.Sport
{
    public class SetOfExercises:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroups { get; set; }
        public string Description { get; set; }
        public Trainer Author { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<TrainingProgram> TrainingProgram { get; set; }

        public SetOfExercises()
        {
            Exercises = new List<Exercise>();
            TrainingProgram = new List<TrainingProgram>();
        }

    }
}
