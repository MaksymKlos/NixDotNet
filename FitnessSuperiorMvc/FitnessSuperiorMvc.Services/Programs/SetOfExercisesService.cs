using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.BusinessModels;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class SetOfExercisesService
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly IRepository<SetOfExercises> _setOfExercisesRepository;

        public SetOfExercisesService() {}
        public SetOfExercisesService(IRepository<Exercise> exerciseRepository, IRepository<SetOfExercises> setOfExercisesRepository)
        {
            _exerciseRepository = exerciseRepository;
            _setOfExercisesRepository = setOfExercisesRepository;
        }

        public virtual List<SetOfExercises> GetAll() => _setOfExercisesRepository.GetAll().OrderBy(s => s.Id).ToList();
        public virtual SetOfExercises GetById(int id, FitnessAppContext context)
        {
            var binder = new Binder(context);
            var complex = _setOfExercisesRepository.GetById(id);
            complex.Exercises = binder.GetExercisesFromComplex(id);
            complex.Author = binder.GetTrainerOfComplex(id);
            return complex;
        }
        public virtual List<SetOfExercises> GetAddingComplexes(Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            var complexes = controller.GetComplexes(user);
            return complexes;
        }
        public virtual void AddAddingComplexes(SetOfExercises complex, Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.AddAddingComplexes(complex, user);
        }
        public virtual void DeleteAddingComplexes(Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.DeleteComplex(user);
        }

        public virtual void RemoveAddingComplexes(int id, Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.RemoveAddingComplexes(id, user);
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
