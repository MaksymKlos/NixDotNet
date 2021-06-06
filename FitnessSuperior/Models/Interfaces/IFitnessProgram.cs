namespace Models.Interfaces
{
    public interface IFitnessProgram<T>:IKey
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public T Specialist { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
    }
}