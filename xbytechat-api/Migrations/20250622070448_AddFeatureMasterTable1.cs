using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddFeatureMasterTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Plan",
                table: "FeatureAccess",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeatureMaster",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Group = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureMaster", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(2995));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1418e3c7-df29-4ae2-aa27-2ef426f1933c"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4384), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("1c5228fa-c7cd-407a-9933-0f09eb3a554f"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4367), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1e5a3b00-04aa-49ab-8174-6ddacb25726d"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4405), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("24262200-285e-4aa6-a065-4c5a49ddc8ac"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4389), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("41d4a538-2ca3-4e67-a336-c52b22fb9b0a"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4324), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("56e48877-6772-4be4-a827-63bc8f5242c2"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4393), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("8bd44ca4-27ea-41d4-835b-8659095ad6c8"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4318), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a8aea059-6ff2-42ad-a155-219ce78916b3"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4361), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a98dfe68-3b7f-4a68-b5a8-8e931896206b"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4349), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("bb77f0eb-50a9-49b0-9f29-154872e2970d"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4422), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("c574e6a2-495c-41cf-8aa4-5f9760d83baf"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4371), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cab676a7-df99-4eaa-bb3d-dfdec1e7ac39"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4344), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cf233a37-a64c-4ae2-aeb1-bf5c4bd642e3"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4354), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d18e4159-67dd-490b-9dd1-fb5685e5073a"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4338), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("dcb05ff3-470d-43d9-8af9-0324c2eba91c"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4415), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("dd3a681f-d5f5-47bb-be92-44f360fce9f7"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4308), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fadff09e-9b6a-44e6-9e1a-07cc6a9c3722"), new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(4327), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 7, 4, 47, 251, DateTimeKind.Utc).AddTicks(1627));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureMaster");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1418e3c7-df29-4ae2-aa27-2ef426f1933c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1c5228fa-c7cd-407a-9933-0f09eb3a554f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1e5a3b00-04aa-49ab-8174-6ddacb25726d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("24262200-285e-4aa6-a065-4c5a49ddc8ac"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("41d4a538-2ca3-4e67-a336-c52b22fb9b0a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("56e48877-6772-4be4-a827-63bc8f5242c2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8bd44ca4-27ea-41d4-835b-8659095ad6c8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a8aea059-6ff2-42ad-a155-219ce78916b3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a98dfe68-3b7f-4a68-b5a8-8e931896206b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bb77f0eb-50a9-49b0-9f29-154872e2970d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c574e6a2-495c-41cf-8aa4-5f9760d83baf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cab676a7-df99-4eaa-bb3d-dfdec1e7ac39"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cf233a37-a64c-4ae2-aeb1-bf5c4bd642e3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d18e4159-67dd-490b-9dd1-fb5685e5073a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dcb05ff3-470d-43d9-8af9-0324c2eba91c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dd3a681f-d5f5-47bb-be92-44f360fce9f7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fadff09e-9b6a-44e6-9e1a-07cc6a9c3722"));

            migrationBuilder.DropColumn(
                name: "Plan",
                table: "FeatureAccess");

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
    }
}
