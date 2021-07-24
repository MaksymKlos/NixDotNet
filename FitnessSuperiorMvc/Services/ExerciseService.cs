using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace Services
{
    public class ExerciseService
    {
        private readonly IRepository<ExerciseDto> _exerciseRepository;
        public ExerciseService()
        {
            
        }
        public ExerciseService(IRepository<ExerciseDto> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public virtual List<ExerciseDto> GetAll()
        {
            var exercises = _exerciseRepository
                .GetAll()
                .GroupBy(e => e.Name)
                .Select(grp=>grp.First())
                .OrderBy(id=>id.Id)
                .ToList();
            return exercises;
        } 
            
        public virtual ExerciseDto GetById(int id) => _exerciseRepository.GetById(id);
        public virtual void Update(ExerciseDto exercise) => _exerciseRepository.Update(exercise);

        public virtual void Delete(int id)
        {
            var exercise = _exerciseRepository.GetById(id);
            if (exercise == null)
            {
                throw new ArgumentNullException(nameof(exercise),$"Cannot find student with id '{id}'");
            }
            _exerciseRepository.Remove(id);
        }

        public virtual ExerciseDto Create(ExerciseDto exercise) => _exerciseRepository.Create(exercise);
    }
}
