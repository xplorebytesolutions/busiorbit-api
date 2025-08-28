using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddClickTypeToCampaignClickLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CampaignClickLogs_CampaignId_ClickedAt",
                table: "CampaignClickLogs");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("003b2812-380b-4a58-9f2d-9577ab36ad76"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("07e64791-e560-40ce-8a9b-126a992a120b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("19e2e6a3-a550-452f-ae36-37ec40e0a283"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1b8b28ef-e6f9-4690-86aa-f80d5460b07e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("445a92bb-19db-4352-9aa4-5914955c97a1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("489ef7d5-b71d-4a02-b3a4-7bf12a13b1e5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("572f5c50-07f4-4c6d-bc2d-0fddc6f61195"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7354d012-cf16-4483-b962-bfe8303390ca"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("77f6d854-dd7e-4f4f-9c25-b5c997a5da59"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9825c18c-79a3-4497-9b88-cde86dac53bc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a963d99a-e0f0-4227-a23b-6b8102a42e85"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d38ad21b-fe63-4f08-88f3-46ff18dc79bf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dfe0750e-e8d3-440e-aca2-5f91a544bfa5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e1ffdfc3-f696-4e41-9e04-5ed1277c20f9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ef4d7145-7602-46db-978b-631bdaffd701"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f6c9b11f-e746-472c-bfb1-0cbf76edf4e1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fdfafbdb-20b2-47b7-9f91-9a7e0669921d"));

            migrationBuilder.AddColumn<string>(
                name: "ClickType",
                table: "CampaignClickLogs",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9672));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0124132b-d34c-481d-a733-f6dd64c02568"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(62), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("04272662-2142-4346-9b04-c829f44058c0"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(80), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("0eb801e8-842e-411a-b95f-a352fcf6f89f"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(34), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("31e684d2-b12c-4029-9a50-85be6a18192f"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(56), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3e68fda3-767b-4cd0-95e0-c0126ad39669"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(22), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3ed30a59-5fe8-4f34-b92d-2eae6c19f8d1"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(68), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("484e51a8-4f56-417f-a95e-93ff61033886"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(52), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6425b294-7571-49b8-a47b-3e86df106956"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(83), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("65070bb1-fdac-4ccf-bbaa-81f9e30f03da"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(30), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("711f93f3-c6c3-4ae8-aa24-c4e573361755"), new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9989), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("74db2ccd-a7d7-4902-920d-1639fcaa3961"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(104), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("8e9f8211-1766-4008-b7b9-015eb334c308"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(77), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("9b720fb7-0f64-4dd9-95ee-4bcb4decfb6c"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(99), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("bc7cd27e-85f4-4e86-8a26-bd4e0ab10373"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(93), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("c160a6c7-07a8-47e0-ac39-637b35a53e59"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(59), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("db725e4c-7bc0-4a65-a537-65f46fb0048d"), new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(9997), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("efaed2b9-bf79-4f15-a633-f25f65f1b9ab"), new DateTime(2025, 8, 28, 7, 50, 38, 605, DateTimeKind.Utc).AddTicks(17), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 7, 50, 38, 604, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.CreateIndex(
                name: "IX_CampaignClickLogs_CampaignId_ClickType_ClickedAt",
                table: "CampaignClickLogs",
                columns: new[] { "CampaignId", "ClickType", "ClickedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CampaignClickLogs_CampaignId_ClickType_ClickedAt",
                table: "CampaignClickLogs");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0124132b-d34c-481d-a733-f6dd64c02568"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("04272662-2142-4346-9b04-c829f44058c0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0eb801e8-842e-411a-b95f-a352fcf6f89f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("31e684d2-b12c-4029-9a50-85be6a18192f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3e68fda3-767b-4cd0-95e0-c0126ad39669"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3ed30a59-5fe8-4f34-b92d-2eae6c19f8d1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("484e51a8-4f56-417f-a95e-93ff61033886"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6425b294-7571-49b8-a47b-3e86df106956"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("65070bb1-fdac-4ccf-bbaa-81f9e30f03da"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("711f93f3-c6c3-4ae8-aa24-c4e573361755"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("74db2ccd-a7d7-4902-920d-1639fcaa3961"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8e9f8211-1766-4008-b7b9-015eb334c308"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9b720fb7-0f64-4dd9-95ee-4bcb4decfb6c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bc7cd27e-85f4-4e86-8a26-bd4e0ab10373"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c160a6c7-07a8-47e0-ac39-637b35a53e59"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("db725e4c-7bc0-4a65-a537-65f46fb0048d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("efaed2b9-bf79-4f15-a633-f25f65f1b9ab"));

            migrationBuilder.DropColumn(
                name: "ClickType",
                table: "CampaignClickLogs");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("003b2812-380b-4a58-9f2d-9577ab36ad76"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7324), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("07e64791-e560-40ce-8a9b-126a992a120b"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7367), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("19e2e6a3-a550-452f-ae36-37ec40e0a283"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7395), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("1b8b28ef-e6f9-4690-86aa-f80d5460b07e"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7371), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("445a92bb-19db-4352-9aa4-5914955c97a1"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7356), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("489ef7d5-b71d-4a02-b3a4-7bf12a13b1e5"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7393), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("572f5c50-07f4-4c6d-bc2d-0fddc6f61195"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7347), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7354d012-cf16-4483-b962-bfe8303390ca"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7352), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("77f6d854-dd7e-4f4f-9c25-b5c997a5da59"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7343), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("9825c18c-79a3-4497-9b88-cde86dac53bc"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7387), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("a963d99a-e0f0-4227-a23b-6b8102a42e85"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7379), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d38ad21b-fe63-4f08-88f3-46ff18dc79bf"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7369), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("dfe0750e-e8d3-440e-aca2-5f91a544bfa5"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7390), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("e1ffdfc3-f696-4e41-9e04-5ed1277c20f9"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7377), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ef4d7145-7602-46db-978b-631bdaffd701"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7350), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f6c9b11f-e746-472c-bfb1-0cbf76edf4e1"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7400), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("fdfafbdb-20b2-47b7-9f91-9a7e0669921d"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7403), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6035));

            migrationBuilder.CreateIndex(
                name: "IX_CampaignClickLogs_CampaignId_ClickedAt",
                table: "CampaignClickLogs",
                columns: new[] { "CampaignId", "ClickedAt" });
        }
    }
}
