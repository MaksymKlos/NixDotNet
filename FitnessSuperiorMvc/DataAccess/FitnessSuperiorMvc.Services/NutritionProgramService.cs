using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.Services
{
    public class NutritionProgramService
    {
        private readonly IRepository<NutritionProgramDto> _programRepository;
        public NutritionProgramService() { }
        public NutritionProgramService(IRepository<NutritionProgramDto> programRepository)
        {
            _programRepository = programRepository;
        }

        public virtual List<NutritionProgramDto> GetAll()
        {
            var program = _programRepository
                .GetAll()
                .GroupBy(e => e.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return program;
        }

        public virtual NutritionProgramDto GetById(int id) => _programRepository.GetById(id);
        public virtual void Update(NutritionProgramDto program) => _programRepository.Update(program);

        public virtual void Delete(int id)
        {
            var program = _programRepository.GetById(id);
            if (program == null)
            {
                throw new ArgumentNullException(nameof(program), $"Cannot find program plan with id '{id}'");
            }
            _programRepository.Remove(id);
        }

        public virtual NutritionProgramDto Create(NutritionProgramDto program) => _programRepository.Create(program);
    }
}
