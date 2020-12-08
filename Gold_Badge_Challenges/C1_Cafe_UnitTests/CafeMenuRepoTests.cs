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
            List<string> seedIngredients = new List<string>();
            seedIngredients.Add("Beer");
            seedIngredients.Add("Tenderloin");
            seedIngredients.Add("Chicken Wings");
            seedIngredients.Add("Pie");

            _menuRepo = new CafeMenuRepo();
            _menu = new CafeMenu(1, "The Big Plate", "Four course meal with drink", seedIngredients, 5.25m);

            _menuRepo.AddMenuItemToList(_menu);
        }
        
        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            //Arrange
            CafeMenu item = new CafeMenu();
            item.MealNumber = 2;
            CafeMenuRepo repo = new CafeMenuRepo();

            //Act
            repo.AddMenuItemToList(item);
            CafeMenu itemFromMenu = repo.GetMenuItemByNumber(2);

            //Assert
            Assert.IsNotNull(itemFromMenu);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //Arrange -- Done in TestInitialize

            //Act
            bool deleteMenuItem = _menuRepo.DeleteMenuItemFromList(_menu.MealNumber);

            //Assert
            Assert.IsTrue(deleteMenuItem);

        }
    }
}
