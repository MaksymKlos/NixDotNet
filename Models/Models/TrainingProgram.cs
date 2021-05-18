using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainingProgram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual List<Exercise> Exercises { get; set; }

        public TrainingProgram(string name, string type, string description, List<Exercise> exercises)
        {
            Name = name;
            Type = type;
            Description = description;
            Exercises = exercises;
        }

    }
}
