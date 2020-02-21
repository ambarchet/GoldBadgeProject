using System;
using System.Collections.Generic;
using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_RepositoryTest
{
    [TestClass]
    public class BadgeRepositoryTest
    {
        BadgeRepository _badgeRepository;

        [TestMethod]
        public void AddBadgeToDictionary()
        {
            _badgeRepository = new BadgeRepository();
            List<Door> newDoorAccessListOne = new List<Door>();
            List<Door> newDoorAccessListTwo = new List<Door>();
            Door doorOne = new Door();
            Door doorTwo = new Door();


            doorOne.DoorName = "A5";
            doorTwo.DoorName = "A7";
            newDoorAccessListOne.Add(doorOne);
            newDoorAccessListTwo.Add(doorTwo);
            int badgeNumber = 12345;
            Badge newBadgeOne = new Badge(badgeNumber, newDoorAccessListOne);
            _badgeRepository.AddBadgeToBadgeDictionary(newBadgeOne);

            int badgeNumberTwo = 32345;
            newDoorAccessListTwo.Add(doorOne);
            Badge newBadgeTwo = new Badge(badgeNumberTwo, newDoorAccessListTwo);
            _badgeRepository.AddBadgeToBadgeDictionary(newBadgeTwo);

            Dictionary<int, List<Door>> _currentDictionary = new Dictionary<int, List<Door>>();
            _currentDictionary = _badgeRepository.GetBadgeDictionary();
            foreach(KeyValuePair<int, List<Door>> valuePair in _currentDictionary)
            {
                if (valuePair.Key == 12345)
                {
                    foreach(Door door in valuePair.Value)
                    {
                        Assert.IsTrue(door.DoorName.Contains("A5") || door.DoorName.Contains("A7"));
                    }
                }
                else if (valuePair.Key == 32345)
                {
                    foreach (Door door in valuePair.Value)
                    {
                        Assert.IsTrue(door.DoorName.Contains("A5") && !door.DoorName.Contains("A7"));
                    }
                }
            }

            List<Door> doorCheck = new List<Door>();
            doorCheck = _badgeRepository.GetDoorListByBadgeID(12345);
            if(doorCheck == null)
            {
                Console.WriteLine("Badge number does not exist.");
            }
            else
            {
                foreach(Door door in doorCheck)
                {
                    Console.WriteLine(door.DoorName);
                }
            }
        }
        [TestMethod]
        public void RemoveDoorsTest()
        {
            _badgeRepository = new BadgeRepository();
            List<Door> newDoorAccessListOne = new List<Door>();
            List<Door> newDoorAccessListTwo = new List<Door>();
            Door doorOne = new Door();
            Door doorTwo = new Door();


            doorOne.DoorName = "A5";
            doorTwo.DoorName = "A7";
            newDoorAccessListOne.Add(doorOne);
            newDoorAccessListTwo.Add(doorTwo);
            int badgeNumber = 12345;
            Badge newBadgeOne = new Badge(badgeNumber, newDoorAccessListOne);
            _badgeRepository.AddBadgeToBadgeDictionary(newBadgeOne);

            int badgeNumberTwo = 22345;
            newDoorAccessListTwo.Add(doorOne);
            Badge newBadgeTwo = new Badge(badgeNumberTwo, newDoorAccessListTwo);
            _badgeRepository.AddBadgeToBadgeDictionary(newBadgeTwo);

            Assert.IsTrue(_badgeRepository.RemoveDoorFromBadge(12345, "A5"));
            Console.WriteLine(newBadgeTwo);

            Dictionary<int, List<Door>> _currentDictionary = new Dictionary<int, List<Door>>();
            _currentDictionary = _badgeRepository.GetBadgeDictionary();
            foreach(KeyValuePair<int, List<Door>> valuePair in _currentDictionary)
            {
                if (valuePair.Key == 12345)
                {
                    Assert.IsTrue(valuePair.Value.Count == 0);
                }
                else if (valuePair.Key == 22345)
                {
                    foreach (Door door in valuePair.Value)
                    {
                        Assert.IsTrue(!door.DoorName.Contains("A5") && door.DoorName.Contains("A7"));
                    }
                }
            }
        }
    }
}
