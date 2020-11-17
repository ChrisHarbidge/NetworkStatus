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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                values: new object[] { 1, new DateTime(2020, 11, 17, 21, 44, 26, 45, DateTimeKind.Local).AddTicks(356), "Test Node" });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 1, 0.48329390375097m, new DateTime(2020, 11, 17, 21, 44, 26, 56, DateTimeKind.Local).AddTicks(9701), 1, 0.208852175720433m, 0.2542829621836m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 2, 0.114092039463153m, new DateTime(2020, 11, 18, 21, 44, 26, 57, DateTimeKind.Local).AddTicks(1523), 1, 0.263363463461103m, 0.32459349060645m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 3, 0.437905222381421m, new DateTime(2020, 11, 19, 21, 44, 26, 57, DateTimeKind.Local).AddTicks(1586), 1, 0.87183145055167m, 0.670715095787642m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 4, 0.758213380704733m, new DateTime(2020, 11, 20, 21, 44, 26, 57, DateTimeKind.Local).AddTicks(1594), 1, 0.267879830798078m, 0.641933014449632m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 5, 0.817963649899682m, new DateTime(2020, 11, 21, 21, 44, 26, 57, DateTimeKind.Local).AddTicks(1602), 1, 0.397608822396774m, 0.613626965141682m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 6, 0.178433545016886m, new DateTime(2020, 11, 22, 21, 44, 26, 57, DateTimeKind.Local).AddTicks(1608), 1, 0.554328349211406m, 0.103307935457354m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 7, 0.995520405469239m, new DateTime(2020, 11, 23, 21, 44, 26, 57, DateTimeKind.Local).AddTicks(1614), 1, 0.488765093725531m, 0.590631458252031m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 8, 0.19158198972772m, new DateTime(2020, 11, 24, 21, 44, 26, 57, DateTimeKind.Local).AddTicks(1621), 1, 0.0351200779132173m, 0.441340396851925m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 9, 0.484966098091084m, new DateTime(2020, 11, 25, 21, 44, 26, 57, DateTimeKind.Local).AddTicks(1627), 1, 0.387735289236407m, 0.353214876425087m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 10, 0.6571174592977m, new DateTime(2020, 11, 26, 21, 44, 26, 57, DateTimeKind.Local).AddTicks(1634), 1, 0.457854005255668m, 0.884976789767378m, 2147483648m });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 9, new DateTime(2020, 11, 25, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(1933), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 8, new DateTime(2020, 11, 24, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(1930), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 7, new DateTime(2020, 11, 23, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(1926), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 6, new DateTime(2020, 11, 22, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(1923), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 10, new DateTime(2020, 11, 26, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(1936), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 4, new DateTime(2020, 11, 20, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(1916), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 3, new DateTime(2020, 11, 19, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(1912), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 2, new DateTime(2020, 11, 18, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(1845), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 1, new DateTime(2020, 11, 17, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(148), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[] { 5, new DateTime(2020, 11, 21, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(1920), true, 1, "TestService" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 10, new DateTime(2020, 11, 26, 21, 44, 26, 60, DateTimeKind.Local).AddTicks(1551), 0.304559786945842m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 9, new DateTime(2020, 11, 25, 21, 44, 26, 60, DateTimeKind.Local).AddTicks(1546), 0.654771542947167m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 7, new DateTime(2020, 11, 23, 21, 44, 26, 60, DateTimeKind.Local).AddTicks(1535), 0.91979301484292m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 6, new DateTime(2020, 11, 22, 21, 44, 26, 60, DateTimeKind.Local).AddTicks(1469), 0.271638334855269m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 8, new DateTime(2020, 11, 24, 21, 44, 26, 60, DateTimeKind.Local).AddTicks(1541), 0.0590821323260116m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 4, new DateTime(2020, 11, 20, 21, 44, 26, 60, DateTimeKind.Local).AddTicks(1459), 0.478518301843907m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 3, new DateTime(2020, 11, 19, 21, 44, 26, 60, DateTimeKind.Local).AddTicks(1452), 0.343362064260692m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 2, new DateTime(2020, 11, 18, 21, 44, 26, 60, DateTimeKind.Local).AddTicks(1281), 0.962442633678411m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 1, new DateTime(2020, 11, 17, 21, 44, 26, 59, DateTimeKind.Local).AddTicks(8458), 0.987832665903416m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[] { 5, new DateTime(2020, 11, 21, 21, 44, 26, 60, DateTimeKind.Local).AddTicks(1464), 0.108699596537603m, true, 1, "192.168.0.30", "1.1.1.1" });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 9, new DateTime(2020, 11, 25, 21, 44, 26, 62, DateTimeKind.Local).AddTicks(1335), 1, 10737418240L, 185897056L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 1, new DateTime(2020, 11, 17, 21, 44, 26, 61, DateTimeKind.Local).AddTicks(9398), 1, 10737418240L, 1276009554L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 2, new DateTime(2020, 11, 18, 21, 44, 26, 62, DateTimeKind.Local).AddTicks(1253), 1, 10737418240L, 1346047849L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 3, new DateTime(2020, 11, 19, 21, 44, 26, 62, DateTimeKind.Local).AddTicks(1314), 1, 10737418240L, 1251731990L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 4, new DateTime(2020, 11, 20, 21, 44, 26, 62, DateTimeKind.Local).AddTicks(1319), 1, 10737418240L, 1914460312L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 5, new DateTime(2020, 11, 21, 21, 44, 26, 62, DateTimeKind.Local).AddTicks(1322), 1, 10737418240L, 1075023942L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 6, new DateTime(2020, 11, 22, 21, 44, 26, 62, DateTimeKind.Local).AddTicks(1325), 1, 10737418240L, 788242283L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 7, new DateTime(2020, 11, 23, 21, 44, 26, 62, DateTimeKind.Local).AddTicks(1329), 1, 10737418240L, 1562396765L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 8, new DateTime(2020, 11, 24, 21, 44, 26, 62, DateTimeKind.Local).AddTicks(1332), 1, 10737418240L, 670738377L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { 10, new DateTime(2020, 11, 26, 21, 44, 26, 62, DateTimeKind.Local).AddTicks(1339), 1, 10737418240L, 1020361374L });

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
