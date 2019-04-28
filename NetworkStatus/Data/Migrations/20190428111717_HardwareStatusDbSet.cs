using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Data.Migrations
{
    public partial class HardwareStatusDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HardwareStatusModel",
                table: "HardwareStatusModel");

            migrationBuilder.RenameTable(
                name: "HardwareStatusModel",
                newName: "HardwareStatus");

            migrationBuilder.RenameIndex(
                name: "IX_HardwareStatusModel_NodeId",
                table: "HardwareStatus",
                newName: "IX_HardwareStatus_NodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HardwareStatus",
                table: "HardwareStatus",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HardwareStatus",
                table: "HardwareStatus");

            migrationBuilder.RenameTable(
                name: "HardwareStatus",
                newName: "HardwareStatusModel");

            migrationBuilder.RenameIndex(
                name: "IX_HardwareStatus_NodeId",
                table: "HardwareStatusModel",
                newName: "IX_HardwareStatusModel_NodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HardwareStatusModel",
                table: "HardwareStatusModel",
                column: "Id");
        }
    }
}
