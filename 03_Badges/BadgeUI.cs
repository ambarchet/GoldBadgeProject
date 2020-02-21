using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    class BadgeUI
    {
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        ViewAllBadgesQuery();
                        EditABadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }
        private void AddBadge()
        {
            Console.WriteLine("What is the number on the badge:");
            string badgeNumber = Console.ReadLine();
            int badgeNumberInt = 0;
            bool idISValid = false;
            while (!idISValid)
            {
                if (!int.TryParse(badgeNumber, out badgeNumberInt))
                {
                    Console.WriteLine("Please enter a valid badge number.");
                    badgeNumber = Console.ReadLine();
                    continue;
                }
            Console.WriteLine("List doors that it needs access to (separate doors by commas:");
            string doorName = Console.ReadLine();
            doorName = doorName.Replace(" ", "");
            doorName = doorName.Trim();
            string[] doorsArray = doorName.Split(',');
            List<Door> newDoorAccessList = new List<Door>();
            foreach(string door in doorsArray)
            {
            Door newDoor = new Door { DoorName = door };
            newDoorAccessList.Add(newDoor);
            }
            Badge newBadgeExample = new Badge(badgeNumberInt, newDoorAccessList);
            _badgeRepo.AddBadgeToBadgeDictionary(newBadgeExample);
            Console.WriteLine("New badge successfully added.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            idISValid = true;
            }
        }

        private void EditABadge()
        {
            Console.WriteLine("What is the badge number to update?:");
            string input = Console.ReadLine();
            bool selectionIsValid = false;
            bool preExistingID = false;
            int currentID = 0;
            int badgeNumberInt = 0;
            while (!selectionIsValid)
            {
                if (!int.TryParse(input, out badgeNumberInt))
                {
                    Console.WriteLine("Please enter a valid badge number.");
                    input = Console.ReadLine();
                    continue;
                }
                Dictionary<int, List<Door>> _currentDictionary = new Dictionary<int, List<Door>>();
                _currentDictionary = _badgeRepo.GetBadgeDictionary();
                foreach(KeyValuePair<int, List<Door>> keyValue in _currentDictionary)
                {
                    if (keyValue.Key == badgeNumberInt)
                    {
                        currentID = keyValue.Key;
                        preExistingID = true;
                    }
                }
                if (!preExistingID)
                {
                    Console.WriteLine("That badge does not exist.");
                    continue;
                }
                bool selectionValid = false;
                while (!selectionValid)
                {
                    Console.WriteLine($"What would you like to do?\n" +
                        $"1. Remove a door\n" +
                        $"2. Remove all doors\n" +
                        $"3. Add a door\n" +
                        $"4. Exit");
                    string userInput = Console.ReadLine().ToLower();
                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("This badge has access to doors:");
                            foreach(KeyValuePair<int, List<Door>> keyValue in _currentDictionary)
                            {
                                if (keyValue.Key == currentID)
                                {
                                    foreach(Door door in keyValue.Value)
                                    {
                                        Console.WriteLine(door.DoorName);
                                    }
                                }
                            }
                            Console.WriteLine("Which door would you like to remove:");
                            string doorToRemove = Console.ReadLine();
                            if(!_badgeRepo.RemoveDoorFromBadge(currentID, doorToRemove))
                            {
                                Console.WriteLine("Door not recognized.");
                                continue;
                            }
                            Console.WriteLine($"Door {doorToRemove} removed successfully.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            selectionValid = true;
                            break;
                        case "2":
                            _badgeRepo.RemoveAllDoors(currentID);
                            Console.WriteLine($"All doors have been removed from badge.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            selectionValid = true;
                            break;
                        case "3":
                            Console.WriteLine("List doors that it needs access to (separate doors by commas):");
                            userInput = Console.ReadLine();
                            userInput= userInput.Replace(" ", "");
                            userInput = userInput.Trim();
                            string[] doorsArray = userInput.Split(',');
                            List<Door> newDoorAccessList = new List<Door>();
                            foreach (string door in doorsArray)
                            {
                                //Need to add to current door instead of adding a new door. having issues.
                            Door newDoor = new Door { DoorName = door };
                            newDoorAccessList.Add(newDoor);
                            }
                            Badge newBadgeExample = new Badge(badgeNumberInt, newDoorAccessList);
                            _badgeRepo.AddBadgeToBadgeDictionary(newBadgeExample);
                            Console.WriteLine("New badge successfully added.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            selectionValid = true;
                            break;
                        case "4":
                            selectionValid = true;
                            break;
                        default:
                            Console.WriteLine("Please try again.");
                            continue;
                    }
                }
                selectionIsValid = true;
            }
        }

        private void ViewAllBadgesQuery()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("List current badges? Y/N");
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "y":
                        ViewAllBadges();
                        isValid = true;
                        break;
                    case "n":
                        isValid = true;
                        break;
                    default:
                        continue;
                }
            }
        }

        private void ViewAllBadges()
        {
            Dictionary<int, List<Door>> _currentDictionary = new Dictionary<int, List<Door>>();
            _currentDictionary = _badgeRepo.GetBadgeDictionary();
            Console.WriteLine($"Badge #:   / Door Access:");
            foreach(KeyValuePair<int, List<Door>> keyValuePair in _currentDictionary)
            {
                int index = keyValuePair.Value.Count();
                string[] doorList = new string[index];
                index = 0;
                foreach (Door door in keyValuePair.Value)
                {
                    doorList[index] = door.DoorName;
                    index++;
                }
                Console.WriteLine($"{keyValuePair.Key}    / " + "{0}", string.Join(", ", doorList));
            }
        }
        //didn't use
        private void GetDoorListByName(string input)
        {
            List<Door> doorCheck = new List<Door>();
            bool inputIsValid = false;
            int inputInt = 0;
            while (!inputIsValid)
            {
                if (!int.TryParse(input, out inputInt))
                {
                    Console.WriteLine("Please enter a valid door name.");
                    input = Console.ReadLine();
                    continue;
                }
            }
            doorCheck = _badgeRepo.GetDoorListByBadgeID(inputInt);
            if(doorCheck == null)
            {
                Console.WriteLine("BadgeID does not exist.");
            }
            else
            {
                foreach (Door door in doorCheck)
                {
                    Console.WriteLine(door.DoorName);
                }
            }
        }
    }
}
