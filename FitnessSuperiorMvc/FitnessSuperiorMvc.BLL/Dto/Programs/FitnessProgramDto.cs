using System;

namespace FitnessSuperiorMvc.BLL.Dto.Programs
{
    /// <summary>
    /// Represent all programs.
    /// </summary>
    public class FitnessProgramDto
    {
        /// <summary>
        /// Program name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Program description.
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Program price.
        /// </summary>
        public decimal Price { get; }
        /// <summary>
        /// Program destination.
        /// </summary>
        public string Destination { get; set; }

        public FitnessProgramDto(string name, string description, string destination, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name of program can't be empty or null.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("The description of program can't be empty or null.", nameof(description));
            }
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new ArgumentException("The destination can't be empty or null.", nameof(destination));
            }
            if (price < 0)
            {
                throw new ArgumentException("Price can't be less than 0.", nameof(price));
            }
            Name = name;
            Description = description;
            Price = price;
            Destination = destination switch
            {
                "men" => "For men",
                "women" => "For women",
                "all" => "For all",
                _ => Destination
            };
        }
    }
}
