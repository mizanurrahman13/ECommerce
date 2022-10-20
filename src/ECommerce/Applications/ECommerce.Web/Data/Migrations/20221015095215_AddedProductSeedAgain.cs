using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Web.Data.Migrations
{
    public partial class AddedProductSeedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "638014459348579618", new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 857, DateTimeKind.Unspecified).AddTicks(9654), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b42eb8c-a7fd-46aa-a88c-8d656b016115"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("136e59e2-2046-460f-ad0e-60b75f3748c9"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(10), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a61cf49-d11a-494d-95ca-c649ed215773"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 857, DateTimeKind.Unspecified).AddTicks(9995), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d0059e3-816c-44e1-8e36-adb7c74e1c7c"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(13), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e2c655f-5e84-48c7-bda1-ad178a7be899"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(18), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c405483e-b35c-4c4e-9e7e-387b5527f0b7"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 857, DateTimeKind.Unspecified).AddTicks(9988), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6dcf59a-0cf7-4c22-aff5-38cd0223aca0"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 858, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(295), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(289), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0564dc12-ca23-4508-8f53-8a4c5aefe1a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(182), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(184), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c7dbebf-c240-405b-9883-1606ec29da00"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(190), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(192), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17a7dff9-34fd-44e6-98c2-aa9dd60392ef"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(175), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(163), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f6a2181-c381-4e6f-9c14-d9fc2c85b4f2"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(200), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d9791cd-737c-4de8-bdfd-acf51a1dbb83"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(231), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(234), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8fe1651-fd04-4c52-a3c1-634ad6d0e413"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(207), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da35a95d-6862-45e1-8f10-6c0a5e1200d0"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(242), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ActiveStatus", "CreatedBy", "CreatedDate", "DeleteQueue", "Description", "DiscountedPrice", "Featured", "Name", "UnitPrice", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3384cc0b-0030-4972-9454-159d47149677"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(216), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Blue Berry", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(218), new TimeSpan(0, 6, 0, 0, 0)) },
                    { new Guid("c272683a-c8d9-4e9d-b876-16f1e6f0d557"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(224), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Green Berry", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 15, 52, 14, 858, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 6, 0, 0, 0)) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3384cc0b-0030-4972-9454-159d47149677"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c272683a-c8d9-4e9d-b876-16f1e6f0d557"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "638014419743767226", new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(7261), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b42eb8c-a7fd-46aa-a88c-8d656b016115"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(7765), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("136e59e2-2046-460f-ad0e-60b75f3748c9"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(7769), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a61cf49-d11a-494d-95ca-c649ed215773"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(7756), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d0059e3-816c-44e1-8e36-adb7c74e1c7c"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(7881), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e2c655f-5e84-48c7-bda1-ad178a7be899"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(7888), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c405483e-b35c-4c4e-9e7e-387b5527f0b7"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6dcf59a-0cf7-4c22-aff5-38cd0223aca0"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(7760), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8571), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ProductId", "UpdatedBy", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { new Guid("168528cc-7ba4-452d-b4bf-d8032b3c2ef7"), "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8625), new TimeSpan(0, 6, 0, 0, 0)), new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"), "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8628), new TimeSpan(0, 6, 0, 0, 0)), "Files\\NoImageFound.png" },
                    { new Guid("9b545b2c-7e36-41ac-b39a-052cd61c8d4c"), "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8637), new TimeSpan(0, 6, 0, 0, 0)), new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"), "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8639), new TimeSpan(0, 6, 0, 0, 0)), "Files\\NoImageFound.png" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0564dc12-ca23-4508-8f53-8a4c5aefe1a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8064), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8066), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c7dbebf-c240-405b-9883-1606ec29da00"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8072), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8075), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17a7dff9-34fd-44e6-98c2-aa9dd60392ef"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8052), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8056), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(7997), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8038), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f6a2181-c381-4e6f-9c14-d9fc2c85b4f2"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8081), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8083), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d9791cd-737c-4de8-bdfd-acf51a1dbb83"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8424), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8436), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8fe1651-fd04-4c52-a3c1-634ad6d0e413"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8089), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8091), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da35a95d-6862-45e1-8f10-6c0a5e1200d0"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8452), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 46, 14, 376, DateTimeKind.Unspecified).AddTicks(8455), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
