using System;
using System.Collections.Generic;
using System.Linq;
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
        public virtual List<Exercise> GetAll()
        {
            var exercises = _exerciseRepository
                .GetAll()
                .GroupBy(e => e.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return exercises;
        }

        public virtual Exercise GetById(int id) => _exerciseRepository.GetById(id);
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
