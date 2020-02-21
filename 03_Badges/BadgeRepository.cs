using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeRepository
    {
        Dictionary<int, List<Door>> _badgeDictionary;

        public BadgeRepository()
        {
            _badgeDictionary = new Dictionary<int, List<Door>>();
        }
      
        public bool RemoveAllDoors(int id)
        {
            foreach(KeyValuePair<int, List<Door>> badge in _badgeDictionary)
            {
                if (badge.Key == id)
                {
                    int currentCount = badge.Value.Count;
                    badge.Value.RemoveRange(0, currentCount);
                    return true;
                }
            }
            return false;
        }
        public void AddBadgeToBadgeDictionary(Badge newBadge)
        {
            _badgeDictionary.Add(newBadge.BadgeNumber, newBadge.DoorAccessList);
        }

        public List<Door> GetDoorListByBadgeID(int badgeNumber)
        {
            foreach(KeyValuePair<int, List<Door>> badge in _badgeDictionary)
            {
                if(badge.Key == badgeNumber)
                {
                    return badge.Value;
                }
            }
            return null;
        }
        public bool RemoveDoorFromBadge(int badgeNumber, string doorName)
        {
            foreach (KeyValuePair<int, List<Door>> badge in _badgeDictionary)
            {
                if(badge.Key == badgeNumber)
                {
                    foreach (Door door in badge.Value)
                    {
                        if(door.DoorName == doorName)
                        {
                            badge.Value.Remove(door);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Dictionary<int, List<Door>> GetBadgeDictionary()
        {
            return _badgeDictionary;
        }
    }
}
