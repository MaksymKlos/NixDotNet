﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessSuperiorMvc.DA.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity Create(TEntity entity);

        void Update(TEntity entity);

        void Remove(int id);
    }
}
