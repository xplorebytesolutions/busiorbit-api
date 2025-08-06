using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("02972145-3fb4-4821-b138-55529fc14140"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2741a9c5-759a-4d7d-bd75-19b39830fb1d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2f815ab0-7114-4d1e-8c11-928a7a1ff3e1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("31551594-28e8-4307-9ff4-c88c90b8e41e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3d68c643-c06a-4d8e-906d-67e431fb8dae"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("418cb051-994a-4227-8191-91f333d022c4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4559c220-b214-4867-a5ef-420dfd537530"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4a7c82bd-282e-4d7f-b06e-942961c578e4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4fe0af17-0bce-4ad8-a006-682780ce8e75"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7f139177-7fec-4f69-ba2a-bff27989f456"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8f8abd40-9e1c-46d5-af37-3e718062b56b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aaff6051-9a29-4693-8587-ec86d1713328"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aec7e2bc-bf4c-4a5a-805a-a081da6fc861"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c6128b15-63a3-4cad-97ca-50d153cd97b9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dda31ae1-dfd6-42e4-9d47-8de18e30e67c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e7332033-fb8e-4ee9-8486-fbc8698c37f8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f6fdc533-cf5c-43c3-9906-8437105d0df4"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4999));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("02972145-3fb4-4821-b138-55529fc14140"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5405), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2741a9c5-759a-4d7d-bd75-19b39830fb1d"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5373), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2f815ab0-7114-4d1e-8c11-928a7a1ff3e1"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5443), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("31551594-28e8-4307-9ff4-c88c90b8e41e"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5411), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3d68c643-c06a-4d8e-906d-67e431fb8dae"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5425), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("418cb051-994a-4227-8191-91f333d022c4"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5432), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("4559c220-b214-4867-a5ef-420dfd537530"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5377), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4a7c82bd-282e-4d7f-b06e-942961c578e4"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5429), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("4fe0af17-0bce-4ad8-a006-682780ce8e75"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5402), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7f139177-7fec-4f69-ba2a-bff27989f456"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5414), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("8f8abd40-9e1c-46d5-af37-3e718062b56b"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5446), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("aaff6051-9a29-4693-8587-ec86d1713328"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5366), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aec7e2bc-bf4c-4a5a-805a-a081da6fc861"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5437), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("c6128b15-63a3-4cad-97ca-50d153cd97b9"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5384), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("dda31ae1-dfd6-42e4-9d47-8de18e30e67c"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5381), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e7332033-fb8e-4ee9-8486-fbc8698c37f8"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5408), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f6fdc533-cf5c-43c3-9906-8437105d0df4"), new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(5387), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 15, 56, 17, 413, DateTimeKind.Utc).AddTicks(4413));
        }
    }
}
