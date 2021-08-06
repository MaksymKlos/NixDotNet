
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;

namespace FitnessSuperiorMvc.DA.Entities.Bridging
{
    public class AddingExercises
    {
        public int AddingExercisesId { get; set; }
        public Exercise ExerciseDto { get; set; }
        public Trainer TrainerDto { get; set; }
        public int TrainerDtoId { get; set; }
    }
}
