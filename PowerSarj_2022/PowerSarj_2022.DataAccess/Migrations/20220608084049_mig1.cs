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
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
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
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
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

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "_id", "adminid", "lastlogin", "mail", "name", "password", "site", "surname", "tel", "username" },
                values: new object[] { "MARSIS_ADMIN_1", "mberkayakar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "m.berkay.akar@gmail.com", "Berkay", "1234", "WHITEROSE", "AKAR", "0552 693 14 36", "MBerkayAkar10" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "_id", "adminid", "lastlogin", "mail", "name", "password", "site", "surname", "tel", "username" },
                values: new object[] { "MARSIS_ADMIN_2", "recepcengiz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recepcengiz@gmail.com", "Recep", "1234", "MAR-SİS BİLİSİM", "Cengiz", "0555 XXX YY ZZ", "recepcengiz" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "_id", "adminid", "charginguser", "date", "deviceid", "devicename", "location", "mobilecharging", "price", "site", "state", "type" },
                values: new object[] { "MARDEV_1", "MARSIS_ADMIN_1", null, new DateTime(2022, 6, 8, 11, 40, 49, 42, DateTimeKind.Local).AddTicks(7048), "MARDEV_1", "MARSISBILISIM_DEVICE_1", "36.36 , 36.36", null, 0m, "WHITEROSE", null, "AC" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "_id", "adminid", "charginguser", "date", "deviceid", "devicename", "location", "mobilecharging", "price", "site", "state", "type" },
                values: new object[] { "MARDEV_2", "MARSIS_ADMIN_2", null, new DateTime(2022, 6, 8, 11, 40, 49, 43, DateTimeKind.Local).AddTicks(2090), "MARDEV_2", "MARSISBILISIM_DEVICE_2", "36.37 , 36.37", null, 0m, "MAR-SİS BİLİSİM", null, "AC" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "_id", "adminid", "charginguser", "date", "deviceid", "devicename", "location", "mobilecharging", "price", "site", "state", "type" },
                values: new object[] { "MARDEV_3", "MARSIS_ADMIN_2", null, new DateTime(2022, 6, 8, 11, 40, 49, 43, DateTimeKind.Local).AddTicks(2112), "MARDEV_3", "MARSISBILISIM_DEVICE_3", "36.37 , 36.37", null, 0m, "MAR-SİS BİLİSİM", null, "DC" });

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
