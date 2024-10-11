using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MealItemNavigation4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
