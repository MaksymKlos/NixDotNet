using System;
using System.Collections.Generic;
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
    }
}
