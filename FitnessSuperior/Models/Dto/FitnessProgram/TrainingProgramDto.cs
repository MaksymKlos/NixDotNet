using System;
using System.Collections.Generic;
using System.Text;
using Models.Dto.Person;

namespace Models.Dto.FitnessProgram
{
    public class TrainingProgramDto:FitnessProgramDto<TrainerDto>
    {
        public string TypeOfProgram { get; set; }
        public string RequiredSkillLevel { get; set; }
        public int? AgeRestriction { get; set; }
        public virtual ICollection<SetOfExercisesDto> SetsOfExercises { get; set; }

        public TrainingProgramDto(string typeOfProgram, string requiredSkillLevel, int? ageRestriction)
        {
            TypeOfProgram = typeOfProgram;
            RequiredSkillLevel = requiredSkillLevel;
            AgeRestriction = ageRestriction;
        }
    }
}
