using Models.Dto.Person;
using Models.Interfaces;

namespace Models.Dto.FitnessProgram
{
    public class FitnessProgramDto:IFitnessProgram
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
        protected FitnessProgramDto() { }
        public FitnessProgramDto(string name, string description, decimal price, string destination)
        {
            Name = name;
            Description = description;
            Price = price;
            Destination = destination;
        }

    }
}
