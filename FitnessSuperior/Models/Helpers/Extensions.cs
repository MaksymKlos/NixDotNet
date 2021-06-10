using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Models.Business.People;
using Models.Business.Services;
using Models.Dto.FitnessProgram;
using Models.Dto.Person;
using Models.Interfaces;

namespace Models.Helpers
{
    public static class Extensions
    {
        public static UserDto ModelToDto(this Client user)
        {
            return new UserDto(
                user.Login,
                user.Name,
                user.Age,
                user.Email,
                user.Status)
            {
                PhoneNumber = user.PhoneNumber,
                SecondName = user.SecondName,
                TrainingPrograms = user.TrainingPrograms,

            };
        }
        public static TrainerDto ModelToDto(this Trainer trainer)
        {
            return new TrainerDto(
                trainer.Login,
                trainer.Name,
                trainer.Age,
                trainer.Email,
                trainer.Education,
                trainer.WorkExperience,
                trainer.Specialization,
                trainer.WorkWithGender);
            }

        public static NutritionistDto ModelToDto(this Nutritionist nutritionist)
        {
            return new NutritionistDto(
                nutritionist.Login,
                nutritionist.Name,
                nutritionist.Age,
                nutritionist.Email,
                nutritionist.Education,
                nutritionist.WorkExperience,
                nutritionist.AgeSpecialization,
                nutritionist.Options);
        }

        public static ExerciseDto ModelToDto(this Exercise exercise)
        {
            return new ExerciseDto(
                exercise.Name,
                exercise.MuscleGroups);
        }

        public static SetOfExercisesDto ModelToDto(this SetOfExercise setOfExercise)
        {
            ICollection<ExerciseDto> exercises = new List<ExerciseDto>();
            foreach (var exercise in setOfExercise.Exercises)
            {
                exercises.Add(exercise.ModelToDto());
            }

            return new SetOfExercisesDto(
                setOfExercise.Name,
                setOfExercise.MuscleGroup
            )
            {
                Exercises = exercises
            };

        }

        public static TrainingProgramDto ModelToDto(this TrainingProgram trainingProgram)
        {
            return new TrainingProgramDto(
                trainingProgram.Name,
                trainingProgram.RequiredSkillLevel,
                trainingProgram.AgeRestriction
            );
        }
    }
}
