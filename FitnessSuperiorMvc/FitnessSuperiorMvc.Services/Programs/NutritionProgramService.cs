using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class NutritionProgramService
    {
        private readonly IRepository<NutritionProgram> _programRepository;
        private readonly IRepository<MealPlan> _mealPlanRepository;
        public NutritionProgramService() {}
        public NutritionProgramService(IRepository<NutritionProgram> programRepository, IRepository<MealPlan> mealPlanRepository)
        {
            _programRepository = programRepository;
            _mealPlanRepository = mealPlanRepository;
        }

        public virtual List<NutritionProgram> GetAll()
        {
            var program = _programRepository
                .GetAll()
                .GroupBy(e => e.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return program;
        }

        public virtual NutritionProgram GetById(int id) => _programRepository.GetById(id);
        public virtual void Update(NutritionProgram program) => _programRepository.Update(program);

        public virtual void Remove(int id)
        {
            var program = _programRepository.GetById(id);
            if (program == null)
            {
                throw new ArgumentNullException(nameof(program), $"Cannot find program plan with id '{id}'");
            }
            foreach (var mealPlan in program.MealPlans.ToList())
            {
                _mealPlanRepository.Remove(mealPlan.Id);
            }
            _programRepository.Remove(id);
        }

        public virtual NutritionProgram Create(NutritionProgram program) => _programRepository.Create(program);
    }
}
