using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using C1_Cafe_Repository;
using System.Collections.Generic;

namespace C1_Cafe_UnitTests
{
    [TestClass]
    public class CafeMenuRepoTests
    {
        private CafeMenuRepo _menuRepo;
        private CafeMenu _menu;
        
        [TestInitialize]
        public void SetUp()
        {
            List<string> seedIngredients = new List<string>
            {
                "Beer",
                "Tenderloin",
                "Chicken Wings",
                "Pie"
            };

            _menuRepo = new CafeMenuRepo();
            _menu = new CafeMenu(1, "The Big Plate", "Four course meal with drink", seedIngredients, 5.25m);

            //_menu = new CafeMenu(1, "The Big Plate", "Four course meal with drink", new List<string> { "Beer", "Tenderloin", "Chicken Wings", "Pie" }, 5.25m);
            // *** Line 28 is another way of seeding using the List<string> initializer within the constructor. Thanks Mitch!! 

            _menuRepo.AddMenuItemToList(_menu);
        }
        
        [TestMethod]
        public void AddToMenu_ShouldReturnTrue()
        {
            //Arrange
            CafeMenu item = new CafeMenu { MealNumber = 2 };
                        

            //Act
            bool wasAdded = _menuRepo.AddMenuItemToList(item); 
            
            //Assert
            Assert.IsTrue(wasAdded); //Verifies that true is returned from the AddMenuItemToList method
        }

        [TestMethod]
        public void GetMenuItemsList_ShouldGetNotNull()
        {
            //Arrange
            List<CafeMenu> verifyMenu;

            //Act
            verifyMenu = _menuRepo.GetMenuItemsList();

            //Assert
            Assert.IsNotNull(verifyMenu); //Verifies that the verifyMenu is no longer null after GetMenuItemsList is called. 
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //Arrange -- Done in TestInitialize

            //Act
            bool deleteMenuItem = _menuRepo.DeleteMenuItemFromList(_menu.MealNumber);

            //Assert
            Assert.IsTrue(deleteMenuItem); //Verifites the menu item was deleted
        }

        [TestMethod]
        public void GetMenuItemByNumber_ShouldGetAreEqual()
        {
            //Arrange
            CafeMenu getMenu = new CafeMenu();

            //Act
            getMenu = _menuRepo.GetMenuItemByNumber(_menu.MealNumber);

            //Assert
            Assert.AreEqual(getMenu.MealNumber, _menu.MealNumber);
        }
    }
}
