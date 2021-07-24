using System;
using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Community;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;

namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport
{
    /// <summary>
    /// Represents training programs.
    /// </summary>
    public class TrainingProgram : FitnessProgram
    {
        public override string ProgramName { get; }
        public override string ProgramDescription { get; }
        public override decimal Price { get; }
        public override List<Feedback> Feedback { get; set; } = new List<Feedback>();

        /// <summary>
        /// Program trainer.
        /// </summary>
        public TrainerDto Trainer { get; }
        /// <summary>
        /// Program type (muscle gain, weight loss).
        /// </summary>
        public string TypeOfProgram { get; }
        /// <summary>
        /// Required skill level(professional, average, beginner).
        /// </summary>
        public string RequiredSkillLevel { get; }
        /// <summary>
        /// Age limit.
        /// </summary>
        public int AgeRestriction { get; }
        /// <summary>
        /// The sets of exercises that make up the program.
        /// </summary>
        public List<SetOfExercises> SetsOfExercises { get; set; } = new List<SetOfExercises>();

        /// <summary>
        /// Create training program.
        /// </summary>
        /// <param name="programName">Program name.</param>
        /// <param name="programDescription">Program description.</param>
        /// <param name="trainer">Program trainer.</param>
        /// <param name="typeOfProgram">Program type (muscle gain, weight loss).</param>
        /// <param name="requiredSkillLevel">Required skill level(professional, average, beginner).</param>
        /// <param name="ageRestriction">Age limit.</param>
        /// <param name="price"> Program price.</param>
        public TrainingProgram(string programName,
            string programDescription,
            TrainerDto trainer,
            string typeOfProgram,
            string requiredSkillLevel,
            int ageRestriction,
            decimal price)
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
            Trainer = trainer ?? throw new ArgumentNullException(nameof(trainer), "Trainer can't be null");
            if (price > 0)
            {
                Price = price;
            }
            TypeOfProgram = typeOfProgram;
            RequiredSkillLevel = requiredSkillLevel;
            AgeRestriction = ageRestriction;
            ProgramName = programName;
            ProgramDescription = programDescription;
        }
    }
}
