using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Door
    {
        public Door() { }
        public Door(string doorName)
        {
            DoorName = doorName;
        }
        public string DoorName { get; set; }
    }
}
