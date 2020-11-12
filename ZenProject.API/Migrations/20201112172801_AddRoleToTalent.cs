using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenProject.API.Migrations
{
    public partial class AddRoleToTalent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Talent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 12, 18, 28, 1, 467, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 12, 18, 28, 1, 471, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 12, 18, 28, 1, 471, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2020, 11, 12, 18, 28, 1, 471, DateTimeKind.Local).AddTicks(5303));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Talent");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 11, 21, 18, 58, 282, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 11, 21, 18, 58, 286, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 11, 21, 18, 58, 286, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2020, 11, 11, 21, 18, 58, 286, DateTimeKind.Local).AddTicks(6993));
        }
    }
}
