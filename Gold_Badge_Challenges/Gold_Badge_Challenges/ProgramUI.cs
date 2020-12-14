using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1_Cafe_Repository;

namespace C1_Cafe_Console
{
    class ProgramUI
    {
        private CafeMenuRepo _menuItemsRepo = new CafeMenuRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool loopMenuOptions = true;
            while (loopMenuOptions)
            {
                //Menu List
                Console.WriteLine(" MENU OPTIONS:\n" +
                    " (1) Add new meal to the menu\n" +
                    " (2) Delete a meal from the menu\n" +
                    " (3) See all meals in the menu\n" +
                    " (4) Exit program\n");
                Console.Write(" Enter number option (1 - 4) here: ");

                //User input option
                string input = Console.ReadLine();

                //Evaluate input option and act
                switch (input)
                {
                    case "1":
                        // Add new meal to the menu
                        AddMealToMenu();
                        break;
                    case "2":
                        // Delete a meal from the menu
                        DeleteMealFromMenu();
                        break;
                    case "3":
                        // See all meals in the menu
                        SeeMenuItems();
                        break;
                    case "4":
                        Console.WriteLine("\n Program will exit");
                        loopMenuOptions = false;
                        break;
                    default:
                        Console.WriteLine(" Invaild option. Option must be between 1 - 4.");
                        break;
                }

                Console.WriteLine("\n Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddMealToMenu()
        {
            Console.Clear();
            CafeMenu newMenuItem = new CafeMenu();

            Console.Write(" Enter number for the new meal: ");
            newMenuItem.MealNumber = int.Parse(Console.ReadLine());           
            
            Console.Write(" Enter a name for the new meal: ");
            newMenuItem.MealName = Console.ReadLine();

            Console.Write(" Enter a description for the new meal: ");
            newMenuItem.MealDescription = Console.ReadLine();

            Console.WriteLine(" Enter an ingredient then press enter. Type 'end' when complete");
            bool input = true;
            while (input)
            {
                Console.Write(" ");
                string ingredient = Console.ReadLine().ToLower();
                if (ingredient == "end")
                {
                    input = false;
                }
                else
                {
                    newMenuItem.MealIngredients.Add(ingredient);
                }
            }

            Console.Write(" Enter the price for this meal: ");
            newMenuItem.MealPrice = decimal.Parse(Console.ReadLine());

            _menuItemsRepo.AddMenuItemToList(newMenuItem);
        }

        private void DeleteMealFromMenu()
        {
            Console.Clear();
            //Display all menu items
            SeeMenuItems();

            //Get user input
            Console.Write("\n Enter meal number to delete from menu list: ");
            int input = int.Parse(Console.ReadLine());

            //Call delete method
            bool wasDeleted = _menuItemsRepo.DeleteMenuItemFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("\n The meal was successfully deleted.");
            }
            else
            {
                Console.WriteLine("\n The meal could not be deleted");
            }
        }

        private void SeeMenuItems()
        {
            Console.Clear();
            List<CafeMenu> listOfMenuItems = _menuItemsRepo.GetMenuItemsList();

            foreach (CafeMenu items in listOfMenuItems)
            {
                Console.WriteLine($" Meal number: {items.MealNumber}\n" +
                    $" Meal name: {items.MealName}\n" +
                    $" Meal description: {items.MealDescription}");

                //Console.WriteLine(" Ingredients: ");
                Console.Write(" Ingredients: ");
                int count = items.MealIngredients.Count;
                foreach (string ingredient in items.MealIngredients)
                {
                    if (count > 1)
                    {
                        Console.Write($"{ingredient}, ");
                        count--;
                    }
                    else
                    {
                        Console.Write($"{ingredient}\n");
                    }                    
                }
                //Console.WriteLine($" Meal Price: ${items.MealPrice}\n");
                Console.WriteLine(" Meal Price: ${0:F2}\n", items.MealPrice);
            }
        }
    }
}
