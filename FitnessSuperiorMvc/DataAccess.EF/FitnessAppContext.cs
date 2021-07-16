using System;
using Microsoft.EntityFrameworkCore;
using Models.Dto.FitnessProgram;
using Models.Dto.Person;

namespace DataAccess.EF
{
    public class FitnessAppContext : DbContext
    {
        public DbSet<TrainerDto> Trainers { get; set; }
        public DbSet<ExerciseDto> Exercises { get; set; }
        public DbSet<TrainingProgramDto> TrainingPrograms { get; set; }
        public DbSet<NutritionistDto> Nutritionists { get; set; }
        public DbSet<NutritionProgramDto> NutritionPrograms { get; set; }
        //public DbSet<SetOfExercisesDto> SetOfExercises { get; set; }
        //public DbSet<MealPlanDto> MealPlans { get; set; }
        
        //public DbSet<FoodDto> Food { get; set; }
        
        //public DbSet<UserDto> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=MAXVEL\SQLEXPRESS;Initial Catalog=FitnessAppDatabase;Integrated Security=True"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
