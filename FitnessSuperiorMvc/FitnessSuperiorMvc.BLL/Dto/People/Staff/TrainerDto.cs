using System;
using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.Dto.Programs.Sport;

namespace FitnessSuperiorMvc.BLL.Dto.People.Staff
{
    /// <summary>
    /// Represents trainers.
    /// </summary>  
    public class TrainerDto:PersonDto
    {
        /// <summary>
        /// Trainer specialization (swimming, fitness, box, etc.).
        /// </summary>
        public string Specialization { get; set; }
        /// <summary>
        /// The gender on which trainer specialized(man,woman,both,etc.).
        /// </summary>
        public string WorkWithGender { get; set; }

        /// <summary>
        /// Programs created by this trainer.
        /// </summary>
        public virtual ICollection<TrainingProgramDto> TrainingPrograms { get; set; } = new List<TrainingProgramDto>();
        /// <summary>
        /// Create trainer.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="secondName">User surname.</param>
        /// <param name="birthDate">User birth date.</param>
        public TrainerDto(string name, string secondName, DateTime birthDate) : base(name, secondName, birthDate)
        {
        }
    }
}
