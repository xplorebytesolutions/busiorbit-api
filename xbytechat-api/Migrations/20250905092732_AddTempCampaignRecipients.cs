using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddTempCampaignRecipients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_BusinessId",
                table: "Contacts");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0073ea73-c2d5-4679-ab78-cda18e2eab6f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("00ba56c9-71d4-44d0-9529-b6f53ebc0b7c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0c814de9-985c-4fb3-90a6-777c5538de91"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("308f3478-698c-4779-9d25-ec0aff94cc25"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3e7b1aaa-d33c-4b6f-9aec-1f3edcb6b426"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4870be49-980d-495d-8c26-5b263b9a8188"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("53b2fc1f-0ba5-4053-87ea-2c99d2c17c22"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("72823a3b-a9a7-4f71-bdf8-b450c08af43c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("74c0ff83-f56e-4735-a8cc-57572f4face0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7ef39c05-5a80-487c-a31e-63a68097dd55"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9c651876-1a7d-4ced-9681-0fdf91ec7551"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a0e52671-9c2c-4b9e-99e3-9a0413d1d2df"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a52d3157-57ec-42ff-ab25-5bb631a27938"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ae246d13-4193-4bbb-95fc-6214de0a35c4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b1f60bcc-9ab3-4d7a-976e-b3cab320921c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cf0c978a-d62d-4606-a6a6-9bf7892461ba"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dc9756aa-b639-4046-bfb2-b6ebd33d16f3"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4078));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4099));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("08200e68-9680-421b-8db3-5e2a1f6eef44"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4430), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1894ac73-191b-484c-a212-5cb2fdf301db"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4485), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2dee7d22-df75-48a3-9b56-1f95c0bf045e"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4470), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2ffdeaee-f441-4e38-b1fd-e5db246aef89"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4422), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("5e026cb6-cd81-4cc8-867a-1426461901c2"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4417), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("70efee96-7da6-4cb5-a10d-a4ded48e54b3"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4502), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("72fc396b-8e15-4f92-841e-9263bd8f3615"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4487), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("85acdf98-8bf9-4705-b2ba-2cedc515964b"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4499), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("a4a429be-44f7-4915-a695-cb99f5b44577"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4461), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aa17a813-6633-43e5-a94d-bd13765dd99c"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4468), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("af487bd4-2ec5-4576-ada7-aa1f09443d2c"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4427), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b8a134c7-68ef-42c2-bcf4-05f8315159a3"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4434), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c85c9078-775a-4c6b-a1b2-de056dce99e5"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4409), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("dcc405a6-68c4-419f-ac31-fd1126ca8115"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4491), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("ebce9383-cf87-4ad8-87b8-2d1b0c60bdf4"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4480), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("ee2cd491-064d-41bd-b612-9ac5b1583619"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4465), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ff90735c-979a-4bb6-972d-8743149eb727"), new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(4449), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 9, 27, 32, 93, DateTimeKind.Utc).AddTicks(3410));

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BusinessId_PhoneNumber",
                table: "Contacts",
                columns: new[] { "BusinessId", "PhoneNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_BusinessId_PhoneNumber",
                table: "Contacts");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("08200e68-9680-421b-8db3-5e2a1f6eef44"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1894ac73-191b-484c-a212-5cb2fdf301db"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2dee7d22-df75-48a3-9b56-1f95c0bf045e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2ffdeaee-f441-4e38-b1fd-e5db246aef89"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5e026cb6-cd81-4cc8-867a-1426461901c2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("70efee96-7da6-4cb5-a10d-a4ded48e54b3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("72fc396b-8e15-4f92-841e-9263bd8f3615"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("85acdf98-8bf9-4705-b2ba-2cedc515964b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a4a429be-44f7-4915-a695-cb99f5b44577"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa17a813-6633-43e5-a94d-bd13765dd99c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("af487bd4-2ec5-4576-ada7-aa1f09443d2c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b8a134c7-68ef-42c2-bcf4-05f8315159a3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c85c9078-775a-4c6b-a1b2-de056dce99e5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dcc405a6-68c4-419f-ac31-fd1126ca8115"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ebce9383-cf87-4ad8-87b8-2d1b0c60bdf4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ee2cd491-064d-41bd-b612-9ac5b1583619"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff90735c-979a-4bb6-972d-8743149eb727"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0073ea73-c2d5-4679-ab78-cda18e2eab6f"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6512), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00ba56c9-71d4-44d0-9529-b6f53ebc0b7c"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6421), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("0c814de9-985c-4fb3-90a6-777c5538de91"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6416), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("308f3478-698c-4779-9d25-ec0aff94cc25"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6404), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3e7b1aaa-d33c-4b6f-9aec-1f3edcb6b426"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6430), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4870be49-980d-495d-8c26-5b263b9a8188"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6525), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("53b2fc1f-0ba5-4053-87ea-2c99d2c17c22"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6437), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("72823a3b-a9a7-4f71-bdf8-b450c08af43c"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6381), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("74c0ff83-f56e-4735-a8cc-57572f4face0"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6351), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7ef39c05-5a80-487c-a31e-63a68097dd55"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6386), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("9c651876-1a7d-4ced-9681-0fdf91ec7551"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6363), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a0e52671-9c2c-4b9e-99e3-9a0413d1d2df"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6507), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("a52d3157-57ec-42ff-ab25-5bb631a27938"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6424), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ae246d13-4193-4bbb-95fc-6214de0a35c4"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6536), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("b1f60bcc-9ab3-4d7a-976e-b3cab320921c"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6397), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cf0c978a-d62d-4606-a6a6-9bf7892461ba"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6540), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("dc9756aa-b639-4046-bfb2-b6ebd33d16f3"), new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(6451), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 10, 38, 13, 787, DateTimeKind.Utc).AddTicks(3761));

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BusinessId",
                table: "Contacts",
                column: "BusinessId");
        }
    }
}
