using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class AddButtonIndexToFlowButtonLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("30b5f2bf-1a4b-46ea-81fa-bcc4ff03fb7f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("456a1d36-b480-4f35-855c-bd941f7efad5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("53377700-2e84-4ae2-8111-1615445222f8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("53bd445c-fd53-4284-8904-712254274bdf"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5f00e094-66b5-4181-a6f3-fbfa57cab06c"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("6151496e-7b23-4a84-8091-d3f5cdea3343"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7d85e4ef-65c4-43c9-8211-4cfd148f6513"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7de7de7b-2c42-4f59-bdba-e8af3afa52dd"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7f11a2f1-0554-4e2e-ae95-8c7d43f5af47"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("892ee30e-97f5-4bb1-bd82-88411471ca87"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa91baab-7ed5-4eef-acbc-81dfae94df51"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ae6a2f12-6c38-45c6-aad3-374123e88e44"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c3dc1883-2f8a-46b0-a32c-73912d9aa884"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c7af55db-9406-429f-bce4-c821358f1174"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d38cd84f-260a-4207-b889-8e6501574fa0"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("d8d5a2a2-848a-4a2e-85d4-9cb3c1394063"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f4eb61f9-6b9f-4b8b-8fc8-29ba80e877ed"));

            migrationBuilder.AddColumn<short>(
                name: "ButtonIndex",
                table: "FlowExecutionLogs",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MessageLogId",
                table: "FlowExecutionLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "FlowExecutionLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "ButtonIndex",
                table: "FlowButtonLinks",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ButtonIndex",
                table: "FlowExecutionLogs");

            migrationBuilder.DropColumn(
                name: "MessageLogId",
                table: "FlowExecutionLogs");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "FlowExecutionLogs");

            migrationBuilder.DropColumn(
                name: "ButtonIndex",
                table: "FlowButtonLinks");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4400));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("30b5f2bf-1a4b-46ea-81fa-bcc4ff03fb7f"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4848), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("456a1d36-b480-4f35-855c-bd941f7efad5"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4909), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("53377700-2e84-4ae2-8111-1615445222f8"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4888), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("53bd445c-fd53-4284-8904-712254274bdf"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4873), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("5f00e094-66b5-4181-a6f3-fbfa57cab06c"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4922), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("6151496e-7b23-4a84-8091-d3f5cdea3343"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4905), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7d85e4ef-65c4-43c9-8211-4cfd148f6513"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4951), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("7de7de7b-2c42-4f59-bdba-e8af3afa52dd"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4869), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7f11a2f1-0554-4e2e-ae95-8c7d43f5af47"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4893), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("892ee30e-97f5-4bb1-bd82-88411471ca87"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4854), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aa91baab-7ed5-4eef-acbc-81dfae94df51"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4859), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ae6a2f12-6c38-45c6-aad3-374123e88e44"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4830), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c3dc1883-2f8a-46b0-a32c-73912d9aa884"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4957), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("c7af55db-9406-429f-bce4-c821358f1174"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4930), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("d38cd84f-260a-4207-b889-8e6501574fa0"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4926), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("d8d5a2a2-848a-4a2e-85d4-9cb3c1394063"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4900), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f4eb61f9-6b9f-4b8b-8fc8-29ba80e877ed"), new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(4942), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 12, 49, 45, 630, DateTimeKind.Utc).AddTicks(3506));
        }
    }
}
