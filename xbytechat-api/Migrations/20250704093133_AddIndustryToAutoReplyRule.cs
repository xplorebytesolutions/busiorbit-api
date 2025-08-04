using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddIndustryToAutoReplyRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
