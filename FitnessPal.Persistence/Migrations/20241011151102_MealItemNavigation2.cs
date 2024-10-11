using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MealItemNavigation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealItems",
                table: "MealItems");

            migrationBuilder.DropIndex(
                name: "IX_MealItems_MealId",
                table: "MealItems");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealItems",
                table: "MealItems",
                columns: new[] { "MealId", "IngredientId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "74eb3f1a-cc00-40e0-907c-e8c01679c33c", "AQAAAAIAAYagAAAAEBAFJ4a4RXHpbfQwQTPa83N8RO7afCfb4TNROzcRl/1bGvoPwS3gDmZVK1fMUCvbuw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "892eb503-f985-4e40-972e-73cbdcaff8ab", "AQAAAAIAAYagAAAAEA0G13bQ1uOc00Ys/4BiP694FMFd/Nddir6DVxrMYRV27opeAcKC2o5JOWmXVEwrvA==" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "MealId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_MealItems_IngredientId",
                table: "MealItems",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MealId",
                table: "Ingredients",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Meals_MealId",
                table: "Ingredients",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Meals_MealId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealItems",
                table: "MealItems");

            migrationBuilder.DropIndex(
                name: "IX_MealItems_IngredientId",
                table: "MealItems");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MealId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Ingredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealItems",
                table: "MealItems",
                columns: new[] { "IngredientId", "MealId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d1d9d60-041e-43d1-afce-8d314172499b", "AQAAAAIAAYagAAAAEJpZHpxzePboU1zQxxMQyyfbIpf9rU+yz/9ZhG+y1px/w+q2/pMIj3U/orHmAOGp/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7540a92c-e1ad-4045-a856-3c16f6291d01", "AQAAAAIAAYagAAAAEG9Bq+jD6iX6Ch0M9IDTgM/jr+6In3pZzKpvSkfAO0vc7Y/x6dUDOiW1nzQDPgTm3Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_MealItems_MealId",
                table: "MealItems",
                column: "MealId");
        }
    }
}
