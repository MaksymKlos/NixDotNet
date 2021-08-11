using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.BusinessModels;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
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

        public virtual List<MealPlan> GetAll() => _mealPlanRepository.GetAll().OrderBy(s=>s.Id).ToList();

        public virtual MealPlan GetById(int id, FitnessAppContext context)
        {
            var binder = new Binder(context);
            var mealPlan = _mealPlanRepository.GetById(id);
            mealPlan.Food = binder.GetFoodFromMealPlan(id);
            mealPlan.Author = binder.GetNutritionistOfComplex(id);
            return mealPlan;
        }
        public virtual List<MealPlan> GetAddingMealPlans(Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            var mealPlans = controller.GetMealPlans(user);
            return mealPlans;
        }
        public virtual void AddAddingMealPlans(MealPlan mealPlan, Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.AddAddingMealPlan(mealPlan, user);
        }
        public virtual void DeleteAddingMealPlan(Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.DeleteMealPlan(user);
        }

        public virtual void RemoveAddingMealPlan(int id, Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.RemoveAddingMealPlans(id, user);
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
