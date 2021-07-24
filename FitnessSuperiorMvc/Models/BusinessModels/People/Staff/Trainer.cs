using System;
using System.Collections.Generic;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;

namespace FitnessSuperiorMvc.BLL.BusinessModels.People.Staff
{
    /// <summary>
    /// Represents trainers.
    /// </summary>
    public class Trainer:Staff
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
        public virtual List<TrainingProgramDto> TrainingPrograms { get; set; }
        /// <summary>
        /// Create trainer.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="secondName">User surname.</param>
        /// <param name="birthDate">User birth date.</param>
        public Trainer(string name, string secondName, DateTime birthDate) : base(name, secondName, birthDate)
        {
        }
    }
}
