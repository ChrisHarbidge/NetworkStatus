using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Data.Migrations
{
    public partial class NodeNetworkStorageServiceAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NetworkId",
                table: "NodeStatus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "NodeStatus",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LinuxServiceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceName = table.Column<string>(nullable: true),
                    IsRunning = table.Column<bool>(nullable: false),
                    NodeStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinuxServiceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinuxServiceStatus_NodeStatus_NodeStatusId",
                        column: x => x.NodeStatusId,
                        principalTable: "NodeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NetworkStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublicIpAddress = table.Column<string>(nullable: true),
                    IsVpn = table.Column<bool>(nullable: false),
                    PrivateIpAddress = table.Column<string>(nullable: true),
                    DownloadSpeed = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsedStorageSpaceBytes = table.Column<long>(nullable: false),
                    TotalStorageSpaceBytes = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NodeStatus_NetworkId",
                table: "NodeStatus",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeStatus_StorageId",
                table: "NodeStatus",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_LinuxServiceStatus_NodeStatusId",
                table: "LinuxServiceStatus",
                column: "NodeStatusId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NodeStatus_NetworkStatus_NetworkId",
                table: "NodeStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_NodeStatus_StorageStatus_StorageId",
                table: "NodeStatus");

            migrationBuilder.DropTable(
                name: "LinuxServiceStatus");

            migrationBuilder.DropTable(
                name: "NetworkStatus");

            migrationBuilder.DropTable(
                name: "StorageStatus");

            migrationBuilder.DropIndex(
                name: "IX_NodeStatus_NetworkId",
                table: "NodeStatus");

            migrationBuilder.DropIndex(
                name: "IX_NodeStatus_StorageId",
                table: "NodeStatus");

            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "NodeStatus");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "NodeStatus");
        }
    }
}
