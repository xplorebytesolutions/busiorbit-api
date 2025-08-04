using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class UPdateTablePlanFeatureMatrix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("096be258-50ae-4078-b0b8-c26a084fd724"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0fd99a93-afb1-4c95-bd45-6cac60d66c95"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("252166cd-7af1-4e13-9307-d49d67174ca0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3ac31a18-ad13-4c36-b48b-809df1accbea"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3ae5fc4a-1802-4e1d-88e1-1a18ec723c68"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3b73270a-83ea-4035-bc71-afcd2712b655"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4a1d7dea-8658-4b83-ab55-3fa7d44acfca"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("58bc10ee-9c29-43f1-91ae-b47c230c074c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5974390a-3569-4e81-844a-eef6252ef7e4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("81b8d4c8-6ce9-45b4-8edf-420e9e7cc508"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ab889393-3213-491e-9a14-22ed8d5e2ec9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cf24b7f5-1cd6-4a11-ae7d-6cf51ef639b4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d93c4342-cb14-4ca7-a8f5-8b48689cb9d5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e6bbb9ea-c7c5-46ec-a174-89321cb049f4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e7be4659-3d78-46ee-ada0-d8daf6dfc315"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("eaea5537-8ed7-4503-aa6e-e7d5e8cff0bb"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f793d715-08c4-4660-bb72-79c135d915fa"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("07503bb5-f5a3-48e0-916c-6310c7e132d6"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5306), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("0c898220-4231-4723-9bbf-304fe6447cd0"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5272), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("0e6bd3b2-5056-4cc3-97fd-a11e4e1e4a3e"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5212), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1198345c-c96c-44d4-9602-3d5382ea69c2"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5226), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2af188d1-7bd2-4eda-bc94-aea97e80d16e"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5260), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3a30a452-7f8c-4d6a-92f0-971393a2b3c5"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5255), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4283079b-7d1f-4184-bd9d-5341d110b461"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5279), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("7504e744-8b7a-4422-8cc2-287e3d771041"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5310), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("7f7bc705-2d45-43cc-815c-a8889a123721"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5295), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("9e2c8d5b-dc26-449d-b0bd-be663e09e61c"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5235), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a3f6f36e-4aa6-4a3f-ba9b-3205bc918f14"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5253), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b25ff30e-10d9-4b9d-bf52-30c92e49d3a7"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5263), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c8729359-8505-47ca-b4fc-5e80ce84e4c7"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5203), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cd29166e-6d07-4f88-bcac-b52eba3e40c8"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5231), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cdcd8d38-dbbc-49ee-a39d-026fa25f1eea"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5195), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e837feae-a731-4ab4-98d0-5441b93ed285"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5217), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ff6899d1-69ff-4245-949c-2446bcf28ff4"), new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(5276), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 13, 5, 4, 368, DateTimeKind.Utc).AddTicks(3875));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("07503bb5-f5a3-48e0-916c-6310c7e132d6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0c898220-4231-4723-9bbf-304fe6447cd0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0e6bd3b2-5056-4cc3-97fd-a11e4e1e4a3e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1198345c-c96c-44d4-9602-3d5382ea69c2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2af188d1-7bd2-4eda-bc94-aea97e80d16e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3a30a452-7f8c-4d6a-92f0-971393a2b3c5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4283079b-7d1f-4184-bd9d-5341d110b461"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7504e744-8b7a-4422-8cc2-287e3d771041"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7f7bc705-2d45-43cc-815c-a8889a123721"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9e2c8d5b-dc26-449d-b0bd-be663e09e61c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a3f6f36e-4aa6-4a3f-ba9b-3205bc918f14"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b25ff30e-10d9-4b9d-bf52-30c92e49d3a7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c8729359-8505-47ca-b4fc-5e80ce84e4c7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cd29166e-6d07-4f88-bcac-b52eba3e40c8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cdcd8d38-dbbc-49ee-a39d-026fa25f1eea"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e837feae-a731-4ab4-98d0-5441b93ed285"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ff6899d1-69ff-4245-949c-2446bcf28ff4"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1547));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("096be258-50ae-4078-b0b8-c26a084fd724"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1993), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("0fd99a93-afb1-4c95-bd45-6cac60d66c95"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2113), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("252166cd-7af1-4e13-9307-d49d67174ca0"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2084), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("3ac31a18-ad13-4c36-b48b-809df1accbea"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1987), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3ae5fc4a-1802-4e1d-88e1-1a18ec723c68"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2003), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3b73270a-83ea-4035-bc71-afcd2712b655"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2069), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4a1d7dea-8658-4b83-ab55-3fa7d44acfca"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2123), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("58bc10ee-9c29-43f1-91ae-b47c230c074c"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2129), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("5974390a-3569-4e81-844a-eef6252ef7e4"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1966), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("81b8d4c8-6ce9-45b4-8edf-420e9e7cc508"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2065), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ab889393-3213-491e-9a14-22ed8d5e2ec9"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2093), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("cf24b7f5-1cd6-4a11-ae7d-6cf51ef639b4"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1934), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d93c4342-cb14-4ca7-a8f5-8b48689cb9d5"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1961), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e6bbb9ea-c7c5-46ec-a174-89321cb049f4"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2058), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e7be4659-3d78-46ee-ada0-d8daf6dfc315"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1998), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("eaea5537-8ed7-4503-aa6e-e7d5e8cff0bb"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(1955), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f793d715-08c4-4660-bb72-79c135d915fa"), new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(2099), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 19, 12, 58, 3, 278, DateTimeKind.Utc).AddTicks(356));
        }
    }
}
