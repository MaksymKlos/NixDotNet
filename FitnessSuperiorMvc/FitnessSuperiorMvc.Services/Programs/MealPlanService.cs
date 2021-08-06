using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class MealPlanService
    {
        private readonly IRepository<MealPlan> _mealPlanRepository;
        private readonly IRepository<Food> _foodRepository;
        public MealPlanService(){}
        public MealPlanService(IRepository<MealPlan> mealPlanRepository, IRepository<Food> foodRepository)
        {
            _mealPlanRepository = mealPlanRepository;
            _foodRepository = foodRepository;
        }

        public virtual List<MealPlan> GetAll()
        {
            var mealPlan = _mealPlanRepository
                .GetAll()
                .GroupBy(e => e.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return mealPlan;
        }

        public virtual MealPlan GetById(int id) => _mealPlanRepository.GetById(id);
        public virtual void Update(MealPlan mealPlan) => _mealPlanRepository.Update(mealPlan);

        public virtual void Remove(int id)
        {
            var mealPlan = _mealPlanRepository.GetById(id);
            if (mealPlan == null)
            {
                throw new ArgumentNullException(nameof(mealPlan), $"Cannot find meal plan with id '{id}'");
            }
            foreach (var food in mealPlan.Food.ToList())
            {
                _foodRepository.Remove(food.Id);
            }
            _mealPlanRepository.Remove(id);
        }

        public virtual MealPlan Create(MealPlan mealPlan) => _mealPlanRepository.Create(mealPlan);
    }
}
