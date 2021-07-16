using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Dto.FitnessProgram;
using Models.Interfaces;

namespace Services
{
    public class SetOfExercisesService
    {
        private readonly IRepository<ExerciseDto> _exerciseRepository;
        private readonly IRepository<SetOfExercisesDto> _setOfExercisesRepository;

        public SetOfExercisesService()
        {
            
        }
        public SetOfExercisesService(IRepository<ExerciseDto> exerciseRepository, IRepository<SetOfExercisesDto> setOfExercisesRepository)
        {
            _exerciseRepository = exerciseRepository;
            _setOfExercisesRepository = setOfExercisesRepository;
        }
        public virtual List<SetOfExercisesDto> GetAllSets()=> _setOfExercisesRepository.GetAll();
        public virtual SetOfExercisesDto GetSetById(int id) => _setOfExercisesRepository.GetById(id);

        public virtual void UpdateSet(SetOfExercisesDto setOfExercises) =>
            _setOfExercisesRepository.Update(setOfExercises);

        public virtual void DeleteSet(int id)
        {
            var setOfExercises = _setOfExercisesRepository.GetById(id);
            if (setOfExercises == null)
            {
                throw new ArgumentNullException(nameof(setOfExercises), $"Cannot find complex with id '{id}'");
            }

            foreach (var exercise in setOfExercises.Exercises.ToList())
            {
                _exerciseRepository.Remove(exercise.Id);
            }
            _setOfExercisesRepository.Remove(id);
        }

        public virtual SetOfExercisesDto CreateSet(SetOfExercisesDto setOfExercises) =>
            _setOfExercisesRepository.Create(setOfExercises);
    }
}
