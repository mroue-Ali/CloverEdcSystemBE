using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloverEdc.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("39685b04-9e96-4d77-bf22-b1b9135ba94c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6eff6b7-4368-4cb3-b502-e57b020471f1"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "StudyId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "RefreshToken", "RoleId", "StudyId", "UserName" },
                values: new object[,]
                {
                    { new Guid("5437ab99-4354-4524-b112-b3930e4dba92"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "Super", false, "Admin", "AQAAAAIAAYagAAAAEOuYv0NWFd1lauBmKIUZ6vKt++Vka3sBMtYDiwepZaYmdusR5D5zNV2UlWa3G8BSyg==", new Guid("f6e2b7dd-ba5f-4124-8640-f56923b3d2fe"), new Guid("f567a244-752e-41c0-9af7-7bd85c71cf41"), null, "superAdmin" },
                    { new Guid("cfd5dbde-af3a-4bf1-9c7d-764daff4f48d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", "A", false, "Admin", "AQAAAAIAAYagAAAAEOuYv0NWFd1lauBmKIUZ6vKt++Vka3sBMtYDiwepZaYmdusR5D5zNV2UlWa3G8BSyg==", new Guid("f5be1d7d-bc87-4e13-84ad-c165c3554b38"), new Guid("f45a7e79-845f-47df-af36-dc486e563772"), null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudyId",
                table: "Users",
                column: "StudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Studies_StudyId",
                table: "Users",
                column: "StudyId",
                principalTable: "Studies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Studies_StudyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudyId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5437ab99-4354-4524-b112-b3930e4dba92"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cfd5dbde-af3a-4bf1-9c7d-764daff4f48d"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudyId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "IsDeleted", "Password", "RefreshToken", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("39685b04-9e96-4d77-bf22-b1b9135ba94c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", false, "AQAAAAIAAYagAAAAEL6Y309UTokX8rF+NOqQoVR9n+WDQExo85uMWxtkfTEQnEOOpS8ypnsbqjzq7KsJ2w==", new Guid("b0e77303-d8d2-4417-9d5c-9020cb7851f4"), new Guid("f45a7e79-845f-47df-af36-dc486e563772"), "admin" },
                    { new Guid("d6eff6b7-4368-4cb3-b502-e57b020471f1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", false, "AQAAAAIAAYagAAAAEL6Y309UTokX8rF+NOqQoVR9n+WDQExo85uMWxtkfTEQnEOOpS8ypnsbqjzq7KsJ2w==", new Guid("95c8439e-7dd1-48d4-9a70-d1ec320e9663"), new Guid("f567a244-752e-41c0-9af7-7bd85c71cf41"), "superAdmin" }
                });
        }
    }
}
