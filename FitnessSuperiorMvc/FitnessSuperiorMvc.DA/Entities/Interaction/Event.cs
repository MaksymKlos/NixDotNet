using System;
using FitnessSuperiorMvc.DA.Entities.Sport;

namespace FitnessSuperiorMvc.DA.Entities.Interaction
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public SetOfExercises SetOfExercises { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
