using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerSarj_2022.DataAccess.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    _id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    adminid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastlogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    _id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cardid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    __v = table.Column<int>(type: "int", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    chargingdevice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    _id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    deviceid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    charginguser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobilecharging = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    devicename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    adminid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x._id);
                    table.ForeignKey(
                        name: "FK_Devices_Admins_adminid",
                        column: x => x.adminid,
                        principalTable: "Admins",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fills",
                columns: table => new
                {
                    _id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lastbalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    admin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fills", x => x._id);
                    table.ForeignKey(
                        name: "FK_Fills_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllowedSites",
                columns: table => new
                {
                    _id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Device_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowedSites", x => x._id);
                    table.ForeignKey(
                        name: "FK_AllowedSites_Devices_Device_id",
                        column: x => x.Device_id,
                        principalTable: "Devices",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceUser",
                columns: table => new
                {
                    User_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    devices_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceUser", x => new { x.User_id, x.devices_id });
                    table.ForeignKey(
                        name: "FK_DeviceUser_Devices_devices_id",
                        column: x => x.devices_id,
                        principalTable: "Devices",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceUser_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    _id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    operation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    energy = table.Column<double>(type: "float", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    deviceid = table.Column<int>(type: "int", nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x._id);
                    table.ForeignKey(
                        name: "FK_Operations_Devices_device_id",
                        column: x => x.device_id,
                        principalTable: "Devices",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operations_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowedSites_Device_id",
                table: "AllowedSites",
                column: "Device_id");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_adminid",
                table: "Devices",
                column: "adminid");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUser_devices_id",
                table: "DeviceUser",
                column: "devices_id");

            migrationBuilder.CreateIndex(
                name: "IX_Fills_user_id",
                table: "Fills",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_device_id",
                table: "Operations",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_user_id",
                table: "Operations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userid",
                table: "Users",
                column: "userid",
                unique: true,
                filter: "[userid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_username",
                table: "Users",
                column: "username",
                unique: true,
                filter: "[username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowedSites");

            migrationBuilder.DropTable(
                name: "DeviceUser");

            migrationBuilder.DropTable(
                name: "Fills");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
