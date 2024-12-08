using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloverEdc.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixPi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pis_Sites_SiteId",
                table: "Pis");

            migrationBuilder.DropIndex(
                name: "IX_Pis_SiteId",
                table: "Pis");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5437ab99-4354-4524-b112-b3930e4dba92"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cfd5dbde-af3a-4bf1-9c7d-764daff4f48d"));

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Pis");

            migrationBuilder.CreateTable(
                name: "PiSites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PiSites_Pis_PiId",
                        column: x => x.PiId,
                        principalTable: "Pis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PiSites_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "RefreshToken", "RoleId", "StudyId", "UserName" },
                values: new object[,]
                {
                    { new Guid("87491b01-3305-4dda-b82b-3c623d135c41"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", "A", false, "Admin", "AQAAAAIAAYagAAAAEBIPTrAOtp/BuziEkIznW59PUFSbP9mdlB5olguq0fBbqnov/QQvkv6IroxtzGm4FQ==", new Guid("584a22df-a5b8-4094-8876-9022ee219553"), new Guid("f45a7e79-845f-47df-af36-dc486e563772"), null, "admin" },
                    { new Guid("a598fec0-905f-49c2-95f9-6457e3b780aa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "Super", false, "Admin", "AQAAAAIAAYagAAAAEBIPTrAOtp/BuziEkIznW59PUFSbP9mdlB5olguq0fBbqnov/QQvkv6IroxtzGm4FQ==", new Guid("9fe3f046-ec8e-4145-9ba1-864e9248e7f9"), new Guid("f567a244-752e-41c0-9af7-7bd85c71cf41"), null, "superAdmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PiSites_PiId",
                table: "PiSites",
                column: "PiId");

            migrationBuilder.CreateIndex(
                name: "IX_PiSites_SiteId",
                table: "PiSites",
                column: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PiSites");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87491b01-3305-4dda-b82b-3c623d135c41"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a598fec0-905f-49c2-95f9-6457e3b780aa"));

            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "Pis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "RefreshToken", "RoleId", "StudyId", "UserName" },
                values: new object[,]
                {
                    { new Guid("5437ab99-4354-4524-b112-b3930e4dba92"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "Super", false, "Admin", "AQAAAAIAAYagAAAAEOuYv0NWFd1lauBmKIUZ6vKt++Vka3sBMtYDiwepZaYmdusR5D5zNV2UlWa3G8BSyg==", new Guid("f6e2b7dd-ba5f-4124-8640-f56923b3d2fe"), new Guid("f567a244-752e-41c0-9af7-7bd85c71cf41"), null, "superAdmin" },
                    { new Guid("cfd5dbde-af3a-4bf1-9c7d-764daff4f48d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", "A", false, "Admin", "AQAAAAIAAYagAAAAEOuYv0NWFd1lauBmKIUZ6vKt++Vka3sBMtYDiwepZaYmdusR5D5zNV2UlWa3G8BSyg==", new Guid("f5be1d7d-bc87-4e13-84ad-c165c3554b38"), new Guid("f45a7e79-845f-47df-af36-dc486e563772"), null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pis_SiteId",
                table: "Pis",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pis_Sites_SiteId",
                table: "Pis",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
