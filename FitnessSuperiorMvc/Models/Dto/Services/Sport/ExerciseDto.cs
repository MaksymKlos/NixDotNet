using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.BLL.Dto.Services.Sport
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