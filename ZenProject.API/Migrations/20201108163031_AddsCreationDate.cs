using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenProject.API.Migrations
{
    public partial class AddsCreationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "TeamMembers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TeamMembers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 8, 17, 30, 31, 423, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 8, 17, 30, 31, 427, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 8, 17, 30, 31, 427, DateTimeKind.Local).AddTicks(5220));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TeamMembers");
        }
    }
}
