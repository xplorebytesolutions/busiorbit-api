using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFeatureAccessTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "PlanFeatureMatrix",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FeatureName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanFeatureMatrix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFeatureAccess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeatureAccess", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1547));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("096be258-50ae-4078-b0b8-c26a084fd724"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1993), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("0fd99a93-afb1-4c95-bd45-6cac60d66c95"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2113), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("252166cd-7af1-4e13-9307-d49d67174ca0"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2084), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("3ac31a18-ad13-4c36-b48b-809df1accbea"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1987), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3ae5fc4a-1802-4e1d-88e1-1a18ec723c68"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2003), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3b73270a-83ea-4035-bc71-afcd2712b655"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2069), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4a1d7dea-8658-4b83-ab55-3fa7d44acfca"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2123), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("58bc10ee-9c29-43f1-91ae-b47c230c074c"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2129), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("5974390a-3569-4e81-844a-eef6252ef7e4"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1966), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("81b8d4c8-6ce9-45b4-8edf-420e9e7cc508"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2065), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ab889393-3213-491e-9a14-22ed8d5e2ec9"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2093), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("cf24b7f5-1cd6-4a11-ae7d-6cf51ef639b4"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1934), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d93c4342-cb14-4ca7-a8f5-8b48689cb9d5"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1961), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e6bbb9ea-c7c5-46ec-a174-89321cb049f4"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2058), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e7be4659-3d78-46ee-ada0-d8daf6dfc315"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1998), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("eaea5537-8ed7-4503-aa6e-e7d5e8cff0bb"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1955), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f793d715-08c4-4660-bb72-79c135d915fa"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2099), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(356));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanFeatureMatrix");

            migrationBuilder.DropTable(
                name: "UserFeatureAccess");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("096be258-50ae-4078-b0b8-c26a084fd724"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0fd99a93-afb1-4c95-bd45-6cac60d66c95"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("252166cd-7af1-4e13-9307-d49d67174ca0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3ac31a18-ad13-4c36-b48b-809df1accbea"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3ae5fc4a-1802-4e1d-88e1-1a18ec723c68"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3b73270a-83ea-4035-bc71-afcd2712b655"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4a1d7dea-8658-4b83-ab55-3fa7d44acfca"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("58bc10ee-9c29-43f1-91ae-b47c230c074c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5974390a-3569-4e81-844a-eef6252ef7e4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("81b8d4c8-6ce9-45b4-8edf-420e9e7cc508"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ab889393-3213-491e-9a14-22ed8d5e2ec9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cf24b7f5-1cd6-4a11-ae7d-6cf51ef639b4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d93c4342-cb14-4ca7-a8f5-8b48689cb9d5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e6bbb9ea-c7c5-46ec-a174-89321cb049f4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e7be4659-3d78-46ee-ada0-d8daf6dfc315"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("eaea5537-8ed7-4503-aa6e-e7d5e8cff0bb"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f793d715-08c4-4660-bb72-79c135d915fa"));

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
        }
    }
}
