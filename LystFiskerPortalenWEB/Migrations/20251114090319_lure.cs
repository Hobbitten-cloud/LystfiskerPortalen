using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LystFiskerPortalenWEB.Migrations
{
    /// <inheritdoc />
    public partial class lure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lures", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Lures",
                columns: new[] { "Id", "Color", "Name", "Type", "Weight" },
                values: new object[,]
                {
                    { 1, "Blank", "Blank", "Blank", 0.0 },
                    { 2, "Sølv/blå", "Möresilda", "Klassisk kystblink til havørred, hornfisk og andre rovfisk. Går lidt dybere og kaster langt.", 7.0 },
                    { 3, "Sølv", "Abu Garcia Toby", "Universelt blink til både sø og kyst. Fisker godt efter gedde, havørred, laks og aborre.", 7.0 },
                    { 4, "pearl/white", "Savage Gear Sandeel Surf Seeker", "Moderne long-cast kystblink. Perfekt til havørred, især i hårdt vejr og lange kasteafstande.", 35.0 },
                    { 5, "kobber/orange", "Hansen Flash", "Kystblink med livlig gang. Godt til havørred på lavere vand.", 15.0 },
                    { 6, "chartreuse", "Snaps", "Kæmpe favorit blandt danske kystfiskere. Særligt effektiv på havørred og hornfisk.", 25.0 },
                    { 7, "sølv/black stripes", "Abu Garcia Atom", "Geddeblink nr. 1 i mange år. Bred, vuggende gang – perfekt i søer og brakvand.", 40.0 },
                    { 8, "Firetiger", "Blue Fox Lucius", "Geddeblink til både lavt og dybt vand. God til at provokere hug i uklart vand.", 27.0 },
                    { 9, "rød/sølv", "Solvkroken Stingsilda", "Kraftigt, tungt blink til havfiskeri og kyst. Bruges ofte til torsk, makrel og havørred.", 18.0 },
                    { 10, "sølv/blue stripes", "Mepps Syclops", "Allround blink med meget “flappende” gang. Bruges til både aborre, gedde og laks.", 12.0 },
                    { 11, "Pink Panther", "Westin D360", "Slankt long-distance blink – super til havørred, især i klart vand.", 22.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lures");
        }
    }
}
