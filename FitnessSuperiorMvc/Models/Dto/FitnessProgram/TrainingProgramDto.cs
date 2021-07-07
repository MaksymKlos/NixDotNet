using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Dto.Person;

namespace Models.Dto.FitnessProgram
{
    public class TrainingProgramDto:FitnessProgramDto
    {
        [Key]
        [ForeignKey("TrainerDto")]
        public override int Id { get; set; }
        public TrainerDto Trainer { get; set; }
        public string TypeOfProgram { get; set; }
        public string RequiredSkillLevel { get; set; }
        public int? AgeRestriction { get; set; }
        public virtual ICollection<SetOfExercisesDto> SetsOfExercises { get; set; }
        private TrainingProgramDto() { }
        public TrainingProgramDto(
            string name,
            string description,
            decimal price,
            string destination, 
            string typeOfProgram,
            string requiredSkillLevel,
            int? ageRestriction,
            TrainerDto trainer
            ) :base(name, description, price, destination)
        {
            TypeOfProgram = typeOfProgram;
            RequiredSkillLevel = requiredSkillLevel;
            AgeRestriction = ageRestriction;
            Trainer = trainer;
        }
    }
}
