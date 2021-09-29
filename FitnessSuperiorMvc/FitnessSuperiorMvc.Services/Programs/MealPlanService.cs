using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class MealPlanService
    {
        private readonly IRepository<MealPlan> _mealPlanRepository;
        private readonly IRepository<Food> _foodRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IFitnessServicesRepository _fitnessServicesRepository;

        public MealPlanService(){}
        public MealPlanService(
            IRepository<MealPlan> mealPlanRepository,
            IRepository<Food> foodRepository,
            IStaffRepository staffRepository,
            IFitnessServicesRepository fitnessServicesRepository)
        {
            _mealPlanRepository = mealPlanRepository;
            _foodRepository = foodRepository;
            _staffRepository = staffRepository;
            _fitnessServicesRepository = fitnessServicesRepository;
        }

        public virtual List<MealPlan> GetAll() => _mealPlanRepository.GetAll().OrderBy(s=>s.Id).ToList();

        public virtual MealPlan GetById(int id)
        {
            var mealPlan = _mealPlanRepository.GetById(id);
            mealPlan.Food = _fitnessServicesRepository.GetFoodFromMealPlan(id);
            mealPlan.Author = _fitnessServicesRepository.GetNutritionistOfComplex(id);
            return mealPlan;
        }
        public virtual List<MealPlan> GetAddingMealPlans(Nutritionist user)
            => _staffRepository.GetMealPlans(user);
        public virtual void AddAddingMealPlans(MealPlan mealPlan, Nutritionist user)
        {
            _staffRepository.AddAddingMealPlan(mealPlan, user);
        }
        public virtual void DeleteAddingMealPlan(Nutritionist user)
        {
            _staffRepository.DeleteMealPlan(user);
        }

        public virtual void RemoveAddingMealPlan(int id, Nutritionist user)
        {
            _staffRepository.RemoveAddingMealPlans(id, user);
        }
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
