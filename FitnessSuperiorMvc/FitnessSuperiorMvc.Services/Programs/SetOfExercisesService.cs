using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class SetOfExercisesService
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly IRepository<SetOfExercises> _setOfExercisesRepository;
       
        private readonly IStaffRepository _staffRepository;
        private readonly IFitnessServicesRepository _fitnessServicesRepository;

        public SetOfExercisesService()
        {
        }
        public SetOfExercisesService(
            IRepository<Exercise> exerciseRepository,
            IRepository<SetOfExercises> setOfExercisesRepository,
            IStaffRepository staffRepository,
            IFitnessServicesRepository fitnessServicesRepository)
        {
            _exerciseRepository = exerciseRepository;
            _setOfExercisesRepository = setOfExercisesRepository;
            _staffRepository = staffRepository;
            _fitnessServicesRepository = fitnessServicesRepository;
        }

        public virtual List<SetOfExercises> GetAll() => _setOfExercisesRepository.GetAll().OrderBy(s => s.Id).ToList();
        public virtual SetOfExercises GetById(int id)
        {
            var complex = _setOfExercisesRepository.GetById(id);
            complex.Exercises = _fitnessServicesRepository.GetExercisesFromComplex(id);
            complex.Author = _fitnessServicesRepository.GetTrainerOfComplex(id);
            return complex;
        }
        public virtual List<SetOfExercises> GetAddingComplexes(Trainer user)=>
             _staffRepository.GetComplexes(user);
        
        public virtual void AddAddingComplexes(SetOfExercises complex, Trainer user)
        {
            _staffRepository.AddAddingComplexes(complex, user);
        }
        public virtual void DeleteAddingComplexes(Trainer user)
        {
            _staffRepository.DeleteComplex(user);
        }

        public virtual void RemoveAddingComplexes(int id, Trainer user)
        {
            _staffRepository.RemoveAddingComplexes(id, user);
        }
        public virtual void Update(SetOfExercises setOfExercises) =>
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

        public virtual SetOfExercises Create(SetOfExercises setOfExercises) =>
            _setOfExercisesRepository.Create(setOfExercises);

    }
}
