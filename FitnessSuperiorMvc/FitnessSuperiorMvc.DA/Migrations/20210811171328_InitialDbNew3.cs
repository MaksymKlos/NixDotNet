using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessSuperiorMvc.DA.Migrations
{
    public partial class InitialDbNew3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_MealPlans_MealPlanId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_NutritionPrograms_NutritionProgramId",
                table: "MealPlans");

            migrationBuilder.DropIndex(
                name: "IX_MealPlans_NutritionProgramId",
                table: "MealPlans");

            migrationBuilder.DropIndex(
                name: "IX_Food_MealPlanId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "NutritionProgramId",
                table: "MealPlans");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "Food");

            migrationBuilder.CreateTable(
                name: "FoodMealPlan",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    MealPlansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMealPlan", x => new { x.FoodId, x.MealPlansId });
                    table.ForeignKey(
                        name: "FK_FoodMealPlan_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodMealPlan_MealPlans_MealPlansId",
                        column: x => x.MealPlansId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealPlanNutritionProgram",
                columns: table => new
                {
                    MealPlansId = table.Column<int>(type: "int", nullable: false),
                    NutritionProgramsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanNutritionProgram", x => new { x.MealPlansId, x.NutritionProgramsId });
                    table.ForeignKey(
                        name: "FK_MealPlanNutritionProgram_MealPlans_MealPlansId",
                        column: x => x.MealPlansId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealPlanNutritionProgram_NutritionPrograms_NutritionProgramsId",
                        column: x => x.NutritionProgramsId,
                        principalTable: "NutritionPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMealPlan_MealPlansId",
                table: "FoodMealPlan",
                column: "MealPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanNutritionProgram_NutritionProgramsId",
                table: "MealPlanNutritionProgram",
                column: "NutritionProgramsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMealPlan");

            migrationBuilder.DropTable(
                name: "MealPlanNutritionProgram");

            migrationBuilder.AddColumn<int>(
                name: "NutritionProgramId",
                table: "MealPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealPlanId",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_NutritionProgramId",
                table: "MealPlans",
                column: "NutritionProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_MealPlanId",
                table: "Food",
                column: "MealPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_MealPlans_MealPlanId",
                table: "Food",
                column: "MealPlanId",
                principalTable: "MealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_NutritionPrograms_NutritionProgramId",
                table: "MealPlans",
                column: "NutritionProgramId",
                principalTable: "NutritionPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
