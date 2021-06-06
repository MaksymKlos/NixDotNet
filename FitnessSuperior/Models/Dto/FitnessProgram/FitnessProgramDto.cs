using Models.Dto.Person;
using Models.Interfaces;

namespace Models.Dto.FitnessProgram
{
    public class FitnessProgramDto<T>:IFitnessProgram<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public T Specialist { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }

    }
}
