using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddRunIdToMessageLog_AndIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "RunId",
                table: "MessageLogs",
                type: "uuid",
                nullable: true);

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
                name: "IX_MessageLogs_MessageId",
                table: "MessageLogs",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_RunId",
                table: "MessageLogs",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSendLogs_MessageId",
                table: "CampaignSendLogs",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSendLogs_RunId",
                table: "CampaignSendLogs",
                column: "RunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MessageLogs_MessageId",
                table: "MessageLogs");

            migrationBuilder.DropIndex(
                name: "IX_MessageLogs_RunId",
                table: "MessageLogs");

            migrationBuilder.DropIndex(
                name: "IX_CampaignSendLogs_MessageId",
                table: "CampaignSendLogs");

            migrationBuilder.DropIndex(
                name: "IX_CampaignSendLogs_RunId",
                table: "CampaignSendLogs");

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

            migrationBuilder.DropColumn(
                name: "RunId",
                table: "MessageLogs");

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
    }
}
