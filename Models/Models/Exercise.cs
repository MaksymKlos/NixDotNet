using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public string Description { get; set; }

        public Exercise(string name, string muscleGroup, string description)
        {
            Name = name;
            MuscleGroup = muscleGroup;
            Description = description;
        }
    }
}
