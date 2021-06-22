
using System.Globalization;
using Models.Interfaces;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace Models.Dto.FitnessProgram
{
    [Table(Name = "Exercises")]
    public class ExerciseDto:IKey
    {
        [Column(IsPrimaryKey = true,IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string MuscleGroups { get; set; }

        public ExerciseDto()
        {
            
        }
        public ExerciseDto(string name, string muscleGroups)
        {
            Name = name;
            MuscleGroups = muscleGroups;
        }
       
    }
}