using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Data.Migrations
{
    public partial class SeparateHardwareStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpuUsage",
                table: "NodeStatus");

            migrationBuilder.DropColumn(
                name: "RamUsage",
                table: "NodeStatus");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "NodeStatus");

            migrationBuilder.DropColumn(
                name: "TotalRam",
                table: "NodeStatus");

            migrationBuilder.AddColumn<int>(
                name: "HardwareStatusId",
                table: "NodeStatus",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HardwareStatusModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Temperature = table.Column<decimal>(nullable: false),
                    CpuUsage = table.Column<decimal>(nullable: false),
                    RamUsage = table.Column<decimal>(nullable: false),
                    TotalRam = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareStatusModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NodeStatus_HardwareStatusId",
                table: "NodeStatus",
                column: "HardwareStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_NodeStatus_HardwareStatusModel_HardwareStatusId",
                table: "NodeStatus",
                column: "HardwareStatusId",
                principalTable: "HardwareStatusModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NodeStatus_HardwareStatusModel_HardwareStatusId",
                table: "NodeStatus");

            migrationBuilder.DropTable(
                name: "HardwareStatusModel");

            migrationBuilder.DropIndex(
                name: "IX_NodeStatus_HardwareStatusId",
                table: "NodeStatus");

            migrationBuilder.DropColumn(
                name: "HardwareStatusId",
                table: "NodeStatus");

            migrationBuilder.AddColumn<decimal>(
                name: "CpuUsage",
                table: "NodeStatus",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RamUsage",
                table: "NodeStatus",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Temperature",
                table: "NodeStatus",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRam",
                table: "NodeStatus",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
