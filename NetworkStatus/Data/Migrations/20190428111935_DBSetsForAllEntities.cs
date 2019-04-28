using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Data.Migrations
{
    public partial class DBSetsForAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NetworkStatusModel",
                table: "NetworkStatusModel");

            migrationBuilder.RenameTable(
                name: "NetworkStatusModel",
                newName: "NetworkStatus");

            migrationBuilder.RenameIndex(
                name: "IX_NetworkStatusModel_NodeId",
                table: "NetworkStatus",
                newName: "IX_NetworkStatus_NodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetworkStatus",
                table: "NetworkStatus",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NetworkStatus",
                table: "NetworkStatus");

            migrationBuilder.RenameTable(
                name: "NetworkStatus",
                newName: "NetworkStatusModel");

            migrationBuilder.RenameIndex(
                name: "IX_NetworkStatus_NodeId",
                table: "NetworkStatusModel",
                newName: "IX_NetworkStatusModel_NodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetworkStatusModel",
                table: "NetworkStatusModel",
                column: "Id");
        }
    }
}
