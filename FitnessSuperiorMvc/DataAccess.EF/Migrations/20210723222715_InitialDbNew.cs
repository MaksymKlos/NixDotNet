﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessSuperiorMvc.DA.Migrations
{
    public partial class InitialDbNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nutritionists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExperience = table.Column<int>(type: "int", nullable: false),
                    AgeSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutritionists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExperience = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkWithGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutritionPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfDiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NutritionistDtoId = table.Column<int>(type: "int", nullable: true),
                    UserDtoId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionPrograms_Nutritionists_NutritionistDtoId",
                        column: x => x.NutritionistDtoId,
                        principalTable: "Nutritionists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NutritionPrograms_UsersDto_UserDtoId",
                        column: x => x.UserDtoId,
                        principalTable: "UsersDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<int>(type: "int", nullable: true),
                    TypeOfProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredSkillLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRestriction = table.Column<int>(type: "int", nullable: true),
                    UserDtoId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPrograms_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingPrograms_UsersDto_UserDtoId",
                        column: x => x.UserDtoId,
                        principalTable: "UsersDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealPlanDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    NutritionProgramDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlanDto_NutritionPrograms_NutritionProgramDtoId",
                        column: x => x.NutritionProgramDtoId,
                        principalTable: "NutritionPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SetOfExercisesDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingProgramDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetOfExercisesDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetOfExercisesDto_TrainingPrograms_TrainingProgramDtoId",
                        column: x => x.TrainingProgramDtoId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    BeneficialFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealPlanDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDto_MealPlanDto_MealPlanDtoId",
                        column: x => x.MealPlanDtoId,
                        principalTable: "MealPlanDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuscleGroups = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetOfExercisesDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseDto_SetOfExercisesDto_SetOfExercisesDtoId",
                        column: x => x.SetOfExercisesDtoId,
                        principalTable: "SetOfExercisesDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDto_SetOfExercisesDtoId",
                table: "ExerciseDto",
                column: "SetOfExercisesDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDto_MealPlanDtoId",
                table: "FoodDto",
                column: "MealPlanDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDto_NutritionProgramDtoId",
                table: "MealPlanDto",
                column: "NutritionProgramDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPrograms_NutritionistDtoId",
                table: "NutritionPrograms",
                column: "NutritionistDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPrograms_UserDtoId",
                table: "NutritionPrograms",
                column: "UserDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_SetOfExercisesDto_TrainingProgramDtoId",
                table: "SetOfExercisesDto",
                column: "TrainingProgramDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_TrainerId",
                table: "TrainingPrograms",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_UserDtoId",
                table: "TrainingPrograms",
                column: "UserDtoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseDto");

            migrationBuilder.DropTable(
                name: "FoodDto");

            migrationBuilder.DropTable(
                name: "SetOfExercisesDto");

            migrationBuilder.DropTable(
                name: "MealPlanDto");

            migrationBuilder.DropTable(
                name: "TrainingPrograms");

            migrationBuilder.DropTable(
                name: "NutritionPrograms");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Nutritionists");

            migrationBuilder.DropTable(
                name: "UsersDto");
        }
    }
}
