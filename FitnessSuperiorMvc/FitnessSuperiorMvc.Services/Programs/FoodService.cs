using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.BusinessModels;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class FoodService
    {
        private readonly IRepository<Food> _foodRepository;
        public FoodService() {}
        public FoodService(IRepository<Food> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public virtual List<Food> GetAll() => _foodRepository.GetAll().OrderBy(s=>s.Id).ToList();

        public virtual Food GetById(int id) => _foodRepository.GetById(id);
        public virtual List<Food> GetAddingFood(Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            var exercises = controller.GetFood(user);
            return exercises;
        }
        public virtual void AddAddingFood(Food food, Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.AddAddingFood(food, user);
        }
        public virtual void DeleteAddingFood(Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.DeleteFood(user);
        }

        public virtual void RemoveAddingFood(int id, Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.RemoveAddingFood(id, user);
        }
        public virtual void Update(Food food) => _foodRepository.Update(food);

        public virtual void Remove(int id)
        {
            var food = _foodRepository.GetById(id);
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food), $"Cannot find food with id '{id}'");
            }
            _foodRepository.Remove(id);
        }

        public virtual Food Create(Food food) => _foodRepository.Create(food);
    }
}
