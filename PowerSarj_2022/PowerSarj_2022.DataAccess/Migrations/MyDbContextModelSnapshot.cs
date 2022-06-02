﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PowerSarj_2022.DataAccess.Concrete.Context.EfContext;

namespace PowerSarj_2022.DataAccess.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeviceUser", b =>
                {
                    b.Property<string>("User_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("devices_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("User_id", "devices_id");

                    b.HasIndex("devices_id");

                    b.ToTable("DeviceUser");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.Admin", b =>
                {
                    b.Property<string>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("adminid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastlogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.AllowedSites", b =>
                {
                    b.Property<string>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Device_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_id");

                    b.HasIndex("Device_id");

                    b.ToTable("AllowedSites");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.Device", b =>
                {
                    b.Property<string>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("adminid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("charginguser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("deviceid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("devicename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobilecharging")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_id");

                    b.HasIndex("adminid");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.Fill", b =>
                {
                    b.Property<string>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("admin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("lastbalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("_id");

                    b.HasIndex("user_id");

                    b.ToTable("Fills");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.Operation", b =>
                {
                    b.Property<string>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("device_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("deviceid")
                        .HasColumnType("int");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<double>("energy")
                        .HasColumnType("float");

                    b.Property<string>("operation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("_id");

                    b.HasIndex("device_id");

                    b.HasIndex("user_id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.User", b =>
                {
                    b.Property<string>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("__v")
                        .HasColumnType("int");

                    b.Property<decimal>("balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("cardid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chargingdevice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("userid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("_id");

                    b.HasIndex("userid")
                        .IsUnique()
                        .HasFilter("[userid] IS NOT NULL");

                    b.HasIndex("username")
                        .IsUnique()
                        .HasFilter("[username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DeviceUser", b =>
                {
                    b.HasOne("PowerSarj_2022.Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerSarj_2022.Entities.Concrete.Device", null)
                        .WithMany()
                        .HasForeignKey("devices_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.AllowedSites", b =>
                {
                    b.HasOne("PowerSarj_2022.Entities.Concrete.Device", null)
                        .WithMany("allowedSites")
                        .HasForeignKey("Device_id");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.Device", b =>
                {
                    b.HasOne("PowerSarj_2022.Entities.Concrete.Admin", "admin")
                        .WithMany("devices")
                        .HasForeignKey("adminid");

                    b.Navigation("admin");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.Fill", b =>
                {
                    b.HasOne("PowerSarj_2022.Entities.Concrete.User", "user")
                        .WithMany("fills")
                        .HasForeignKey("user_id");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.Operation", b =>
                {
                    b.HasOne("PowerSarj_2022.Entities.Concrete.Device", "device")
                        .WithMany("operations")
                        .HasForeignKey("device_id");

                    b.HasOne("PowerSarj_2022.Entities.Concrete.User", "user")
                        .WithMany("operations")
                        .HasForeignKey("user_id");

                    b.Navigation("device");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.Admin", b =>
                {
                    b.Navigation("devices");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.Device", b =>
                {
                    b.Navigation("allowedSites");

                    b.Navigation("operations");
                });

            modelBuilder.Entity("PowerSarj_2022.Entities.Concrete.User", b =>
                {
                    b.Navigation("fills");

                    b.Navigation("operations");
                });
#pragma warning restore 612, 618
        }
    }
}