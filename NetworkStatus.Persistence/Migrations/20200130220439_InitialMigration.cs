using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NodeStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeName = table.Column<string>(nullable: true),
                    LastPinged = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardwareStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeId = table.Column<int>(nullable: false),
                    Temperature = table.Column<decimal>(nullable: false),
                    CpuUsage = table.Column<decimal>(nullable: false),
                    RamUsage = table.Column<decimal>(nullable: false),
                    TotalRam = table.Column<decimal>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareStatus", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Hardware_Node",
                        column: x => x.NodeId,
                        principalTable: "NodeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinuxServiceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeId = table.Column<int>(nullable: false),
                    ServiceName = table.Column<string>(nullable: true),
                    IsRunning = table.Column<bool>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinuxServiceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_ServiceStatus_Node",
                        column: x => x.NodeId,
                        principalTable: "NodeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NetworkStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeId = table.Column<int>(nullable: false),
                    PublicIpAddress = table.Column<string>(nullable: true),
                    IsVpn = table.Column<bool>(nullable: false),
                    PrivateIpAddress = table.Column<string>(nullable: true),
                    DownloadSpeed = table.Column<decimal>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkStatus", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Network_Node",
                        column: x => x.NodeId,
                        principalTable: "NodeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeId = table.Column<int>(nullable: false),
                    UsedStorageSpaceBytes = table.Column<long>(nullable: false),
                    TotalStorageSpaceBytes = table.Column<long>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageStatus", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Storage_Node",
                        column: x => x.NodeId,
                        principalTable: "NodeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NodeStatus",
                columns: new[] { "Id", "LastPinged", "NodeName" },
                values: new object[] { 1, new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954), "Test Node" });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 1, 50.0m, new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954), 1, 1.5m, 30.0m, 4m });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 1, new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954), true, 1, "Test service" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 1, new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954), 1.0m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 1, new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954), 1, 10000000L, 50000L });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareStatus_NodeId",
                table: "HardwareStatus",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LinuxServiceStatus_NodeId",
                table: "LinuxServiceStatus",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkStatus_NodeId",
                table: "NetworkStatus",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageStatus_NodeId",
                table: "StorageStatus",
                column: "NodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareStatus");

            migrationBuilder.DropTable(
                name: "LinuxServiceStatus");

            migrationBuilder.DropTable(
                name: "NetworkStatus");

            migrationBuilder.DropTable(
                name: "StorageStatus");

            migrationBuilder.DropTable(
                name: "NodeStatus");
        }
    }
}
