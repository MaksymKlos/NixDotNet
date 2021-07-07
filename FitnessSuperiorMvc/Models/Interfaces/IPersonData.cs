namespace Models.Interfaces
{
    public interface IPersonData
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string SecondName { get; set; }
        public string Email { get; }
    }
}
