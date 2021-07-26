﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;
using FitnessSuperiorMvc.BLL.Interfaces;

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
        public virtual List<SetOfExercisesDto> GetAll()=> _setOfExercisesRepository.GetAll();
        public virtual SetOfExercisesDto GetById(int id) => _setOfExercisesRepository.GetById(id);

        public virtual void Update(SetOfExercisesDto setOfExercises) =>
            _setOfExercisesRepository.Update(setOfExercises);

        public virtual void Remove(int id)
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

        public virtual SetOfExercisesDto Create(SetOfExercisesDto setOfExercises) =>
            _setOfExercisesRepository.Create(setOfExercises);
    }
}
