using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LystFiskerPortalenWEB.Migrations
{
    /// <inheritdoc />
    public partial class AnotherMissType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "public/TestPictures/TestFisk3.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "public/TestPictures/TestFisk3.jpg");
        }
    }
}
