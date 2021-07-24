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
        /// Exercises included in the complex.
        /// </summary>
        public List<Exercise> Exercises { get; }

        /// <summary>
        /// Complex creation.
        /// </summary>
        /// <param name="name">Complex name.</param>
        /// <param name="muscleGroups"> Muscle group that are used during the complex.</param>
        /// <param name="exercises">Exercises included in the complex.</param>
        public SetOfExercises(string name, string muscleGroups, List<Exercise> exercises)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(muscleGroups))
            {
                throw new ArgumentException("Muscle groups can't be empty or null.");
            }
            Exercises = exercises ?? throw new ArgumentNullException(nameof(exercises), "Exercises can't be null");
            Name = name;
            MuscleGroups = muscleGroups;
        }

    }
}
