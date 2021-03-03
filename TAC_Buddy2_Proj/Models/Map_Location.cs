//using CoordinateSharp;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TAC_Buddy2_Proj.Models
//{
//    public class Map_Location
//    {
//        [Key]
//        public double Location_ID { get; set; }

//        [ForeignKey("TAC_TeamLeader_ID")]
//        public double TAC_TeamLeader_ID { get; set; }
//        public TAC_TeamLeader TAC_TeamLeader { get; set; }

//        [Display(Name = "MGRS Grid Coordinates")]
//        public MilitaryGridReferenceSystem MGRS_Coords { get; set; }

//        public double Elevation { get; set; }

//        [Display(Name = "Lat/Long Coordinates")]
//        public Coordinate Lat_Long { get; set; }
//    }
//}
