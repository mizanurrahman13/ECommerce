using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Web.Data.Migrations
{
    public partial class AddedInventorySeedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "638014789856748423", new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8458), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b42eb8c-a7fd-46aa-a88c-8d656b016115"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8740), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("136e59e2-2046-460f-ad0e-60b75f3748c9"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8743), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a61cf49-d11a-494d-95ca-c649ed215773"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8733), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d0059e3-816c-44e1-8e36-adb7c74e1c7c"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8747), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e2c655f-5e84-48c7-bda1-ad178a7be899"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8749), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c405483e-b35c-4c4e-9e7e-387b5527f0b7"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8728), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6dcf59a-0cf7-4c22-aff5-38cd0223aca0"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8736), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8894), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8889), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ProductId", "Quantity", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0ac9c4cd-003d-4bce-b5bc-732f025a57df"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8898), new TimeSpan(0, 0, 0, 0, 0)), new Guid("17a7dff9-34fd-44e6-98c2-aa9dd60392ef"), 25, null, null },
                    { new Guid("1fa9d85a-1f28-4a16-a6ab-83cd29082a9d"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8915), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3384cc0b-0030-4972-9454-159d47149677"), 25, null, null },
                    { new Guid("3ca1f739-7559-4a50-b4e3-8e8d8c86d482"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8903), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7f6a2181-c381-4e6f-9c14-d9fc2c85b4f2"), 25, null, null },
                    { new Guid("76e3dac5-facf-471d-af6c-ba5eb733f0d8"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c8fe1651-fd04-4c52-a3c1-634ad6d0e413"), 25, null, null },
                    { new Guid("9249ed3f-50d1-4f62-8d2f-9e047770ea6c"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8921), new TimeSpan(0, 0, 0, 0, 0)), new Guid("da35a95d-6862-45e1-8f10-6c0a5e1200d0"), 25, null, null },
                    { new Guid("b5ede1aa-d435-4817-b11d-55a518ad338f"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8912), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c272683a-c8d9-4e9d-b876-16f1e6f0d557"), 25, null, null },
                    { new Guid("beb721e0-0880-47b0-8a4e-298214b89134"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8918), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9d9791cd-737c-4de8-bdfd-acf51a1dbb83"), 25, null, null },
                    { new Guid("e2390a67-27f8-439f-9c62-3ecb09dca511"), "Admin@gmail.com", new DateTimeOffset(new DateTime(2022, 10, 15, 19, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8900), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0c7dbebf-c240-405b-9883-1606ec29da00"), 25, null, null }
                });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("0221e486-e1fb-4f70-bb50-b527d1f28aa9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9074), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9075), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("168528cc-7ba4-452d-b4bf-d8032b3c2ef7"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9055), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("23fcef43-c376-42bf-aeb9-a7814bd389b1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9216), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9218), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("30b27db0-5cfb-4191-87f2-31055a93bcf9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9190), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9192), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("35eb699e-2178-4aa9-aa35-9da2f042f5aa"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9069), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("39002937-6e1b-4aae-8c44-48f4f6110b4b"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9102), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9103), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("39343150-0ebd-4034-b593-2260a85959bb"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9210), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9211), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("3ea2bf49-689e-4835-afaf-0e6634bc116e"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9165), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9166), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("48ecb090-d6e6-456e-ae46-3bac53c6940d"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9092), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("4c78c682-3db8-475e-adbc-acf6ef43cef7"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9125), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9127), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("4ff8ed54-c165-40e9-ab72-41badce8bf96"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9113), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9115), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("6ba7ec7d-76ed-4e4b-a5bd-f720c829e524"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9178), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9179), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("85142851-d4db-4e6d-b79c-34f42a844c72"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9153), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9155), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("8f6722d3-465d-4179-82df-45437c3616b6"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9142), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9143), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("9b545b2c-7e36-41ac-b39a-052cd61c8d4c"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9060), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9062), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("a0fc5bd0-c61b-4245-912c-592f364119ee"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9080), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9082), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("a4a74c94-afe8-4b2b-8b52-3de87ce926c3"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9172), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("b10e0200-8dd7-4363-a910-dd8951015917"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9137), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9138), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("bb16a155-3b52-4068-a639-ead927c7eb18"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9206), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("c46e2768-2dee-456e-b4a9-395980d959b9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9148), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9149), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("cd51ede2-86ed-4be8-90a7-a793533180a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9086), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9087), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("cf96e6bd-ed46-440f-b7a6-74478e6c0f1c"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9131), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9132), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("cf9c16f2-f231-4333-8f03-80eb2e0ad668"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9120), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("e055e80e-6894-43e9-bce3-3ee45c044b3e"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9196), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9200), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("e8378dea-aa5f-4687-ad57-59c7beb7dd78"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9107), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9109), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("ec75d4e0-6988-4e50-968b-a090b90dbaaf"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9184), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9186), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("f5e85072-f168-47c5-9c9c-f49980f0c88e"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9159), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(9161), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0564dc12-ca23-4508-8f53-8a4c5aefe1a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8811), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c7dbebf-c240-405b-9883-1606ec29da00"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8818), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17a7dff9-34fd-44e6-98c2-aa9dd60392ef"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8805), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8807), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3384cc0b-0030-4972-9454-159d47149677"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8836), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8785), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8798), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f6a2181-c381-4e6f-9c14-d9fc2c85b4f2"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8824), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8826), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d9791cd-737c-4de8-bdfd-acf51a1dbb83"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8848), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8849), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c272683a-c8d9-4e9d-b876-16f1e6f0d557"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8844), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8fe1651-fd04-4c52-a3c1-634ad6d0e413"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8830), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8832), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da35a95d-6862-45e1-8f10-6c0a5e1200d0"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8854), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 16, 1, 3, 5, 674, DateTimeKind.Unspecified).AddTicks(8855), new TimeSpan(0, 6, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("0ac9c4cd-003d-4bce-b5bc-732f025a57df"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("1fa9d85a-1f28-4a16-a6ab-83cd29082a9d"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("3ca1f739-7559-4a50-b4e3-8e8d8c86d482"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("76e3dac5-facf-471d-af6c-ba5eb733f0d8"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("9249ed3f-50d1-4f62-8d2f-9e047770ea6c"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("b5ede1aa-d435-4817-b11d-55a518ad338f"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("beb721e0-0880-47b0-8a4e-298214b89134"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("e2390a67-27f8-439f-9c62-3ecb09dca511"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08643fd-487f-401c-97bb-6117531abc7a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "638014460237097579", new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(7608), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b42eb8c-a7fd-46aa-a88c-8d656b016115"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(7873), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("136e59e2-2046-460f-ad0e-60b75f3748c9"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(7876), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a61cf49-d11a-494d-95ca-c649ed215773"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(7866), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d0059e3-816c-44e1-8e36-adb7c74e1c7c"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(7960), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e2c655f-5e84-48c7-bda1-ad178a7be899"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(7963), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c405483e-b35c-4c4e-9e7e-387b5527f0b7"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(7860), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6dcf59a-0cf7-4c22-aff5-38cd0223aca0"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(7869), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("97081fb9-f963-4125-aee3-ae7deaecb0ec"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8098), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("f23b443b-2185-4dd7-9952-8a91185e5244"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 10, 15, 9, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8093), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("0221e486-e1fb-4f70-bb50-b527d1f28aa9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8149), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8150), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("168528cc-7ba4-452d-b4bf-d8032b3c2ef7"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8131), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("23fcef43-c376-42bf-aeb9-a7814bd389b1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8275), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("30b27db0-5cfb-4191-87f2-31055a93bcf9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8254), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("35eb699e-2178-4aa9-aa35-9da2f042f5aa"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8143), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("39002937-6e1b-4aae-8c44-48f4f6110b4b"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8170), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8171), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("39343150-0ebd-4034-b593-2260a85959bb"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8269), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8270), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("3ea2bf49-689e-4835-afaf-0e6634bc116e"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8232), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8234), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("48ecb090-d6e6-456e-ae46-3bac53c6940d"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8164), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8166), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("4c78c682-3db8-475e-adbc-acf6ef43cef7"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8195), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8197), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("4ff8ed54-c165-40e9-ab72-41badce8bf96"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8180), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8181), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("6ba7ec7d-76ed-4e4b-a5bd-f720c829e524"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8243), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("85142851-d4db-4e6d-b79c-34f42a844c72"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8222), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8223), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("8f6722d3-465d-4179-82df-45437c3616b6"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8212), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8213), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("9b545b2c-7e36-41ac-b39a-052cd61c8d4c"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8137), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8139), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("a0fc5bd0-c61b-4245-912c-592f364119ee"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8154), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8155), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("a4a74c94-afe8-4b2b-8b52-3de87ce926c3"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8238), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8239), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("b10e0200-8dd7-4363-a910-dd8951015917"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8206), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8208), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("bb16a155-3b52-4068-a639-ead927c7eb18"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8264), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8265), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("c46e2768-2dee-456e-b4a9-395980d959b9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8217), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8218), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("cd51ede2-86ed-4be8-90a7-a793533180a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8159), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8161), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("cf96e6bd-ed46-440f-b7a6-74478e6c0f1c"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8200), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8202), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("cf9c16f2-f231-4333-8f03-80eb2e0ad668"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8188), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8190), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("e055e80e-6894-43e9-bce3-3ee45c044b3e"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8259), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8260), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("e8378dea-aa5f-4687-ad57-59c7beb7dd78"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8175), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8176), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("ec75d4e0-6988-4e50-968b-a090b90dbaaf"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8248), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8249), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("f5e85072-f168-47c5-9c9c-f49980f0c88e"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8228), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8229), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0564dc12-ca23-4508-8f53-8a4c5aefe1a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8023), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8024), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c7dbebf-c240-405b-9883-1606ec29da00"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8029), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17a7dff9-34fd-44e6-98c2-aa9dd60392ef"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8016), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3384cc0b-0030-4972-9454-159d47149677"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8047), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8048), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410bdfd-c2f1-4f29-b8b1-1321810cc9a9"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(7999), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f6a2181-c381-4e6f-9c14-d9fc2c85b4f2"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8035), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8036), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d9791cd-737c-4de8-bdfd-acf51a1dbb83"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8057), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8058), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c272683a-c8d9-4e9d-b876-16f1e6f0d557"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8052), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8053), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8fe1651-fd04-4c52-a3c1-634ad6d0e413"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8042), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8043), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da35a95d-6862-45e1-8f10-6c0a5e1200d0"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8062), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 15, 15, 53, 43, 709, DateTimeKind.Unspecified).AddTicks(8063), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
