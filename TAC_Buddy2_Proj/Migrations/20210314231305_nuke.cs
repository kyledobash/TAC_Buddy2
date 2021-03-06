﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TAC_Buddy2_Proj.Migrations
{
    public partial class nuke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDL_Items",
                columns: table => new
                {
                    EDL_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAC_TeamLeader_ID = table.Column<int>(nullable: true),
                    TAC_TeamMate_ID = table.Column<int>(nullable: true),
                    EDL_Item_Name = table.Column<string>(nullable: true),
                    EDL_Serial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDL_Items", x => x.EDL_ID);
                });

            migrationBuilder.CreateTable(
                name: "TAC_TeamMates",
                columns: table => new
                {
                    TAC_TeamMate_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAC_TeamLeader_ID = table.Column<int>(nullable: false),
                    Rank = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EDIPI_DoD_ID = table.Column<double>(nullable: false),
                    Billet = table.Column<string>(nullable: true),
                    MOS_designator = table.Column<string>(nullable: true),
                    EDL_Last_Verified = table.Column<DateTime>(nullable: false),
                    ZAP_Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAC_TeamMates", x => x.TAC_TeamMate_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TAC_TeamLeaders",
                columns: table => new
                {
                    TAC_TeamLeader_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EDIPI_DoD_ID = table.Column<double>(nullable: false),
                    Billet = table.Column<string>(nullable: true),
                    MOS_designator = table.Column<string>(nullable: true),
                    EDL_Last_Verified = table.Column<DateTime>(nullable: false),
                    ZAP_Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAC_TeamLeaders", x => x.TAC_TeamLeader_ID);
                    table.ForeignKey(
                        name: "FK_TAC_TeamLeaders_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd0ba084-28a8-4cf8-9c2e-1526d55a71eb", "36d84b38-e15e-4825-98b4-120d52067ec5", "TAC_TeamLeader", "TAC_TeamLeader" });

            migrationBuilder.InsertData(
                table: "EDL_Items",
                columns: new[] { "EDL_ID", "EDL_Item_Name", "EDL_Serial", "TAC_TeamLeader_ID", "TAC_TeamMate_ID" },
                values: new object[,]
                {
                    { 24, "PRC-152", "G49YT328", null, 4 },
                    { 23, "CMD", "GITJ8498", null, 4 },
                    { 22, "PVS-31", "5893743905", null, 4 },
                    { 21, "GLOCK 17", "48957390", null, 4 },
                    { 20, "M4A1", "93KIRT373", null, 4 },
                    { 19, "PVS-31", "JWWU9374", null, 3 },
                    { 18, "PRC-152", "JDI8394", null, 3 },
                    { 17, "240B SPARE BARREL", "IDS9345", null, 3 },
                    { 16, "GLOCK 17", "IDS9345", null, 3 },
                    { 15, "M240B", "1178DI99B", null, 3 },
                    { 13, "PRC-117", "99JKI54", null, 2 },
                    { 14, "PRC-152", "102QE32", null, 2 },
                    { 11, "PVS-31", "HJ33HU23T", null, 2 },
                    { 10, "M4A1", "993JF9I807", null, 2 },
                    { 9, "PRC-152", "94858937", null, 1 },
                    { 8, "GLOCK 17", "1979TG143", null, 1 },
                    { 7, "PVS-31", "45578982", null, 1 },
                    { 6, "M110 SASS", "8679YU123", null, 1 },
                    { 5, "GLOCK 17", "TT5R91", 1, null },
                    { 4, "PRC-152", "008POZ91", 1, null },
                    { 3, "M203", "98HJU7", 1, null },
                    { 2, "PVS-14", "4552983", 1, null },
                    { 1, "M38", "189GH200", 1, null },
                    { 12, "GLOCK 17", "JT9012CV", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "TAC_TeamMates",
                columns: new[] { "TAC_TeamMate_ID", "Billet", "EDIPI_DoD_ID", "EDL_Last_Verified", "FirstName", "LastName", "MOS_designator", "Rank", "TAC_TeamLeader_ID", "ZAP_Number" },
                values: new object[,]
                {
                    { 3, "Machine Gunner", 1424993820.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dylan", "Snyder", "0331", "CPL", 1, "DS93820" },
                    { 1, "Sniper", 1672285964.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jared", "Firebaugh", "0317", "CPL", 1, "JF85964" },
                    { 2, "JTAC", 1683040678.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dan", "Wargo", "8002", "SGT", 1, "DW40678" },
                    { 4, "EOD", 1839477601.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeffery", "Allen", "2336", "CPL", 1, "JA77601" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TAC_TeamLeaders_IdentityUserId",
                table: "TAC_TeamLeaders",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EDL_Items");

            migrationBuilder.DropTable(
                name: "TAC_TeamLeaders");

            migrationBuilder.DropTable(
                name: "TAC_TeamMates");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
