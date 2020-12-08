using Microsoft.EntityFrameworkCore.Migrations;

namespace TRKPortfolio.Data.Migrations
{
    public partial class ProjectTestimonialOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Testimonials_TestimonialId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TestimonialId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TestimonialId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Testimonials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_ProjectId",
                table: "Testimonials",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Projects_ProjectId",
                table: "Testimonials",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Projects_ProjectId",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_ProjectId",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Testimonials");

            migrationBuilder.AddColumn<int>(
                name: "TestimonialId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TestimonialId",
                table: "Projects",
                column: "TestimonialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Testimonials_TestimonialId",
                table: "Projects",
                column: "TestimonialId",
                principalTable: "Testimonials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
