using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddFlowConext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ButtonBundleJson",
                table: "MessageLogs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlowVersion",
                table: "MessageLogs",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4400));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("30b5f2bf-1a4b-46ea-81fa-bcc4ff03fb7f"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4848), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("456a1d36-b480-4f35-855c-bd941f7efad5"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4909), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("53377700-2e84-4ae2-8111-1615445222f8"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4888), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("53bd445c-fd53-4284-8904-712254274bdf"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4873), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("5f00e094-66b5-4181-a6f3-fbfa57cab06c"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4922), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("6151496e-7b23-4a84-8091-d3f5cdea3343"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4905), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7d85e4ef-65c4-43c9-8211-4cfd148f6513"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4951), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("7de7de7b-2c42-4f59-bdba-e8af3afa52dd"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4869), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7f11a2f1-0554-4e2e-ae95-8c7d43f5af47"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4893), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("892ee30e-97f5-4bb1-bd82-88411471ca87"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4854), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aa91baab-7ed5-4eef-acbc-81dfae94df51"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4859), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ae6a2f12-6c38-45c6-aad3-374123e88e44"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4830), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c3dc1883-2f8a-46b0-a32c-73912d9aa884"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4957), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("c7af55db-9406-429f-bce4-c821358f1174"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4930), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("d38cd84f-260a-4207-b889-8e6501574fa0"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4926), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("d8d5a2a2-848a-4a2e-85d4-9cb3c1394063"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4900), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f4eb61f9-6b9f-4b8b-8fc8-29ba80e877ed"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4942), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3506));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("30b5f2bf-1a4b-46ea-81fa-bcc4ff03fb7f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("456a1d36-b480-4f35-855c-bd941f7efad5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("53377700-2e84-4ae2-8111-1615445222f8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("53bd445c-fd53-4284-8904-712254274bdf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5f00e094-66b5-4181-a6f3-fbfa57cab06c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6151496e-7b23-4a84-8091-d3f5cdea3343"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7d85e4ef-65c4-43c9-8211-4cfd148f6513"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7de7de7b-2c42-4f59-bdba-e8af3afa52dd"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7f11a2f1-0554-4e2e-ae95-8c7d43f5af47"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("892ee30e-97f5-4bb1-bd82-88411471ca87"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa91baab-7ed5-4eef-acbc-81dfae94df51"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ae6a2f12-6c38-45c6-aad3-374123e88e44"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c3dc1883-2f8a-46b0-a32c-73912d9aa884"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c7af55db-9406-429f-bce4-c821358f1174"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d38cd84f-260a-4207-b889-8e6501574fa0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d8d5a2a2-848a-4a2e-85d4-9cb3c1394063"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f4eb61f9-6b9f-4b8b-8fc8-29ba80e877ed"));

            migrationBuilder.DropColumn(
                name: "ButtonBundleJson",
                table: "MessageLogs");

            migrationBuilder.DropColumn(
                name: "FlowVersion",
                table: "MessageLogs");

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
    }
}
