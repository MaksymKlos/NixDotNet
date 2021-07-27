using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessSuperiorMvc.DA.Migrations
{
    public partial class Initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    NutritionistId = table.Column<int>(type: "int", nullable: true),
                    UserDtoId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    UserDtoId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    NutritionProgramDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlanDto_Nutritionists_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Nutritionists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealPlanDto_NutritionPrograms_NutritionProgramDtoId",
                        column: x => x.NutritionProgramDtoId,
                        principalTable: "NutritionPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NutritionistDtoId = table.Column<int>(type: "int", nullable: true),
                    TrainingProgramDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Nutritionists_NutritionistDtoId",
                        column: x => x.NutritionistDtoId,
                        principalTable: "Nutritionists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_TrainingPrograms_TrainingProgramDtoId",
                        column: x => x.TrainingProgramDtoId,
                        principalTable: "TrainingPrograms",
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    TrainingProgramDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetOfExercisesDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetOfExercisesDto_Trainers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SetOfExercisesDto_TrainingPrograms_TrainingProgramDtoId",
                        column: x => x.TrainingProgramDtoId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_AddingMealPlans_MealPlanDto_MealPlanDtoId",
                        column: x => x.MealPlanDtoId,
                        principalTable: "MealPlanDto",
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
                        name: "FK_AddingComplexes_SetOfExercisesDto_SetOfExercisesDtoId",
                        column: x => x.SetOfExercisesDtoId,
                        principalTable: "SetOfExercisesDto",
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
                name: "ExerciseDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuscleGroups = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_AddingFood_FoodDto_FoodDtoId",
                        column: x => x.FoodDtoId,
                        principalTable: "FoodDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddingFood_Nutritionists_NutritionistDtoId",
                        column: x => x.NutritionistDtoId,
                        principalTable: "Nutritionists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_AddingExercises_ExerciseDto_ExerciseDtoId",
                        column: x => x.ExerciseDtoId,
                        principalTable: "ExerciseDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddingExercises_Trainers_TrainerDtoId",
                        column: x => x.TrainerDtoId,
                        principalTable: "Trainers",
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
                name: "IX_ExerciseDto_SetOfExercisesDtoId",
                table: "ExerciseDto",
                column: "SetOfExercisesDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_NutritionistDtoId",
                table: "Feedback",
                column: "NutritionistDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_TrainingProgramDtoId",
                table: "Feedback",
                column: "TrainingProgramDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDto_MealPlanDtoId",
                table: "FoodDto",
                column: "MealPlanDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDto_AuthorId",
                table: "MealPlanDto",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDto_NutritionProgramDtoId",
                table: "MealPlanDto",
                column: "NutritionProgramDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPrograms_NutritionistId",
                table: "NutritionPrograms",
                column: "NutritionistId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPrograms_UserDtoId",
                table: "NutritionPrograms",
                column: "UserDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_SetOfExercisesDto_AuthorId",
                table: "SetOfExercisesDto",
                column: "AuthorId");

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
                name: "AddingComplexes");

            migrationBuilder.DropTable(
                name: "AddingExercises");

            migrationBuilder.DropTable(
                name: "AddingFood");

            migrationBuilder.DropTable(
                name: "AddingMealPlans");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Managers");

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
