using System;
using System.Collections.Generic;


namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport
{
    /// <summary>
    /// Complex of exercises for one day.
    /// </summary>
    public class SetOfExercises
    {
        /// <summary>
        /// Complex name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Muscle group that are used during the complex.
        /// </summary>
        public string MuscleGroups { get; }
        /// <summary>
        /// Complex description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Complex creation.
        /// </summary>
        /// <param name="name">Complex name.</param>
        /// <param name="muscleGroups"> Muscle group that are used during the complex.</param>
        /// <param name="exercises">Exercises included in the complex.</param>
        public SetOfExercises(string name, string muscleGroups, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(muscleGroups))
            {
                throw new ArgumentException("Muscle groups can't be empty or null.");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description can't be empty or null.");
            }
            Name = name;
            MuscleGroups = muscleGroups;
            Description = description;
        }

    }
}
