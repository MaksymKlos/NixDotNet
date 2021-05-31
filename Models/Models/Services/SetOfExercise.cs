using System;
using System.Collections.Generic;

namespace Models.Services
{
    public class SetOfExercise
    {
        #region Fields

        private readonly List<Exercise> _exercises;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; }
        public string MuscleGroup { get; }
        public List<Exercise> Exercises => _exercises;
        #endregion

        #region Constructors

        public SetOfExercise(string name, string muscleGroup, List<Exercise> exercises)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can't be empty or null.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(muscleGroup))
            {
                throw new ArgumentException("Muscle group can't be empty or null.");
            }
            _exercises = exercises??throw new ArgumentNullException(nameof(exercises),"Exercises can't be null");
            Name = name;
            MuscleGroup = muscleGroup;
            
        }
        #endregion

        #region Methods
        internal void AddExercise(Exercise exercise)
        {
            if (exercise==null)
            {
                throw new ArgumentNullException(nameof(exercise), "Exercise can't be null");
            }
            _exercises.Add(exercise);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Exercises.Count; i++)
            {
                result += $"{_exercises[i]}\n";
            }

            return result;
        }

        #endregion
    }
}
