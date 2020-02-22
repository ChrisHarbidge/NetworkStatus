using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkStatus.Persistence.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CpuUsage", "DateSent", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 0.580643920498269m, new DateTime(2020, 2, 22, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(3709), 0.535151584788762m, 0.32787762551004m, 2147483648m });

            migrationBuilder.InsertData(
                table: "HardwareStatus",
                columns: new[] { "Id", "CpuUsage", "DateSent", "NodeId", "RamUsage", "Temperature", "TotalRam" },
                values: new object[,]
                {
                    { 10, 0.87412453623215m, new DateTime(2020, 3, 2, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(5002), 1, 0.664338219288894m, 0.332479488725066m, 2147483648m },
                    { 9, 0.149812138709152m, new DateTime(2020, 3, 1, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(4997), 1, 0.754422777683671m, 0.0250914478791372m, 2147483648m },
                    { 8, 0.388998909568879m, new DateTime(2020, 2, 29, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(4991), 1, 0.16818913592407m, 0.140272293305151m, 2147483648m },
                    { 7, 0.0120031316820547m, new DateTime(2020, 2, 28, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(4986), 1, 0.658594589987115m, 0.0470323930713499m, 2147483648m },
                    { 2, 0.197682405448371m, new DateTime(2020, 2, 23, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(4913), 1, 0.30649041910958m, 0.136104733746548m, 2147483648m },
                    { 5, 0.241641112250109m, new DateTime(2020, 2, 26, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(4974), 1, 0.960343701280814m, 0.426200505544525m, 2147483648m },
                    { 3, 0.354786161498533m, new DateTime(2020, 2, 24, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(4962), 1, 0.304546534225599m, 0.796247567420941m, 2147483648m },
                    { 6, 0.452831974929586m, new DateTime(2020, 2, 27, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(4980), 1, 0.934128552178912m, 0.154218471215208m, 2147483648m },
                    { 4, 0.444758564440887m, new DateTime(2020, 2, 25, 21, 14, 45, 506, DateTimeKind.Local).AddTicks(4969), 1, 0.764379314037216m, 0.350447819731407m, 2147483648m }
                });

            migrationBuilder.UpdateData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSent", "ServiceName" },
                values: new object[] { new DateTime(2020, 2, 22, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(6339), "TestService" });

            migrationBuilder.InsertData(
                table: "LinuxServiceStatus",
                columns: new[] { "Id", "DateSent", "IsRunning", "NodeId", "ServiceName" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 2, 23, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(7471), true, 1, "TestService" },
                    { 3, new DateTime(2020, 2, 24, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(7526), true, 1, "TestService" },
                    { 4, new DateTime(2020, 2, 25, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(7531), true, 1, "TestService" },
                    { 5, new DateTime(2020, 2, 26, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(7535), true, 1, "TestService" },
                    { 6, new DateTime(2020, 2, 27, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(7538), true, 1, "TestService" },
                    { 8, new DateTime(2020, 2, 29, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(7545), true, 1, "TestService" },
                    { 9, new DateTime(2020, 3, 1, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(7548), true, 1, "TestService" },
                    { 10, new DateTime(2020, 3, 2, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(7552), true, 1, "TestService" },
                    { 7, new DateTime(2020, 2, 28, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(7541), true, 1, "TestService" }
                });

            migrationBuilder.UpdateData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSent", "DownloadSpeed" },
                values: new object[] { new DateTime(2020, 2, 22, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(254), 0.387793444277622m });

            migrationBuilder.InsertData(
                table: "NetworkStatus",
                columns: new[] { "Id", "DateSent", "DownloadSpeed", "IsVpn", "NodeId", "PrivateIpAddress", "PublicIpAddress" },
                values: new object[,]
                {
                    { 8, new DateTime(2020, 2, 29, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(2302), 0.967623117364768m, true, 1, "192.168.0.30", "1.1.1.1" },
                    { 10, new DateTime(2020, 3, 2, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(2312), 0.356594338247829m, true, 1, "192.168.0.30", "1.1.1.1" },
                    { 9, new DateTime(2020, 3, 1, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(2307), 0.25221631175476m, true, 1, "192.168.0.30", "1.1.1.1" },
                    { 7, new DateTime(2020, 2, 28, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(2298), 0.4848356272489m, true, 1, "192.168.0.30", "1.1.1.1" },
                    { 5, new DateTime(2020, 2, 26, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(2289), 0.287769114266974m, true, 1, "192.168.0.30", "1.1.1.1" },
                    { 3, new DateTime(2020, 2, 24, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(2278), 0.628562714731583m, true, 1, "192.168.0.30", "1.1.1.1" },
                    { 2, new DateTime(2020, 2, 23, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(2206), 0.714188226831233m, true, 1, "192.168.0.30", "1.1.1.1" },
                    { 6, new DateTime(2020, 2, 27, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(2293), 0.553525684659148m, true, 1, "192.168.0.30", "1.1.1.1" },
                    { 4, new DateTime(2020, 2, 25, 21, 14, 45, 508, DateTimeKind.Local).AddTicks(2284), 0.74022531590435m, true, 1, "192.168.0.30", "1.1.1.1" }
                });

            migrationBuilder.UpdateData(
                table: "NodeStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastPinged",
                value: new DateTime(2020, 2, 22, 21, 14, 45, 501, DateTimeKind.Local).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSent", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { new DateTime(2020, 2, 22, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(1834), 10737418240L, 1443218607L });

            migrationBuilder.InsertData(
                table: "StorageStatus",
                columns: new[] { "Id", "DateSent", "NodeId", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 2, 23, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(2894), 1, 10737418240L, 1733173690L },
                    { 3, new DateTime(2020, 2, 24, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(2937), 1, 10737418240L, 436413020L },
                    { 4, new DateTime(2020, 2, 25, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(2942), 1, 10737418240L, 616203318L },
                    { 5, new DateTime(2020, 2, 26, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(2946), 1, 10737418240L, 1028455509L },
                    { 6, new DateTime(2020, 2, 27, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(2950), 1, 10737418240L, 1061144517L },
                    { 7, new DateTime(2020, 2, 28, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(2953), 1, 10737418240L, 1849638825L },
                    { 8, new DateTime(2020, 2, 29, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(2957), 1, 10737418240L, 897743775L },
                    { 9, new DateTime(2020, 3, 1, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(2961), 1, 10737418240L, 1544501219L },
                    { 10, new DateTime(2020, 3, 2, 21, 14, 45, 509, DateTimeKind.Local).AddTicks(2964), 1, 10737418240L, 1744199831L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "HardwareStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CpuUsage", "DateSent", "RamUsage", "Temperature", "TotalRam" },
                values: new object[] { 50.0m, new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954), 1.5m, 30.0m, 4m });

            migrationBuilder.UpdateData(
                table: "LinuxServiceStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSent", "ServiceName" },
                values: new object[] { new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954), "Test service" });

            migrationBuilder.UpdateData(
                table: "NetworkStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSent", "DownloadSpeed" },
                values: new object[] { new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954), 1.0m });

            migrationBuilder.UpdateData(
                table: "NodeStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastPinged",
                value: new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954));

            migrationBuilder.UpdateData(
                table: "StorageStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSent", "TotalStorageSpaceBytes", "UsedStorageSpaceBytes" },
                values: new object[] { new DateTime(2020, 1, 30, 22, 4, 38, 588, DateTimeKind.Local).AddTicks(5954), 10000000L, 50000L });
        }
    }
}
