using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanIdToBusinesses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("077411e5-1f1b-4e94-90b9-febb503d955a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("106019ac-e3ba-47c5-aa3d-3de8459189f7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2cd29bd3-f812-435e-bfa4-dcbe753c8a0a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("348b34f4-6d0a-4505-a7f9-f67a64e867f6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("43751848-5176-482e-8854-cfe0c1fe1476"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("48b591be-65f7-451f-b719-f327dada5ad4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8730c3e3-5f76-4acd-bba1-619e983d37d4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8988065d-f1a5-4e5c-aff1-36b30317c807"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("89b52866-c0a4-4988-aee5-e5afb670f1db"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9695b1ca-cf9e-4ba8-b608-25ba5ed6c578"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9efa0b93-4944-4e5c-b8a8-7d85661a26a3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a47785b3-34d7-43e2-a1ab-b9e91e987dfa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b2178c98-9d0e-45f1-9e60-47f9763367e9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b85669b0-d5f9-4b87-8a5b-617120e76679"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ccd710e6-baf8-414e-b3ce-fdba41bb9692"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d2a22e67-99a2-4f6c-b042-38c9647d0ea0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("da299567-1c2c-4912-977f-70a7a102ffb4"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2922));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2925));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2927));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2936));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2996));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("10074a09-5db5-4e2e-9d12-97d89079ba43"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3554), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("1694debc-9945-4918-ab2d-a18baf097c25"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3527), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1938632b-e6b4-4b3f-9cd0-f86304184ff0"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3508), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("22ce1b29-a2dc-4c99-924a-fb1c947e05b7"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3491), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("25801f86-7ae8-41f4-8512-ff76d5a10596"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3523), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2e5fbcc5-4671-4eba-8e70-22fdcadbfb86"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3475), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3fc84fcb-f95a-4d1d-b8af-1d00fb10bff8"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3467), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7129083f-2a63-4b04-bfdc-e8e299c26978"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3559), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("81c240af-c44b-4ae7-b17a-898db3a76007"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3486), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("83c06787-5e61-4d38-b937-b3b771f1203f"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3548), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("a8a067ca-6119-455c-9921-0c3b2862dee7"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3537), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("b38ef749-bab7-4f05-8fb6-209e1ba9d842"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3483), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cc42f0a5-1e27-4848-ab3a-1c7620e56bcb"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3518), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("de123a2a-23ad-4aea-ad11-63f14e44d21a"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3512), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e195e4db-5a73-4979-8b4f-768e3aec1a67"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3541), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("ec7a1734-9e24-461b-94af-5b63d7067a13"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3545), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("f2f832f2-370c-4c86-9daf-b93e6736233c"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3479), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2291));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("10074a09-5db5-4e2e-9d12-97d89079ba43"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1694debc-9945-4918-ab2d-a18baf097c25"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1938632b-e6b4-4b3f-9cd0-f86304184ff0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("22ce1b29-a2dc-4c99-924a-fb1c947e05b7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("25801f86-7ae8-41f4-8512-ff76d5a10596"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2e5fbcc5-4671-4eba-8e70-22fdcadbfb86"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3fc84fcb-f95a-4d1d-b8af-1d00fb10bff8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7129083f-2a63-4b04-bfdc-e8e299c26978"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("81c240af-c44b-4ae7-b17a-898db3a76007"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("83c06787-5e61-4d38-b937-b3b771f1203f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a8a067ca-6119-455c-9921-0c3b2862dee7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b38ef749-bab7-4f05-8fb6-209e1ba9d842"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cc42f0a5-1e27-4848-ab3a-1c7620e56bcb"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("de123a2a-23ad-4aea-ad11-63f14e44d21a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e195e4db-5a73-4979-8b4f-768e3aec1a67"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ec7a1734-9e24-461b-94af-5b63d7067a13"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f2f832f2-370c-4c86-9daf-b93e6736233c"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8382));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("077411e5-1f1b-4e94-90b9-febb503d955a"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8718), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("106019ac-e3ba-47c5-aa3d-3de8459189f7"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8783), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2cd29bd3-f812-435e-bfa4-dcbe753c8a0a"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8787), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("348b34f4-6d0a-4505-a7f9-f67a64e867f6"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8820), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("43751848-5176-482e-8854-cfe0c1fe1476"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8725), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("48b591be-65f7-451f-b719-f327dada5ad4"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8705), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("8730c3e3-5f76-4acd-bba1-619e983d37d4"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8700), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("8988065d-f1a5-4e5c-aff1-36b30317c807"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8810), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("89b52866-c0a4-4988-aee5-e5afb670f1db"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8807), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("9695b1ca-cf9e-4ba8-b608-25ba5ed6c578"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8802), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("9efa0b93-4944-4e5c-b8a8-7d85661a26a3"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8805), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("a47785b3-34d7-43e2-a1ab-b9e91e987dfa"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8792), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b2178c98-9d0e-45f1-9e60-47f9763367e9"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8714), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b85669b0-d5f9-4b87-8a5b-617120e76679"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8817), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("ccd710e6-baf8-414e-b3ce-fdba41bb9692"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8776), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d2a22e67-99a2-4f6c-b042-38c9647d0ea0"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8780), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("da299567-1c2c-4912-977f-70a7a102ffb4"), new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(8721), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 10, 12, 24, 21, 784, DateTimeKind.Utc).AddTicks(7684));
        }
    }
}
