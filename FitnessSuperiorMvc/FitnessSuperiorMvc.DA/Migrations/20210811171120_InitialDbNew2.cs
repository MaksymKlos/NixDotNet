using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessSuperiorMvc.DA.Migrations
{
    public partial class InitialDbNew2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "MealPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_AuthorId",
                table: "MealPlans",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_Nutritionists_AuthorId",
                table: "MealPlans",
                column: "AuthorId",
                principalTable: "Nutritionists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_Nutritionists_AuthorId",
                table: "MealPlans");

            migrationBuilder.DropIndex(
                name: "IX_MealPlans_AuthorId",
                table: "MealPlans");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "MealPlans");
        }
    }
}
