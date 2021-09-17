using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Store.Persistence.Migrations
{
    public partial class IsActive_ForUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 4, 9, 14, 47, 276, DateTimeKind.Local).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 4, 9, 14, 47, 280, DateTimeKind.Local).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 4, 9, 14, 47, 280, DateTimeKind.Local).AddTicks(7065));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 3, 20, 18, 5, 903, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 3, 20, 18, 5, 913, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 3, 20, 18, 5, 913, DateTimeKind.Local).AddTicks(2402));
        }
    }
}
