using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Web.Data.Migrations
{
    public partial class AddedProductImageDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "638011064678511435", new DateTimeOffset(new DateTime(2022, 10, 11, 11, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1467), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 11, 11, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1752), new TimeSpan(0, 0, 0, 0, 0)), "Files\\NoImageFound.png" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 11, 11, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1834), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 11, 11, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1829), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ProductId", "UpdatedBy", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { new Guid("168528cc-7ba4-452d-b4bf-d8032b3c2ef7"), "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 11, 17, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 6, 0, 0, 0)), new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"), "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 11, 17, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1866), new TimeSpan(0, 6, 0, 0, 0)), "Files\\NoImageFound.png" },
                    { new Guid("9b545b2c-7e36-41ac-b39a-052cd61c8d4c"), "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 11, 17, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1872), new TimeSpan(0, 6, 0, 0, 0)), new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"), "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 11, 17, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1874), new TimeSpan(0, 6, 0, 0, 0)), "Files\\NoImageFound.png" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 11, 17, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1800), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 11, 17, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1802), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 11, 17, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1780), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 11, 17, 34, 27, 851, DateTimeKind.Unspecified).AddTicks(1793), new TimeSpan(0, 6, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("168528cc-7ba4-452d-b4bf-d8032b3c2ef7"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("9b545b2c-7e36-41ac-b39a-052cd61c8d4c"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "638010454372737001", new DateTimeOffset(new DateTime(2022, 10, 10, 18, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 10, 18, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7427), new TimeSpan(0, 0, 0, 0, 0)), "Files/NoImageFoung.png" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 10, 18, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7553), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 10, 18, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7545), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 11, 0, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7501), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 11, 0, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7505), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 11, 0, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7473), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 11, 0, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7491), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
