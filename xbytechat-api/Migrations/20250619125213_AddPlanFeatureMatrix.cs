using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanFeatureMatrix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("03816e54-47a3-467d-8c88-e43ea4536e05"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("341fb820-6b52-4174-9662-3b214e82e6e3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3c392691-3438-4a20-b045-7df862eafc67"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3df6dae8-231e-4d76-82e2-2884cc481a43"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4d721807-27c2-4739-accb-9f31089a94c2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("50f07690-d640-4399-b443-e340aee9d3a0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("56e6eda1-6ed4-4b00-9a1d-53ee6d41e251"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7df4604b-fe0e-4f58-8622-9ca6cca4e079"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("86dc236f-b269-46af-bf2d-823f9ab40ce2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("88838163-0483-46a7-a5dd-db80abc6c5c6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("abeb1282-e95e-4b1d-b1dd-62104642ebc4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("be5dd8e3-2c78-46b6-af9c-ee91c9390de5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cb57d18f-d96a-4634-a65e-edbe6c34ae73"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cbd3bd8a-2761-449b-80fd-16ec9c4b56f3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e0cd0f85-44d7-49d8-b1a1-ad7d400ed458"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e8a60265-2301-4d75-906b-488c01fc1b00"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("eef2747c-b46d-452a-82a1-55e1005b9baa"));

            migrationBuilder.CreateTable(
                name: "FeatureAccess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureAccess", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(5976));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(5986));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6028));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("04458866-2ef9-4687-bfec-4198044108a5"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6468), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("118fff52-3cdc-4147-a9ee-43a793d8fb75"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6616), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("30f9753b-4f86-46e3-9ecd-5296dafc2e22"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6529), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("30f9766a-dd91-4cbb-b18f-687fd63ec978"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6487), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("31893be4-65b2-4891-b4f0-5f510b257752"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6629), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("32a1772e-104a-4df9-91cc-21147553a2f2"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6491), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("33aa695f-30d9-4b7f-972f-c53e47d44472"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6449), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4ba699b2-f51b-481b-bc33-e1440f46f7f4"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6534), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("80e010d0-9eb8-44dc-9b2d-d92112209731"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6514), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("8328b691-55fe-4a99-81fd-6e8a97c34c39"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6538), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("857ce948-a586-4443-a932-37839f780841"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6480), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("8f64dac3-89ca-4d79-b83d-f983c96ed0e3"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6503), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a64cc25f-9b4f-4484-9fec-4e16d43c82b3"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6637), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("dcd4151c-a419-4554-b864-4051acc33ae8"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6496), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e0b7aab9-8202-43e7-ba87-b4ddc393df56"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6458), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f8d37bcf-3b68-4e47-ad19-53716fead29a"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6463), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f9aeccd1-91d1-4509-9f8d-303684423c1b"), new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(6509), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 52, 12, 620, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.CreateIndex(
                name: "IX_FeatureAccess_BusinessId_FeatureName",
                table: "FeatureAccess",
                columns: new[] { "BusinessId", "FeatureName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureAccess");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("04458866-2ef9-4687-bfec-4198044108a5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("118fff52-3cdc-4147-a9ee-43a793d8fb75"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("30f9753b-4f86-46e3-9ecd-5296dafc2e22"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("30f9766a-dd91-4cbb-b18f-687fd63ec978"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("31893be4-65b2-4891-b4f0-5f510b257752"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("32a1772e-104a-4df9-91cc-21147553a2f2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("33aa695f-30d9-4b7f-972f-c53e47d44472"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4ba699b2-f51b-481b-bc33-e1440f46f7f4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("80e010d0-9eb8-44dc-9b2d-d92112209731"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8328b691-55fe-4a99-81fd-6e8a97c34c39"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("857ce948-a586-4443-a932-37839f780841"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8f64dac3-89ca-4d79-b83d-f983c96ed0e3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a64cc25f-9b4f-4484-9fec-4e16d43c82b3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dcd4151c-a419-4554-b864-4051acc33ae8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e0b7aab9-8202-43e7-ba87-b4ddc393df56"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f8d37bcf-3b68-4e47-ad19-53716fead29a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f9aeccd1-91d1-4509-9f8d-303684423c1b"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("03816e54-47a3-467d-8c88-e43ea4536e05"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8144), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("341fb820-6b52-4174-9662-3b214e82e6e3"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8207), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3c392691-3438-4a20-b045-7df862eafc67"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8229), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3df6dae8-231e-4d76-82e2-2884cc481a43"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8214), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4d721807-27c2-4739-accb-9f31089a94c2"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8263), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("50f07690-d640-4399-b443-e340aee9d3a0"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8127), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("56e6eda1-6ed4-4b00-9a1d-53ee6d41e251"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8221), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7df4604b-fe0e-4f58-8622-9ca6cca4e079"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8314), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("86dc236f-b269-46af-bf2d-823f9ab40ce2"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8184), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("88838163-0483-46a7-a5dd-db80abc6c5c6"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8255), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("abeb1282-e95e-4b1d-b1dd-62104642ebc4"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8336), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("be5dd8e3-2c78-46b6-af9c-ee91c9390de5"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8175), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cb57d18f-d96a-4634-a65e-edbe6c34ae73"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8162), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cbd3bd8a-2761-449b-80fd-16ec9c4b56f3"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8269), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("e0cd0f85-44d7-49d8-b1a1-ad7d400ed458"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8236), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e8a60265-2301-4d75-906b-488c01fc1b00"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8329), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("eef2747c-b46d-452a-82a1-55e1005b9baa"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8154), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6282));
        }
    }
}
