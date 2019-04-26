using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Data.Migrations
{
    public partial class RenameNodeStatusModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkStatus");

            migrationBuilder.CreateTable(
                name: "NetworkStatusModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublicIpAddress = table.Column<string>(nullable: true),
                    IsVpn = table.Column<bool>(nullable: false),
                    PrivateIpAddress = table.Column<string>(nullable: true),
                    DownloadSpeed = table.Column<decimal>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false),
                    NodeStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkStatusModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkStatusModel_NodeStatus_NodeStatusId",
                        column: x => x.NodeStatusId,
                        principalTable: "NodeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NetworkStatusModel_NodeStatusId",
                table: "NetworkStatusModel",
                column: "NodeStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkStatusModel");

            migrationBuilder.CreateTable(
                name: "NetworkStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateSent = table.Column<DateTime>(nullable: false),
                    DownloadSpeed = table.Column<decimal>(nullable: false),
                    IsVpn = table.Column<bool>(nullable: false),
                    NodeStatusId = table.Column<int>(nullable: true),
                    PrivateIpAddress = table.Column<string>(nullable: true),
                    PublicIpAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkStatus_NodeStatus_NodeStatusId",
                        column: x => x.NodeStatusId,
                        principalTable: "NodeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NetworkStatus_NodeStatusId",
                table: "NetworkStatus",
                column: "NodeStatusId");
        }
    }
}
