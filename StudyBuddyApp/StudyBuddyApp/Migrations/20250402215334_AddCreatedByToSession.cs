using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyBuddyApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByToSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Sessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CreatedById",
                table: "Sessions",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AspNetUsers_CreatedById",
                table: "Sessions",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AspNetUsers_CreatedById",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CreatedById",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Sessions");
        }
    }
}
