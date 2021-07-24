using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;

namespace FitnessSuperiorMvc.BLL.Dto.People.Staff
{
    public class TrainerDto:PersonDto
    {
        public string Education { get; set; }
        public int WorkExperience { get; set; }
        public string Specialization { get; set; }
        public string WorkWithGender { get; set; }
        public virtual ICollection<TrainingProgramDto> TrainingPrograms { get; set; } = new List<TrainingProgramDto>();


        public TrainerDto() { }
    }
}
