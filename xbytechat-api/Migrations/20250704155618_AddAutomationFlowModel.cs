using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddAutomationFlowModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("08e81e86-af2e-44e7-aa98-96ddbb265fd4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("104a4dec-d683-4af5-b817-5d89b2ae09c0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("170baea8-4ee1-433c-ae9a-bc9cb7db938f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2fb759a5-ff0d-417f-bb97-bd4483b70a22"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("31bd93dc-41dc-4409-8d30-b1c5996624f9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("37991ff4-bae2-408a-9a00-028fadc69810"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3bb13eca-7657-4609-ae59-15ef6b008b29"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4ad7df90-e52f-4dc5-aef8-1a7c0c70e673"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5633443a-4b94-4adf-af7b-7c59c990c42d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("665cf6fe-9022-4367-8474-90954e49b350"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("697a8ab6-5898-4ed6-8114-611f34ddc7e8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("943e78ee-02dc-495e-a212-b3f037b742c7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a64bfba6-28df-42e4-94f0-c14a37c081b7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a71bc075-0ae0-4903-b0bd-3c5e834eb092"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a8768168-5817-4ec6-8558-72508caf72d8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cf227764-e3bc-4c10-a73a-f104c99b5fc2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d585ad3d-c3bc-4d6a-ad03-15bb1bcc61c1"));

            migrationBuilder.AddColumn<string>(
                name: "IndustryTag",
                table: "AutoReplyRules",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceChannel",
                table: "AutoReplyRules",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndustryTag",
                table: "AutoReplyFlows",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultTemplate",
                table: "AutoReplyFlows",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                table: "AutoReplyFlows",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UseCase",
                table: "AutoReplyFlows",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NodeName",
                table: "AutoReplyFlowNodes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AutomationFlows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TriggerKeyword = table.Column<string>(type: "text", nullable: false),
                    NodesJson = table.Column<string>(type: "text", nullable: false),
                    EdgesJson = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationFlows", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutomationFlows");

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

            migrationBuilder.DropColumn(
                name: "IndustryTag",
                table: "AutoReplyRules");

            migrationBuilder.DropColumn(
                name: "SourceChannel",
                table: "AutoReplyRules");

            migrationBuilder.DropColumn(
                name: "IndustryTag",
                table: "AutoReplyFlows");

            migrationBuilder.DropColumn(
                name: "IsDefaultTemplate",
                table: "AutoReplyFlows");

            migrationBuilder.DropColumn(
                name: "Keyword",
                table: "AutoReplyFlows");

            migrationBuilder.DropColumn(
                name: "UseCase",
                table: "AutoReplyFlows");

            migrationBuilder.DropColumn(
                name: "NodeName",
                table: "AutoReplyFlowNodes");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2816));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2819));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("08e81e86-af2e-44e7-aa98-96ddbb265fd4"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3320), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("104a4dec-d683-4af5-b817-5d89b2ae09c0"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3282), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("170baea8-4ee1-433c-ae9a-bc9cb7db938f"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3303), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2fb759a5-ff0d-417f-bb97-bd4483b70a22"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3296), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("31bd93dc-41dc-4409-8d30-b1c5996624f9"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3268), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("37991ff4-bae2-408a-9a00-028fadc69810"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3286), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3bb13eca-7657-4609-ae59-15ef6b008b29"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3271), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4ad7df90-e52f-4dc5-aef8-1a7c0c70e673"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3259), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("5633443a-4b94-4adf-af7b-7c59c990c42d"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3306), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("665cf6fe-9022-4367-8474-90954e49b350"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3247), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("697a8ab6-5898-4ed6-8114-611f34ddc7e8"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3300), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("943e78ee-02dc-495e-a212-b3f037b742c7"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3251), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a64bfba6-28df-42e4-94f0-c14a37c081b7"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3237), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a71bc075-0ae0-4903-b0bd-3c5e834eb092"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3314), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("a8768168-5817-4ec6-8558-72508caf72d8"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3255), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cf227764-e3bc-4c10-a73a-f104c99b5fc2"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3263), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d585ad3d-c3bc-4d6a-ad03-15bb1bcc61c1"), new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(3277), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 9, 31, 32, 982, DateTimeKind.Utc).AddTicks(2143));
        }
    }
}
