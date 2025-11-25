using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LystFiskerPortalenWEB.Migrations
{
    /// <inheritdoc />
    public partial class Profile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Techniques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImagePath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "testid", 0, "cd63e3f3-9961-4f18-9b0c-66aed6bd4534", null, false, "/public/Images/DefaultProfileImage.png", false, null, null, null, null, null, false, "user", "9cf1bf26-c506-448e-83c1-258e695072ea", false, "testuser" });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Blank", "Blank" },
                    { 2, "En af de mest klassiske rigs i både salt- og ferskvand. Et lod sidder nederst, og 1–3 kroge sidder på korte forfang (”trembler”) over loddet.", "Paternoster-rig" },
                    { 3, "Et kuglelod glider frit på hovedlinen foran en perle og en svirvel. Herefter kommer et langt forfang med en enkeltkrog.", "Carolina-rig" },
                    { 4, "Ligner Carolina-rigget, men loddet sidder direkte foran agnen (typisk med en lille gummistopper). Agnen (ofte en softbait) kan rigges ”weedless”.", "Texas-rig" },
                    { 5, "Et lod trækkes frit på hovedlinen, enten gennem et rør eller et glidelod, før en svirvel og et forfang.", "Glidende bundrig" },
                    { 6, "En aflange kasteflåd (bombarda) monteres på linen, så man kan kaste selv små fluer eller lette agn meget langt.", "Bombarda-rig" },
                    { 7, "En enkeltkrog bindes på linen, og loddet sidder i enden. Krogen kan justeres i præcis den ønskede højde.", "Drop-shot-rig" },
                    { 8, "Krogen bindes på en speciel måde, hvor agnen (fx boilies) sidder på en lille “hair” efter krogen og ikke direkte på krogen.", "Hair-rig" },
                    { 9, "Et simpelt rig med flåd, stopperknuder, lodder og krog.", "Float-rig" },
                    { 10, "Bruges især til dødagn, hvor et spinnerblad eller rotator tilføjes for at give en livlig gang.", "Spinner-rig" },
                    { 11, "Specialiseret bundrig med korte forfang og farvede perler/spinnerblade, ofte med to kroge.", "Fladfiskerig" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreationDate", "Description", "Location", "Picture", "ProfileID", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "En fantastisk dag ved søen med masser af fisk!", "Søen ved Skoven", "public/TestPictures/TestFisk1.png", "testid", "Fisketur ved søen" },
                    { 2, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "En spændende dag på havet med store fangster.", "Kysten ved Byen", "public/TestPictures/TestFisk2.jpg", "testid", "Havfiskeri eventyr" },
                    { 3, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeg fangede en kæmpe blæksprutte - det ikke AI", "Byens kyst", "public/TestPictures/TestFisk3.png", "testid", "Kæmpe blæksprutte fanget!" },
                    { 4, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Søger single lystfiskere i Odense beliggenhed", null, null, "testid", "Hej Fiskere!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfileID",
                table: "Posts",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Profiles",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Profiles",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Lures");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Techniques");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
