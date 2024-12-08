using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloverEdc.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThrdDbStr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98556a3d-8b9d-45cc-ba41-4292dea6b3d2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fe601199-a622-43dd-ade8-ed18a6d1aae7"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UpdateRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Studies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Queries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Protocols",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Locks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DmSites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Dms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CrfValues",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CrfTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Crfs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CrfPages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CrfFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CrfFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CrcSites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Crcs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AuditTrails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdverseEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f45a7e79-845f-47df-af36-dc486e563772"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f567a244-752e-41c0-9af7-7bd85c71cf41"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "IsDeleted", "Password", "RefreshToken", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("39685b04-9e96-4d77-bf22-b1b9135ba94c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", false, "AQAAAAIAAYagAAAAEL6Y309UTokX8rF+NOqQoVR9n+WDQExo85uMWxtkfTEQnEOOpS8ypnsbqjzq7KsJ2w==", new Guid("b0e77303-d8d2-4417-9d5c-9020cb7851f4"), new Guid("f45a7e79-845f-47df-af36-dc486e563772"), "admin" },
                    { new Guid("d6eff6b7-4368-4cb3-b502-e57b020471f1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", false, "AQAAAAIAAYagAAAAEL6Y309UTokX8rF+NOqQoVR9n+WDQExo85uMWxtkfTEQnEOOpS8ypnsbqjzq7KsJ2w==", new Guid("95c8439e-7dd1-48d4-9a70-d1ec320e9663"), new Guid("f567a244-752e-41c0-9af7-7bd85c71cf41"), "superAdmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("39685b04-9e96-4d77-bf22-b1b9135ba94c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6eff6b7-4368-4cb3-b502-e57b020471f1"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UpdateRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Studies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Protocols");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pis");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Locks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DmSites");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Dms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CrfValues");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CrfTemplates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Crfs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CrfPages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CrfFiles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CrfFields");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CrcSites");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Crcs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdverseEvents");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "Password", "RefreshToken", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("98556a3d-8b9d-45cc-ba41-4292dea6b3d2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", "AQAAAAIAAYagAAAAEJdNTHPhGzzb4oz2hS33oP63ZEMBmi32cLbFQL1GZ+cJZWMUCHA7VrIqLrNbIf5VWA==", new Guid("e2640f85-77bf-4e0e-8a69-6354e38df585"), new Guid("f45a7e79-845f-47df-af36-dc486e563772"), "admin" },
                    { new Guid("fe601199-a622-43dd-ade8-ed18a6d1aae7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "AQAAAAIAAYagAAAAEJdNTHPhGzzb4oz2hS33oP63ZEMBmi32cLbFQL1GZ+cJZWMUCHA7VrIqLrNbIf5VWA==", new Guid("6eadd13b-0074-4f98-a1d6-19a2ce5f1333"), new Guid("f567a244-752e-41c0-9af7-7bd85c71cf41"), "superAdmin" }
                });
        }
    }
}
