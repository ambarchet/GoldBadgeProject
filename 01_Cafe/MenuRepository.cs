using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuItemList = new List<MenuItem>();

        public bool AddMenuItemToMenuItemList(MenuItem menuItem)
        {
            int menuLength = _menuItemList.Count();
            _menuItemList.Add(menuItem);
            bool wasAdded = menuLength + 1 == _menuItemList.Count();
            return wasAdded;
        }


        public List<MenuItem> GetMenuItemsList()
        {
            return _menuItemList;
        }
        public MenuItem GetMenuItemByName(string name)
        {
            foreach (MenuItem menuItem in _menuItemList)
            {
                if (menuItem.Name.ToLower() == name.ToLower())
                {
                    return menuItem;
                }
            }
            return null;
        }

        public bool DeleteExistingMenuItem(string name)
        {
            MenuItem foundMenuItem = GetMenuItemByName(name);
            bool deletedResult = _menuItemList.Remove(foundMenuItem);
            return deletedResult;
        }

        public List<string> AddIngredients()
        {
            List<string> newItemIngredients = new List<string>();
            int newIngredientsCounter;
            Console.WriteLine("How many items would you like to add?");
            newIngredientsCounter = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please list your first ingredient: ");
            newItemIngredients.Add(Console.ReadLine());
            newIngredientsCounter--;

            while (newIngredientsCounter > 0)
            {
                Console.WriteLine("What is the next ingredient you would like to add?");
                newItemIngredients.Add(Console.ReadLine());
                newIngredientsCounter--;
            }
            return newItemIngredients;
        }
    }
}
