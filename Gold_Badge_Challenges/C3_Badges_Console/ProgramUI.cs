using C3_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Badges_Console
{
    class ProgramUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();
        

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool loopMenu = true;
            while(loopMenu)
            {
                Console.WriteLine("\n Choose from the following list:\n" +
                    " (1) Create a new badge\n" +
                    " (2) Add doors for an existing badge\n" +
                    " (3) Delete doors from an existing badge\n" +
                    " (4) Show a list with all badge numbers and door access\n" +
                    " (5) Exit program\n");
                Console.Write(" Enter choice here: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Create a new badge
                        CreateNewBadge();
                        break;
                    case "2":
                        //Add doors for an existing badge
                        AddDoorsForExistingBadge();
                        break;
                    case "3":
                        //Delete all doors from an existing badge
                        DeleteDoorsForExistingBadge();
                        break;
                    case "4":
                        //Show a list with all badge numbers and door access
                        ShowListOfBadges();
                        break;
                    case "5":
                        //Exit program
                        Console.WriteLine("\n Exit program\n");
                        loopMenu = false;
                        break;
                    default:
                        Console.WriteLine("\n Enter a valid number.\n");
                        break;
                }

                Console.Write("\n Press any key to continue... ");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewBadge()
        {
            Badges newBadge = new Badges();
            Console.Clear();
            Console.Write("\n Enter a new badge ID: ");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("\n Enter door(s) accessibility (hit 'enter' after every door entry and type 'end' when complete): ");
            bool input = true;
            while (input)
            {
                Console.Write(" ");
                string door = Console.ReadLine();
                if (door == "end")
                {
                    input = false;
                }
                else
                {
                    newBadge.DoorNames.Add(door);
                }
            }
            _badgesRepo.AddBadgeToDictionary(newBadge);
        }

        private void AddDoorsForExistingBadge()
        {
            Console.Clear();
            ShowListOfBadges();
            Console.Write("\n Which badge number would you like to add doors to?: ");

            int badgeToAddDoors = int.Parse(Console.ReadLine());
            Badges badgeToAdd = GetListOfBadgesByID(badgeToAddDoors);
            if (_badgesRepo.GetBadgeByID(badgeToAddDoors) != 0)
            {

                Console.WriteLine("\n Enter the door(s) you'd like to add. (hit 'enter' after every door entry and type 'end' when complete): ");
                bool input = true;
                List<string> addDoors = new List<string>();
                while (input)
                {
                    Console.Write(" ");
                    string door = Console.ReadLine();
                    if (door == "end")
                    {
                        input = false;
                    }
                    else
                    {
                        addDoors.Add(door);
                    }
                }
                bool wasAdded = _badgesRepo.AddDoorToExistingBadge(badgeToAddDoors, addDoors, badgeToAdd);
                if (wasAdded)
                {
                    Console.WriteLine("\n Update complete.");
                }
                else
                {
                    Console.WriteLine("\n Update could not be completed");
                }

            }
            else
            {
                Console.WriteLine("\n Invalid entry. Return to main menu.");
            }
        }

        private void DeleteDoorsForExistingBadge()
        {
            Console.Clear();
            ShowListOfBadges();
            Console.Write("\n Which badge number would you like to delete doors from?: ");

            int badgeToDeleteDoors = int.Parse(Console.ReadLine());
            Badges badgeToDelete = GetListOfBadgesByID(badgeToDeleteDoors);
            if (_badgesRepo.GetBadgeByID(badgeToDeleteDoors) != 0)
            {

                Console.WriteLine("\n Enter the door(s) you'd like to delete. (hit 'enter' after every door entry and type 'end' when complete): ");
                bool input = true;
                List<string> deleteDoors = new List<string>();
                while (input)
                {
                    Console.Write(" ");
                    string door = Console.ReadLine();
                    if (door == "end")
                    {
                        input = false;
                    }
                    else
                    {
                        deleteDoors.Add(door);
                    }
                }
                bool wasDeleted = _badgesRepo.DeleteDoorFromExistingBadge(badgeToDeleteDoors, deleteDoors, badgeToDelete);
                if (wasDeleted)
                {
                    Console.WriteLine("\n Deletion complete.");
                }
                else
                {
                    Console.WriteLine("\n Deletion could not be completed");
                }

            }
            else
            {
                Console.WriteLine("\n Invaild entry. Return to main menu.");
            }
        }

        private void ShowListOfBadges()
        {
            Dictionary<int, Badges> listOfBadges = _badgesRepo.GetBadgeList();
            Console.Clear();
            Console.WriteLine("\n {0,-15}{1,-20}", "Badge#", "Door Access List");

            foreach (KeyValuePair<int, Badges> badge in listOfBadges)
            {
                Console.Write(" {0,-15}", badge.Key);
               int count = badge.Value.DoorNames.Count;                
                foreach (string doors in badge.Value.DoorNames)
                {
                    if (count > 1)
                    {
                        Console.Write(doors+",");                        
                        count--;
                    }
                    else
                    {
                        Console.WriteLine(doors);
                    }

                }
            }
        }

        private Badges GetListOfBadgesByID(int badgeID)
        {
            Dictionary<int, Badges> listOfBadges = _badgesRepo.GetBadgeList();
            foreach(KeyValuePair<int, Badges> badge in listOfBadges)
            {
                if (badge.Key == badgeID)
                {
                    return badge.Value;
                }                
            }
            return null;
        }
    }   
}
