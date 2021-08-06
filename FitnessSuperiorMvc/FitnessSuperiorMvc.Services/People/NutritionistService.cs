using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.People
{
    public class NutritionistService
    {
        private readonly IRepository<Nutritionist> _nutritionistRepository;
        public NutritionistService() { }
        public NutritionistService(IRepository<Nutritionist> nutritionistRepository)
        {
            _nutritionistRepository = nutritionistRepository;
        }

        public virtual List<Nutritionist> GetAll()
        {
            var users = _nutritionistRepository
                .GetAll().ToList();
            return users;
        }

        public virtual Nutritionist GetById(int id)
        {
            return _nutritionistRepository.GetById(id);
        }

        public virtual Nutritionist GetByIdentityId(string identityId)
        {
            var userId = _nutritionistRepository.GetAll().First(u => u.IdentityId == identityId).Id;
            return GetById(userId);
        }

        public virtual void Update(Nutritionist user) => _nutritionistRepository.Update(user);

        public virtual void Remove(int id)
        {
            var user = _nutritionistRepository.GetById(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), $"Cannot find user with id '{id}'");
            }
            _nutritionistRepository.Remove(id);
        }

        public virtual Nutritionist Create(Nutritionist user) => _nutritionistRepository.Create(user);
    }
}
