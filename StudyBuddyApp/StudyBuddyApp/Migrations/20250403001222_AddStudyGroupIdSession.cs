using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyBuddyApp.Migrations
{
    /// <inheritdoc />
    public partial class AddStudyGroupIdSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_StudyGroups_GroupId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Sessions",
                newName: "StudyGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_GroupId",
                table: "Sessions",
                newName: "IX_Sessions_StudyGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_StudyGroups_StudyGroupId",
                table: "Sessions",
                column: "StudyGroupId",
                principalTable: "StudyGroups",
                principalColumn: "StudyGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_StudyGroups_StudyGroupId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "StudyGroupId",
                table: "Sessions",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_StudyGroupId",
                table: "Sessions",
                newName: "IX_Sessions_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_StudyGroups_GroupId",
                table: "Sessions",
                column: "GroupId",
                principalTable: "StudyGroups",
                principalColumn: "StudyGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
