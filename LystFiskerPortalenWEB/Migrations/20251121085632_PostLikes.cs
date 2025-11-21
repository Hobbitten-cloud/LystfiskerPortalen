using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LystFiskerPortalenWEB.Migrations
{
    /// <inheritdoc />
    public partial class PostLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Likes",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Likes",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Likes",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Likes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: "testid",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6c5a60b2-d68d-4ce4-9080-98001c8443f0", "df37b28a-f5d5-4b9a-a403-6e42ff775387" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: "testid",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cd63e3f3-9961-4f18-9b0c-66aed6bd4534", "9cf1bf26-c506-448e-83c1-258e695072ea" });
        }
    }
}
