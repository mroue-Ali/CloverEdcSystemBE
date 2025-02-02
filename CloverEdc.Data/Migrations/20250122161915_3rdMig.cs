using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloverEdc.Data.Migrations
{
    /// <inheritdoc />
    public partial class _3rdMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("94472c84-cd4d-4d4d-86cf-68a5a0636231"));

            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("f4044c03-78ea-4db2-a71b-140e6d2b913b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4450a8e5-8f17-44e1-b9b5-739f4f451755"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c180b129-3f34-4250-8829-9e90821a1780"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dbc54f61-0d64-4e90-8bf4-d903b9e036a2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f81e5c97-161f-4096-be7b-ac6c8633828e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bdff14f5-98e1-4962-ac8f-91a7bdc88b24"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0147613e-b596-4089-a65f-1c832a8b846b"));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "CrfValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ValidationRules",
                table: "CrfFields",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_DropDownOptions_BaseFieldId",
                table: "DropDownOptions",
                column: "BaseFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_DropDownOptions_BaseFields_BaseFieldId",
                table: "DropDownOptions",
                column: "BaseFieldId",
                principalTable: "BaseFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DropDownOptions_BaseFields_BaseFieldId",
                table: "DropDownOptions");

            migrationBuilder.DropIndex(
                name: "IX_DropDownOptions_BaseFieldId",
                table: "DropDownOptions");

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

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "CrfValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ValidationRules",
                table: "CrfFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Protocols",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name", "NumOfVisits", "Randomization" },
                values: new object[,]
                {
                    { new Guid("94472c84-cd4d-4d4d-86cf-68a5a0636231"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-2", 2, false },
                    { new Guid("f4044c03-78ea-4db2-a71b-140e6d2b913b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-1", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("0147613e-b596-4089-a65f-1c832a8b846b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "SuperAdmin" },
                    { new Guid("4450a8e5-8f17-44e1-b9b5-739f4f451755"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Admin" },
                    { new Guid("c180b129-3f34-4250-8829-9e90821a1780"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "DM" },
                    { new Guid("dbc54f61-0d64-4e90-8bf4-d903b9e036a2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "PI" },
                    { new Guid("f81e5c97-161f-4096-be7b-ac6c8633828e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "CRC" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "RefreshToken", "RoleId", "StudyId", "UserName" },
                values: new object[] { new Guid("bdff14f5-98e1-4962-ac8f-91a7bdc88b24"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "Supera", false, "Admina", "ewr8kKmoypzYataEw+OGjMRyx8LZ9IAxFQ7Op2a3Fv3Xpf+M0qqFxHRE40oqnDSe", new Guid("8035cd1e-a4a2-44d9-8ca0-0426822087ad"), new Guid("0147613e-b596-4089-a65f-1c832a8b846b"), null, "superAdmina" });
        }
    }
}
