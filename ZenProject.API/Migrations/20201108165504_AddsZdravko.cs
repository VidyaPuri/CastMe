using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenProject.API.Migrations
{
    public partial class AddsZdravko : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 8, 17, 55, 4, 37, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 8, 17, 55, 4, 41, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 8, 17, 55, 4, 41, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "TeamMemberId", "CreationDate", "EditDate", "Email", "Equipment", "FbHandle", "FirstName", "IgHandle", "LastName", "PhoneNumber", "Role" },
                values: new object[] { 4, new DateTime(2020, 11, 8, 17, 55, 4, 41, DateTimeKind.Local).AddTicks(8420), null, "luckar@gmail.com", "Lights, Dimmers, ..", "facebook\\luckarZdravko", "Zdravko", "instagram\\luckarZdravko", "Pravnyk", "041-465-725", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: 4);

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
    }
}
