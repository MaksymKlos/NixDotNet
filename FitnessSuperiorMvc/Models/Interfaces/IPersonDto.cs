namespace Models.Interfaces
{
    public interface IPersonDto : IKey
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}