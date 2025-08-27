using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddProviderAndApiKeyToWhatsAppSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("031e65e6-599d-439c-a1d8-8decdcb98a26"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2370e10b-2703-4299-bdaf-88e0612580d6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3eb15687-7591-49b8-8ffd-f7399dd12585"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("44a2fe82-5e92-4c07-823a-340698292992"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("496860c0-4c58-44bd-a6e7-babccb2b8a2a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("53a96adc-7794-43c3-a0bb-0f44bda7c1a4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("56d97758-ac0a-4afb-a96b-ed581be2181c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("619cbee9-dcce-45b9-a80a-003973f496f2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6a5e4880-abb4-4fc3-ac20-8501caa54f5b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7ff0f2f7-b7a8-4538-a4fb-c7518aa52e39"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a8fed746-37aa-4550-ab7e-9d584743e28d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b3bfa028-194c-4c49-b0bb-1a9e6d6a96cc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("be7c15a3-99bc-4637-8d40-ee8d5027971e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cab58879-d116-4e65-8c77-1545cec43e87"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d9abd4cb-4e9e-448f-ae87-24f6fbd1d16c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dde37ff0-6eb9-407a-8a39-dbb2b811d391"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fcad5c0b-f2a0-438a-920d-aabff6eca1a7"));

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppBusinessNumber",
                table: "WhatsAppSettings",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "WhatsAppSettings",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Provider",
                table: "WhatsAppSettings",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WebhookSecret",
                table: "WhatsAppSettings",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebhookVerifyToken",
                table: "WhatsAppSettings",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "WhatsAppSettings");

            migrationBuilder.DropColumn(
                name: "Provider",
                table: "WhatsAppSettings");

            migrationBuilder.DropColumn(
                name: "WebhookSecret",
                table: "WhatsAppSettings");

            migrationBuilder.DropColumn(
                name: "WebhookVerifyToken",
                table: "WhatsAppSettings");

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppBusinessNumber",
                table: "WhatsAppSettings",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4243));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("031e65e6-599d-439c-a1d8-8decdcb98a26"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4636), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2370e10b-2703-4299-bdaf-88e0612580d6"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4654), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3eb15687-7591-49b8-8ffd-f7399dd12585"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4665), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("44a2fe82-5e92-4c07-823a-340698292992"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4755), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("496860c0-4c58-44bd-a6e7-babccb2b8a2a"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4710), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("53a96adc-7794-43c3-a0bb-0f44bda7c1a4"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4602), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("56d97758-ac0a-4afb-a96b-ed581be2181c"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4669), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("619cbee9-dcce-45b9-a80a-003973f496f2"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4651), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6a5e4880-abb4-4fc3-ac20-8501caa54f5b"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4661), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7ff0f2f7-b7a8-4538-a4fb-c7518aa52e39"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4647), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a8fed746-37aa-4550-ab7e-9d584743e28d"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4689), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("b3bfa028-194c-4c49-b0bb-1a9e6d6a96cc"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4686), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("be7c15a3-99bc-4637-8d40-ee8d5027971e"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4702), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("cab58879-d116-4e65-8c77-1545cec43e87"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4682), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("d9abd4cb-4e9e-448f-ae87-24f6fbd1d16c"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4658), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("dde37ff0-6eb9-407a-8a39-dbb2b811d391"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4618), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fcad5c0b-f2a0-438a-920d-aabff6eca1a7"), new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(4611), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 6, 48, 259, DateTimeKind.Utc).AddTicks(3372));
        }
    }
}
