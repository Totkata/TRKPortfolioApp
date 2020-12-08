namespace TRKPortfolio.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EditReplyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Replies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Replies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
