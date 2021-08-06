using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
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

        public virtual List<Food> GetAll()
        {
            var food = _foodRepository
                .GetAll()
                .GroupBy(e => e.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return food;
        }

        public virtual Food GetById(int id) => _foodRepository.GetById(id);
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
