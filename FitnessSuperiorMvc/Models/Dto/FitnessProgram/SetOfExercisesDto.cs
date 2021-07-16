using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Interfaces;

namespace Models.Dto.FitnessProgram
{
    public sealed class SetOfExercisesDto:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public ICollection<ExerciseDto> Exercises { get; set; }

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
