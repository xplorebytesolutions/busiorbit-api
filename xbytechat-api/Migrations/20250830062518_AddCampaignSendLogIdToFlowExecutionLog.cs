using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaignSendLogIdToFlowExecutionLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "CampaignSendLogId",
                table: "FlowExecutionLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7601));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(7630));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("047dbde8-fdf6-4403-9c76-0fe7b418d321"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8115), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("065ac699-cea3-4898-b0a0-7a5909c376ea"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8177), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("0ba8cd7f-eb07-4280-9fcf-61cf6d500fb4"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8073), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1077f8ea-50a3-4dc3-a09d-cad00273870a"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8174), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("24cf6f02-4e98-4fe2-a953-efbbbb434b77"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8050), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("49f3207d-fd0c-4543-8009-4af0b1f579a3"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8132), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("762c16a1-4238-42af-a644-8e81a931f0db"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8111), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7b4051a5-c3a0-4b06-9050-8207cdd221d1"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8081), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("8080f528-3555-4011-96c4-024e874dadd5"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8044), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("9157f2a5-8e6b-4d9f-b52f-3baed50c2bd0"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8123), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("9b282071-e71a-4ae9-9251-45a099d8617a"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8107), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b31d1088-6dbb-4f12-9c80-7de5607597d9"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8166), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("c77f3306-94fd-4a26-bed8-a345e09e5ad5"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8144), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("dcb31066-a673-4baf-8370-36f07c13e37b"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8093), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e69d2504-0139-49e7-9627-a5debd1982f1"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8120), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e6a13986-7cf4-4ba7-9364-e07f58670f77"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8137), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("f93f8497-1767-4fbe-a987-f52dc88b204f"), new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(8069), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(6871));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(6874));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(6875));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 6, 25, 17, 368, DateTimeKind.Utc).AddTicks(6877));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("047dbde8-fdf6-4403-9c76-0fe7b418d321"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("065ac699-cea3-4898-b0a0-7a5909c376ea"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0ba8cd7f-eb07-4280-9fcf-61cf6d500fb4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1077f8ea-50a3-4dc3-a09d-cad00273870a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("24cf6f02-4e98-4fe2-a953-efbbbb434b77"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("49f3207d-fd0c-4543-8009-4af0b1f579a3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("762c16a1-4238-42af-a644-8e81a931f0db"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7b4051a5-c3a0-4b06-9050-8207cdd221d1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8080f528-3555-4011-96c4-024e874dadd5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9157f2a5-8e6b-4d9f-b52f-3baed50c2bd0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9b282071-e71a-4ae9-9251-45a099d8617a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b31d1088-6dbb-4f12-9c80-7de5607597d9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c77f3306-94fd-4a26-bed8-a345e09e5ad5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dcb31066-a673-4baf-8370-36f07c13e37b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e69d2504-0139-49e7-9627-a5debd1982f1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e6a13986-7cf4-4ba7-9364-e07f58670f77"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f93f8497-1767-4fbe-a987-f52dc88b204f"));

            migrationBuilder.DropColumn(
                name: "CampaignSendLogId",
                table: "FlowExecutionLogs");

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
        }
    }
}
