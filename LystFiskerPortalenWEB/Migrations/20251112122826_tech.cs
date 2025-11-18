using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LystFiskerPortalenWEB.Migrations
{
    /// <inheritdoc />
    public partial class tech : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Techniques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "gay", "Dennis" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Techniques");
        }
    }
}
