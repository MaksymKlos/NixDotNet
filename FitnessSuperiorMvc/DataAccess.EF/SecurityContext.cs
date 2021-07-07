using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.Dto.Person;

namespace DataAccess.EF
{
    public class SecurityContext:IdentityDbContext
    {
        //private readonly IOptions<RepositoryOptions> _options;

        //protected SecurityContext(IOptions<RepositoryOptions> options)
        //{
        //    _options = options;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=MAXVEL\\SQLEXPRESS;Initial Catalog=FitnessAppDatabase;Integrated Security=True");
        }

        public DbSet<PersonDto> Persons { get; set; }
    }
}
