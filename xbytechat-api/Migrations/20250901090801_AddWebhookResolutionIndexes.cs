using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddWebhookResolutionIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MessageLogs_BusinessId",
                table: "MessageLogs");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("01cc914d-0166-43cb-ac34-4d86c143b5a1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1673849e-1a35-45ef-99bc-c2714c8c2c54"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1c472684-79be-432f-908c-80d4b12dfa8f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2443a874-9924-4b94-928c-ff33bbb17376"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("278e527b-1749-4672-88a8-8b0391556b4f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2833217d-0988-4c78-9838-8d2e94c87668"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("767ffebf-a490-4d8c-8f7e-bb05fb2fd071"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7cbcece2-1080-48a7-a386-1657335518e2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("83d15d08-cf44-49d0-9315-bc49832c8496"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8c6863c4-cfbe-460e-8deb-af11eb909763"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("931f83f1-ee94-43fc-9844-6513ae50db64"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b144c403-d4b7-4db4-ad86-83d3d7e2adb1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b29d7cbb-8e69-47ba-af3c-1d5533b44ca7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bd09481f-9202-46b8-a8f0-51f9df74be0c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d988a214-5ee1-4ae8-821e-7423c3ef9200"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ebff8fce-64bb-4adc-aff9-6658c4eb1160"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fe1dad12-9253-4dc3-bd0d-e5a30534f517"));

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

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppSettings_Business_Provider_IsActive",
                table: "WhatsAppSettings",
                columns: new[] { "BusinessId", "Provider", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppSettings_Provider_BusinessNumber",
                table: "WhatsAppSettings",
                columns: new[] { "Provider", "WhatsAppBusinessNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppSettings_Provider_PhoneNumberId",
                table: "WhatsAppSettings",
                columns: new[] { "Provider", "PhoneNumberId" });

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppSettings_Provider_WabaId",
                table: "WhatsAppSettings",
                columns: new[] { "Provider", "WabaId" });

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_Business_MessageId",
                table: "MessageLogs",
                columns: new[] { "BusinessId", "MessageId" });

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_Business_Recipient",
                table: "MessageLogs",
                columns: new[] { "BusinessId", "RecipientNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSendLogs_Business_MessageId",
                table: "CampaignSendLogs",
                columns: new[] { "BusinessId", "MessageId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WhatsAppSettings_Business_Provider_IsActive",
                table: "WhatsAppSettings");

            migrationBuilder.DropIndex(
                name: "IX_WhatsAppSettings_Provider_BusinessNumber",
                table: "WhatsAppSettings");

            migrationBuilder.DropIndex(
                name: "IX_WhatsAppSettings_Provider_PhoneNumberId",
                table: "WhatsAppSettings");

            migrationBuilder.DropIndex(
                name: "IX_WhatsAppSettings_Provider_WabaId",
                table: "WhatsAppSettings");

            migrationBuilder.DropIndex(
                name: "IX_MessageLogs_Business_MessageId",
                table: "MessageLogs");

            migrationBuilder.DropIndex(
                name: "IX_MessageLogs_Business_Recipient",
                table: "MessageLogs");

            migrationBuilder.DropIndex(
                name: "IX_CampaignSendLogs_Business_MessageId",
                table: "CampaignSendLogs");

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3266));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3286));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("01cc914d-0166-43cb-ac34-4d86c143b5a1"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3687), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1673849e-1a35-45ef-99bc-c2714c8c2c54"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3694), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1c472684-79be-432f-908c-80d4b12dfa8f"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3691), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2443a874-9924-4b94-928c-ff33bbb17376"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3705), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("278e527b-1749-4672-88a8-8b0391556b4f"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3709), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2833217d-0988-4c78-9838-8d2e94c87668"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3647), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("767ffebf-a490-4d8c-8f7e-bb05fb2fd071"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3718), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("7cbcece2-1080-48a7-a386-1657335518e2"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3637), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("83d15d08-cf44-49d0-9315-bc49832c8496"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3644), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("8c6863c4-cfbe-460e-8deb-af11eb909763"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3724), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("931f83f1-ee94-43fc-9844-6513ae50db64"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3666), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b144c403-d4b7-4db4-ad86-83d3d7e2adb1"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3729), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("b29d7cbb-8e69-47ba-af3c-1d5533b44ca7"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3703), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("bd09481f-9202-46b8-a8f0-51f9df74be0c"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3662), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d988a214-5ee1-4ae8-821e-7423c3ef9200"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3651), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ebff8fce-64bb-4adc-aff9-6658c4eb1160"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3682), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fe1dad12-9253-4dc3-bd0d-e5a30534f517"), new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(3678), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 2, 42, 32, 501, DateTimeKind.Utc).AddTicks(2668));

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_BusinessId",
                table: "MessageLogs",
                column: "BusinessId");
        }
    }
}
