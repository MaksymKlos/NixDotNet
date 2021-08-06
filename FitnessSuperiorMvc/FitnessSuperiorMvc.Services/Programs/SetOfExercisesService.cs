using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.BusinessModels;
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
        public virtual List<SetOfExercises> GetAll()
        {
            var complexes = _setOfExercisesRepository
                .GetAll()
                .GroupBy(n => n.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return complexes;
        }

        public virtual List<Exercise> GetAddingExercises(Trainer user)
        {
            AddingController controller = new AddingController();
            var exercises = controller.GetExercises(user);
            return exercises;
        }

        public virtual void DeleteAddingExercises(Trainer user)
        {
            AddingController controller = new AddingController();
            controller.DeleteExercises(user);
        }

        public virtual SetOfExercises GetById(int id)
        {
            var binder = new Binder();
            var complex = _setOfExercisesRepository.GetById(id);
            complex.Exercises = binder.GetExercisesFromComplex(id);
            complex.Author = binder.GetTrainerOfComplex(id);
            return complex;
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
