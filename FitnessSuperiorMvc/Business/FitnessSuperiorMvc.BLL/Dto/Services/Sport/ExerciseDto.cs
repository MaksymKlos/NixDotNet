using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.BLL.Dto.Services.Sport
{
    public class ExerciseDto:IKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroups { get; set; }
        public string Description { get; set; }
        public string YoutubeUrl { get; set; }

        public ExerciseDto() {}
    }
}