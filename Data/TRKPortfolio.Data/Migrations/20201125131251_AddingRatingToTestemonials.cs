namespace TRKPortfolio.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddingRatingToTestemonials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_AspNetUsers_ApplicationUserId",
                table: "Testimonials");

            migrationBuilder.DropTable(
                name: "TestimonialAttachments");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_ApplicationUserId",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Testimonials");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    TestimonialId = table.Column<int>(nullable: false),
                    WorkRating = table.Column<byte>(nullable: false),
                    SkillRating = table.Column<byte>(nullable: false),
                    DeadlineRating = table.Column<byte>(nullable: false),
                    CooperatingRating = table.Column<byte>(nullable: false),
                    AvaliabilityRating = table.Column<byte>(nullable: false),
                    ComunicationRating = table.Column<byte>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Testimonials_TestimonialId",
                        column: x => x.TestimonialId,
                        principalTable: "Testimonials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TestimonialId",
                table: "Ratings",
                column: "TestimonialId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Testimonials",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Testimonials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TestimonialAttachments",
                columns: table => new
                {
                    TestimonialId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestimonialAttachments", x => new { x.TestimonialId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_TestimonialAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestimonialAttachments_Testimonials_TestimonialId",
                        column: x => x.TestimonialId,
                        principalTable: "Testimonials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_ApplicationUserId",
                table: "Testimonials",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestimonialAttachments_AttachmentId",
                table: "TestimonialAttachments",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_AspNetUsers_ApplicationUserId",
                table: "Testimonials",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
