using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Data.Migrations
{
    public partial class OneToManyNodeStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NodeStatus_HardwareStatusModel_HardwareStatusId",
                table: "NodeStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_NodeStatus_NetworkStatus_NetworkId",
                table: "NodeStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_NodeStatus_StorageStatus_StorageId",
                table: "NodeStatus");

            migrationBuilder.DropIndex(
                name: "IX_NodeStatus_HardwareStatusId",
                table: "NodeStatus");

            migrationBuilder.DropIndex(
                name: "IX_NodeStatus_NetworkId",
                table: "NodeStatus");

            migrationBuilder.DropIndex(
                name: "IX_NodeStatus_StorageId",
                table: "NodeStatus");

            migrationBuilder.DropColumn(
                name: "HardwareStatusId",
                table: "NodeStatus");

            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "NodeStatus");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "NodeStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSent",
                table: "StorageStatus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NodeStatusId",
                table: "StorageStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSent",
                table: "NetworkStatus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NodeStatusId",
                table: "NetworkStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSent",
                table: "LinuxServiceStatus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSent",
                table: "HardwareStatusModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NodeStatusId",
                table: "HardwareStatusModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageStatus_NodeStatusId",
                table: "StorageStatus",
                column: "NodeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkStatus_NodeStatusId",
                table: "NetworkStatus",
                column: "NodeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareStatusModel_NodeStatusId",
                table: "HardwareStatusModel",
                column: "NodeStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareStatusModel_NodeStatus_NodeStatusId",
                table: "HardwareStatusModel",
                column: "NodeStatusId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkStatus_NodeStatus_NodeStatusId",
                table: "NetworkStatus",
                column: "NodeStatusId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageStatus_NodeStatus_NodeStatusId",
                table: "StorageStatus",
                column: "NodeStatusId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareStatusModel_NodeStatus_NodeStatusId",
                table: "HardwareStatusModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkStatus_NodeStatus_NodeStatusId",
                table: "NetworkStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageStatus_NodeStatus_NodeStatusId",
                table: "StorageStatus");

            migrationBuilder.DropIndex(
                name: "IX_StorageStatus_NodeStatusId",
                table: "StorageStatus");

            migrationBuilder.DropIndex(
                name: "IX_NetworkStatus_NodeStatusId",
                table: "NetworkStatus");

            migrationBuilder.DropIndex(
                name: "IX_HardwareStatusModel_NodeStatusId",
                table: "HardwareStatusModel");

            migrationBuilder.DropColumn(
                name: "DateSent",
                table: "StorageStatus");

            migrationBuilder.DropColumn(
                name: "NodeStatusId",
                table: "StorageStatus");

            migrationBuilder.DropColumn(
                name: "DateSent",
                table: "NetworkStatus");

            migrationBuilder.DropColumn(
                name: "NodeStatusId",
                table: "NetworkStatus");

            migrationBuilder.DropColumn(
                name: "DateSent",
                table: "LinuxServiceStatus");

            migrationBuilder.DropColumn(
                name: "DateSent",
                table: "HardwareStatusModel");

            migrationBuilder.DropColumn(
                name: "NodeStatusId",
                table: "HardwareStatusModel");

            migrationBuilder.AddColumn<int>(
                name: "HardwareStatusId",
                table: "NodeStatus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NetworkId",
                table: "NodeStatus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "NodeStatus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NodeStatus_HardwareStatusId",
                table: "NodeStatus",
                column: "HardwareStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeStatus_NetworkId",
                table: "NodeStatus",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeStatus_StorageId",
                table: "NodeStatus",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_NodeStatus_HardwareStatusModel_HardwareStatusId",
                table: "NodeStatus",
                column: "HardwareStatusId",
                principalTable: "HardwareStatusModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeStatus_NetworkStatus_NetworkId",
                table: "NodeStatus",
                column: "NetworkId",
                principalTable: "NetworkStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeStatus_StorageStatus_StorageId",
                table: "NodeStatus",
                column: "StorageId",
                principalTable: "StorageStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
