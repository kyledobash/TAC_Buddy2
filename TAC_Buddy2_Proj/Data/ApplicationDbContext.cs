using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TAC_Buddy2_Proj.Models;
using CoordinateSharp;
using Microsoft.AspNetCore.Identity;

namespace TAC_Buddy2_Proj.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TAC_TeamLeader> TAC_TeamLeaders { get; set; }
        public DbSet<TAC_TeamMate> TAC_TeamMates { get; set; }
        //public DbSet<Map_Location> Map_Locations { get; set; }
        public DbSet<EDL_Item> EDL_Items { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
             .HasData(
                 new IdentityRole
                 {
                     Name = "TAC_TeamLeader",
                     NormalizedName = "TAC_TeamLeader"
                 }
             );

            builder.Entity<TAC_TeamMate>()
            .HasData(
                new TAC_TeamMate
                {
                    TAC_TeamMate_ID = 1,
                    TAC_TeamLeader_ID = 1,
                    Rank = "CPL",
                    FirstName = "Jared",
                    LastName = "Firebaugh",
                    EDIPI_DoD_ID = 1672285964,
                    Billet = "Sniper",
                    MOS_designator = "0317",
                    ZAP_Number = "JF85964"
                }
                ,
                new TAC_TeamMate
                {
                    TAC_TeamMate_ID = 2,
                    TAC_TeamLeader_ID = 1,
                    Rank = "SGT",
                    FirstName = "Dan",
                    LastName = "Wargo",
                    EDIPI_DoD_ID = 1683040678,
                    Billet = "JTAC",
                    MOS_designator = "8002",
                    ZAP_Number = "DW40678"
                }
                ,
                new TAC_TeamMate
                {
                    TAC_TeamMate_ID = 3,
                    TAC_TeamLeader_ID = 1,
                    Rank = "CPL",
                    FirstName = "Dylan",
                    LastName = "Snyder",
                    EDIPI_DoD_ID = 1424993820,
                    Billet = "Machine Gunner",
                    MOS_designator = "0331",
                    ZAP_Number = "DS93820"
                }
                ,
                new TAC_TeamMate
                {
                    TAC_TeamMate_ID = 4,
                    TAC_TeamLeader_ID = 1,
                    Rank = "CPL",
                    FirstName = "Jeffery",
                    LastName = "Allen",
                    EDIPI_DoD_ID = 1839477601,
                    Billet = "EOD",
                    MOS_designator = "2336",
                    ZAP_Number = "JA77601"
                }
             );

            builder.Entity<EDL_Item>()
            .HasData(
                new EDL_Item
                {
                    EDL_ID = 1,
                    TAC_TeamLeader_ID = 1,
                    EDL_Item_Name = "M38",
                    EDL_Serial = "189GH200"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 2,
                    TAC_TeamLeader_ID = 1,
                    EDL_Item_Name = "PVS-14",
                    EDL_Serial = "4552983"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 3,
                    TAC_TeamLeader_ID = 1,
                    EDL_Item_Name = "M203",
                    EDL_Serial = "98HJU7"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 4,
                    TAC_TeamLeader_ID = 1,
                    EDL_Item_Name = "PRC-152",
                    EDL_Serial = "008POZ91"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 5,
                    TAC_TeamLeader_ID = 1,
                    EDL_Item_Name = "GLOCK 17",
                    EDL_Serial = "TT5R91"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 6,
                    TAC_TeamMate_ID = 1,
                    EDL_Item_Name = "M110 SASS",
                    EDL_Serial = "8679YU123"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 7,
                    TAC_TeamMate_ID = 1,
                    EDL_Item_Name = "PVS-31",
                    EDL_Serial = "45578982"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 8,
                    TAC_TeamMate_ID = 1,
                    EDL_Item_Name = "GLOCK 17",
                    EDL_Serial = "1979TG143"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 9,
                    TAC_TeamMate_ID = 1,
                    EDL_Item_Name = "PRC-152",
                    EDL_Serial = "94858937"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 10,
                    TAC_TeamMate_ID = 2,
                    EDL_Item_Name = "M4A1",
                    EDL_Serial = "993JF9I807"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 11,
                    TAC_TeamMate_ID = 2,
                    EDL_Item_Name = "PVS-31",
                    EDL_Serial = "HJ33HU23T"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 12,
                    TAC_TeamMate_ID = 2,
                    EDL_Item_Name = "GLOCK 17",
                    EDL_Serial = "JT9012CV"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 13,
                    TAC_TeamMate_ID = 2,
                    EDL_Item_Name = "PRC-117",
                    EDL_Serial = "99JKI54"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 14,
                    TAC_TeamMate_ID = 2,
                    EDL_Item_Name = "PRC-152",
                    EDL_Serial = "102QE32"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 15,
                    TAC_TeamMate_ID = 3,
                    EDL_Item_Name = "M240B",
                    EDL_Serial = "1178DI99B"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 16,
                    TAC_TeamMate_ID = 3,
                    EDL_Item_Name = "GLOCK 17",
                    EDL_Serial = "IDS9345"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 17,
                    TAC_TeamMate_ID = 3,
                    EDL_Item_Name = "240B SPARE BARREL",
                    EDL_Serial = "IDS9345"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 18,
                    TAC_TeamMate_ID = 3,
                    EDL_Item_Name = "PRC-152",
                    EDL_Serial = "JDI8394"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 19,
                    TAC_TeamMate_ID = 3,
                    EDL_Item_Name = "PVS-31",
                    EDL_Serial = "JWWU9374"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 20,
                    TAC_TeamMate_ID = 4,
                    EDL_Item_Name = "M4A1",
                    EDL_Serial = "93KIRT373"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 21,
                    TAC_TeamMate_ID = 4,
                    EDL_Item_Name = "GLOCK 17",
                    EDL_Serial = "48957390"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 22,
                    TAC_TeamMate_ID = 4,
                    EDL_Item_Name = "PVS-31",
                    EDL_Serial = "5893743905"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 23,
                    TAC_TeamMate_ID = 4,
                    EDL_Item_Name = "CMD",
                    EDL_Serial = "GITJ8498"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 24,
                    TAC_TeamMate_ID = 4,
                    EDL_Item_Name = "PRC-152",
                    EDL_Serial = "G49YT328"
                }
            );
        }
    }
}
