using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Badges_Repository
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();

        public Badges() { }

        public Badges(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
}
