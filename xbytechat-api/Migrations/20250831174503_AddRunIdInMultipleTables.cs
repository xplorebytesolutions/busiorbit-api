using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddRunIdInMultipleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("14fbbc40-25da-4b00-a132-a8c03c8b498a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("15c789d9-758c-436b-a0a8-85c120edd67a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("222a1077-8ca1-4fc0-ade6-ce387fb5f625"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3b9758d8-35b8-44e5-a383-1d25485ca02a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("607f7ef8-fe33-4849-a4a4-a0a6ddb2c246"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("71809198-181e-4ac0-a1cc-d8c326feece3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("71a43703-8f50-47cc-9384-1c4d17563121"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("800eab6e-334f-4b47-b7d7-41ad3669952d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("849a87c9-2820-4191-9d98-b000161f849d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("89f8df7a-6a9c-4c3e-8615-b5e7be00bd9e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8a69bbfd-fc41-42f4-a662-c58b92a47d75"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8f9d9f2a-2e57-41eb-b9f9-f4be4694ce64"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("90b9571e-bb1d-460e-8e9b-8479f36f9da3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a90e2321-faac-419c-bc23-34712c3a064e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c721c541-a487-4a13-a4ac-41f9f881d946"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e17553ac-c13d-408d-830f-263ef6c7d4f8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e4323f3d-7c0b-4cb0-98d2-b9dd8f4274ba"));

            migrationBuilder.AddColumn<Guid>(
                name: "RunId",
                table: "FlowExecutionLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RunId",
                table: "CampaignSendLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RunId",
                table: "CampaignClickLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3164));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3185));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("175680fc-64b6-4c76-b15a-98d7b6fc39f7"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3538), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1908ead2-193f-4ef5-b408-ae44bc41084b"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3619), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("3e553c5b-843a-4e0b-bf42-216778612653"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3578), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("41dee7ea-3cf0-4a35-a5f9-856d122ba68a"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3588), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4945ab25-2bb2-4f2b-822a-86bc67e7cafa"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3607), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("5dc3ce66-5350-4657-bf8b-4885f9235824"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3581), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("66bd78f6-ad55-4034-a60d-2540705ff83a"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3626), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("7a2a1b8a-cdf5-4cd4-955a-d65046c36e89"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3551), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7ca1dc9f-7412-4bf8-bc8b-f8f2b4ff18aa"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3541), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("81070c02-877f-472e-b827-db6bbba33bd2"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3584), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b2ddd2c1-f33e-4983-98bb-9875dd1a5644"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3521), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b635e084-dc9d-45a0-9c15-a26afc5eba7f"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3534), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b9477047-560b-4ad3-bd16-3c0a8300a0ef"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3591), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c9bab964-9b19-4f1e-b699-8dca3c981d22"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3604), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("cbf6ac1b-991c-4079-84f4-e6630c0ab13e"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3600), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("d7a90f87-4926-434b-8d95-3c9e58647c47"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3555), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f62eb640-caa9-4d01-9c9b-7ad79056d586"), new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(3630), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 17, 45, 2, 157, DateTimeKind.Utc).AddTicks(2334));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("175680fc-64b6-4c76-b15a-98d7b6fc39f7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1908ead2-193f-4ef5-b408-ae44bc41084b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3e553c5b-843a-4e0b-bf42-216778612653"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("41dee7ea-3cf0-4a35-a5f9-856d122ba68a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4945ab25-2bb2-4f2b-822a-86bc67e7cafa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5dc3ce66-5350-4657-bf8b-4885f9235824"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("66bd78f6-ad55-4034-a60d-2540705ff83a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7a2a1b8a-cdf5-4cd4-955a-d65046c36e89"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7ca1dc9f-7412-4bf8-bc8b-f8f2b4ff18aa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("81070c02-877f-472e-b827-db6bbba33bd2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b2ddd2c1-f33e-4983-98bb-9875dd1a5644"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b635e084-dc9d-45a0-9c15-a26afc5eba7f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b9477047-560b-4ad3-bd16-3c0a8300a0ef"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c9bab964-9b19-4f1e-b699-8dca3c981d22"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cbf6ac1b-991c-4079-84f4-e6630c0ab13e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d7a90f87-4926-434b-8d95-3c9e58647c47"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f62eb640-caa9-4d01-9c9b-7ad79056d586"));

            migrationBuilder.DropColumn(
                name: "RunId",
                table: "FlowExecutionLogs");

            migrationBuilder.DropColumn(
                name: "RunId",
                table: "CampaignSendLogs");

            migrationBuilder.DropColumn(
                name: "RunId",
                table: "CampaignClickLogs");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3861));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3879));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("14fbbc40-25da-4b00-a132-a8c03c8b498a"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4266), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("15c789d9-758c-436b-a0a8-85c120edd67a"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4317), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("222a1077-8ca1-4fc0-ade6-ce387fb5f625"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4230), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3b9758d8-35b8-44e5-a383-1d25485ca02a"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4259), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("607f7ef8-fe33-4849-a4a4-a0a6ddb2c246"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4255), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("71809198-181e-4ac0-a1cc-d8c326feece3"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4293), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("71a43703-8f50-47cc-9384-1c4d17563121"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4240), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("800eab6e-334f-4b47-b7d7-41ad3669952d"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4271), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("849a87c9-2820-4191-9d98-b000161f849d"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4337), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("89f8df7a-6a9c-4c3e-8615-b5e7be00bd9e"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4313), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("8a69bbfd-fc41-42f4-a662-c58b92a47d75"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4285), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("8f9d9f2a-2e57-41eb-b9f9-f4be4694ce64"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4333), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("90b9571e-bb1d-460e-8e9b-8479f36f9da3"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4325), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("a90e2321-faac-419c-bc23-34712c3a064e"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4309), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("c721c541-a487-4a13-a4ac-41f9f881d946"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4300), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e17553ac-c13d-408d-830f-263ef6c7d4f8"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4288), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e4323f3d-7c0b-4cb0-98d2-b9dd8f4274ba"), new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(4281), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 54, 51, 725, DateTimeKind.Utc).AddTicks(3106));
        }
    }
}
