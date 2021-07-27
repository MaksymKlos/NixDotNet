using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.Services
{
    public class MealPlanService
    {
        private readonly IRepository<MealPlanDto> _mealPlanRepository;
        public MealPlanService() { }
        public MealPlanService(IRepository<MealPlanDto> mealPlanRepository)
        {
            _mealPlanRepository = mealPlanRepository;
        }

        public virtual List<MealPlanDto> GetAll()
        {
            var mealPlan = _mealPlanRepository
                .GetAll()
                .GroupBy(e => e.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return mealPlan;
        }

        public virtual MealPlanDto GetById(int id) => _mealPlanRepository.GetById(id);
        public virtual void Update(MealPlanDto mealPlan) => _mealPlanRepository.Update(mealPlan);

        public virtual void Delete(int id)
        {
            var mealPlan = _mealPlanRepository.GetById(id);
            if (mealPlan == null)
            {
                throw new ArgumentNullException(nameof(mealPlan), $"Cannot find meal plan with id '{id}'");
            }
            _mealPlanRepository.Remove(id);
        }

        public virtual MealPlanDto Create(MealPlanDto mealPlan) => _mealPlanRepository.Create(mealPlan);
    }
}
