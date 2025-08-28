using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaignClickLogstbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CampaignClickDailyAgg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Day = table.Column<DateTime>(type: "date", nullable: false),
                    ButtonIndex = table.Column<int>(type: "integer", nullable: false),
                    Clicks = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignClickDailyAgg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignClickLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignSendLogId = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: true),
                    ButtonIndex = table.Column<int>(type: "integer", nullable: false),
                    ButtonTitle = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Destination = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    Ip = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    UserAgent = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    ClickedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignClickLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("003b2812-380b-4a58-9f2d-9577ab36ad76"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7324), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("07e64791-e560-40ce-8a9b-126a992a120b"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7367), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("19e2e6a3-a550-452f-ae36-37ec40e0a283"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7395), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("1b8b28ef-e6f9-4690-86aa-f80d5460b07e"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7371), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("445a92bb-19db-4352-9aa4-5914955c97a1"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7356), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("489ef7d5-b71d-4a02-b3a4-7bf12a13b1e5"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7393), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("572f5c50-07f4-4c6d-bc2d-0fddc6f61195"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7347), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7354d012-cf16-4483-b962-bfe8303390ca"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7352), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("77f6d854-dd7e-4f4f-9c25-b5c997a5da59"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7343), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("9825c18c-79a3-4497-9b88-cde86dac53bc"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7387), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("a963d99a-e0f0-4227-a23b-6b8102a42e85"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7379), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d38ad21b-fe63-4f08-88f3-46ff18dc79bf"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7369), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("dfe0750e-e8d3-440e-aca2-5f91a544bfa5"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7390), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("e1ffdfc3-f696-4e41-9e04-5ed1277c20f9"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7377), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ef4d7145-7602-46db-978b-631bdaffd701"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7350), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f6c9b11f-e746-472c-bfb1-0cbf76edf4e1"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7400), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("fdfafbdb-20b2-47b7-9f91-9a7e0669921d"), new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(7403), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 3, 43, 33, 968, DateTimeKind.Utc).AddTicks(6035));

            migrationBuilder.CreateIndex(
                name: "IX_CampaignClickDailyAgg_CampaignId_Day_ButtonIndex",
                table: "CampaignClickDailyAgg",
                columns: new[] { "CampaignId", "Day", "ButtonIndex" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignClickLogs_CampaignId_ButtonIndex",
                table: "CampaignClickLogs",
                columns: new[] { "CampaignId", "ButtonIndex" });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignClickLogs_CampaignId_ClickedAt",
                table: "CampaignClickLogs",
                columns: new[] { "CampaignId", "ClickedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignClickLogs_CampaignId_ContactId",
                table: "CampaignClickLogs",
                columns: new[] { "CampaignId", "ContactId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignClickDailyAgg");

            migrationBuilder.DropTable(
                name: "CampaignClickLogs");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("003b2812-380b-4a58-9f2d-9577ab36ad76"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("07e64791-e560-40ce-8a9b-126a992a120b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("19e2e6a3-a550-452f-ae36-37ec40e0a283"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1b8b28ef-e6f9-4690-86aa-f80d5460b07e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("445a92bb-19db-4352-9aa4-5914955c97a1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("489ef7d5-b71d-4a02-b3a4-7bf12a13b1e5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("572f5c50-07f4-4c6d-bc2d-0fddc6f61195"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7354d012-cf16-4483-b962-bfe8303390ca"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("77f6d854-dd7e-4f4f-9c25-b5c997a5da59"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9825c18c-79a3-4497-9b88-cde86dac53bc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a963d99a-e0f0-4227-a23b-6b8102a42e85"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d38ad21b-fe63-4f08-88f3-46ff18dc79bf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dfe0750e-e8d3-440e-aca2-5f91a544bfa5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e1ffdfc3-f696-4e41-9e04-5ed1277c20f9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ef4d7145-7602-46db-978b-631bdaffd701"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f6c9b11f-e746-472c-bfb1-0cbf76edf4e1"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fdfafbdb-20b2-47b7-9f91-9a7e0669921d"));

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
        }
    }
}
