using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;

namespace DataAccess.EF
{
    public class FitnessAppRepository<T> : IRepository<T> where T : class
    {
        private readonly FitnessAppContext _context;
        protected DbSet<T> DbSet;
        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
