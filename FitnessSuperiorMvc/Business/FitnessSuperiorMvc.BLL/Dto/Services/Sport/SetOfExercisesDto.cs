using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.BLL.Dto.Services.Sport
{
    public sealed class SetOfExercisesDto:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public string Description { get; set; }
        public TrainerDto Author { get; set; }
        public ICollection<ExerciseDto> Exercises { get; set; }
        public SetOfExercisesDto() { }
    }
}
