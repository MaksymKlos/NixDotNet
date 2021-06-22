using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq;
using System.Linq;
using LinqToDB.Reflection;
using Models.Interfaces;
using Models.Dto.FitnessProgram;
using Models.Dto.Person;

namespace FitnessSuperior
{
    public class LinkToSql<T> :IRepository<T> where T : class,IKey
    {
        private static string _connectionString =
            @"Data Source=MAXVEL\SQLEXPRESS;Initial Catalog=LinqToDb;Integrated Security=True";

        private DataContext db = new DataContext(_connectionString);
        //public static void Add(T obj)
        //{
        //    CreateTable().InsertOnSubmit(obj);
        //}

        //public static void DeleteById(int id)
        //{
        //    var type = typeof(T);
        //    var deleteObj = CreateTable().FirstOrDefault(o => o.Id == id);
        //}

        

        public List<T> GetAll()
        {
            return db.GetTable<T>().ToList();
        }

        public T GetById(int id)
        {
            return db.GetTable<T>().FirstOrDefault(o => o.Id.Equals(id));
        }

        public T Create(T entity)
        {
            if (entity != null)
            {
                db.GetTable<T>().InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity;
            }

            throw new ArgumentNullException(nameof(entity));
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                db.GetTable<T>().DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
            else
            {
                throw new ArgumentException("db has no element with this id.");
            }
            
        }
       
    }
}
