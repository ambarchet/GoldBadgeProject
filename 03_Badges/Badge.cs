using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeNumber, List<Door> doorAccessList)
        {
            BadgeNumber = badgeNumber;
            DoorAccessList = doorAccessList;
        }
        public int BadgeNumber { get; set; }
        public List<Door> DoorAccessList { get; set; }
    }
}
