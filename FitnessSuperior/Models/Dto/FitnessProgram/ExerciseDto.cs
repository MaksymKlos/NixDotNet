using Models.Interfaces;

namespace Models.Dto.FitnessProgram
{
    public class ExerciseDto:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroups { get; set; }

        public ExerciseDto(string name, string muscleGroups)
        {
            Name = name;
            MuscleGroups = muscleGroups;
        }
       
    }
}