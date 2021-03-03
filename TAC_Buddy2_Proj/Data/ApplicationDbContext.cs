using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TAC_Buddy2_Proj.Models;
using CoordinateSharp;

namespace TAC_Buddy2_Proj.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TAC_TeamLeader> TAC_TeamLeaders { get; set; }
        public DbSet<TAC_TeamMate> TAC_TeamMates { get; set; }
        public DbSet<Map_Location> Map_Locations { get; set; }
        public DbSet<EDL_Item> EDL_Items { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TAC_TeamLeader>()
            .HasData(
                new TAC_TeamLeader
                {
                    TAC_TeamLeader_ID = 1,
                    Rank = "CPL",
                    FirstName = "Kyle",
                    LastName = "Dobash",
                    EDIPI_DoD_ID = 1528906067,
                    Billet = "Team Leader",
                    MOS_designator = "0341",
                    ZAP_Number = "KD06067"
                }
             );

            builder.Entity<TAC_TeamMate>()
            .HasData(
                new TAC_TeamMate
                {
                    TAC_TeamMate_ID = 1,
                    TAC_TeamLeader_ID = 1,
                    Rank = "CPL",
                    FirstName = "Jake",
                    LastName = "Hinton",
                    EDIPI_DoD_ID = 1672285964,
                    Billet = "Assistant Team Leader",
                    MOS_designator = "0341",
                    ZAP_Number = "JH85964"
                }
                ,
                new TAC_TeamMate
                {
                    TAC_TeamMate_ID = 2,
                    TAC_TeamLeader_ID = 1,
                    Rank = "LCPL",
                    FirstName = "Jack",
                    LastName = "Ingles",
                    EDIPI_DoD_ID = 1683040678,
                    Billet = "Designated Marksman",
                    MOS_designator = "0311",
                    ZAP_Number = "JI40678"
                }
             );

            builder.Entity<EDL_Item>()
            .HasData(
                new EDL_Item
                {
                    EDL_ID = 1,
                    TAC_TeamLeader_ID = 1,
                    EDL_Item_Name = "M4A1",
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
                    TAC_TeamMate_ID = 1,
                    EDL_Item_Name = "M27 IAR",
                    EDL_Serial = "8679YU123"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 4,
                    TAC_TeamMate_ID = 1,
                    EDL_Item_Name = "PVS-14",
                    EDL_Serial = "45578982"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 5,
                    TAC_TeamMate_ID = 2,
                    EDL_Item_Name = "M38 IAR",
                    EDL_Serial = "1979TG143"
                }
                ,
                new EDL_Item
                {
                    EDL_ID = 6,
                    TAC_TeamMate_ID = 2,
                    EDL_Item_Name = "PVS-14",
                    EDL_Serial = "94858937"
                }
            );

            builder.Entity<Map_Location>()
            .HasData(
                new Map_Location
                {
                    Location_ID = 1,
                    TAC_TeamLeader_ID = 1,
                    MGRS_Coords = new MilitaryGridReferenceSystem("11S", "NT", 7864, 9553),
                    Elevation = 1245,
                    Lat_Long = new Coordinate(34.298, -116.145)
                }
            );
        }
    }
}
