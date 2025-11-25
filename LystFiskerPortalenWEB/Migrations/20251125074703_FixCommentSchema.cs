using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LystFiskerPortalenWEB.Migrations
{
    /// <inheritdoc />
    public partial class FixCommentSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_Id",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comments_Old");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.Sql(@"
IF OBJECT_ID('dbo.Comments_Old', 'U') IS NOT NULL
BEGIN
    SET IDENTITY_INSERT dbo.Comments ON;
    INSERT INTO dbo.Comments (Id, CreationDate, Description, Picture, PostId)
    SELECT Id, CreationDate, Description, Picture, PostId
    FROM dbo.Comments_Old;
    SET IDENTITY_INSERT dbo.Comments OFF;
END");

            migrationBuilder.DropTable(
                name: "Comments_Old");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments_Old",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments_Old", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Old_Posts_Id",
                        column: x => x.Id,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql(@"
IF OBJECT_ID('dbo.Comments', 'U') IS NOT NULL
BEGIN
    INSERT INTO dbo.Comments_Old (Id, CreationDate, Description, Picture, PostId)
    SELECT Id, CreationDate, Description, Picture, PostId
    FROM dbo.Comments;
END");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments_Old",
                newName: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_Id",
                table: "Comments",
                column: "Id",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
