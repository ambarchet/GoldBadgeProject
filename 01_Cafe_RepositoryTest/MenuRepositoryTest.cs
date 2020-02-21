using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_RepositoryTest
{
    [TestClass]
    public class MenuRepositoryTest
    {
        [TestMethod]
        public void AddMenuItemToMenuItemList_ShouldGetCorrectBoolean()
        {
            MenuItem menuItem = new MenuItem();
            MenuRepository repository = new MenuRepository();

            bool addResult = repository.AddMenuItemToMenuItemList(menuItem);

            Assert.IsTrue(addResult);
            Console.WriteLine(addResult);
        }

        [TestMethod]
        public void GetMenuItemList_ShouldReturnCorrectMenuItemList()
        {
            MenuItem menuItem = new MenuItem();
            MenuRepository repo = new MenuRepository();

            repo.AddMenuItemToMenuItemList(menuItem);
            List<MenuItem> menuItems = repo.GetMenuItemsList();

            bool menuHasItems = menuItems.Contains(menuItem);
            Assert.IsTrue(menuHasItems);
            Console.WriteLine(menuHasItems);
        }
        private MenuRepository _repo;
        private MenuItem _menuItem;
        [TestInitialize]

        public void Arrange()
        {
            _repo = new MenuRepository();
            _menuItem = new MenuItem("ExampleItem1", 0, "Example Description",new List<string>(){"ExampleIngredient","ExampleIngredient2"}, 0.01m);
            _repo.AddMenuItemToMenuItemList(_menuItem);
        }


        [TestMethod]
        public void DeleteExistingMenuItem_ShouldReturnCorrectBool()
        {
            /*  MenuRepository repository = new MenuRepository();
              MenuItem menuItem = new MenuItem();
              */

            bool removeResult = _repo.DeleteExistingMenuItem("ExampleItem1");
            Assert.IsTrue(removeResult);
        }

    }
}
