using System;
using System.Collections.Generic;
using System.Text;
using FitnessSuperiorMvc.BLL.BusinessModels.People.Staff;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Community;


namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Nutrition
{
    public class NutritionProgram:FitnessProgram
    {
        public override string Name { get; }
        public override string Description { get; }
        public override decimal Price { get; }
        public string Destination { get; set; }
        /// <summary>
        /// Program type (muscle gain, weight loss).
        /// </summary>
        public string TypeOfDiet { get; set; }

        /// <summary>
        /// Create training program.
        /// </summary>
        /// <param name="programName">Program name.</param>
        /// <param name="programDescription">Program description.</param>
        /// <param name="typeOfDiet">Program type (muscle gain, weight loss).</param>
        /// <param name="destination"></param>
        /// <param name="price"> Program price.</param>
        public NutritionProgram(string programName, string programDescription, string destination, decimal price,string typeOfDiet)
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
                throw new ArgumentException("The destination can't be empty or null.", nameof(destination));
            }
            if (string.IsNullOrWhiteSpace(typeOfDiet))
            {
                throw new ArgumentException("The type of diet can't be empty or null.", nameof(typeOfDiet));
            }
            if (price < 0)
            {
                throw new ArgumentException("Price can't be less than 0.", nameof(price));
            }
            
            if (price > 0)
            {
                Price = price;
            }
            TypeOfDiet = typeOfDiet switch
            {
                "loss" => "Weight loss",
                "gain" => "Muscle gain",
                _ => typeOfDiet
            };
            Destination = destination switch
            {
                "men" => "For men",
                "women" => "For women",
                "all" => "For all",
                _ => Destination
            };
            Name = programName;
            Description = programDescription;
        }
    }
}
