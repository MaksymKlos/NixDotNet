using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class TrainingProgramsService
    {
        private readonly IRepository<TrainingProgram> _trainingProgramRepository;
        private readonly IRepository<SetOfExercises> _setOfExercisesRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IFitnessServicesRepository _fitnessServicesRepository;

        public TrainingProgramsService() {}
        public TrainingProgramsService(
            IRepository<TrainingProgram> trainingProgramRepository,
            IRepository<SetOfExercises> setOfExercisesRepository,
            IStaffRepository staffRepository,
            IFitnessServicesRepository fitnessServicesRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
            _setOfExercisesRepository = setOfExercisesRepository;
            _staffRepository = staffRepository;
            _fitnessServicesRepository = fitnessServicesRepository;
        }

        public virtual List<TrainingProgram> GetAll() =>
            _trainingProgramRepository.GetAll().OrderBy(s => s.Id).ToList();
        public virtual TrainingProgram GetById(int id)
        {
            var program = _trainingProgramRepository.GetById(id);
            program.SetsOfExercises = _fitnessServicesRepository.GetComplexFromProgram(id);
            program.Trainer = _fitnessServicesRepository.GetTrainerOfProgram(id);
            return program;
        }
        public virtual List<TrainingProgram> GetTrainingPrograms(int id)=>
             _fitnessServicesRepository.GetTrainingPrograms(id);
 
        public virtual List<SetOfExercises> GetAddingComplexes(Trainer user)
            => _staffRepository.GetComplexes(user);

        public virtual void DeleteAddingComplexes(Trainer user)
            => _staffRepository.DeleteComplex(user);
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

