using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Web.Data.Migrations
{
    public partial class CategoryandProductDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "638010394959939255", new DateTimeOffset(new DateTime(2022, 10, 10, 16, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9288), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 10, 16, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9548), new TimeSpan(0, 0, 0, 0, 0)), "Category Example....", "Files/NoImageFoung.png", "Default", null, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ActiveStatus", "CreatedBy", "CreatedDate", "DeleteQueue", "Description", "DiscountedPrice", "Featured", "Name", "UnitPrice", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 10, 22, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9598), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Bata Shoes", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 10, 22, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9600), new TimeSpan(0, 6, 0, 0, 0)) },
                    { new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 10, 22, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9574), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Apex Shoes", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 10, 22, 58, 15, 993, DateTimeKind.Unspecified).AddTicks(9591), new TimeSpan(0, 6, 0, 0, 0)) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "73da2169-6fe8-4d66-897c-e2db8ed60297", new DateTimeOffset(new DateTime(2022, 10, 10, 12, 20, 46, 162, DateTimeKind.Unspecified).AddTicks(9977), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
