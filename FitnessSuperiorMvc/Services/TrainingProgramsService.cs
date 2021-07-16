using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Dto.FitnessProgram;
using Models.Dto.Person;
using Models.Interfaces;

namespace Services
{
    public class TrainingProgramsService
    {
        private readonly IRepository<TrainingProgramDto> _trainingProgramRepository;
        private readonly IRepository<SetOfExercisesDto> _setOfExercisesRepository;

        public TrainingProgramsService()
        {

        }
        public TrainingProgramsService(IRepository<TrainingProgramDto> trainingProgramRepository, IRepository<SetOfExercisesDto> setOfExercisesRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
            _setOfExercisesRepository = setOfExercisesRepository;
        }
        public virtual List<TrainingProgramDto> GetAll() => _trainingProgramRepository.GetAll();
        public virtual TrainingProgramDto GetById(int id) => _trainingProgramRepository.GetById(id);

        public virtual void Update(TrainingProgramDto trainingProgram) =>
            _trainingProgramRepository.Update(trainingProgram);

        public virtual void Delete(int id)
        {
            var trainingProgram = _trainingProgramRepository.GetById(id);
            if (trainingProgram == null)
            {
                throw new ArgumentNullException(nameof(trainingProgram), $"Cannot find complex with id '{id}'");
            }

            foreach (var complex in trainingProgram.SetsOfExercises.ToList())
            {
                _trainingProgramRepository.Remove(complex.Id);
            }
            _trainingProgramRepository.Remove(id);
        }

        public virtual TrainingProgramDto Create(TrainingProgramDto trainingProgram) =>
            _trainingProgramRepository.Create(trainingProgram);
    }
}

