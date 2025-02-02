using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloverEdc.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CrfTemplateId",
                table: "BaseFields",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_BaseFields_CrfTemplateId",
                table: "BaseFields",
                column: "CrfTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseFields_CrfTemplates_CrfTemplateId",
                table: "BaseFields",
                column: "CrfTemplateId",
                principalTable: "CrfTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseFields_CrfTemplates_CrfTemplateId",
                table: "BaseFields");

            migrationBuilder.DropIndex(
                name: "IX_BaseFields_CrfTemplateId",
                table: "BaseFields");

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

            migrationBuilder.DropColumn(
                name: "CrfTemplateId",
                table: "BaseFields");

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
    }
}
