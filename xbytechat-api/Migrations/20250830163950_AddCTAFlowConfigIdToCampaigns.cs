using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddCTAFlowConfigIdToCampaigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("01cf034f-c007-45ef-a6e1-fe40d96e7108"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0232e84d-2280-4e79-b22e-6771ba8c50d5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("04c3f5f7-49a6-4313-ac4c-754a94e619fa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1368d371-d5d2-4255-904b-a9eee99ff9e9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("200514e4-91f8-479f-b305-f88d3399ff41"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2aadf3f2-3537-46dd-a500-f5c66ada8930"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("33a498f6-9212-4b14-a9e8-47363b1d6329"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3f375d64-007e-4802-94e1-e103b06ae243"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5fe0e41b-a583-4173-99ea-688b73b1d142"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("74897926-55cd-445f-bc2b-443640a9b9cc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("83153ec2-a389-4242-86bd-52c74059d433"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a86880af-6276-4112-814b-40458e466efa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b0deac97-c5d3-46ef-b3e7-dbdc41e236a8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ce9962d3-da47-48a1-973b-e8520d2beefc"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("dd2b072a-c698-4b1f-be63-48a6ad4196c8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f0715a2c-4bb7-4cbd-906e-31507b2afa13"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f8a2f420-3acc-482d-abf0-aa351889ab90"));

            migrationBuilder.AddColumn<Guid>(
                name: "CTAFlowConfigId",
                table: "Campaigns",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("05c967d4-7fa1-4bec-8173-555e5c8a8861"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9607), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("1299168e-44ff-471c-96ab-d1134f24f065"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9562), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("145866db-c47d-4f34-b94c-4a3f05266a4e"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9572), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1b2311f0-e0ec-4dcb-8d2b-b4f8390be4a9"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9520), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("28b888f9-2110-4ff6-8ea2-47d84ad9c8d8"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9587), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("2ecdbe3f-f8a7-44d9-ad36-d3b7c662b822"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9568), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("4a6b7dc5-e439-478f-8999-64ddfe78d3e6"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9542), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6a875da8-0748-4b4e-9474-f8d16e14af1b"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9582), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("7a1c1613-1fd9-41e5-8f59-ded6e694dde2"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9555), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7efdc0fc-3591-48fa-9a6a-c1d0f6bf2084"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9525), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("80d3ef51-499f-45e0-8e3d-2d14fc777a51"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9590), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("98b8d40d-7f6b-463c-9639-d63a7c359a61"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9558), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aea64726-ea39-438f-848c-6a93748ab62f"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9501), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b934bf7c-cd8f-4a44-8729-56beec734e5d"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9530), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("bea4c24b-120b-4a67-ba16-23de7b8a649d"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9536), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c8d082d6-3928-4f7e-86da-b676a7d9901d"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9610), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("efe8ca11-c7bb-4eb0-85c0-6da00a0ba58c"), new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(9599), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 16, 39, 49, 637, DateTimeKind.Utc).AddTicks(8472));

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CTAFlowConfigId",
                table: "Campaigns",
                column: "CTAFlowConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_CTAFlowConfigs_CTAFlowConfigId",
                table: "Campaigns",
                column: "CTAFlowConfigId",
                principalTable: "CTAFlowConfigs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_CTAFlowConfigs_CTAFlowConfigId",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_CTAFlowConfigId",
                table: "Campaigns");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("05c967d4-7fa1-4bec-8173-555e5c8a8861"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1299168e-44ff-471c-96ab-d1134f24f065"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("145866db-c47d-4f34-b94c-4a3f05266a4e"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1b2311f0-e0ec-4dcb-8d2b-b4f8390be4a9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("28b888f9-2110-4ff6-8ea2-47d84ad9c8d8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("2ecdbe3f-f8a7-44d9-ad36-d3b7c662b822"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4a6b7dc5-e439-478f-8999-64ddfe78d3e6"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6a875da8-0748-4b4e-9474-f8d16e14af1b"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7a1c1613-1fd9-41e5-8f59-ded6e694dde2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7efdc0fc-3591-48fa-9a6a-c1d0f6bf2084"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("80d3ef51-499f-45e0-8e3d-2d14fc777a51"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("98b8d40d-7f6b-463c-9639-d63a7c359a61"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aea64726-ea39-438f-848c-6a93748ab62f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b934bf7c-cd8f-4a44-8729-56beec734e5d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("bea4c24b-120b-4a67-ba16-23de7b8a649d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c8d082d6-3928-4f7e-86da-b676a7d9901d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("efe8ca11-c7bb-4eb0-85c0-6da00a0ba58c"));

            migrationBuilder.DropColumn(
                name: "CTAFlowConfigId",
                table: "Campaigns");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("01cf034f-c007-45ef-a6e1-fe40d96e7108"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6825), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("0232e84d-2280-4e79-b22e-6771ba8c50d5"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6943), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("04c3f5f7-49a6-4313-ac4c-754a94e619fa"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6870), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1368d371-d5d2-4255-904b-a9eee99ff9e9"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6746), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("200514e4-91f8-479f-b305-f88d3399ff41"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6879), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2aadf3f2-3537-46dd-a500-f5c66ada8930"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6951), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("33a498f6-9212-4b14-a9e8-47363b1d6329"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6763), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3f375d64-007e-4802-94e1-e103b06ae243"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6816), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("5fe0e41b-a583-4173-99ea-688b73b1d142"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6791), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("74897926-55cd-445f-bc2b-443640a9b9cc"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6890), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("83153ec2-a389-4242-86bd-52c74059d433"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6861), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a86880af-6276-4112-814b-40458e466efa"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6907), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b0deac97-c5d3-46ef-b3e7-dbdc41e236a8"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6993), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("ce9962d3-da47-48a1-973b-e8520d2beefc"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6971), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("dd2b072a-c698-4b1f-be63-48a6ad4196c8"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(7002), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("f0715a2c-4bb7-4cbd-906e-31507b2afa13"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6934), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("f8a2f420-3acc-482d-abf0-aa351889ab90"), new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(6800), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 13, 28, 1, 327, DateTimeKind.Utc).AddTicks(4488));
        }
    }
}
