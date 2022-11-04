using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Web.Data.Migrations
{
    public partial class AddedProductandCategorySeedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "638014418660556793", new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0b42eb8c-a7fd-46aa-a88c-8d656b016115"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7199), new TimeSpan(0, 0, 0, 0, 0)), "Category Description Example....", "Files\\NoImageFound.png", "Seasonal Food", null, null },
                    { new Guid("136e59e2-2046-460f-ad0e-60b75f3748c9"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7206), new TimeSpan(0, 0, 0, 0, 0)), "Category Description Example....", "Files\\NoImageFound.png", "Phone", null, null },
                    { new Guid("7a61cf49-d11a-494d-95ca-c649ed215773"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7173), new TimeSpan(0, 0, 0, 0, 0)), "Category Description Example....", "Files\\NoImageFound.png", "Food", null, null },
                    { new Guid("7d0059e3-816c-44e1-8e36-adb7c74e1c7c"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7210), new TimeSpan(0, 0, 0, 0, 0)), "Category Description Example....", "Files\\NoImageFound.png", "Cloths", null, null },
                    { new Guid("7e2c655f-5e84-48c7-bda1-ad178a7be899"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7214), new TimeSpan(0, 0, 0, 0, 0)), "Category Description Example....", "Files\\NoImageFound.png", "Gadgets", null, null },
                    { new Guid("c405483e-b35c-4c4e-9e7e-387b5527f0b7"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7167), new TimeSpan(0, 0, 0, 0, 0)), "Category Description Example....", "Files\\NoImageFound.png", "Default", null, null },
                    { new Guid("d6dcf59a-0cf7-4c22-aff5-38cd0223aca0"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7191), new TimeSpan(0, 0, 0, 0, 0)), "Category Description Example....", "Files\\NoImageFound.png", "Vegetable", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7403), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 8, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7396), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("168528cc-7ba4-452d-b4bf-d8032b3c2ef7"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7437), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7441), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("9b545b2c-7e36-41ac-b39a-052cd61c8d4c"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7452), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7454), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7264), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7282), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ActiveStatus", "CreatedBy", "CreatedDate", "DeleteQueue", "Description", "DiscountedPrice", "Featured", "Name", "UnitPrice", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0564dc12-ca23-4508-8f53-8a4c5aefe1a9"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7301), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "JackFruit", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7303), new TimeSpan(0, 6, 0, 0, 0)) },
                    { new Guid("0c7dbebf-c240-405b-9883-1606ec29da00"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7313), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Apple", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7315), new TimeSpan(0, 6, 0, 0, 0)) },
                    { new Guid("17a7dff9-34fd-44e6-98c2-aa9dd60392ef"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7291), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Mango", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7293), new TimeSpan(0, 6, 0, 0, 0)) },
                    { new Guid("7f6a2181-c381-4e6f-9c14-d9fc2c85b4f2"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7321), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Banana", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7323), new TimeSpan(0, 6, 0, 0, 0)) },
                    { new Guid("9d9791cd-737c-4de8-bdfd-acf51a1dbb83"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7343), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Green Apple", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7346), new TimeSpan(0, 6, 0, 0, 0)) },
                    { new Guid("c8fe1651-fd04-4c52-a3c1-634ad6d0e413"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Black Berry", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 6, 0, 0, 0)) },
                    { new Guid("da35a95d-6862-45e1-8f10-6c0a5e1200d0"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7352), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Date", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 14, 44, 26, 55, DateTimeKind.Unspecified).AddTicks(7355), new TimeSpan(0, 6, 0, 0, 0)) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b42eb8c-a7fd-46aa-a88c-8d656b016115"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("136e59e2-2046-460f-ad0e-60b75f3748c9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a61cf49-d11a-494d-95ca-c649ed215773"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d0059e3-816c-44e1-8e36-adb7c74e1c7c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e2c655f-5e84-48c7-bda1-ad178a7be899"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c405483e-b35c-4c4e-9e7e-387b5527f0b7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6dcf59a-0cf7-4c22-aff5-38cd0223aca0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0564dc12-ca23-4508-8f53-8a4c5aefe1a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c7dbebf-c240-405b-9883-1606ec29da00"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17a7dff9-34fd-44e6-98c2-aa9dd60392ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f6a2181-c381-4e6f-9c14-d9fc2c85b4f2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d9791cd-737c-4de8-bdfd-acf51a1dbb83"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8fe1651-fd04-4c52-a3c1-634ad6d0e413"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da35a95d-6862-45e1-8f10-6c0a5e1200d0"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "638013884185786710", new DateTimeOffset(new DateTime(2022, 10, 14, 17, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(6747), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 14, 17, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(6985), new TimeSpan(0, 0, 0, 0, 0)), "Category Example....", "Files\\NoImageFound.png", "Default", null, null });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 14, 17, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7071), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 14, 17, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7065), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("168528cc-7ba4-452d-b4bf-d8032b3c2ef7"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 14, 23, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7098), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7101), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("9b545b2c-7e36-41ac-b39a-052cd61c8d4c"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 14, 23, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7108), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7110), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 14, 23, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7013), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 14, 23, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7026), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ActiveStatus", "CreatedBy", "CreatedDate", "DeleteQueue", "Description", "DiscountedPrice", "Featured", "Name", "UnitPrice", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("72a73a5f-1930-49e3-b924-d72b59c050a2"), true, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7033), new TimeSpan(0, 6, 0, 0, 0)), false, "This is the best product...........", 3000m, false, "Bata Shoes", 2500m, "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 14, 23, 53, 38, 578, DateTimeKind.Unspecified).AddTicks(7036), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
