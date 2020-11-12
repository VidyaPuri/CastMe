using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenProject.API.Migrations
{
    public partial class AddProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Talent",
                table: "Talent");

            migrationBuilder.RenameTable(
                name: "Talent",
                newName: "Talents");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "StaffMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Talents",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Talents",
                table: "Talents",
                column: "TalentId");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Outfit = table.Column<string>(nullable: true),
                    Concept = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Lighting = table.Column<string>(nullable: true),
                    Composition = table.Column<string>(nullable: true),
                    Props = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    Form = table.Column<int>(nullable: false),
                    Other = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 11, 12, 19, 43, 56, 35, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2020, 11, 12, 19, 43, 56, 39, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2020, 11, 12, 19, 43, 56, 39, DateTimeKind.Local).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2020, 11, 12, 19, 43, 56, 39, DateTimeKind.Local).AddTicks(9625));

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_ProjectId",
                table: "StaffMembers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_ProjectId",
                table: "Talents",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffMembers_Projects_ProjectId",
                table: "StaffMembers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Talents_Projects_ProjectId",
                table: "Talents",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffMembers_Projects_ProjectId",
                table: "StaffMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Talents_Projects_ProjectId",
                table: "Talents");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_StaffMembers_ProjectId",
                table: "StaffMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Talents",
                table: "Talents");

            migrationBuilder.DropIndex(
                name: "IX_Talents_ProjectId",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Talents");

            migrationBuilder.RenameTable(
                name: "Talents",
                newName: "Talent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Talent",
                table: "Talent",
                column: "TalentId");

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
    }
}
