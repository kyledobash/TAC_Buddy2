﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TAC_Buddy2_Proj.Data;

namespace TAC_Buddy2_Proj.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210314231305_nuke")]
    partial class nuke
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "dd0ba084-28a8-4cf8-9c2e-1526d55a71eb",
                            ConcurrencyStamp = "36d84b38-e15e-4825-98b4-120d52067ec5",
                            Name = "TAC_TeamLeader",
                            NormalizedName = "TAC_TeamLeader"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TAC_Buddy2_Proj.Models.EDL_Item", b =>
                {
                    b.Property<int>("EDL_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EDL_Item_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EDL_Serial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TAC_TeamLeader_ID")
                        .HasColumnType("int");

                    b.Property<int?>("TAC_TeamMate_ID")
                        .HasColumnType("int");

                    b.HasKey("EDL_ID");

                    b.ToTable("EDL_Items");

                    b.HasData(
                        new
                        {
                            EDL_ID = 1,
                            EDL_Item_Name = "M38",
                            EDL_Serial = "189GH200",
                            TAC_TeamLeader_ID = 1
                        },
                        new
                        {
                            EDL_ID = 2,
                            EDL_Item_Name = "PVS-14",
                            EDL_Serial = "4552983",
                            TAC_TeamLeader_ID = 1
                        },
                        new
                        {
                            EDL_ID = 3,
                            EDL_Item_Name = "M203",
                            EDL_Serial = "98HJU7",
                            TAC_TeamLeader_ID = 1
                        },
                        new
                        {
                            EDL_ID = 4,
                            EDL_Item_Name = "PRC-152",
                            EDL_Serial = "008POZ91",
                            TAC_TeamLeader_ID = 1
                        },
                        new
                        {
                            EDL_ID = 5,
                            EDL_Item_Name = "GLOCK 17",
                            EDL_Serial = "TT5R91",
                            TAC_TeamLeader_ID = 1
                        },
                        new
                        {
                            EDL_ID = 6,
                            EDL_Item_Name = "M110 SASS",
                            EDL_Serial = "8679YU123",
                            TAC_TeamMate_ID = 1
                        },
                        new
                        {
                            EDL_ID = 7,
                            EDL_Item_Name = "PVS-31",
                            EDL_Serial = "45578982",
                            TAC_TeamMate_ID = 1
                        },
                        new
                        {
                            EDL_ID = 8,
                            EDL_Item_Name = "GLOCK 17",
                            EDL_Serial = "1979TG143",
                            TAC_TeamMate_ID = 1
                        },
                        new
                        {
                            EDL_ID = 9,
                            EDL_Item_Name = "PRC-152",
                            EDL_Serial = "94858937",
                            TAC_TeamMate_ID = 1
                        },
                        new
                        {
                            EDL_ID = 10,
                            EDL_Item_Name = "M4A1",
                            EDL_Serial = "993JF9I807",
                            TAC_TeamMate_ID = 2
                        },
                        new
                        {
                            EDL_ID = 11,
                            EDL_Item_Name = "PVS-31",
                            EDL_Serial = "HJ33HU23T",
                            TAC_TeamMate_ID = 2
                        },
                        new
                        {
                            EDL_ID = 12,
                            EDL_Item_Name = "GLOCK 17",
                            EDL_Serial = "JT9012CV",
                            TAC_TeamMate_ID = 2
                        },
                        new
                        {
                            EDL_ID = 13,
                            EDL_Item_Name = "PRC-117",
                            EDL_Serial = "99JKI54",
                            TAC_TeamMate_ID = 2
                        },
                        new
                        {
                            EDL_ID = 14,
                            EDL_Item_Name = "PRC-152",
                            EDL_Serial = "102QE32",
                            TAC_TeamMate_ID = 2
                        },
                        new
                        {
                            EDL_ID = 15,
                            EDL_Item_Name = "M240B",
                            EDL_Serial = "1178DI99B",
                            TAC_TeamMate_ID = 3
                        },
                        new
                        {
                            EDL_ID = 16,
                            EDL_Item_Name = "GLOCK 17",
                            EDL_Serial = "IDS9345",
                            TAC_TeamMate_ID = 3
                        },
                        new
                        {
                            EDL_ID = 17,
                            EDL_Item_Name = "240B SPARE BARREL",
                            EDL_Serial = "IDS9345",
                            TAC_TeamMate_ID = 3
                        },
                        new
                        {
                            EDL_ID = 18,
                            EDL_Item_Name = "PRC-152",
                            EDL_Serial = "JDI8394",
                            TAC_TeamMate_ID = 3
                        },
                        new
                        {
                            EDL_ID = 19,
                            EDL_Item_Name = "PVS-31",
                            EDL_Serial = "JWWU9374",
                            TAC_TeamMate_ID = 3
                        },
                        new
                        {
                            EDL_ID = 20,
                            EDL_Item_Name = "M4A1",
                            EDL_Serial = "93KIRT373",
                            TAC_TeamMate_ID = 4
                        },
                        new
                        {
                            EDL_ID = 21,
                            EDL_Item_Name = "GLOCK 17",
                            EDL_Serial = "48957390",
                            TAC_TeamMate_ID = 4
                        },
                        new
                        {
                            EDL_ID = 22,
                            EDL_Item_Name = "PVS-31",
                            EDL_Serial = "5893743905",
                            TAC_TeamMate_ID = 4
                        },
                        new
                        {
                            EDL_ID = 23,
                            EDL_Item_Name = "CMD",
                            EDL_Serial = "GITJ8498",
                            TAC_TeamMate_ID = 4
                        },
                        new
                        {
                            EDL_ID = 24,
                            EDL_Item_Name = "PRC-152",
                            EDL_Serial = "G49YT328",
                            TAC_TeamMate_ID = 4
                        });
                });

            modelBuilder.Entity("TAC_Buddy2_Proj.Models.TAC_TeamLeader", b =>
                {
                    b.Property<int>("TAC_TeamLeader_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Billet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EDIPI_DoD_ID")
                        .HasColumnType("float");

                    b.Property<DateTime>("EDL_Last_Verified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MOS_designator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZAP_Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TAC_TeamLeader_ID");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("TAC_TeamLeaders");
                });

            modelBuilder.Entity("TAC_Buddy2_Proj.Models.TAC_TeamMate", b =>
                {
                    b.Property<int>("TAC_TeamMate_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Billet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EDIPI_DoD_ID")
                        .HasColumnType("float");

                    b.Property<DateTime>("EDL_Last_Verified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MOS_designator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TAC_TeamLeader_ID")
                        .HasColumnType("int");

                    b.Property<string>("ZAP_Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TAC_TeamMate_ID");

                    b.ToTable("TAC_TeamMates");

                    b.HasData(
                        new
                        {
                            TAC_TeamMate_ID = 1,
                            Billet = "Sniper",
                            EDIPI_DoD_ID = 1672285964.0,
                            EDL_Last_Verified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jared",
                            LastName = "Firebaugh",
                            MOS_designator = "0317",
                            Rank = "CPL",
                            TAC_TeamLeader_ID = 1,
                            ZAP_Number = "JF85964"
                        },
                        new
                        {
                            TAC_TeamMate_ID = 2,
                            Billet = "JTAC",
                            EDIPI_DoD_ID = 1683040678.0,
                            EDL_Last_Verified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Dan",
                            LastName = "Wargo",
                            MOS_designator = "8002",
                            Rank = "SGT",
                            TAC_TeamLeader_ID = 1,
                            ZAP_Number = "DW40678"
                        },
                        new
                        {
                            TAC_TeamMate_ID = 3,
                            Billet = "Machine Gunner",
                            EDIPI_DoD_ID = 1424993820.0,
                            EDL_Last_Verified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Dylan",
                            LastName = "Snyder",
                            MOS_designator = "0331",
                            Rank = "CPL",
                            TAC_TeamLeader_ID = 1,
                            ZAP_Number = "DS93820"
                        },
                        new
                        {
                            TAC_TeamMate_ID = 4,
                            Billet = "EOD",
                            EDIPI_DoD_ID = 1839477601.0,
                            EDL_Last_Verified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jeffery",
                            LastName = "Allen",
                            MOS_designator = "2336",
                            Rank = "CPL",
                            TAC_TeamLeader_ID = 1,
                            ZAP_Number = "JA77601"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TAC_Buddy2_Proj.Models.TAC_TeamLeader", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
