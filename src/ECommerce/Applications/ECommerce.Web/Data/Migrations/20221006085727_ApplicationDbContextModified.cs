using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Web.Data.Migrations
{
    public partial class ApplicationDbContextModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 6, 8, 57, 26, 539, DateTimeKind.Unspecified).AddTicks(2374), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 5, 18, 27, 33, 434, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
