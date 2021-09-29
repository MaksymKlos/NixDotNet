using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class ExerciseService
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly IStaffRepository _staffRepository;
        public ExerciseService() {}
        public ExerciseService(
            IRepository<Exercise> exerciseRepository,
            IStaffRepository staffRepository)
        {
            _exerciseRepository = exerciseRepository;
            _staffRepository = staffRepository;
        }

        public virtual List<Exercise> GetAll() =>
            _exerciseRepository.GetAll().OrderBy(s=>s.Id).ToList();

        public virtual Exercise GetById(int id) =>
            _exerciseRepository.GetById(id);

        public virtual List<Exercise> GetAddingExercises(Trainer user)
            => _staffRepository.GetExercises(user);

        public virtual void AddAddingExercises(Exercise exercise, Trainer user)
        { 
            _staffRepository.AddAddingExercises(exercise, user);
        }
        public virtual void DeleteAddingExercises(Trainer user)
        {
            _staffRepository.DeleteExercises(user);
        }
       
        public virtual void RemoveAddingExercises(int id, Trainer user)
        {
            _staffRepository.RemoveAddingExercises(id,user);
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
