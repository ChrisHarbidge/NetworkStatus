using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Persistence.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareStatus_NodeStatus_NodeId",
                table: "HardwareStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_LinuxServiceStatus_NodeStatus_NodeId",
                table: "LinuxServiceStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkStatus_NodeStatus_NodeId",
                table: "NetworkStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageStatus_NodeStatus_NodeId",
                table: "StorageStatus");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Hardware_Node",
                table: "HardwareStatus",
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
                table: "NetworkStatus",
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
                table: "HardwareStatus");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_ServiceStatus_Node",
                table: "LinuxServiceStatus");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Network_Node",
                table: "NetworkStatus");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Storage_Node",
                table: "StorageStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareStatus_NodeStatus_NodeId",
                table: "HardwareStatus",
                column: "NodeId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinuxServiceStatus_NodeStatus_NodeId",
                table: "LinuxServiceStatus",
                column: "NodeId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkStatus_NodeStatus_NodeId",
                table: "NetworkStatus",
                column: "NodeId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageStatus_NodeStatus_NodeId",
                table: "StorageStatus",
                column: "NodeId",
                principalTable: "NodeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
