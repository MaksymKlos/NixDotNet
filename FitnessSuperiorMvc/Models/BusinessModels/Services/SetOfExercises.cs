using System;
using System.Collections.Generic;
using System.Linq;
using Models.Dto.FitnessProgram;

namespace Models.BusinessModels.Services
{
    /// <summary>
    /// Complex of exercises for one day.
    /// </summary>
    public class SetOfExercises
    {
        #region Properties
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
        #endregion

        #region Constructors
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
        #endregion

        #region Methods

        public static implicit operator SetOfExercisesDto(SetOfExercises exercise)
        {
            return new SetOfExercisesDto(exercise.Name, exercise.MuscleGroups);
        }


        #endregion
    }
}
