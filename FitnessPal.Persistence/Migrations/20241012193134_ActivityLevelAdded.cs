using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ActivityLevelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityLevel",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8cf40327-d03a-49cb-9c0f-384747632960", "AQAAAAIAAYagAAAAEIw5CzdtSmXvyyPIFsB8TODRrDn5q4fVzLaf7WrqeiBVsCqQHkljT/zlgj9mCIZG2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a8ab852-8205-488e-ad10-a464ecc041d1", "AQAAAAIAAYagAAAAEOnfwzYW0ivESRx1v9HC+oct/XL66gUk1ISSLAaxLfl6ObkGekm2B+ds1MTvM8hUiA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "Goals");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "07a6f636-530f-478a-860b-51bb1d04b75f", "AQAAAAIAAYagAAAAEHbITGjXBKX0aPpVgER4wO92DylpyZpa2GO+aKFuKsy1HIn5tTzAkL8wyQZOM9EAZg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2ac5d43-3d8e-41de-8e18-f544637dfa04", "AQAAAAIAAYagAAAAEJel3/koq5RutqJ6s505reN038eKIuP6vTycIq8yn5Yf/n/a+GvZv+maiQV2rS6IoQ==" });
        }
    }
}
