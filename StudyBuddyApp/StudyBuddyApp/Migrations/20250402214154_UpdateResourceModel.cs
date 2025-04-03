using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyBuddyApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateResourceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_StudyGroups_GroupId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_User_UploadedById",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Resources",
                newName: "StudyGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_GroupId",
                table: "Resources",
                newName: "IX_Resources_StudyGroupId");

            migrationBuilder.AlterColumn<string>(
                name: "UploadedById",
                table: "Resources",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadedAt",
                table: "Resources",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_AspNetUsers_UploadedById",
                table: "Resources",
                column: "UploadedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_StudyGroups_StudyGroupId",
                table: "Resources",
                column: "StudyGroupId",
                principalTable: "StudyGroups",
                principalColumn: "StudyGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_AspNetUsers_UploadedById",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_StudyGroups_StudyGroupId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "UploadedAt",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "StudyGroupId",
                table: "Resources",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_StudyGroupId",
                table: "Resources",
                newName: "IX_Resources_GroupId");

            migrationBuilder.AlterColumn<int>(
                name: "UploadedById",
                table: "Resources",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_StudyGroups_GroupId",
                table: "Resources",
                column: "GroupId",
                principalTable: "StudyGroups",
                principalColumn: "StudyGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_User_UploadedById",
                table: "Resources",
                column: "UploadedById",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
