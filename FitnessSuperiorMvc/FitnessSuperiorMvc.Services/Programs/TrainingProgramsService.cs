using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.BusinessModels;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class TrainingProgramsService
    {
        private readonly IRepository<TrainingProgram> _trainingProgramRepository;
        private readonly IRepository<SetOfExercises> _setOfExercisesRepository;

        public TrainingProgramsService() {}
        public TrainingProgramsService(IRepository<TrainingProgram> trainingProgramRepository, IRepository<SetOfExercises> setOfExercisesRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
            _setOfExercisesRepository = setOfExercisesRepository;
        }
        public virtual List<TrainingProgram> GetAll()
        {
            var programs = _trainingProgramRepository
                .GetAll()
                .GroupBy(n => n.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return programs;
        }
        public virtual TrainingProgram GetById(int id)
        {
            var binder = new Binder();
            var program = _trainingProgramRepository.GetById(id);
            program.SetsOfExercises = binder.GetComplexFromProgram(id);
            program.Trainer = binder.GetTrainerOfProgram(id);
            return program;
        }

        public virtual void Update(TrainingProgram trainingProgram) =>
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

        public virtual TrainingProgram Create(TrainingProgram trainingProgram) =>
            _trainingProgramRepository.Create(trainingProgram);
    }
}

