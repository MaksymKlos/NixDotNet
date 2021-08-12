using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.People
{
    public class TrainerService
    {
        private readonly IRepository<Trainer> _trainerRepository;
        public TrainerService() { }
        public TrainerService(IRepository<Trainer> trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public virtual List<Trainer> GetAll()
        {
            var users = _trainerRepository
                .GetAll().ToList();
            return users;
        }

        public virtual Trainer GetById(int id)
        {
            return _trainerRepository.GetById(id);
        }

        public virtual Trainer GetByIdentityId(string identityId)
        {
            var userId = _trainerRepository.GetAll().First(u => u.IdentityId == identityId).Id;
            return GetById(userId);
        }

        public virtual void Update(Trainer user) => _trainerRepository.Update(user);

        public virtual void Remove(int id)
        {
            var user = _trainerRepository.GetById(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), $"Cannot find user with id '{id}'");
            }
            _trainerRepository.Remove(id);
        }

        public virtual Trainer Create(Trainer user) => _trainerRepository.Create(user);
    }
}
