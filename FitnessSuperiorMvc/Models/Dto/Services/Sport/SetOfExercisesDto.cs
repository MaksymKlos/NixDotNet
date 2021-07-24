using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.BLL.Dto.Services.Sport
{
    public sealed class SetOfExercisesDto:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public ICollection<ExerciseDto> Exercises { get; set; }
        public SetOfExercisesDto() { }
        public SetOfExercisesDto(string name, string muscleGroup)
        {
            Name = name;
            MuscleGroup = muscleGroup;
        }
        public void AddItem(ExerciseDto exercise)
        {
            var ex = Exercises.FirstOrDefault(e => e.Id == exercise.Id);
            if (ex == null)
            {
                Exercises.Add(exercise);
            }
        }
    }
}
