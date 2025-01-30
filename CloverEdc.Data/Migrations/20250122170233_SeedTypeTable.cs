using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloverEdc.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("40d30c4c-83f3-4463-ad3d-73cda33c3ba9"));

            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("dbada4e1-7a9b-4776-aa9a-211bd4aa6d38"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("27f3c9e6-b5c4-4ab3-9e92-eeb183389e61"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2f03c572-bf31-4e39-8b69-a1e5e4b347e8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("64a90931-8208-4b80-821a-8d134ed13997"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("783ce7fd-8307-4dbe-9fbb-14bad6e7c3f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7ad1657-8dce-41c5-9e44-72e75fbd9078"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ca0d94ac-70ee-4e37-ad1e-cedf315a71be"));

            migrationBuilder.AddColumn<string>(
                name: "RequiredFieldValue",
                table: "CrfFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Protocols",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name", "NumOfVisits", "Randomization" },
                values: new object[,]
                {
                    { new Guid("234ebf04-2019-4103-ac66-56c4d8546984"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-2", 2, false },
                    { new Guid("c53a6657-7be0-4c1e-ae21-69ef395de9b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-1", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("479c485b-e6d7-4137-a41c-943275e1e0f7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "PI" },
                    { new Guid("94a52d54-c446-470b-93c7-98676b0c46ef"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "SuperAdmin" },
                    { new Guid("ce85653c-5521-4d84-9800-93b66fc217ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "DM" },
                    { new Guid("de1c3bde-444d-4de2-ab56-8f923628676d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "CRC" },
                    { new Guid("f7005a56-6273-4bbc-b96f-826bd49d1ddf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "DataType", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("2ba95634-97f3-4313-a2b8-38aff2e587b9"), "DateTime", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Date" },
                    { new Guid("61c0b7b4-a0db-4fa5-b593-05de15b0a4da"), "bool", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "ToggleButton" },
                    { new Guid("8d05441f-bf16-4928-86ea-f09ec1a52219"), "List<string>", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "DropDown" },
                    { new Guid("a624b7d8-dd79-4fe9-86fb-5d8f39b0f8bb"), "decimal", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Number" },
                    { new Guid("b912ced8-67bd-4583-bd25-8593ad09d25d"), "string", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Text" },
                    { new Guid("cb2b6926-fbce-45f7-b56b-41dc1ad9b41f"), "File", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "File" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "RefreshToken", "RoleId", "StudyId", "UserName" },
                values: new object[] { new Guid("fd72e76e-6b58-46d2-9903-a6afb38dc514"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "Supera", false, "Admina", "i35LXzP80StjUXPntX0Sz5XQGXPEfWGrN+UsGaPjTSaVj6FlAwB3XX3+FFulZ6XR", new Guid("9e0d9f97-c76e-4d80-a6c1-d3317d5f18e2"), new Guid("94a52d54-c446-470b-93c7-98676b0c46ef"), null, "superAdmina" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("234ebf04-2019-4103-ac66-56c4d8546984"));

            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("c53a6657-7be0-4c1e-ae21-69ef395de9b2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("479c485b-e6d7-4137-a41c-943275e1e0f7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ce85653c-5521-4d84-9800-93b66fc217ff"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("de1c3bde-444d-4de2-ab56-8f923628676d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f7005a56-6273-4bbc-b96f-826bd49d1ddf"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("2ba95634-97f3-4313-a2b8-38aff2e587b9"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("61c0b7b4-a0db-4fa5-b593-05de15b0a4da"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("8d05441f-bf16-4928-86ea-f09ec1a52219"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("a624b7d8-dd79-4fe9-86fb-5d8f39b0f8bb"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("b912ced8-67bd-4583-bd25-8593ad09d25d"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("cb2b6926-fbce-45f7-b56b-41dc1ad9b41f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fd72e76e-6b58-46d2-9903-a6afb38dc514"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("94a52d54-c446-470b-93c7-98676b0c46ef"));

            migrationBuilder.DropColumn(
                name: "RequiredFieldValue",
                table: "CrfFields");

            migrationBuilder.InsertData(
                table: "Protocols",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name", "NumOfVisits", "Randomization" },
                values: new object[,]
                {
                    { new Guid("40d30c4c-83f3-4463-ad3d-73cda33c3ba9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-1", 3, true },
                    { new Guid("dbada4e1-7a9b-4776-aa9a-211bd4aa6d38"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-2", 2, false }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("27f3c9e6-b5c4-4ab3-9e92-eeb183389e61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "CRC" },
                    { new Guid("2f03c572-bf31-4e39-8b69-a1e5e4b347e8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "PI" },
                    { new Guid("64a90931-8208-4b80-821a-8d134ed13997"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Admin" },
                    { new Guid("783ce7fd-8307-4dbe-9fbb-14bad6e7c3f5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "DM" },
                    { new Guid("ca0d94ac-70ee-4e37-ad1e-cedf315a71be"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "RefreshToken", "RoleId", "StudyId", "UserName" },
                values: new object[] { new Guid("d7ad1657-8dce-41c5-9e44-72e75fbd9078"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "Supera", false, "Admina", "lE1mwTMdijuKhS0iWAhQTj+Q4wSsQZgbORiwtOiwGYIHWMJsfD/g9ISZcNwvA+vS", new Guid("13b6cbae-894d-43fa-aa12-dc05cf182c30"), new Guid("ca0d94ac-70ee-4e37-ad1e-cedf315a71be"), null, "superAdmina" });
        }
    }
}
