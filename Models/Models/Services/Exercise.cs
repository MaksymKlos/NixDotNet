using System;

namespace Models.Services
{
    public class Exercise
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; }
        public string MuscleGroups { get; }

        #endregion

        #region Constructors
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
    }
}
