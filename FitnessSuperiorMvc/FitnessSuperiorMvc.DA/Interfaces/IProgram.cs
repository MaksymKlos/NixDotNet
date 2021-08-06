namespace FitnessSuperiorMvc.DA.Interfaces
{
    internal interface IProgram
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
    }
}
