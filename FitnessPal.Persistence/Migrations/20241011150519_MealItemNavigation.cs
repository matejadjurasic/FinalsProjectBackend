using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MealItemNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealItems_Ingredients_FoodsId",
                table: "MealItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealItems",
                table: "MealItems");

            migrationBuilder.DropColumn(
                name: "FoodsId",
                table: "MealItems");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "MealItems",
                newName: "IngredientId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MealItems_Ingredients_IngredientId",
                table: "MealItems",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealItems_Ingredients_IngredientId",
                table: "MealItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealItems",
                table: "MealItems");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "MealItems",
                newName: "FoodId");

            migrationBuilder.AddColumn<int>(
                name: "FoodsId",
                table: "MealItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealItems",
                table: "MealItems",
                columns: new[] { "FoodsId", "MealId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1fd59ef9-7073-45c1-9972-4e24ee0ab492", "AQAAAAIAAYagAAAAEIdV1/H2Th04VKJL4S2hcGCrQwINF1c/2A9/TYptm2kwcsjIFWJD8X/oJhvirNZHrA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11dac450-aa25-48d2-b43a-a01212ee2363", "AQAAAAIAAYagAAAAECAWVl4f4hczItWJ9qTRIVghAw8kD6Yqb08GNx4piRzwjDBzxxdXDmU1SIMpZPiRWg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_MealItems_Ingredients_FoodsId",
                table: "MealItems",
                column: "FoodsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
