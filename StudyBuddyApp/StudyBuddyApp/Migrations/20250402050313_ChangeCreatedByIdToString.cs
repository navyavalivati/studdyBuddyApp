using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyBuddyApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCreatedByIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyGroups_User_CreatedById",
                table: "StudyGroups");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "StudyGroups",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyGroups_AspNetUsers_CreatedById",
                table: "StudyGroups",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyGroups_AspNetUsers_CreatedById",
                table: "StudyGroups");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "StudyGroups",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyGroups_User_CreatedById",
                table: "StudyGroups",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
