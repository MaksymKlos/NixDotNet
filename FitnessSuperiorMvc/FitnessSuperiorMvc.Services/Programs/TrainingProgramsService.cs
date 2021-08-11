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

        public virtual List<TrainingProgram> GetAll() =>
            _trainingProgramRepository.GetAll().OrderBy(s => s.Id).ToList();
        public virtual TrainingProgram GetById(int id, FitnessAppContext context)
        {
            var binder = new Binder(context);
            var program = _trainingProgramRepository.GetById(id);
            program.SetsOfExercises = binder.GetComplexFromProgram(id);
            program.Trainer = binder.GetTrainerOfProgram(id);
            return program;
        }
        public virtual List<TrainingProgram> GetTrainingPrograms(int id, FitnessAppContext context)
        {
            Binder binder = new Binder(context);
            var programs = binder.GetTrainingPrograms(id);
            return programs;
        }
        public virtual List<SetOfExercises> GetAddingComplexes(Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            var complexes = controller.GetComplexes(user);
            return complexes;
        }
        public virtual void DeleteAddingComplexes(Trainer user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.DeleteComplex(user);
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

