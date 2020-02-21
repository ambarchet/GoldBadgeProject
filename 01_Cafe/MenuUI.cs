using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();
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
                Console.WriteLine("Please select an option number:\n" +
                    "1. Display menu\n" +
                    "2. Add menu item\n" +
                    "3. Remove menu item\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        DisplayMenu();
                        break;
                    case "2":
                        AddNewMenuItem();
                        break;
                    case "3":
                        RemoveMenuItem();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void DisplayMenu()
        {
            List<MenuItem> menu = _menuRepo.GetMenuItemsList();
            foreach (MenuItem menuItem in menu)
            {
                Console.WriteLine($"Name: {menuItem.Name}\n" +
                    $"Number: {menuItem.Number}\n" +
                    $"Description: {menuItem.Description}\n");
                    foreach (string ingredient in menuItem.Ingredients)
                    {
                    Console.WriteLine($"Ingredients: {ingredient}");
                    }
                Console.WriteLine($"\nPrice: {menuItem.Price}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddNewMenuItem()
        {
            MenuItem menuItem = new MenuItem();
            Console.WriteLine("Please enter a new menu item name:");
            menuItem.Name = Console.ReadLine();

            Console.WriteLine("Next, add a new meal number:");
            menuItem.Number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Next, add a meal description:");
            menuItem.Description = Console.ReadLine();

            Console.WriteLine("New, add meal ingredients:");
            menuItem.Ingredients = _menuRepo.AddIngredients();

            Console.WriteLine("New, add a meal price:");
            menuItem.Price = Convert.ToDecimal(Console.ReadLine());

            _menuRepo.AddMenuItemToMenuItemList(menuItem);
            Console.WriteLine($"{menuItem.Name} has been added! Press any key to return to the main menu");
            Console.ReadKey();
        }

       private void RemoveMenuItem()
        {
            DisplayMenu();
            Console.WriteLine("What is the menu item you would like to remove?");
             string name = Console.ReadLine();

            bool success = _menuRepo.DeleteExistingMenuItem(name);
            if (success == true)
            {
                Console.WriteLine($"{name} has been removed. Press any button to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{name} was unable to be removed at this time.");
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
