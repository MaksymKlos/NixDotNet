﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Services
{
    public class SetOfExercise
    {
        #region Fields

        private readonly ICollection<Exercise> _exercises;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; }
        public string MuscleGroup { get; }
        public ICollection<Exercise> Exercises => _exercises;
        #endregion

        #region Constructors

        public SetOfExercise(string name, string muscleGroup, ICollection<Exercise> exercises)
        {
            _exercises = new List<Exercise>();
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
        #endregion
    }
}
