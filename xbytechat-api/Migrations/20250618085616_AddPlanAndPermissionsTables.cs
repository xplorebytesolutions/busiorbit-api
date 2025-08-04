using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanAndPermissionsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("02764f80-8341-4f65-9ba0-4a9a82c3d02c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1ad951a6-4970-42e7-94b1-5b96729f870d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1ca2458f-1612-464a-9bcc-1c133f15053b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("24e2cfbb-0475-407a-aed2-436393a916e4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2aa6096a-a2e5-430a-a871-b9d93358204d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("30bbab7e-d3ca-4113-928a-ce20506fb542"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("33993d87-cdc5-44b7-bbdd-8285317b7a68"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6485bf8f-a5cc-48a0-8a30-0b5f0742387a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7dbef1b0-e4f0-4e02-87e1-43e9a1612515"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("82df3d2a-da23-44d4-9b14-5d61bcf4de91"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("88d10a1c-6dc1-4bf1-aab7-6be6f4962c4d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("954fd0fe-c5fe-4f83-81b3-8a3ae1ec1015"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa51357f-8f50-4c23-a15e-f2a446a70db8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d9d64c9b-37f4-4d59-b835-288a424c40cb"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dbdb282e-add5-46fd-ad64-3545858ecae9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e41905a0-52b8-48a4-87dc-36e8b21f9937"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fa3591be-aeee-47ee-aeb7-983b168ab174"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("003843fd-8c1e-48ca-b835-204f1bd45d70"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7100), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("14e55de6-27a2-4628-936b-b69ba64abda9"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7153), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2564bb32-540e-454a-b685-b7f24c341fa7"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7115), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("39cdceb8-6001-45db-aeea-c39f35f9b6ac"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7068), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("46549846-d2a6-47d1-8166-203b5b8c9033"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7167), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("613a89f2-84ba-462a-8c70-8749baf7f5cf"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7138), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("63c8311f-bd99-4511-8832-d2290f88f672"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7095), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6555c2bd-fc8d-4f45-abb2-c92de944216e"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7074), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6ab149de-62f7-4207-8a09-5e49252b1635"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7120), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6f3808e5-4643-448a-8ea6-672acab61a4b"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7162), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("91c81b3d-49f0-4ccb-b9fc-4afb84755e05"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7105), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aa2fcb6f-93b6-42b5-af4a-bcaf1da0e724"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7134), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("b06e50ad-f1ff-4f90-b44d-c440be8dc23c"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7084), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("bef317da-6e28-43f1-99c9-d1e7d7734ccf"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7090), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d361b7d0-0308-4e2c-b12b-0715b7a86887"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6976), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("dcfb4546-1ec5-4842-af11-0e127094e50b"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7142), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("ea9e2321-7062-4390-97dc-a6f0cfd92988"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7000), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4978));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("003843fd-8c1e-48ca-b835-204f1bd45d70"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("14e55de6-27a2-4628-936b-b69ba64abda9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2564bb32-540e-454a-b685-b7f24c341fa7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("39cdceb8-6001-45db-aeea-c39f35f9b6ac"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("46549846-d2a6-47d1-8166-203b5b8c9033"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("613a89f2-84ba-462a-8c70-8749baf7f5cf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("63c8311f-bd99-4511-8832-d2290f88f672"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6555c2bd-fc8d-4f45-abb2-c92de944216e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6ab149de-62f7-4207-8a09-5e49252b1635"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6f3808e5-4643-448a-8ea6-672acab61a4b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("91c81b3d-49f0-4ccb-b9fc-4afb84755e05"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa2fcb6f-93b6-42b5-af4a-bcaf1da0e724"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b06e50ad-f1ff-4f90-b44d-c440be8dc23c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bef317da-6e28-43f1-99c9-d1e7d7734ccf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d361b7d0-0308-4e2c-b12b-0715b7a86887"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dcfb4546-1ec5-4842-af11-0e127094e50b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ea9e2321-7062-4390-97dc-a6f0cfd92988"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8550));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("02764f80-8341-4f65-9ba0-4a9a82c3d02c"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9295), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("1ad951a6-4970-42e7-94b1-5b96729f870d"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9298), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("1ca2458f-1612-464a-9bcc-1c133f15053b"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9250), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("24e2cfbb-0475-407a-aed2-436393a916e4"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9254), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2aa6096a-a2e5-430a-a871-b9d93358204d"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9257), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("30bbab7e-d3ca-4113-928a-ce20506fb542"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9270), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("33993d87-cdc5-44b7-bbdd-8285317b7a68"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9247), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6485bf8f-a5cc-48a0-8a30-0b5f0742387a"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9288), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("7dbef1b0-e4f0-4e02-87e1-43e9a1612515"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9244), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("82df3d2a-da23-44d4-9b14-5d61bcf4de91"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8861), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("88d10a1c-6dc1-4bf1-aab7-6be6f4962c4d"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9220), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("954fd0fe-c5fe-4f83-81b3-8a3ae1ec1015"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9278), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("aa51357f-8f50-4c23-a15e-f2a446a70db8"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8849), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d9d64c9b-37f4-4d59-b835-288a424c40cb"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8865), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("dbdb282e-add5-46fd-ad64-3545858ecae9"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(8857), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e41905a0-52b8-48a4-87dc-36e8b21f9937"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9274), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("fa3591be-aeee-47ee-aeb7-983b168ab174"), new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(9230), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 6, 52, 13, 690, DateTimeKind.Utc).AddTicks(7874));
        }
    }
}
