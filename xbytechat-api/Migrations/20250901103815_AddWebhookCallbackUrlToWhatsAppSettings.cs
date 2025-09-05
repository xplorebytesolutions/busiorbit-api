using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddWebhookCallbackUrlToWhatsAppSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1ae45d84-0cde-4632-b6c3-2527ebbab044"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2514f9a9-1334-4061-ad94-069608e2ce53"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3c0eb240-c8a4-4adc-92f5-bb83340c434e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3e0d5b7b-70f8-4815-b17e-ee4094bc4050"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("493cf64d-c45f-47b4-8519-8532524de1ed"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("49de9186-d69f-4933-94b8-178510e3ea53"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("60c22265-ec09-4861-8e1f-82f34b3ef518"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6ad65d51-1a54-4f17-9579-07befea5231e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("82010b83-3c8e-4f41-9f30-7266da3544c5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("857ad4d9-030e-421e-a739-fbf21e7ec5e6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b5a4e475-06f6-427e-a87a-083d20134934"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b89d7e5e-61f2-4580-94f9-3c9046d15780"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ba005e1b-11c6-44b0-9c46-4c209f6e4859"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ba61fbb0-e2b2-4ed8-ac54-4f956feed964"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c19bdda7-a1c2-4c68-a6d0-a7d7fe3ac521"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c6ff97ba-10c6-4797-99f4-6d09e4549766"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f29eb261-56c5-4ef1-b0f2-ebdbd0f31df8"));

            migrationBuilder.AddColumn<string>(
                name: "WebhookCallbackUrl",
                table: "WhatsAppSettings",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

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
                name: "IX_WhatsAppSettings_Provider_CallbackUrl",
                table: "WhatsAppSettings",
                columns: new[] { "Provider", "WebhookCallbackUrl" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WhatsAppSettings_Provider_CallbackUrl",
                table: "WhatsAppSettings");

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

            migrationBuilder.DropColumn(
                name: "WebhookCallbackUrl",
                table: "WhatsAppSettings");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8019));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1ae45d84-0cde-4632-b6c3-2527ebbab044"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8544), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2514f9a9-1334-4061-ad94-069608e2ce53"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8529), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3c0eb240-c8a4-4adc-92f5-bb83340c434e"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8547), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("3e0d5b7b-70f8-4815-b17e-ee4094bc4050"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8423), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("493cf64d-c45f-47b4-8519-8532524de1ed"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8407), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("49de9186-d69f-4933-94b8-178510e3ea53"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8446), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("60c22265-ec09-4861-8e1f-82f34b3ef518"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8526), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6ad65d51-1a54-4f17-9579-07befea5231e"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8559), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("82010b83-3c8e-4f41-9f30-7266da3544c5"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8414), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("857ad4d9-030e-421e-a739-fbf21e7ec5e6"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8565), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("b5a4e475-06f6-427e-a87a-083d20134934"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8419), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b89d7e5e-61f2-4580-94f9-3c9046d15780"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8431), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ba005e1b-11c6-44b0-9c46-4c209f6e4859"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8540), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("ba61fbb0-e2b2-4ed8-ac54-4f956feed964"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8551), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("c19bdda7-a1c2-4c68-a6d0-a7d7fe3ac521"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8426), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c6ff97ba-10c6-4797-99f4-6d09e4549766"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8449), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f29eb261-56c5-4ef1-b0f2-ebdbd0f31df8"), new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(8456), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(7219));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 9, 8, 0, 484, DateTimeKind.Utc).AddTicks(7227));
        }
    }
}
