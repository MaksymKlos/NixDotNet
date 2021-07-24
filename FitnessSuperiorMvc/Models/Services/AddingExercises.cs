using System;
using System.Collections.Generic;
using System.Text;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;

namespace FitnessSuperiorMvc.BLL.Services
{
    public class AddingExercises
    {
        public int AddingExercisesId { get; set; }
        public virtual ICollection<ExerciseDto> Exercises { get; set; }

    }
}
