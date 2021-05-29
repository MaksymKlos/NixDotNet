using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Models.People;

namespace Models.Services
{
    public class TrainingProgram:FitnessProgram<Trainer>
    {
        #region Fields
        private ICollection<SetOfExercise> _setsOfExercises;
        #endregion

        #region Properties
        public int Id { get; set; }
        public override string ProgramName { get; }
        public override string ProgramDescription { get; }
        public override Trainer Specialist { get; }
        public string TypeOfProgram { get; }
        public string RequiredSkillLevel { get; }
        public int? AgeRestriction { get; }

        public ICollection<SetOfExercise> SetsOfExercises
        {
            get
            {
                if (_setsOfExercises != null)
                {
                    return _setsOfExercises;
                }

                throw new ArgumentNullException(nameof(_setsOfExercises), "Sets of exercises has not assigned a value");
            }
            set => _setsOfExercises=value?? throw new ArgumentNullException(nameof(value), "SetsOfExercises can't be null");
        }

        #endregion

        #region Constructors

        public TrainingProgram(string programName,
            string programDescription,
            Trainer specialist,
            string typeOfProgram,
            string requiredSkillLevel,
            int? ageRestriction,
            ICollection<SetOfExercise> setsOfExercises)
        {
            if (string.IsNullOrWhiteSpace(programName))
            {
                throw new ArgumentException("The name of program can't be empty or null.", nameof(programName));
            }  
            if (string.IsNullOrWhiteSpace(programDescription))
            {
                throw new ArgumentException("The description of program can't be empty or null.", nameof(programDescription));
            } 
            if (string.IsNullOrWhiteSpace(typeOfProgram))
            {
                throw new ArgumentException("The type of program can't be empty or null.", nameof(typeOfProgram));
            }
            if (string.IsNullOrWhiteSpace(requiredSkillLevel))
            {
                throw new ArgumentException("The required skill level can't be empty or null.", nameof(requiredSkillLevel));
            }
            Specialist = specialist ?? throw new ArgumentNullException(nameof(specialist), "Specialist can't be null");
            SetsOfExercises = setsOfExercises;
            TypeOfProgram = typeOfProgram;
            RequiredSkillLevel = requiredSkillLevel;
            AgeRestriction = ageRestriction;
            ProgramName = programName;
            ProgramDescription = programDescription;
           }

        #endregion

        #region Methods

        public override void GetInfoAboutProgram()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
