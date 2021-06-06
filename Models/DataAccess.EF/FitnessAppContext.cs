using System;
using Microsoft.EntityFrameworkCore;
using Models.People;

namespace DataAccess.EF
{
    public class FitnessAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MAXVEL\SQLEXPRESS;Initial Catalog=FitnessAppDatabase;Integrated Security=True");
        }

        public DbSet<Trainer> Persons { get; set; }
    }
}
