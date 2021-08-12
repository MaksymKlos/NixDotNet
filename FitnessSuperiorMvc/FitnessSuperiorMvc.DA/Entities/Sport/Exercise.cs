using System;
using System.Collections.Generic;
using System.Text;
using FitnessSuperiorMvc.DA.Interfaces;


namespace FitnessSuperiorMvc.DA.Entities.Sport
{
    public class Exercise : IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroups { get; set; }
        public string Description { get; set; }
        public string YoutubeUrl { get; set; }
        public ICollection<SetOfExercises> SetOfExercises { get; set; }

        public Exercise()
        {
            SetOfExercises = new List<SetOfExercises>();
        }

        public Exercise(string name, string muscleGroups, string description)
        {
            Name = name;
            MuscleGroups = muscleGroups;
            Description = description;
        }
    }
}
