using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TAC_Buddy2_Proj.Models
{
    public class TAC_TeamMate
    {
        [Key]
        public double TAC_TeamMate_ID { get; set; }

        [ForeignKey("TAC_TeamLeader_ID")]
        public double TAC_TeamLeader_ID { get; set; }
        public TAC_TeamLeader TAC_TeamLeader { get; set; }

        public string Rank { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "EDIPI/DoD ID Number")]
        public double EDIPI_DoD_ID { get; set; }

        public string Billet { get; set; }

        [Display(Name = "MOS")]
        public string MOS_designator { get; set; }

        [Display(Name = "EDL Last Verified")]
        public DateTime EDL_Last_Verified { get; set; }

        [Display(Name = "ZAP Number")]
        public string ZAP_Number { get; set; }
    }
}
