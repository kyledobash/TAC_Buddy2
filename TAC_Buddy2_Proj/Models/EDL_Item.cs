using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TAC_Buddy2_Proj.Models
{
    public class EDL_Item
    {
        [Key]
        public double EDL_ID { get; set; }

        [ForeignKey("TAC_TeamLeader_ID")]
        public double? TAC_TeamLeader_ID { get; set; }

        [ForeignKey("TAC_TeamMate_ID")]
        public double? TAC_TeamMate_ID { get; set; }

        [Display(Name = "Item Name/Type")]
        public string EDL_Item_Name { get; set; }

        [Display(Name = "Serial Number")]
        public string EDL_Serial { get; set; }
    }
}
