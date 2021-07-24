using System;
using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;

namespace FitnessSuperiorMvc.BLL.BusinessModels.Services
{
    public class TrainingProgram : FitnessProgram
    {
        #region Fields
        private List<SetOfExercises> _setsOfExercises;
        #endregion

        #region Properties
        public int Id { get; set; }
        public override string ProgramName { get; }
        public override string ProgramDescription { get; }
        public TrainerDto Specialist { get; }
        public override decimal Price { get; } = 0;
        public override string Destination { get; } = "General";
        public string TypeOfProgram { get; }
        public string RequiredSkillLevel { get; }
        public int? AgeRestriction { get; }


        public List<SetOfExercises> SetsOfExercises
        {
            get
            {
                if (_setsOfExercises != null)
                {
                    return _setsOfExercises;
                }

                throw new ArgumentNullException(nameof(_setsOfExercises), "Sets of exercises has not assigned a value");
            }
            set => _setsOfExercises = value ?? throw new ArgumentNullException(nameof(value), "SetsOfExercises can't be null");
        }

        #endregion

        #region Constructors

        public TrainingProgram(string programName,
            string programDescription,
            TrainerDto specialist,
            string typeOfProgram,
            string requiredSkillLevel,
            int? ageRestriction,
            List<SetOfExercises> setsOfExercises)
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
        public TrainingProgram(string programName,
            string programDescription,
            TrainerDto specialist,
            string typeOfProgram,
            string requiredSkillLevel,
            int? ageRestriction,
            List<SetOfExercises> setsOfExercises,
            decimal price)
        : this(programName, programDescription, specialist, typeOfProgram, requiredSkillLevel, ageRestriction, setsOfExercises)
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

            if (price < 0)
            {
                throw new ArgumentException("Price can't be less than 0.", nameof(price));
            }
            Specialist = specialist ?? throw new ArgumentNullException(nameof(specialist), "Specialist can't be null");
            if (price > 0)
            {
                Price = price;
                Destination = "Personal";
            }
            SetsOfExercises = setsOfExercises;
            TypeOfProgram = typeOfProgram;
            RequiredSkillLevel = requiredSkillLevel;
            AgeRestriction = ageRestriction;
            ProgramName = programName;
            ProgramDescription = programDescription;
        }
        #endregion

        #region Methods
        public static implicit operator TrainingProgramDto(TrainingProgram program)
        {
            return new TrainingProgramDto(program.ProgramName,program.ProgramDescription,program.Price,program.Destination,program.TypeOfProgram,program.RequiredSkillLevel,program.AgeRestriction,program.Specialist);
        }
        #endregion

    }
}
