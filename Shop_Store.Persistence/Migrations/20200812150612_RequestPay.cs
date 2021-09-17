using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Store.Persistence.Migrations
{
    public partial class RequestPay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestPays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestPays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2020, 8, 12, 19, 36, 11, 733, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2020, 8, 12, 19, 36, 11, 741, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2020, 8, 12, 19, 36, 11, 741, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.CreateIndex(
                name: "IX_RequestPays_UserId",
                table: "RequestPays",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestPays");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2020, 8, 12, 14, 19, 40, 624, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2020, 8, 12, 14, 19, 40, 628, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2020, 8, 12, 14, 19, 40, 628, DateTimeKind.Local).AddTicks(9004));
        }
    }
}
