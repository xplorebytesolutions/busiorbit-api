using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddWhatsAppTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("03d59c01-0279-48ce-8e13-b8141322e394"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3d49eb05-172b-4cca-8874-491f3dbd4a44"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4b11234b-62e2-4dfc-a671-30b702687fa0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4c584954-6f79-4b88-8abb-a35f2304c749"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("50cd9d64-fc86-431c-8079-a129bcc9c619"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("59120a76-33c8-472f-aaf2-7e405952a532"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("60d3c5c7-14c9-4753-b670-63d3c13d445b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6d1eb017-d3ac-4e8b-be8c-1dc2ba15f5f8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("79168bb2-83f6-4c09-9e86-31871f99319d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b95d6e65-4c47-46e8-bf15-79447f5119db"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("baa06095-7755-4539-af47-c395e3450535"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bb75e558-37a9-40ed-867b-662113abb881"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c406b207-ede4-436d-a878-c009e493954f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("db9aaa2d-0c72-48e6-ae39-3c54179b87f7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e531c89e-a040-44b4-b084-aba415a06e08"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("eaedc8b9-9c17-4fee-a631-1cd0b4b45890"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ec16b5ba-9258-41de-a403-07e3b327ebc9"));

            migrationBuilder.CreateTable(
                name: "WhatsAppTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Provider = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ExternalId = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    Name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Language = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Status = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Category = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Body = table.Column<string>(type: "text", nullable: false),
                    HasImageHeader = table.Column<bool>(type: "boolean", nullable: false),
                    PlaceholderCount = table.Column<int>(type: "integer", nullable: false),
                    ButtonsJson = table.Column<string>(type: "text", nullable: false),
                    RawJson = table.Column<string>(type: "text", nullable: false),
                    LastSyncedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsAppTemplates", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5254));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5332));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("13313cfb-9000-4382-b9a9-784ffdc77070"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5758), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("1a0fab7f-c9e0-411b-8156-b6c8308dab35"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5749), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("388a0b39-6799-46c0-a407-5a1bc26895a2"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5669), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4bcafbd2-f965-45f0-b0d2-c79a40bdb721"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5715), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4cd72ffb-1c0b-4629-a962-2218c34e4443"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5727), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("5ec974c0-7262-4725-b5fb-0bc60e91d870"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5677), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("78481725-46ae-4ab8-8c30-cab6f0ea736d"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5770), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("849d8282-0636-4588-b01e-f17eb38d2f1b"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5704), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("8f6118e3-51e8-4aa6-aa08-b292d075c1a7"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5685), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a10fca4f-d5e2-4e33-9509-0cbd5c6fa6e3"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5733), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b21a3c29-a737-4430-8710-4dc78f1ebdec"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5766), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("b88e4968-db52-40ed-bfc7-933b741366ca"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5743), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("bf2a6dcc-72c0-4e80-9ef8-9a78c1a5210f"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5747), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("ce6bf6df-8f3b-4044-a1a5-3a9c32a45dd7"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5688), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e8f4a680-feb8-484b-a897-b6baceae3ab9"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5730), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("edd9c61b-3e4e-4d93-877d-2f1a25b3ee73"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5736), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fd6d06ce-9e22-47e9-ae76-414b2a076cc8"), new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(5700), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 7, 7, 2, 458, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppTemplates_BusinessId_Name",
                table: "WhatsAppTemplates",
                columns: new[] { "BusinessId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppTemplates_BusinessId_Name_Language_Provider",
                table: "WhatsAppTemplates",
                columns: new[] { "BusinessId", "Name", "Language", "Provider" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppTemplates_BusinessId_Provider",
                table: "WhatsAppTemplates",
                columns: new[] { "BusinessId", "Provider" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhatsAppTemplates");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("13313cfb-9000-4382-b9a9-784ffdc77070"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1a0fab7f-c9e0-411b-8156-b6c8308dab35"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("388a0b39-6799-46c0-a407-5a1bc26895a2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4bcafbd2-f965-45f0-b0d2-c79a40bdb721"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4cd72ffb-1c0b-4629-a962-2218c34e4443"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5ec974c0-7262-4725-b5fb-0bc60e91d870"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("78481725-46ae-4ab8-8c30-cab6f0ea736d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("849d8282-0636-4588-b01e-f17eb38d2f1b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8f6118e3-51e8-4aa6-aa08-b292d075c1a7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a10fca4f-d5e2-4e33-9509-0cbd5c6fa6e3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b21a3c29-a737-4430-8710-4dc78f1ebdec"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b88e4968-db52-40ed-bfc7-933b741366ca"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bf2a6dcc-72c0-4e80-9ef8-9a78c1a5210f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ce6bf6df-8f3b-4044-a1a5-3a9c32a45dd7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e8f4a680-feb8-484b-a897-b6baceae3ab9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("edd9c61b-3e4e-4d93-877d-2f1a25b3ee73"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fd6d06ce-9e22-47e9-ae76-414b2a076cc8"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1729));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(1731));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("03d59c01-0279-48ce-8e13-b8141322e394"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2063), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3d49eb05-172b-4cca-8874-491f3dbd4a44"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2076), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4b11234b-62e2-4dfc-a671-30b702687fa0"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2079), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4c584954-6f79-4b88-8abb-a35f2304c749"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2056), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("50cd9d64-fc86-431c-8079-a129bcc9c619"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2032), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("59120a76-33c8-472f-aaf2-7e405952a532"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2111), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("60d3c5c7-14c9-4753-b670-63d3c13d445b"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2106), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("6d1eb017-d3ac-4e8b-be8c-1dc2ba15f5f8"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2096), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("79168bb2-83f6-4c09-9e86-31871f99319d"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2086), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b95d6e65-4c47-46e8-bf15-79447f5119db"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2043), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("baa06095-7755-4539-af47-c395e3450535"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2059), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("bb75e558-37a9-40ed-867b-662113abb881"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2074), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c406b207-ede4-436d-a878-c009e493954f"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2103), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("db9aaa2d-0c72-48e6-ae39-3c54179b87f7"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2115), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("e531c89e-a040-44b4-b084-aba415a06e08"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2039), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("eaedc8b9-9c17-4fee-a631-1cd0b4b45890"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2083), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ec16b5ba-9258-41de-a403-07e3b327ebc9"), new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(2100), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 16, 30, 28, 266, DateTimeKind.Utc).AddTicks(990));
        }
    }
}
