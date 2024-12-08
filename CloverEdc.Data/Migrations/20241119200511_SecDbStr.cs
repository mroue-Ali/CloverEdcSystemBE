using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloverEdc.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecDbStr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrfFields_CrfTemplates_CrfTemplateId",
                table: "CrfFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Queries_Users_DmId",
                table: "Queries");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateRequests_Users_UserId",
                table: "UpdateRequests");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("59df017c-4f1d-4a31-9204-78a10f0fc5e2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c18722b9-636e-4cc1-b22d-4e805f51e131"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UpdateRequests",
                newName: "CrcId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateRequests_UserId",
                table: "UpdateRequests",
                newName: "IX_UpdateRequests_CrcId");

            migrationBuilder.RenameColumn(
                name: "CrfTemplateId",
                table: "CrfFields",
                newName: "CrfPageId");

            migrationBuilder.RenameIndex(
                name: "IX_CrfFields_CrfTemplateId",
                table: "CrfFields",
                newName: "IX_CrfFields_CrfPageId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CrfValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "CrfTemplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "StudyId",
                table: "CrfTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "CrfFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RequiredFieldId",
                table: "CrfFields",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Treatment",
                table: "AdverseEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CrfFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CrfTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrfFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrfFiles_CrfTemplates_CrfTemplateId",
                        column: x => x.CrfTemplateId,
                        principalTable: "CrfTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pis_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pis_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrfPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrfFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequiredPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrfPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrfPages_CrfFiles_CrfFileId",
                        column: x => x.CrfFileId,
                        principalTable: "CrfFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "Password", "RefreshToken", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("98556a3d-8b9d-45cc-ba41-4292dea6b3d2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", "AQAAAAIAAYagAAAAEJdNTHPhGzzb4oz2hS33oP63ZEMBmi32cLbFQL1GZ+cJZWMUCHA7VrIqLrNbIf5VWA==", new Guid("e2640f85-77bf-4e0e-8a69-6354e38df585"), new Guid("f45a7e79-845f-47df-af36-dc486e563772"), "admin" },
                    { new Guid("fe601199-a622-43dd-ade8-ed18a6d1aae7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "AQAAAAIAAYagAAAAEJdNTHPhGzzb4oz2hS33oP63ZEMBmi32cLbFQL1GZ+cJZWMUCHA7VrIqLrNbIf5VWA==", new Guid("6eadd13b-0074-4f98-a1d6-19a2ce5f1333"), new Guid("f567a244-752e-41c0-9af7-7bd85c71cf41"), "superAdmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrfTemplates_StudyId",
                table: "CrfTemplates",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_CrfFiles_CrfTemplateId",
                table: "CrfFiles",
                column: "CrfTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CrfPages_CrfFileId",
                table: "CrfPages",
                column: "CrfFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Pis_SiteId",
                table: "Pis",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pis_UserId",
                table: "Pis",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrfFields_CrfPages_CrfPageId",
                table: "CrfFields",
                column: "CrfPageId",
                principalTable: "CrfPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrfTemplates_Studies_StudyId",
                table: "CrfTemplates",
                column: "StudyId",
                principalTable: "Studies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Queries_Dms_DmId",
                table: "Queries",
                column: "DmId",
                principalTable: "Dms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateRequests_Crcs_CrcId",
                table: "UpdateRequests",
                column: "CrcId",
                principalTable: "Crcs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrfFields_CrfPages_CrfPageId",
                table: "CrfFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CrfTemplates_Studies_StudyId",
                table: "CrfTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_Queries_Dms_DmId",
                table: "Queries");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateRequests_Crcs_CrcId",
                table: "UpdateRequests");

            migrationBuilder.DropTable(
                name: "CrfPages");

            migrationBuilder.DropTable(
                name: "Pis");

            migrationBuilder.DropTable(
                name: "CrfFiles");

            migrationBuilder.DropIndex(
                name: "IX_CrfTemplates_StudyId",
                table: "CrfTemplates");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98556a3d-8b9d-45cc-ba41-4292dea6b3d2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fe601199-a622-43dd-ade8-ed18a6d1aae7"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CrfValues");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "CrfTemplates");

            migrationBuilder.DropColumn(
                name: "StudyId",
                table: "CrfTemplates");

            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "CrfFields");

            migrationBuilder.DropColumn(
                name: "RequiredFieldId",
                table: "CrfFields");

            migrationBuilder.RenameColumn(
                name: "CrcId",
                table: "UpdateRequests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateRequests_CrcId",
                table: "UpdateRequests",
                newName: "IX_UpdateRequests_UserId");

            migrationBuilder.RenameColumn(
                name: "CrfPageId",
                table: "CrfFields",
                newName: "CrfTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_CrfFields_CrfPageId",
                table: "CrfFields",
                newName: "IX_CrfFields_CrfTemplateId");

            migrationBuilder.AlterColumn<string>(
                name: "Treatment",
                table: "AdverseEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "Password", "RefreshToken", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("59df017c-4f1d-4a31-9204-78a10f0fc5e2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", "AQAAAAIAAYagAAAAEGy3eLniR0AM0XxOXzUzK0KYCkLpL4OvtJl0Vrfncqtq0jltylFdXsilF982s61hKg==", new Guid("e38cf176-a55a-411d-90d5-d53fec4eb124"), new Guid("f45a7e79-845f-47df-af36-dc486e563772"), "admin" },
                    { new Guid("c18722b9-636e-4cc1-b22d-4e805f51e131"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "AQAAAAIAAYagAAAAEGy3eLniR0AM0XxOXzUzK0KYCkLpL4OvtJl0Vrfncqtq0jltylFdXsilF982s61hKg==", new Guid("6b336210-f4f1-4c2d-8144-0d85f7877426"), new Guid("f567a244-752e-41c0-9af7-7bd85c71cf41"), "superAdmin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CrfFields_CrfTemplates_CrfTemplateId",
                table: "CrfFields",
                column: "CrfTemplateId",
                principalTable: "CrfTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Queries_Users_DmId",
                table: "Queries",
                column: "DmId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateRequests_Users_UserId",
                table: "UpdateRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
