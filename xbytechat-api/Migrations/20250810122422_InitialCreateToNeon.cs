using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateToNeon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0478c3a5-283b-442d-a51d-909c2b0172d3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0759059d-e71d-4198-b3b9-58d12c8200f9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("15b8aca8-7fb9-4e9f-8f59-9e88bd26b0ec"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("18c92b80-4c5e-4d54-b364-8b3953000241"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("251c0b3d-3bb2-4e11-a64f-190d457306d0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("40fe8966-eefb-43ef-b8ca-677f107d33dc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5f2a715d-4a83-4669-b42c-1df495d349b8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("65ffa364-2c5a-45e0-af28-5a1730dc9d94"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8ce09038-350b-4f34-9467-38ba611c61bd"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8e58d8a5-dc1f-4fb9-9198-f868ae63fc70"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a471818e-7c64-4c7f-869c-545938ad9217"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa7bf421-9fdc-4a77-b822-29b6a5a1c131"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("af77b30e-d9b4-4052-b378-4b862fe1a86c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b30d4433-c4b8-4131-8072-bb52a720f964"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cddcfa62-e4bb-4433-83fa-42bce5951025"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e0e5dc1c-9235-4fa8-863d-8a57c01e8a24"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f6933ae2-c83d-4652-bdd6-559684858967"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0478c3a5-283b-442d-a51d-909c2b0172d3"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5559), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("0759059d-e71d-4198-b3b9-58d12c8200f9"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5539), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("15b8aca8-7fb9-4e9f-8f59-9e88bd26b0ec"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5524), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("18c92b80-4c5e-4d54-b364-8b3953000241"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5515), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("251c0b3d-3bb2-4e11-a64f-190d457306d0"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5509), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("40fe8966-eefb-43ef-b8ca-677f107d33dc"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5535), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("5f2a715d-4a83-4669-b42c-1df495d349b8"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5554), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("65ffa364-2c5a-45e0-af28-5a1730dc9d94"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5551), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("8ce09038-350b-4f34-9467-38ba611c61bd"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5569), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("8e58d8a5-dc1f-4fb9-9198-f868ae63fc70"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5542), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a471818e-7c64-4c7f-869c-545938ad9217"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5533), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aa7bf421-9fdc-4a77-b822-29b6a5a1c131"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5518), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("af77b30e-d9b4-4052-b378-4b862fe1a86c"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5512), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b30d4433-c4b8-4131-8072-bb52a720f964"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5572), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("cddcfa62-e4bb-4433-83fa-42bce5951025"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5499), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e0e5dc1c-9235-4fa8-863d-8a57c01e8a24"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5522), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f6933ae2-c83d-4652-bdd6-559684858967"), new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(5557), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 8, 3, 13, 784, DateTimeKind.Utc).AddTicks(3906));
        }
    }
}
