using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloverEdc.Data.Migrations
{
    /// <inheritdoc />
    public partial class retaltionfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("09d06cf3-0d7c-4e83-9154-791e0a0e0c14"));

            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: new Guid("a0ad495f-7427-4a47-b1a3-64a8b562a0f6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3fd510fb-83ab-49c1-8a7b-32cdbd9920ff"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("966d5963-5846-4bc9-afbd-b37bd6fcfc2c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b4c9307c-2047-4f23-922b-da4d18ccbb47"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bf1d3cca-15db-4890-b18d-c95f6647ec70"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4394f568-f2b0-4744-ae5c-b9c9b4b744b6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("635b2f08-21bd-4e5c-b7ec-e67d043c9381"));

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "CrfFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_CrfFiles_ParentFileId",
                table: "CrfFiles",
                column: "ParentFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrfFiles_CrfFiles_ParentFileId",
                table: "CrfFiles",
                column: "ParentFileId",
                principalTable: "CrfFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrfFiles_CrfFiles_ParentFileId",
                table: "CrfFiles");

            migrationBuilder.DropIndex(
                name: "IX_CrfFiles_ParentFileId",
                table: "CrfFiles");

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

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "CrfFiles");

            migrationBuilder.InsertData(
                table: "Protocols",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name", "NumOfVisits", "Randomization" },
                values: new object[,]
                {
                    { new Guid("09d06cf3-0d7c-4e83-9154-791e0a0e0c14"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-2", 2, false },
                    { new Guid("a0ad495f-7427-4a47-b1a3-64a8b562a0f6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Protocol-1", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("3fd510fb-83ab-49c1-8a7b-32cdbd9920ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "DM" },
                    { new Guid("635b2f08-21bd-4e5c-b7ec-e67d043c9381"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "SuperAdmin" },
                    { new Guid("966d5963-5846-4bc9-afbd-b37bd6fcfc2c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Admin" },
                    { new Guid("b4c9307c-2047-4f23-922b-da4d18ccbb47"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "PI" },
                    { new Guid("bf1d3cca-15db-4890-b18d-c95f6647ec70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "CRC" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "RefreshToken", "RoleId", "StudyId", "UserName" },
                values: new object[] { new Guid("4394f568-f2b0-4744-ae5c-b9c9b4b744b6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin@example.com", "Supera", false, "Admina", "eR1+zKbCL7GfNVY260MpFVRN1uYrfajRD7dch72/XjdWWrktmNqn8Gte4y1x4Rrs", new Guid("792fa12c-3ba8-42bc-b3e9-b61846b4bb65"), new Guid("635b2f08-21bd-4e5c-b7ec-e67d043c9381"), null, "superAdmina" });
        }
    }
}
