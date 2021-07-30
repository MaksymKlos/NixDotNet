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
        private readonly IRepository<FoodDto> _foodRepository;
        public MealPlanService(){}
        public MealPlanService(IRepository<MealPlanDto> mealPlanRepository, IRepository<FoodDto> foodRepository)
        {
            _mealPlanRepository = mealPlanRepository;
            _foodRepository = foodRepository;
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

        public virtual MealPlanDto Create(MealPlanDto mealPlan) => _mealPlanRepository.Create(mealPlan);
    }
}
