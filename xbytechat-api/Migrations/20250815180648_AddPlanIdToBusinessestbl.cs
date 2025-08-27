using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanIdToBusinessestbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("10074a09-5db5-4e2e-9d12-97d89079ba43"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1694debc-9945-4918-ab2d-a18baf097c25"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1938632b-e6b4-4b3f-9cd0-f86304184ff0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("22ce1b29-a2dc-4c99-924a-fb1c947e05b7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("25801f86-7ae8-41f4-8512-ff76d5a10596"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2e5fbcc5-4671-4eba-8e70-22fdcadbfb86"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3fc84fcb-f95a-4d1d-b8af-1d00fb10bff8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7129083f-2a63-4b04-bfdc-e8e299c26978"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("81c240af-c44b-4ae7-b17a-898db3a76007"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("83c06787-5e61-4d38-b937-b3b771f1203f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a8a067ca-6119-455c-9921-0c3b2862dee7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b38ef749-bab7-4f05-8fb6-209e1ba9d842"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("cc42f0a5-1e27-4848-ab3a-1c7620e56bcb"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("de123a2a-23ad-4aea-ad11-63f14e44d21a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e195e4db-5a73-4979-8b4f-768e3aec1a67"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ec7a1734-9e24-461b-94af-5b63d7067a13"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f2f832f2-370c-4c86-9daf-b93e6736233c"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "Businesses",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_PlanId",
                table: "Businesses",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Plans_PlanId",
                table: "Businesses",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Plans_PlanId",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_PlanId",
                table: "Businesses");

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

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Businesses");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2922));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2925));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2927));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2936));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2996));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("10074a09-5db5-4e2e-9d12-97d89079ba43"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3554), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("1694debc-9945-4918-ab2d-a18baf097c25"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3527), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1938632b-e6b4-4b3f-9cd0-f86304184ff0"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3508), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("22ce1b29-a2dc-4c99-924a-fb1c947e05b7"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3491), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("25801f86-7ae8-41f4-8512-ff76d5a10596"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3523), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2e5fbcc5-4671-4eba-8e70-22fdcadbfb86"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3475), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3fc84fcb-f95a-4d1d-b8af-1d00fb10bff8"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3467), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7129083f-2a63-4b04-bfdc-e8e299c26978"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3559), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("81c240af-c44b-4ae7-b17a-898db3a76007"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3486), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("83c06787-5e61-4d38-b937-b3b771f1203f"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3548), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("a8a067ca-6119-455c-9921-0c3b2862dee7"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3537), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("b38ef749-bab7-4f05-8fb6-209e1ba9d842"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3483), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cc42f0a5-1e27-4848-ab3a-1c7620e56bcb"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3518), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("de123a2a-23ad-4aea-ad11-63f14e44d21a"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3512), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e195e4db-5a73-4979-8b4f-768e3aec1a67"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3541), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("ec7a1734-9e24-461b-94af-5b63d7067a13"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3545), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("f2f832f2-370c-4c86-9daf-b93e6736233c"), new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(3479), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 15, 18, 4, 12, 571, DateTimeKind.Utc).AddTicks(2291));
        }
    }
}
