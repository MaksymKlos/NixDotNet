﻿// <auto-generated />
using System;
using FitnessSuperiorMvc.DA.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitnessSuperiorMvc.DA.Migrations
{
    [DbContext(typeof(FitnessAppContext))]
    [Migration("20210814111330_InitialDbNew242")]
    partial class InitialDbNew242
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExerciseSetOfExercises", b =>
                {
                    b.Property<int>("ExercisesId")
                        .HasColumnType("int");

                    b.Property<int>("SetOfExercisesId")
                        .HasColumnType("int");

                    b.HasKey("ExercisesId", "SetOfExercisesId");

                    b.HasIndex("SetOfExercisesId");

                    b.ToTable("ExerciseSetOfExercises");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Binders.AddingComplexes", b =>
                {
                    b.Property<int>("AddingComplexesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SetOfExercisesDtoId")
                        .HasColumnType("int");

                    b.Property<int>("TrainerDtoId")
                        .HasColumnType("int");

                    b.HasKey("AddingComplexesId");

                    b.HasIndex("SetOfExercisesDtoId");

                    b.HasIndex("TrainerDtoId");

                    b.ToTable("AddingComplexes");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Binders.AddingExercises", b =>
                {
                    b.Property<int>("AddingExercisesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExerciseDtoId")
                        .HasColumnType("int");

                    b.Property<int>("TrainerDtoId")
                        .HasColumnType("int");

                    b.HasKey("AddingExercisesId");

                    b.HasIndex("ExerciseDtoId");

                    b.HasIndex("TrainerDtoId");

                    b.ToTable("AddingExercises");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Binders.AddingFood", b =>
                {
                    b.Property<int>("AddingFoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FoodDtoId")
                        .HasColumnType("int");

                    b.Property<int>("NutritionistDtoId")
                        .HasColumnType("int");

                    b.HasKey("AddingFoodId");

                    b.HasIndex("FoodDtoId");

                    b.HasIndex("NutritionistDtoId");

                    b.ToTable("AddingFood");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Binders.AddingMealPlans", b =>
                {
                    b.Property<int>("AddingMealPlansId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MealPlanDtoId")
                        .HasColumnType("int");

                    b.Property<int>("NutritionistDtoId")
                        .HasColumnType("int");

                    b.HasKey("AddingMealPlansId");

                    b.HasIndex("MealPlanDtoId");

                    b.HasIndex("NutritionistDtoId");

                    b.ToTable("AddingMealPlans");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Interaction.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SetOfExercisesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.HasIndex("SetOfExercisesId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Interaction.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NutritionistId")
                        .HasColumnType("int");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NutritionistId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Interaction.Mailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mailer");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Nutrition.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BeneficialFeatures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<double>("Carbohydrates")
                        .HasColumnType("float");

                    b.Property<double>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Proteins")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Nutrition.MealPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("MealPlans");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Nutrition.NutritionProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NutritionistId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("TypeOfDiet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NutritionistId");

                    b.HasIndex("UserId");

                    b.ToTable("NutritionPrograms");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.People.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("IdentityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.People.Nutritionist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AgeSpecialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Nutritionists");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.People.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkExperience")
                        .HasColumnType("int");

                    b.Property<string>("WorkWithGender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.People.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("IdentityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersDto");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Sport.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MuscleGroups")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YoutubeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Sport.SetOfExercises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MuscleGroups")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("SetOfExercises");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Sport.TrainingProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("RequiredSkillLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfProgram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingPrograms");
                });

            modelBuilder.Entity("FoodMealPlan", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("MealPlansId")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "MealPlansId");

                    b.HasIndex("MealPlansId");

                    b.ToTable("FoodMealPlan");
                });

            modelBuilder.Entity("MealPlanNutritionProgram", b =>
                {
                    b.Property<int>("MealPlansId")
                        .HasColumnType("int");

                    b.Property<int>("NutritionProgramsId")
                        .HasColumnType("int");

                    b.HasKey("MealPlansId", "NutritionProgramsId");

                    b.HasIndex("NutritionProgramsId");

                    b.ToTable("MealPlanNutritionProgram");
                });

            modelBuilder.Entity("SetOfExercisesTrainingProgram", b =>
                {
                    b.Property<int>("SetsOfExercisesId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingProgramId")
                        .HasColumnType("int");

                    b.HasKey("SetsOfExercisesId", "TrainingProgramId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("SetOfExercisesTrainingProgram");
                });

            modelBuilder.Entity("ExerciseSetOfExercises", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Sport.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Sport.SetOfExercises", null)
                        .WithMany()
                        .HasForeignKey("SetOfExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Binders.AddingComplexes", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Sport.SetOfExercises", "SetOfExercisesDto")
                        .WithMany()
                        .HasForeignKey("SetOfExercisesDtoId");

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Trainer", "TrainerDto")
                        .WithMany("AddingComplexes")
                        .HasForeignKey("TrainerDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SetOfExercisesDto");

                    b.Navigation("TrainerDto");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Binders.AddingExercises", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Sport.Exercise", "ExerciseDto")
                        .WithMany()
                        .HasForeignKey("ExerciseDtoId");

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Trainer", "TrainerDto")
                        .WithMany("AddingExercises")
                        .HasForeignKey("TrainerDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseDto");

                    b.Navigation("TrainerDto");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Binders.AddingFood", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Nutrition.Food", "FoodDto")
                        .WithMany()
                        .HasForeignKey("FoodDtoId");

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Nutritionist", "NutritionistDto")
                        .WithMany("AddingFood")
                        .HasForeignKey("NutritionistDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodDto");

                    b.Navigation("NutritionistDto");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Binders.AddingMealPlans", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Nutrition.MealPlan", "MealPlanDto")
                        .WithMany()
                        .HasForeignKey("MealPlanDtoId");

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Nutritionist", "NutritionistDto")
                        .WithMany("AddingMealPlans")
                        .HasForeignKey("NutritionistDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MealPlanDto");

                    b.Navigation("NutritionistDto");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Interaction.Event", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Sport.SetOfExercises", "SetOfExercises")
                        .WithMany()
                        .HasForeignKey("SetOfExercisesId");

                    b.Navigation("SetOfExercises");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Interaction.Feedback", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Nutritionist", null)
                        .WithMany("Feedback")
                        .HasForeignKey("NutritionistId");

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Trainer", null)
                        .WithMany("Feedback")
                        .HasForeignKey("TrainerId");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Nutrition.MealPlan", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Nutritionist", "Author")
                        .WithMany("MealPlans")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Nutrition.NutritionProgram", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Nutritionist", "Nutritionist")
                        .WithMany("NutritionPrograms")
                        .HasForeignKey("NutritionistId");

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.User", null)
                        .WithMany("NutritionPrograms")
                        .HasForeignKey("UserId");

                    b.Navigation("Nutritionist");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Sport.SetOfExercises", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Trainer", "Author")
                        .WithMany("SetOfExercises")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.Sport.TrainingProgram", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.Trainer", "Trainer")
                        .WithMany("TrainingPrograms")
                        .HasForeignKey("TrainerId");

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.People.User", null)
                        .WithMany("TrainingPrograms")
                        .HasForeignKey("UserId");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("FoodMealPlan", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Nutrition.Food", null)
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Nutrition.MealPlan", null)
                        .WithMany()
                        .HasForeignKey("MealPlansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MealPlanNutritionProgram", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Nutrition.MealPlan", null)
                        .WithMany()
                        .HasForeignKey("MealPlansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Nutrition.NutritionProgram", null)
                        .WithMany()
                        .HasForeignKey("NutritionProgramsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SetOfExercisesTrainingProgram", b =>
                {
                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Sport.SetOfExercises", null)
                        .WithMany()
                        .HasForeignKey("SetsOfExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessSuperiorMvc.DA.Entities.Sport.TrainingProgram", null)
                        .WithMany()
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.People.Nutritionist", b =>
                {
                    b.Navigation("AddingFood");

                    b.Navigation("AddingMealPlans");

                    b.Navigation("Feedback");

                    b.Navigation("MealPlans");

                    b.Navigation("NutritionPrograms");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.People.Trainer", b =>
                {
                    b.Navigation("AddingComplexes");

                    b.Navigation("AddingExercises");

                    b.Navigation("Feedback");

                    b.Navigation("SetOfExercises");

                    b.Navigation("TrainingPrograms");
                });

            modelBuilder.Entity("FitnessSuperiorMvc.DA.Entities.People.User", b =>
                {
                    b.Navigation("NutritionPrograms");

                    b.Navigation("TrainingPrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
