using System;
using System.Collections.Generic;
using System.Text;
using Models.Dto.FitnessProgram;
using Models.Interfaces;

namespace Services
{
    public class ExerciseService
    {
        private readonly IRepository<ExerciseDto> _exerciseRepository;

        public ExerciseService()
        {
            
        }
        public ExerciseService(IRepository<ExerciseDto> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public virtual List<ExerciseDto> GetAllExercises() => _exerciseRepository.GetAll();
        public virtual ExerciseDto GetExerciseById(int id) => _exerciseRepository.GetById(id);
        public virtual void UpdateExercise(ExerciseDto exercise) => _exerciseRepository.Update(exercise);

        public virtual void DeleteExercise(int id)
        {
            var exercise = _exerciseRepository.GetById(id);
            if (exercise == null)
            {
                throw new ArgumentNullException(nameof(exercise),$"Cannot find student with id '{id}'");
            }
            _exerciseRepository.Remove(id);
        }

        public virtual ExerciseDto CreateExercise(ExerciseDto exercise) => _exerciseRepository.Create(exercise);
    }
}
