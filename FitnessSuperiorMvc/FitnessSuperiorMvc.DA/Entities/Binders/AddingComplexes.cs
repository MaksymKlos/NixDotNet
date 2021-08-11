using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;

namespace FitnessSuperiorMvc.DA.Entities.Binders
{
    public class AddingComplexes
    {
        public int AddingComplexesId { get; set; }
        public SetOfExercises SetOfExercisesDto { get; set; }
        public Trainer TrainerDto { get; set; }
        public int TrainerDtoId { get; set; }
    }
}
