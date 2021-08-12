using System;
using System.Collections.Generic;

namespace FitnessSuperiorMvc.BLL.Dto.Programs.Sport
{
    public class TrainingProgramDto:FitnessProgramDto
    {
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

        public TrainingProgramDto(string name, string description, string destination, decimal price, string typeOfProgram, string requiredSkillLevel, int ageRestriction) : base(name, description, destination,price)
        {
            if (string.IsNullOrWhiteSpace(typeOfProgram))
            {
                throw new ArgumentException("The type of program can't be empty or null.", nameof(typeOfProgram));
            }
            if (string.IsNullOrWhiteSpace(requiredSkillLevel))
            {
                throw new ArgumentException("The required skill level can't be empty or null.", nameof(requiredSkillLevel));
            }
            TypeOfProgram = typeOfProgram switch
            {
                "loss" => "Weight loss",
                "gain" => "Muscle gain",
                _ => TypeOfProgram
            };
            RequiredSkillLevel = requiredSkillLevel;
            AgeRestriction = ageRestriction;
        }
    }
}
