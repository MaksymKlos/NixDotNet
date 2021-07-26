using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;

namespace FitnessSuperiorMvc.BLL.Services
{
    public class AddingComplexes
    {
        public int AddingComplexesId { get; set; }
        public SetOfExercisesDto SetOfExercisesDto { get; set; }
        public TrainerDto TrainerDto { get; set; }
        public int TrainerDtoId { get; set; }
    }
}
