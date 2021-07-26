using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.BLL.Dto.People
{
    public class PersonDto:IPersonDto
    {
        
        public int Id { get; set; }

        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }

        public string IdentityId { get; set; }

        public PersonDto() { }

    }
}
