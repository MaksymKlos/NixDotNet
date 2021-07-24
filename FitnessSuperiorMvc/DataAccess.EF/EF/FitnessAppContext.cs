using FitnessSuperiorMvc.BLL.Dto.People;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.People.Users;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;
using FitnessSuperiorMvc.BLL.Services;
using Microsoft.EntityFrameworkCore;

namespace FitnessSuperiorMvc.DA.EF
{
    public sealed class FitnessAppContext : DbContext
    {
        public DbSet<TrainingProgramDto> TrainingPrograms { get; set; }
        public DbSet<NutritionProgramDto> NutritionPrograms { get; set; }
        public DbSet<UserDto> UsersDto { get; set; }
        public DbSet<TrainerDto> Trainers { get; set; }
        public DbSet<NutritionistDto> Nutritionists { get; set; }
        public DbSet<ManagerDto> Managers { get; set; }

        public FitnessAppContext()
        {
            
        }
        public FitnessAppContext(DbContextOptions<FitnessAppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
