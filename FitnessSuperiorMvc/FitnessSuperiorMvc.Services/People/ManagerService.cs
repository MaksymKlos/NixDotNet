using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.People
{
    public class ManagerService
    {
        private readonly IRepository<Manager> _managerRepository;
        public ManagerService() { }
        public ManagerService(IRepository<Manager> managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public virtual List<Manager> GetAll()
        {
            var users = _managerRepository
                .GetAll().ToList();
            return users;
        }

        public virtual Manager GetById(int id)
        {
            return _managerRepository.GetById(id);
        }

        public virtual Manager GetByIdentityId(string identityId)
        {
            var userId = _managerRepository.GetAll().First(u => u.IdentityId == identityId).Id;
            return GetById(userId);
        }

        public virtual void Update(Manager user) => _managerRepository.Update(user);

        public virtual void Remove(int id)
        {
            var user = _managerRepository.GetById(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), $"Cannot find user with id '{id}'");
            }
            _managerRepository.Remove(id);
        }

        public virtual Manager Create(Manager user) => _managerRepository.Create(user);
    }
}
