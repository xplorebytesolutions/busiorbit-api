using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("07503bb5-f5a3-48e0-916c-6310c7e132d6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0c898220-4231-4723-9bbf-304fe6447cd0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0e6bd3b2-5056-4cc3-97fd-a11e4e1e4a3e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1198345c-c96c-44d4-9602-3d5382ea69c2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2af188d1-7bd2-4eda-bc94-aea97e80d16e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3a30a452-7f8c-4d6a-92f0-971393a2b3c5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4283079b-7d1f-4184-bd9d-5341d110b461"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7504e744-8b7a-4422-8cc2-287e3d771041"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7f7bc705-2d45-43cc-815c-a8889a123721"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9e2c8d5b-dc26-449d-b0bd-be663e09e61c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a3f6f36e-4aa6-4a3f-ba9b-3205bc918f14"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b25ff30e-10d9-4b9d-bf52-30c92e49d3a7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c8729359-8505-47ca-b4fc-5e80ce84e4c7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cd29166e-6d07-4f88-bcac-b52eba3e40c8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cdcd8d38-dbbc-49ee-a39d-026fa25f1eea"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e837feae-a731-4ab4-98d0-5441b93ed285"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff6899d1-69ff-4245-949c-2446bcf28ff4"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "UserFeatureAccess",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FeatureAccess",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "FeatureAccess",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9629));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0574c0c9-3f81-428d-af3a-d2a90fb35b8e"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(111), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("08344dd6-c032-4918-a5ed-145f085617e0"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(101), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2dc90489-89ac-4877-b0df-869a7bf893ed"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(31), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3313278a-881c-4bb0-932f-adb0ef4f960e"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(106), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("389c40b7-c1a8-4933-9b22-7a13099641e6"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(134), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("3f057e7a-e29b-4ca9-932b-6f5700c26eda"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(85), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("623c923e-ed8a-40e1-bdf2-75beadd7c3fd"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(77), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6fd53fe6-6790-4c93-9193-e40732e38797"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(137), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("76b5616e-cf3f-4a28-b434-a75380fa86a5"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(89), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7eae3e11-c8fb-4870-a688-1eb0b69f3fe6"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(52), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("90235fca-ea3a-4d87-9843-8120d6a248aa"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(56), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a3ff4e6d-c3db-47d0-8d5a-dc05a868bd21"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(23), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b5fa27ec-9cba-4d9e-9e7b-1914c6a1be5c"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(35), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b60da824-36e3-40c6-9dcc-254786b056d7"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(73), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c7ceb1c9-1bcf-41fc-8be3-5bb894ecd502"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(126), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("f50a2419-dcfa-42e1-9b5f-feed5cb19d55"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(39), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fc083ff6-22d7-45ff-a2ea-db995bf3634e"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(81), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8747));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0574c0c9-3f81-428d-af3a-d2a90fb35b8e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("08344dd6-c032-4918-a5ed-145f085617e0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2dc90489-89ac-4877-b0df-869a7bf893ed"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3313278a-881c-4bb0-932f-adb0ef4f960e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("389c40b7-c1a8-4933-9b22-7a13099641e6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3f057e7a-e29b-4ca9-932b-6f5700c26eda"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("623c923e-ed8a-40e1-bdf2-75beadd7c3fd"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6fd53fe6-6790-4c93-9193-e40732e38797"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("76b5616e-cf3f-4a28-b434-a75380fa86a5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7eae3e11-c8fb-4870-a688-1eb0b69f3fe6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("90235fca-ea3a-4d87-9843-8120d6a248aa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a3ff4e6d-c3db-47d0-8d5a-dc05a868bd21"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b5fa27ec-9cba-4d9e-9e7b-1914c6a1be5c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b60da824-36e3-40c6-9dcc-254786b056d7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c7ceb1c9-1bcf-41fc-8be3-5bb894ecd502"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f50a2419-dcfa-42e1-9b5f-feed5cb19d55"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fc083ff6-22d7-45ff-a2ea-db995bf3634e"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "UserFeatureAccess");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FeatureAccess");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "FeatureAccess");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("07503bb5-f5a3-48e0-916c-6310c7e132d6"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5306), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("0c898220-4231-4723-9bbf-304fe6447cd0"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5272), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("0e6bd3b2-5056-4cc3-97fd-a11e4e1e4a3e"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5212), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1198345c-c96c-44d4-9602-3d5382ea69c2"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5226), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2af188d1-7bd2-4eda-bc94-aea97e80d16e"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5260), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3a30a452-7f8c-4d6a-92f0-971393a2b3c5"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5255), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4283079b-7d1f-4184-bd9d-5341d110b461"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5279), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("7504e744-8b7a-4422-8cc2-287e3d771041"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5310), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("7f7bc705-2d45-43cc-815c-a8889a123721"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5295), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("9e2c8d5b-dc26-449d-b0bd-be663e09e61c"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5235), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a3f6f36e-4aa6-4a3f-ba9b-3205bc918f14"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5253), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b25ff30e-10d9-4b9d-bf52-30c92e49d3a7"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5263), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c8729359-8505-47ca-b4fc-5e80ce84e4c7"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5203), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cd29166e-6d07-4f88-bcac-b52eba3e40c8"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5231), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cdcd8d38-dbbc-49ee-a39d-026fa25f1eea"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5195), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e837feae-a731-4ab4-98d0-5441b93ed285"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5217), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ff6899d1-69ff-4245-949c-2446bcf28ff4"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5276), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3875));
        }
    }
}
