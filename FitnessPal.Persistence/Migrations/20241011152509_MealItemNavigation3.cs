using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MealItemNavigation3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Meals_MealId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MealId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Ingredients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0dbe7d00-5207-44ed-8080-fc429ce4df66", "AQAAAAIAAYagAAAAEEgSu4Sn38nrCKdTvShixdr8fQprzKcTx18pwtIAwBv0Uhey7n863JkToKq8+mdrWg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1309c0ca-9c96-4c89-905f-1f2dad3b8d26", "AQAAAAIAAYagAAAAEL4Mtf8m4JUk35QjWx+LRKyuXiomDqGDaUAz6BhFl4a6FKUTTzXjI1Jpm/Vxabq1lg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Ingredients",
                type: "int",
                nullable: true);

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
    }
}
