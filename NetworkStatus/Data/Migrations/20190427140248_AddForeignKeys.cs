using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Data.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareStatusModel_NodeStatus_NodeStatusId",
                table: "HardwareStatusModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LinuxServiceStatus_NodeStatus_NodeStatusId",
                table: "LinuxServiceStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkStatusModel_NodeStatus_NodeStatusId",
                table: "NetworkStatusModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageStatus_NodeStatus_NodeStatusId",
                table: "StorageStatus");

            migrationBuilder.DropIndex(
                name: "IX_StorageStatus_NodeStatusId",
                table: "StorageStatus");

            migrationBuilder.DropIndex(
                name: "IX_NetworkStatusModel_NodeStatusId",
                table: "NetworkStatusModel");

            migrationBuilder.DropIndex(
                name: "IX_LinuxServiceStatus_NodeStatusId",
                table: "LinuxServiceStatus");

            migrationBuilder.DropIndex(
                name: "IX_HardwareStatusModel_NodeStatusId",
                table: "HardwareStatusModel");

            migrationBuilder.DropColumn(
                name: "NodeStatusId",
                table: "StorageStatus");

            migrationBuilder.DropColumn(
                name: "NodeStatusId",
                table: "NetworkStatusModel");

            migrationBuilder.DropColumn(
                name: "NodeStatusId",
                table: "LinuxServiceStatus");

            migrationBuilder.DropColumn(
                name: "NodeStatusId",
                table: "HardwareStatusModel");

            migrationBuilder.AddColumn<int>(
                name: "NodeId",
                table: "StorageStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NodeId",
                table: "NetworkStatusModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NodeId",
                table: "LinuxServiceStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NodeId",
                table: "HardwareStatusModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StorageStatus_NodeId",
                table: "StorageStatus",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkStatusModel_NodeId",
                table: "NetworkStatusModel",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LinuxServiceStatus_NodeId",
                table: "LinuxServiceStatus",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareStatusModel_NodeId",
                table: "HardwareStatusModel",
                column: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Hardware_Node",
                table: "HardwareStatusModel",
                column: "NodeId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_ServiceStatus_Node",
                table: "LinuxServiceStatus",
                column: "NodeId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Network_Node",
                table: "NetworkStatusModel",
                column: "NodeId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Storage_Node",
                table: "StorageStatus",
                column: "NodeId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Hardware_Node",
                table: "HardwareStatusModel");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_ServiceStatus_Node",
                table: "LinuxServiceStatus");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Network_Node",
                table: "NetworkStatusModel");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Storage_Node",
                table: "StorageStatus");

            migrationBuilder.DropIndex(
                name: "IX_StorageStatus_NodeId",
                table: "StorageStatus");

            migrationBuilder.DropIndex(
                name: "IX_NetworkStatusModel_NodeId",
                table: "NetworkStatusModel");

            migrationBuilder.DropIndex(
                name: "IX_LinuxServiceStatus_NodeId",
                table: "LinuxServiceStatus");

            migrationBuilder.DropIndex(
                name: "IX_HardwareStatusModel_NodeId",
                table: "HardwareStatusModel");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "StorageStatus");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "NetworkStatusModel");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "LinuxServiceStatus");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "HardwareStatusModel");

            migrationBuilder.AddColumn<int>(
                name: "NodeStatusId",
                table: "StorageStatus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NodeStatusId",
                table: "NetworkStatusModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NodeStatusId",
                table: "LinuxServiceStatus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NodeStatusId",
                table: "HardwareStatusModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageStatus_NodeStatusId",
                table: "StorageStatus",
                column: "NodeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkStatusModel_NodeStatusId",
                table: "NetworkStatusModel",
                column: "NodeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LinuxServiceStatus_NodeStatusId",
                table: "LinuxServiceStatus",
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
                name: "FK_LinuxServiceStatus_NodeStatus_NodeStatusId",
                table: "LinuxServiceStatus",
                column: "NodeStatusId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkStatusModel_NodeStatus_NodeStatusId",
                table: "NetworkStatusModel",
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
    }
}
