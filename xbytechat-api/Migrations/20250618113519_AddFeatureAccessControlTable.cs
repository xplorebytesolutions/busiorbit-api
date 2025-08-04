using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddFeatureAccessControlTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("003843fd-8c1e-48ca-b835-204f1bd45d70"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("14e55de6-27a2-4628-936b-b69ba64abda9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2564bb32-540e-454a-b685-b7f24c341fa7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("39cdceb8-6001-45db-aeea-c39f35f9b6ac"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("46549846-d2a6-47d1-8166-203b5b8c9033"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("613a89f2-84ba-462a-8c70-8749baf7f5cf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("63c8311f-bd99-4511-8832-d2290f88f672"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6555c2bd-fc8d-4f45-abb2-c92de944216e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6ab149de-62f7-4207-8a09-5e49252b1635"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6f3808e5-4643-448a-8ea6-672acab61a4b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("91c81b3d-49f0-4ccb-b9fc-4afb84755e05"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa2fcb6f-93b6-42b5-af4a-bcaf1da0e724"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b06e50ad-f1ff-4f90-b44d-c440be8dc23c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bef317da-6e28-43f1-99c9-d1e7d7734ccf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d361b7d0-0308-4e2c-b12b-0715b7a86887"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dcfb4546-1ec5-4842-af11-0e127094e50b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ea9e2321-7062-4390-97dc-a6f0cfd92988"));

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AssignedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPermissions_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("03816e54-47a3-467d-8c88-e43ea4536e05"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8144), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("341fb820-6b52-4174-9662-3b214e82e6e3"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8207), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3c392691-3438-4a20-b045-7df862eafc67"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8229), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3df6dae8-231e-4d76-82e2-2884cc481a43"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8214), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4d721807-27c2-4739-accb-9f31089a94c2"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8263), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("50f07690-d640-4399-b443-e340aee9d3a0"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8127), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("56e6eda1-6ed4-4b00-9a1d-53ee6d41e251"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8221), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7df4604b-fe0e-4f58-8622-9ca6cca4e079"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8314), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("86dc236f-b269-46af-bf2d-823f9ab40ce2"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8184), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("88838163-0483-46a7-a5dd-db80abc6c5c6"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8255), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("abeb1282-e95e-4b1d-b1dd-62104642ebc4"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8336), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("be5dd8e3-2c78-46b6-af9c-ee91c9390de5"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8175), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cb57d18f-d96a-4634-a65e-edbe6c34ae73"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8162), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cbd3bd8a-2761-449b-80fd-16ec9c4b56f3"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8269), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("e0cd0f85-44d7-49d8-b1a1-ad7d400ed458"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8236), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e8a60265-2301-4d75-906b-488c01fc1b00"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8329), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("eef2747c-b46d-452a-82a1-55e1005b9baa"), new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(8154), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 11, 35, 17, 880, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermissions_PermissionId",
                table: "PlanPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPermissions_PlanId",
                table: "PlanPermissions",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanPermissions");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("03816e54-47a3-467d-8c88-e43ea4536e05"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("341fb820-6b52-4174-9662-3b214e82e6e3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3c392691-3438-4a20-b045-7df862eafc67"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3df6dae8-231e-4d76-82e2-2884cc481a43"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4d721807-27c2-4739-accb-9f31089a94c2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("50f07690-d640-4399-b443-e340aee9d3a0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("56e6eda1-6ed4-4b00-9a1d-53ee6d41e251"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7df4604b-fe0e-4f58-8622-9ca6cca4e079"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("86dc236f-b269-46af-bf2d-823f9ab40ce2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("88838163-0483-46a7-a5dd-db80abc6c5c6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("abeb1282-e95e-4b1d-b1dd-62104642ebc4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("be5dd8e3-2c78-46b6-af9c-ee91c9390de5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cb57d18f-d96a-4634-a65e-edbe6c34ae73"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cbd3bd8a-2761-449b-80fd-16ec9c4b56f3"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e0cd0f85-44d7-49d8-b1a1-ad7d400ed458"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e8a60265-2301-4d75-906b-488c01fc1b00"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("eef2747c-b46d-452a-82a1-55e1005b9baa"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("003843fd-8c1e-48ca-b835-204f1bd45d70"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7100), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("14e55de6-27a2-4628-936b-b69ba64abda9"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7153), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2564bb32-540e-454a-b685-b7f24c341fa7"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7115), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("39cdceb8-6001-45db-aeea-c39f35f9b6ac"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7068), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("46549846-d2a6-47d1-8166-203b5b8c9033"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7167), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("613a89f2-84ba-462a-8c70-8749baf7f5cf"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7138), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("63c8311f-bd99-4511-8832-d2290f88f672"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7095), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6555c2bd-fc8d-4f45-abb2-c92de944216e"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7074), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6ab149de-62f7-4207-8a09-5e49252b1635"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7120), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6f3808e5-4643-448a-8ea6-672acab61a4b"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7162), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("91c81b3d-49f0-4ccb-b9fc-4afb84755e05"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7105), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aa2fcb6f-93b6-42b5-af4a-bcaf1da0e724"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7134), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("b06e50ad-f1ff-4f90-b44d-c440be8dc23c"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7084), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("bef317da-6e28-43f1-99c9-d1e7d7734ccf"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7090), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d361b7d0-0308-4e2c-b12b-0715b7a86887"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(6976), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("dcfb4546-1ec5-4842-af11-0e127094e50b"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7142), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("ea9e2321-7062-4390-97dc-a6f0cfd92988"), new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(7000), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 8, 56, 15, 175, DateTimeKind.Utc).AddTicks(4978));
        }
    }
}
