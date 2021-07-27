using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;
using FitnessSuperiorMvc.BLL.Interfaces;

namespace FitnessSuperiorMvc.Services
{
    public class FoodService
    {
        private readonly IRepository<FoodDto> _foodRepository;
        public FoodService() {}
        public FoodService(IRepository<FoodDto> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public virtual List<FoodDto> GetAll()
        {
            var food = _foodRepository
                .GetAll()
                .GroupBy(e => e.Name)
                .Select(grp => grp.First())
                .OrderBy(id => id.Id)
                .ToList();
            return food;
        }

        public virtual FoodDto GetById(int id) => _foodRepository.GetById(id);
        public virtual void Update(FoodDto food) => _foodRepository.Update(food);

        public virtual void Delete(int id)
        {
            var food = _foodRepository.GetById(id);
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food), $"Cannot find food with id '{id}'");
            }
            _foodRepository.Remove(id);
        }

        public virtual FoodDto Create(FoodDto food) => _foodRepository.Create(food);
    }
}
