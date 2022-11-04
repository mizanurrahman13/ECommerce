using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Web.Data.Migrations
{
    public partial class AddedInventoryDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 10, 18, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7427), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ProductId", "Quantity", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 10, 18, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7553), new TimeSpan(0, 0, 0, 0, 0)), new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"), 25, null, null },
                    { new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 10, 18, 37, 17, 273, DateTimeKind.Unspecified).AddTicks(7545), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"), 23, null, null }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "638010394959939255", new DateTimeOffset(new DateTime(2022, 10, 10, 16, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9288), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 10, 16, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9548), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 10, 22, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9598), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 10, 22, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9600), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 10, 22, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9574), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 10, 22, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9591), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
