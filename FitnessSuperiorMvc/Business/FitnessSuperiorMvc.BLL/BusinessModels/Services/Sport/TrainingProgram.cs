using System;
namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport
{
    /// <summary>
    /// Represents training programs.
    /// </summary>
    public class TrainingProgram : FitnessProgram
    {
        public override string Name { get; }
        public override string Description { get; }
        public override decimal Price { get; }
        public string Destination { get; set; }
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
        /// Create training program.
        /// </summary>
        /// <param name="programName">Program name.</param>
        /// <param name="programDescription">Program description.</param>
        /// <param name="destination"></param>
        /// <param name="typeOfProgram">Program type (muscle gain, weight loss).</param>
        /// <param name="requiredSkillLevel">Required skill level(professional, average, beginner).</param>
        /// <param name="ageRestriction">Age limit.</param>
        /// <param name="price"> Program price.</param>
        public TrainingProgram(string programName,
            string programDescription,
            string destination,
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
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new ArgumentException("Destination can't be empty or null.", nameof(destination));
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
            if (price > 0)
            {
                Price = price;
            }

            TypeOfProgram = typeOfProgram switch
            {
                "loss" => "Weight loss",
                "gain" => "Muscle gain",
                _ => TypeOfProgram
            };
            Destination = destination switch
            {
                "men" => "For men",
                "women" => "For women",
                "all" => "For all",
                _ => Destination
            };
            RequiredSkillLevel = requiredSkillLevel;
            AgeRestriction = ageRestriction;
            Name = programName;
            Description = programDescription;
        }
    }
}
