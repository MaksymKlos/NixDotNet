using System;
using System.Collections.Generic;
using Models.Services;

namespace Models.People
{
    public class Trainer:Staff
    {
        #region Properties
        /// <summary>
        /// Trainer specialization (swimming, fitness, box, etc.).
        /// </summary>
        public string Specialization { get; }
        /// <summary>
        /// The gender on which trainer specialized(man,woman,both,etc.).
        /// </summary>
        public string WorkWithGender { get; }
        #endregion
        #region Constructors
        public Trainer(string login,
            string name,
            DateTime birthDate,
            string email,
            DateTime startWorkDate,
            string education,
            string specialization,
            string workWithGender)
            : base(login, name, birthDate, email, startWorkDate, education)
        {
            if (string.IsNullOrWhiteSpace(specialization))
            {
                throw new ArgumentException("Specialization can't be empty or null.", nameof(specialization));
            }
            if (string.IsNullOrWhiteSpace(workWithGender))
            {
                throw new ArgumentException("Work with gender can't be empty or null.", nameof(workWithGender));
            }
            Specialization = specialization;
            WorkWithGender = workWithGender;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create new training program from this trainer.
        /// </summary>
        /// <param name="programName">The name of program</param>
        /// <param name="programDescription">The description of the program</param>
        /// <param name="typeOfProgram">The type of program</param>
        /// <param name="requiredSkillLevel">Skill level that you need to have</param>
        /// <param name="ageRestriction">The age restriction</param>
        /// <param name="setOfExercises">The sets of exercises that program is containing</param>
        /// <returns>new Training program</returns>
        public TrainingProgram CreateTrainingProgram(string programName,
            string programDescription,string typeOfProgram,
            string requiredSkillLevel, int? ageRestriction,
            ICollection<SetOfExercise> setOfExercises) => 
                new TrainingProgram(programName, programDescription, this,
                typeOfProgram,requiredSkillLevel,ageRestriction,setOfExercises);
        public SetOfExercise CreateSetOfExercise()
        {
            return null;
        }
        #endregion


    }
}
