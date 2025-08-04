using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddFeatureMasterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0574c0c9-3f81-428d-af3a-d2a90fb35b8e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("08344dd6-c032-4918-a5ed-145f085617e0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2dc90489-89ac-4877-b0df-869a7bf893ed"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3313278a-881c-4bb0-932f-adb0ef4f960e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("389c40b7-c1a8-4933-9b22-7a13099641e6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3f057e7a-e29b-4ca9-932b-6f5700c26eda"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("623c923e-ed8a-40e1-bdf2-75beadd7c3fd"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6fd53fe6-6790-4c93-9193-e40732e38797"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("76b5616e-cf3f-4a28-b434-a75380fa86a5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7eae3e11-c8fb-4870-a688-1eb0b69f3fe6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("90235fca-ea3a-4d87-9843-8120d6a248aa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a3ff4e6d-c3db-47d0-8d5a-dc05a868bd21"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b5fa27ec-9cba-4d9e-9e7b-1914c6a1be5c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b60da824-36e3-40c6-9dcc-254786b056d7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c7ceb1c9-1bcf-41fc-8be3-5bb894ecd502"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f50a2419-dcfa-42e1-9b5f-feed5cb19d55"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fc083ff6-22d7-45ff-a2ea-db995bf3634e"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3176));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3323));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3359));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("06eeda5f-6a80-43f6-ad18-0ffa7de3b82d"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4016), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1d69a371-aa3a-4c5c-8f89-854b77861a08"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3988), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1f98a6c6-dfa6-4199-b997-9a88a3592f93"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3935), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2647805a-3461-4fd0-9dc4-2b73e06ab436"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4103), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("31077fc3-8326-4a70-88e5-d02f4909b523"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3975), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("351db354-aa0a-4250-ab44-9c1ca3df05d4"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4047), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("410a4982-9970-411e-9fcd-a10403a66018"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4127), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("4f4dfc5f-13db-4287-bc1d-4800e5d08fe7"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4039), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("5a665b77-9472-41fc-87af-75a7c1718a3e"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4023), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("84e7384c-5e71-4c66-9d29-97c299d806b8"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4066), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("aeab94b3-1bb2-470b-868d-8f25c69fce36"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4119), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("aedf4756-e1d0-4c34-bd96-dc58bff5e0a0"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3967), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c3855b1f-c41e-4807-bf68-1bbc24414225"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4073), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("c65530da-5647-4dcb-b556-91b548ed188f"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4085), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("e71628db-a572-49ae-8898-695d0c7c6b22"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(3959), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e89d8afd-00bd-4450-88d8-1ffbaf616163"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4009), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("eaca9399-e841-42eb-806c-e94fca09d80d"), new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(4031), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 6, 23, 49, 975, DateTimeKind.Utc).AddTicks(2084));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("06eeda5f-6a80-43f6-ad18-0ffa7de3b82d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1d69a371-aa3a-4c5c-8f89-854b77861a08"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1f98a6c6-dfa6-4199-b997-9a88a3592f93"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2647805a-3461-4fd0-9dc4-2b73e06ab436"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("31077fc3-8326-4a70-88e5-d02f4909b523"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("351db354-aa0a-4250-ab44-9c1ca3df05d4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("410a4982-9970-411e-9fcd-a10403a66018"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4f4dfc5f-13db-4287-bc1d-4800e5d08fe7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5a665b77-9472-41fc-87af-75a7c1718a3e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("84e7384c-5e71-4c66-9d29-97c299d806b8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aeab94b3-1bb2-470b-868d-8f25c69fce36"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aedf4756-e1d0-4c34-bd96-dc58bff5e0a0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c3855b1f-c41e-4807-bf68-1bbc24414225"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c65530da-5647-4dcb-b556-91b548ed188f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e71628db-a572-49ae-8898-695d0c7c6b22"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e89d8afd-00bd-4450-88d8-1ffbaf616163"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("eaca9399-e841-42eb-806c-e94fca09d80d"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9629));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0574c0c9-3f81-428d-af3a-d2a90fb35b8e"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(111), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("08344dd6-c032-4918-a5ed-145f085617e0"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(101), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2dc90489-89ac-4877-b0df-869a7bf893ed"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(31), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3313278a-881c-4bb0-932f-adb0ef4f960e"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(106), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("389c40b7-c1a8-4933-9b22-7a13099641e6"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(134), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("3f057e7a-e29b-4ca9-932b-6f5700c26eda"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(85), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("623c923e-ed8a-40e1-bdf2-75beadd7c3fd"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(77), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6fd53fe6-6790-4c93-9193-e40732e38797"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(137), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("76b5616e-cf3f-4a28-b434-a75380fa86a5"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(89), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7eae3e11-c8fb-4870-a688-1eb0b69f3fe6"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(52), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("90235fca-ea3a-4d87-9843-8120d6a248aa"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(56), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a3ff4e6d-c3db-47d0-8d5a-dc05a868bd21"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(23), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b5fa27ec-9cba-4d9e-9e7b-1914c6a1be5c"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(35), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b60da824-36e3-40c6-9dcc-254786b056d7"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(73), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c7ceb1c9-1bcf-41fc-8be3-5bb894ecd502"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(126), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("f50a2419-dcfa-42e1-9b5f-feed5cb19d55"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(39), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fc083ff6-22d7-45ff-a2ea-db995bf3634e"), new DateTime(2025, 6, 21, 7, 36, 11, 863, DateTimeKind.Utc).AddTicks(81), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 7, 36, 11, 862, DateTimeKind.Utc).AddTicks(8747));
        }
    }
}
