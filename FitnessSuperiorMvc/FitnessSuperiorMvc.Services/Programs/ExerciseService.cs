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
    public class ExerciseService
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        public ExerciseService() {}
        public ExerciseService(IRepository<Exercise> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public virtual List<Exercise> GetAll() => _exerciseRepository.GetAll().OrderBy(s=>s.Id).ToList();

        public virtual Exercise GetById(int id) => _exerciseRepository.GetById(id);

        public virtual List<Exercise> GetAddingExercises(Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            var exercises = controller.GetExercises(user);
            return exercises;
        }
        public virtual void AddAddingExercises(Exercise exercise, Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.AddAddingExercises(exercise, user);
        }
        public virtual void DeleteAddingExercises(Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.DeleteExercises(user);
        }
       
        public virtual void RemoveAddingExercises(int id, Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.RemoveAddingExercises(id,user);
        }
        public virtual void Update(Exercise exercise) => _exerciseRepository.Update(exercise);

        public virtual void Remove(int id)
        {
            var exercise = _exerciseRepository.GetById(id);
            if (exercise == null)
            {
                throw new ArgumentNullException(nameof(exercise), $"Cannot find exercise with id '{id}'");
            }
            _exerciseRepository.Remove(id);
        }

        public virtual Exercise Create(Exercise exercise) => _exerciseRepository.Create(exercise);
    }
}
