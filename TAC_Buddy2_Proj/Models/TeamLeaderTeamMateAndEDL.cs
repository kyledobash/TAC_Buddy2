using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAC_Buddy2_Proj.Models
{
    public class TeamLeaderTeamMateAndEDL
    {
        public TAC_TeamLeader TAC_TeamLeader { get; set; }

        public List<TAC_TeamMate> TAC_TeamMates { get; set; }

        public List<EDL_Item> EDL_Items { get; set; }
    }
}
