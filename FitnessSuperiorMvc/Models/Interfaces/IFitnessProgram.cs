namespace Models.Interfaces
{
    public interface IFitnessProgram:IKey
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
    }
}