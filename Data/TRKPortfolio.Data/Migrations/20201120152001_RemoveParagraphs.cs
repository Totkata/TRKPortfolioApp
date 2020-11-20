using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TRKPortfolio.Data.Migrations
{
    public partial class RemoveParagraphs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Paragraphs_ParagraphId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "ParagraphAttachments");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_ParagraphId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ParagraphId",
                table: "Attachments");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "ParagraphId",
                table: "Attachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParagraphAttachments",
                columns: table => new
                {
                    ParagraphId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParagraphAttachments", x => new { x.ParagraphId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_ParagraphAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParagraphAttachments_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ParagraphId",
                table: "Attachments",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_ParagraphAttachments_AttachmentId",
                table: "ParagraphAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_IsDeleted",
                table: "Paragraphs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_PostId",
                table: "Paragraphs",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_ProjectId",
                table: "Paragraphs",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Paragraphs_ParagraphId",
                table: "Attachments",
                column: "ParagraphId",
                principalTable: "Paragraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
