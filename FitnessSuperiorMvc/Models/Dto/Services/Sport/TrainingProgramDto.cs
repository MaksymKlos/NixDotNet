using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Community;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;

namespace FitnessSuperiorMvc.BLL.Dto.Services.Sport
{
    public class TrainingProgramDto:FitnessProgramDto
    {
        [Key]
        [ForeignKey("TrainerDto")]
        public override int Id { get; set; }
        public TrainerDto Trainer { get; set; }
        public string TypeOfProgram { get; set; }
        public string RequiredSkillLevel { get; set; }
        public int AgeRestriction { get; set; }
        public virtual ICollection<SetOfExercisesDto> SetsOfExercises { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
        private TrainingProgramDto() { }
        public TrainingProgramDto(
            string name,
            string description,
            decimal price,
            string destination, 
            string typeOfProgram,
            string requiredSkillLevel,
            int ageRestriction,
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
