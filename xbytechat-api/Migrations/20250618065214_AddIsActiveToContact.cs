using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("079e80c6-323c-4a08-94a2-51bd604f4929"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("37eabfd6-e9f8-498f-8532-d7dd7a3b80d7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3b9748e5-b4e1-4d9d-a962-71caa9954a8b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3c4ce25c-0e01-417e-9449-eb52371f8166"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("47f15563-8f8a-4072-8654-c8b497de1ee6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("55ec2d92-e5c7-4bf0-9fe9-3e2125e972b6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6a15f715-fffc-4731-aedc-c905efaa8f37"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7dbca6d5-8cb2-44ef-a4b8-4c74bbe632bd"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("818c1856-92a1-4791-bf0e-3f4b9d19a694"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("925fabe1-5550-4418-9b2b-2e841f8fd598"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b4438d9f-0f6c-4d90-8876-f8e5f44277ce"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c37fb295-55f6-4864-bce6-15fef6a141b4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e1f27aa9-0113-4c6c-92ee-dad1416bfc20"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e97935dc-a48a-4b8f-9cf6-985a2838e269"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("eebb40df-29d7-48cb-991c-97bc78fde2fa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f085246d-dd95-4ef7-9c6b-03079155e299"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fae4e29c-e7a3-41e7-a591-e54220d55e51"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Contacts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1727));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1737));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("079e80c6-323c-4a08-94a2-51bd604f4929"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2209), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("37eabfd6-e9f8-498f-8532-d7dd7a3b80d7"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2225), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3b9748e5-b4e1-4d9d-a962-71caa9954a8b"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2202), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3c4ce25c-0e01-417e-9449-eb52371f8166"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2257), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("47f15563-8f8a-4072-8654-c8b497de1ee6"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2248), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("55ec2d92-e5c7-4bf0-9fe9-3e2125e972b6"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2217), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6a15f715-fffc-4731-aedc-c905efaa8f37"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2213), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7dbca6d5-8cb2-44ef-a4b8-4c74bbe632bd"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2186), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("818c1856-92a1-4791-bf0e-3f4b9d19a694"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2253), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("925fabe1-5550-4418-9b2b-2e841f8fd598"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2192), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b4438d9f-0f6c-4d90-8876-f8e5f44277ce"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2271), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("c37fb295-55f6-4864-bce6-15fef6a141b4"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2281), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("e1f27aa9-0113-4c6c-92ee-dad1416bfc20"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2221), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e97935dc-a48a-4b8f-9cf6-985a2838e269"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2285), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("eebb40df-29d7-48cb-991c-97bc78fde2fa"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2234), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f085246d-dd95-4ef7-9c6b-03079155e299"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2156), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fae4e29c-e7a3-41e7-a591-e54220d55e51"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2167), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(856));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(862));
        }
    }
}
