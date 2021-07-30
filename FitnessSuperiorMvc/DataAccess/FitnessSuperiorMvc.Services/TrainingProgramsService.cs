using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.Services
{
    public class TrainingProgramsService
    {
        private readonly IRepository<TrainingProgramDto> _trainingProgramRepository;
        private readonly IRepository<SetOfExercisesDto> _setOfExercisesRepository;

        public TrainingProgramsService() {}
        public TrainingProgramsService(IRepository<TrainingProgramDto> trainingProgramRepository, IRepository<SetOfExercisesDto> setOfExercisesRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
            _setOfExercisesRepository = setOfExercisesRepository;
        }
        public virtual List<TrainingProgramDto> GetAll()
        {
            var programs = _trainingProgramRepository
                .GetAll()
                .GroupBy(n => n.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return programs;
        }
        public virtual TrainingProgramDto GetById(int id) => _trainingProgramRepository.GetById(id);

        public virtual void Update(TrainingProgramDto trainingProgram) =>
            _trainingProgramRepository.Update(trainingProgram);

        public virtual void Remove(int id)
        {
            var trainingProgram = _trainingProgramRepository.GetById(id);
            if (trainingProgram == null)
            {
                throw new ArgumentNullException(nameof(trainingProgram), $"Cannot find program with id '{id}'");
            }

            foreach (var complex in trainingProgram.SetsOfExercises.ToList())
            {
                _setOfExercisesRepository.Remove(complex.Id);
            }
            _trainingProgramRepository.Remove(id);
        }

        public virtual TrainingProgramDto Create(TrainingProgramDto trainingProgram) =>
            _trainingProgramRepository.Create(trainingProgram);
    }
}

