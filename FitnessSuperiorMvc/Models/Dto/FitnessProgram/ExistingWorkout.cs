using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Models.Dto.FitnessProgram
{
    public class ExistingWorkout
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TypeOfDiet { get; set; }
        public string Specialist { get; set; }
        public decimal Price { get; set; }
    }
}
