﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetworkStatus.Persistence.Data;

namespace NetworkStatus.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetworkStatus.Persistence.Models.HardwareStatusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CpuUsage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.Property<decimal>("RamUsage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalRam")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("HardwareStatus");
                });

            modelBuilder.Entity("NetworkStatus.Persistence.Models.LinuxServiceStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRunning")
                        .HasColumnType("bit");

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("LinuxServiceStatus");
                });

            modelBuilder.Entity("NetworkStatus.Persistence.Models.NetworkStatusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DownloadSpeed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsVpn")
                        .HasColumnType("bit");

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.Property<string>("PrivateIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("NetworkStatus");
                });

            modelBuilder.Entity("NetworkStatus.Persistence.Models.NodeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastPinged")
                        .HasColumnType("datetime2");

                    b.Property<string>("NodeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NodeStatus");
                });

            modelBuilder.Entity("NetworkStatus.Persistence.Models.StorageStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.Property<long>("TotalStorageSpaceBytes")
                        .HasColumnType("bigint");

                    b.Property<long>("UsedStorageSpaceBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("StorageStatus");
                });

            modelBuilder.Entity("NetworkStatus.Persistence.Models.HardwareStatusModel", b =>
                {
                    b.HasOne("NetworkStatus.Persistence.Models.NodeStatus", "Node")
                        .WithMany("HardwareStatus")
                        .HasForeignKey("NodeId")
                        .HasConstraintName("ForeignKey_Hardware_Node")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetworkStatus.Persistence.Models.LinuxServiceStatus", b =>
                {
                    b.HasOne("NetworkStatus.Persistence.Models.NodeStatus", "Node")
                        .WithMany("Services")
                        .HasForeignKey("NodeId")
                        .HasConstraintName("ForeignKey_ServiceStatus_Node")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetworkStatus.Persistence.Models.NetworkStatusModel", b =>
                {
                    b.HasOne("NetworkStatus.Persistence.Models.NodeStatus", "Node")
                        .WithMany("Network")
                        .HasForeignKey("NodeId")
                        .HasConstraintName("ForeignKey_Network_Node")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetworkStatus.Persistence.Models.StorageStatus", b =>
                {
                    b.HasOne("NetworkStatus.Persistence.Models.NodeStatus", "Node")
                        .WithMany("Storage")
                        .HasForeignKey("NodeId")
                        .HasConstraintName("ForeignKey_Storage_Node")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
