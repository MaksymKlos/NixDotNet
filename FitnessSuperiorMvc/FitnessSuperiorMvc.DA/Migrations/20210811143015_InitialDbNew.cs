using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessSuperiorMvc.DA.Migrations
{
    public partial class InitialDbNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuscleGroups = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutritionists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExperience = table.Column<int>(type: "int", nullable: false),
                    AgeSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExperience = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkWithGender = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddingExercises",
                columns: table => new
                {
                    AddingExercisesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseDtoId = table.Column<int>(type: "int", nullable: true),
                    TrainerDtoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddingExercises", x => x.AddingExercisesId);
                    table.ForeignKey(
                        name: "FK_AddingExercises_Exercises_ExerciseDtoId",
                        column: x => x.ExerciseDtoId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddingExercises_Trainers_TrainerDtoId",
                        column: x => x.TrainerDtoId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NutritionistId = table.Column<int>(type: "int", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Nutritionists_NutritionistId",
                        column: x => x.NutritionistId,
                        principalTable: "Nutritionists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SetOfExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuscleGroups = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetOfExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetOfExercises_Trainers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NutritionPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfDiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NutritionistId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionPrograms_Nutritionists_NutritionistId",
                        column: x => x.NutritionistId,
                        principalTable: "Nutritionists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NutritionPrograms_UsersDto_UserId",
                        column: x => x.UserId,
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredSkillLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_TrainingPrograms_UsersDto_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddingComplexes",
                columns: table => new
                {
                    AddingComplexesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetOfExercisesDtoId = table.Column<int>(type: "int", nullable: true),
                    TrainerDtoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddingComplexes", x => x.AddingComplexesId);
                    table.ForeignKey(
                        name: "FK_AddingComplexes_SetOfExercises_SetOfExercisesDtoId",
                        column: x => x.SetOfExercisesDtoId,
                        principalTable: "SetOfExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddingComplexes_Trainers_TrainerDtoId",
                        column: x => x.TrainerDtoId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSetOfExercises",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    SetOfExercisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSetOfExercises", x => new { x.ExercisesId, x.SetOfExercisesId });
                    table.ForeignKey(
                        name: "FK_ExerciseSetOfExercises_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSetOfExercises_SetOfExercises_SetOfExercisesId",
                        column: x => x.SetOfExercisesId,
                        principalTable: "SetOfExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    NutritionProgramId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlans_NutritionPrograms_NutritionProgramId",
                        column: x => x.NutritionProgramId,
                        principalTable: "NutritionPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SetOfExercisesTrainingProgram",
                columns: table => new
                {
                    SetsOfExercisesId = table.Column<int>(type: "int", nullable: false),
                    TrainingProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetOfExercisesTrainingProgram", x => new { x.SetsOfExercisesId, x.TrainingProgramId });
                    table.ForeignKey(
                        name: "FK_SetOfExercisesTrainingProgram_SetOfExercises_SetsOfExercisesId",
                        column: x => x.SetsOfExercisesId,
                        principalTable: "SetOfExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetOfExercisesTrainingProgram_TrainingPrograms_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddingMealPlans",
                columns: table => new
                {
                    AddingMealPlansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealPlanDtoId = table.Column<int>(type: "int", nullable: true),
                    NutritionistDtoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddingMealPlans", x => x.AddingMealPlansId);
                    table.ForeignKey(
                        name: "FK_AddingMealPlans_MealPlans_MealPlanDtoId",
                        column: x => x.MealPlanDtoId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddingMealPlans_Nutritionists_NutritionistDtoId",
                        column: x => x.NutritionistDtoId,
                        principalTable: "Nutritionists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Proteins = table.Column<double>(type: "float", nullable: false),
                    Fats = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    BeneficialFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_MealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddingFood",
                columns: table => new
                {
                    AddingFoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodDtoId = table.Column<int>(type: "int", nullable: true),
                    NutritionistDtoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddingFood", x => x.AddingFoodId);
                    table.ForeignKey(
                        name: "FK_AddingFood_Food_FoodDtoId",
                        column: x => x.FoodDtoId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddingFood_Nutritionists_NutritionistDtoId",
                        column: x => x.NutritionistDtoId,
                        principalTable: "Nutritionists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddingComplexes_SetOfExercisesDtoId",
                table: "AddingComplexes",
                column: "SetOfExercisesDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_AddingComplexes_TrainerDtoId",
                table: "AddingComplexes",
                column: "TrainerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_AddingExercises_ExerciseDtoId",
                table: "AddingExercises",
                column: "ExerciseDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_AddingExercises_TrainerDtoId",
                table: "AddingExercises",
                column: "TrainerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_AddingFood_FoodDtoId",
                table: "AddingFood",
                column: "FoodDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_AddingFood_NutritionistDtoId",
                table: "AddingFood",
                column: "NutritionistDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_AddingMealPlans_MealPlanDtoId",
                table: "AddingMealPlans",
                column: "MealPlanDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_AddingMealPlans_NutritionistDtoId",
                table: "AddingMealPlans",
                column: "NutritionistDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSetOfExercises_SetOfExercisesId",
                table: "ExerciseSetOfExercises",
                column: "SetOfExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_NutritionistId",
                table: "Feedback",
                column: "NutritionistId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_TrainerId",
                table: "Feedback",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_MealPlanId",
                table: "Food",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_NutritionProgramId",
                table: "MealPlans",
                column: "NutritionProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPrograms_NutritionistId",
                table: "NutritionPrograms",
                column: "NutritionistId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPrograms_UserId",
                table: "NutritionPrograms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SetOfExercises_AuthorId",
                table: "SetOfExercises",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_SetOfExercisesTrainingProgram_TrainingProgramId",
                table: "SetOfExercisesTrainingProgram",
                column: "TrainingProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_TrainerId",
                table: "TrainingPrograms",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_UserId",
                table: "TrainingPrograms",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddingComplexes");

            migrationBuilder.DropTable(
                name: "AddingExercises");

            migrationBuilder.DropTable(
                name: "AddingFood");

            migrationBuilder.DropTable(
                name: "AddingMealPlans");

            migrationBuilder.DropTable(
                name: "ExerciseSetOfExercises");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "SetOfExercisesTrainingProgram");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "SetOfExercises");

            migrationBuilder.DropTable(
                name: "TrainingPrograms");

            migrationBuilder.DropTable(
                name: "MealPlans");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "NutritionPrograms");

            migrationBuilder.DropTable(
                name: "Nutritionists");

            migrationBuilder.DropTable(
                name: "UsersDto");
        }
    }
}
