using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddFlowBundleToCampaignSendLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("05c967d4-7fa1-4bec-8173-555e5c8a8861"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1299168e-44ff-471c-96ab-d1134f24f065"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("145866db-c47d-4f34-b94c-4a3f05266a4e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1b2311f0-e0ec-4dcb-8d2b-b4f8390be4a9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("28b888f9-2110-4ff6-8ea2-47d84ad9c8d8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2ecdbe3f-f8a7-44d9-ad36-d3b7c662b822"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4a6b7dc5-e439-478f-8999-64ddfe78d3e6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6a875da8-0748-4b4e-9474-f8d16e14af1b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7a1c1613-1fd9-41e5-8f59-ded6e694dde2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7efdc0fc-3591-48fa-9a6a-c1d0f6bf2084"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("80d3ef51-499f-45e0-8e3d-2d14fc777a51"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("98b8d40d-7f6b-463c-9639-d63a7c359a61"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aea64726-ea39-438f-848c-6a93748ab62f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b934bf7c-cd8f-4a44-8729-56beec734e5d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bea4c24b-120b-4a67-ba16-23de7b8a649d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c8d082d6-3928-4f7e-86da-b676a7d9901d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("efe8ca11-c7bb-4eb0-85c0-6da00a0ba58c"));

            migrationBuilder.AddColumn<string>(
                name: "ButtonBundleJson",
                table: "CampaignSendLogs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CTAFlowConfigId",
                table: "CampaignSendLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CTAFlowStepId",
                table: "CampaignSendLogs",
                type: "uuid",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ButtonBundleJson",
                table: "CampaignSendLogs");

            migrationBuilder.DropColumn(
                name: "CTAFlowConfigId",
                table: "CampaignSendLogs");

            migrationBuilder.DropColumn(
                name: "CTAFlowStepId",
                table: "CampaignSendLogs");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("05c967d4-7fa1-4bec-8173-555e5c8a8861"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9607), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("1299168e-44ff-471c-96ab-d1134f24f065"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9562), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("145866db-c47d-4f34-b94c-4a3f05266a4e"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9572), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1b2311f0-e0ec-4dcb-8d2b-b4f8390be4a9"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9520), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("28b888f9-2110-4ff6-8ea2-47d84ad9c8d8"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9587), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2ecdbe3f-f8a7-44d9-ad36-d3b7c662b822"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9568), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4a6b7dc5-e439-478f-8999-64ddfe78d3e6"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9542), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6a875da8-0748-4b4e-9474-f8d16e14af1b"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9582), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("7a1c1613-1fd9-41e5-8f59-ded6e694dde2"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9555), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7efdc0fc-3591-48fa-9a6a-c1d0f6bf2084"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9525), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("80d3ef51-499f-45e0-8e3d-2d14fc777a51"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9590), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("98b8d40d-7f6b-463c-9639-d63a7c359a61"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9558), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aea64726-ea39-438f-848c-6a93748ab62f"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9501), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b934bf7c-cd8f-4a44-8729-56beec734e5d"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9530), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("bea4c24b-120b-4a67-ba16-23de7b8a649d"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9536), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c8d082d6-3928-4f7e-86da-b676a7d9901d"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9610), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("efe8ca11-c7bb-4eb0-85c0-6da00a0ba58c"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9599), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8472));
        }
    }
}
