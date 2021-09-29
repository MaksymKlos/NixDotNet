using FitnessSuperiorMvc.DA.Entities.Binders;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using Microsoft.EntityFrameworkCore;

namespace FitnessSuperiorMvc.DA.EF
{
    public sealed class FitnessAppContext:DbContext
    {
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<SetOfExercises> SetOfExercises { get; set; }


        public DbSet<NutritionProgram> NutritionPrograms { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }

        public DbSet<User> UsersDto { get; set; }


        public DbSet<AddingExercises> AddingExercises { get; set; }
        public DbSet<AddingComplexes> AddingComplexes { get; set; }
        public DbSet<AddingFood> AddingFood { get; set; }
        public DbSet<AddingMealPlans> AddingMealPlans { get; set; }

        public FitnessAppContext() { }
        public FitnessAppContext(DbContextOptions<FitnessAppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
