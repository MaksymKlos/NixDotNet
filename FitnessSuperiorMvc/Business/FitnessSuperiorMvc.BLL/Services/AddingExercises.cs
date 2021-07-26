using System;
using System.Collections.Generic;
using System.Text;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;

namespace FitnessSuperiorMvc.BLL.Services
{
    public class AddingExercises
    {
        public int AddingExercisesId { get; set; }
        public ExerciseDto ExerciseDto { get; set; }
        public TrainerDto TrainerDto { get; set; }
        public int TrainerDtoId { get; set; }
    }
}
