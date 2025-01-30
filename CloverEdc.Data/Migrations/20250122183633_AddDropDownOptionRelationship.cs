using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloverEdc.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDropDownOptionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("0f3c68fb-2111-46d8-a5c1-0b2977d2d0d1"));

            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("639e100d-4087-4b2a-ba60-fd37bacba978"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("01a0a82c-7f37-4df9-8939-3966390fed34"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0e930171-3776-4b80-a5dc-029277442423"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a28e2a7f-9d21-4c28-adb6-64ba8076e161"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b27306a0-40c1-49e2-9814-a2d79e1671b2"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("15a50bf4-c654-4646-9fcd-f727fa6011d5"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("28d928f1-b9c9-4f6b-9b06-5f6abf56ef9f"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("5a7aaf34-20c3-46eb-ba54-5f36153d5c6e"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("77254bca-62b0-4421-9c97-aa6bf3be5813"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("a71cc8c7-67af-4f61-9afe-0fefc4fb8134"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("d4b7ddb9-0bba-4105-b242-2db6d11f3204"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e63fbaef-1067-47a6-8390-a495d94fa237"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9873e6dc-c7bd-4673-b293-9ccc546a53c7"));

            migrationBuilder.InsertData(
                table: "Protocols",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name", "NumOfVisits", "Randomization" },
                values: new object[,]
                {
                    { new Guid("ac96081e-4ac2-4753-9723-9be653ec6a6b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-2", 2, false },
                    { new Guid("c73df170-f3f9-404a-89cc-6e5bbd9ddc97"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-1", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("bf1dcc22-c99c-42f7-a60e-8114aea10bc9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "CRC" },
                    { new Guid("d5dd93c9-c0f6-4e81-b431-a85de6ad4ca2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Admin" },
                    { new Guid("dbdf1958-6ca4-497f-8f72-69490265f978"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "DM" },
                    { new Guid("e2d97a60-176a-4979-af84-4a9b25fe7681"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "SuperAdmin" },
                    { new Guid("effb05be-8aec-4df4-a5f4-ea22c30db903"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "PI" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "DataType", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("061b60b2-5215-42ec-9eb7-90cc1614e25e"), "List<string>", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "DropDown" },
                    { new Guid("14e2ca0f-4bb6-4acc-8acd-08c052f67a22"), "bool", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "ToggleButton" },
                    { new Guid("39799cac-1b8d-4b6a-912f-53b5f9063b86"), "string", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Text" },
                    { new Guid("657f10f0-68fc-437e-8f86-e371e748f4ca"), "File", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "File" },
                    { new Guid("6931e2d3-4c18-4e58-9565-535ee757586c"), "decimal", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Number" },
                    { new Guid("ecad5376-ada1-4f8e-9e41-f57d8c661129"), "DateTime", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Date" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "RefreshToken", "RoleId", "StudyId", "UserName" },
                values: new object[] { new Guid("75ee4d19-8ac1-49e3-918e-b186196e4781"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "Supera", false, "Admina", "kgisPpnw3pBhDDvyp6IoT7cWy8mXZ5CdIKe1y/827+S3wzDAawDq9PcZW58XIsXf", new Guid("4216694e-b595-4940-9cd6-09466b3d99f8"), new Guid("e2d97a60-176a-4979-af84-4a9b25fe7681"), null, "superAdmina" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("ac96081e-4ac2-4753-9723-9be653ec6a6b"));

            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("c73df170-f3f9-404a-89cc-6e5bbd9ddc97"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bf1dcc22-c99c-42f7-a60e-8114aea10bc9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d5dd93c9-c0f6-4e81-b431-a85de6ad4ca2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dbdf1958-6ca4-497f-8f72-69490265f978"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("effb05be-8aec-4df4-a5f4-ea22c30db903"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("061b60b2-5215-42ec-9eb7-90cc1614e25e"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("14e2ca0f-4bb6-4acc-8acd-08c052f67a22"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("39799cac-1b8d-4b6a-912f-53b5f9063b86"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("657f10f0-68fc-437e-8f86-e371e748f4ca"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("6931e2d3-4c18-4e58-9565-535ee757586c"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("ecad5376-ada1-4f8e-9e41-f57d8c661129"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75ee4d19-8ac1-49e3-918e-b186196e4781"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e2d97a60-176a-4979-af84-4a9b25fe7681"));

            migrationBuilder.InsertData(
                table: "Protocols",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name", "NumOfVisits", "Randomization" },
                values: new object[,]
                {
                    { new Guid("0f3c68fb-2111-46d8-a5c1-0b2977d2d0d1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-1", 3, true },
                    { new Guid("639e100d-4087-4b2a-ba60-fd37bacba978"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-2", 2, false }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("01a0a82c-7f37-4df9-8939-3966390fed34"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "DM" },
                    { new Guid("0e930171-3776-4b80-a5dc-029277442423"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Admin" },
                    { new Guid("9873e6dc-c7bd-4673-b293-9ccc546a53c7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "SuperAdmin" },
                    { new Guid("a28e2a7f-9d21-4c28-adb6-64ba8076e161"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "CRC" },
                    { new Guid("b27306a0-40c1-49e2-9814-a2d79e1671b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "PI" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "DataType", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("15a50bf4-c654-4646-9fcd-f727fa6011d5"), "File", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "File" },
                    { new Guid("28d928f1-b9c9-4f6b-9b06-5f6abf56ef9f"), "DateTime", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Date" },
                    { new Guid("5a7aaf34-20c3-46eb-ba54-5f36153d5c6e"), "decimal", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Number" },
                    { new Guid("77254bca-62b0-4421-9c97-aa6bf3be5813"), "string", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Text" },
                    { new Guid("a71cc8c7-67af-4f61-9afe-0fefc4fb8134"), "List<string>", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "DropDown" },
                    { new Guid("d4b7ddb9-0bba-4105-b242-2db6d11f3204"), "bool", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "ToggleButton" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "RefreshToken", "RoleId", "StudyId", "UserName" },
                values: new object[] { new Guid("e63fbaef-1067-47a6-8390-a495d94fa237"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "Supera", false, "Admina", "j99QFevFcsj4KuyHvh9WXToXeINJ04WmbnloJjYCfspx8iI7MT8JUGlM87pYYLms", new Guid("cb91bac0-bbfe-41a8-ba8d-49c83287429b"), new Guid("9873e6dc-c7bd-4673-b293-9ccc546a53c7"), null, "superAdmina" });
        }
    }
}
