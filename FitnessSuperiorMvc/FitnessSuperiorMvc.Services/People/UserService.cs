using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.People
{
    public class UserService
    {
        private readonly IRepository<User> _useRepository;
        public UserService() { }
        public UserService(IRepository<User> useRepository)
        {
            _useRepository = useRepository;
        }

        public virtual List<User> GetAll()
        {
            var users = _useRepository
                .GetAll().ToList();
            return users;
        }

        public virtual User GetById(int id)
        {
            return _useRepository.GetById(id);
        }

        public virtual User GetByIdentityId(string identityId)
        {
            var userId = _useRepository.GetAll().First(u => u.IdentityId == identityId).Id;
            return GetById(userId);
        }

        public virtual void Update(User user) => _useRepository.Update(user);

        public virtual void Remove(int id)
        {
            var user = _useRepository.GetById(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), $"Cannot find user with id '{id}'");
            }
            _useRepository.Remove(id);
        }

        public virtual User Create(User user) => _useRepository.Create(user);
    }
}
