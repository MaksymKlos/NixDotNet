namespace FitnessSuperiorMvc.BLL.Interfaces
{
    public interface IPersonDto : IKey
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
    }
}