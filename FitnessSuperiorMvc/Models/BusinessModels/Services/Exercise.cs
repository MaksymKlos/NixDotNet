using System;
using Models.Dto.FitnessProgram;

namespace Models.BusinessModels.Services
{
    public class Exercise
    {
        #region Properties
        /// <summary>
        /// The name of the exercise.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Muscles that are used during the exercise.
        /// </summary>
        public string MuscleGroups { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Exercise creation.
        /// </summary>
        /// <param name="name">The name of the exercise.</param>
        /// <param name="muscleGroups">Muscles that are used during the exercise.</param>
        public Exercise(string name, string muscleGroups)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(muscleGroups))
            {
                throw new ArgumentException("Muscle groups can't be empty or null.");
            }
            Name = name;
            MuscleGroups = muscleGroups;
        }
        #endregion
        public static implicit operator ExerciseDto(Exercise exercise)
        {
            return new ExerciseDto(exercise.Name, exercise.MuscleGroups);
        }
    }
}
