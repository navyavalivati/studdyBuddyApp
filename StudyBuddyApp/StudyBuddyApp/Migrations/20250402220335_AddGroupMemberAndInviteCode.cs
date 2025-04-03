using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StudyBuddyApp.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupMemberAndInviteCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_StudyGroups_GroupId",
                table: "GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_User_UserId",
                table: "GroupMembers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "GroupMembers");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "GroupMembers",
                newName: "StudyGroupId");

            migrationBuilder.RenameColumn(
                name: "GroupMemberId",
                table: "GroupMembers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMembers_GroupId",
                table: "GroupMembers",
                newName: "IX_GroupMembers_StudyGroupId");

            migrationBuilder.AddColumn<string>(
                name: "InviteCode",
                table: "StudyGroups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GroupMembers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedAt",
                table: "GroupMembers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_AspNetUsers_UserId",
                table: "GroupMembers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_StudyGroups_StudyGroupId",
                table: "GroupMembers",
                column: "StudyGroupId",
                principalTable: "StudyGroups",
                principalColumn: "StudyGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_AspNetUsers_UserId",
                table: "GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_StudyGroups_StudyGroupId",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "InviteCode",
                table: "StudyGroups");

            migrationBuilder.DropColumn(
                name: "JoinedAt",
                table: "GroupMembers");

            migrationBuilder.RenameColumn(
                name: "StudyGroupId",
                table: "GroupMembers",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GroupMembers",
                newName: "GroupMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMembers_StudyGroupId",
                table: "GroupMembers",
                newName: "IX_GroupMembers_GroupId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GroupMembers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "GroupMembers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    University = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_StudyGroups_GroupId",
                table: "GroupMembers",
                column: "GroupId",
                principalTable: "StudyGroups",
                principalColumn: "StudyGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_User_UserId",
                table: "GroupMembers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
