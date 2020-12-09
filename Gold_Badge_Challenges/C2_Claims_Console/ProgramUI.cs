using C2_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Claims_Console
{
    class ProgramUI
    {
        private ClaimMenuRepo _queueOfClaimsRepo = new ClaimMenuRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool loopClaimMenu = true;
            while (loopClaimMenu)
            {
                Console.WriteLine("\n Choose a menu item:\n" +
                    " (1) See all claims\n" +
                    " (2) Take care of next claim\n" +
                    " (3) Enter a new claim\n" +
                    " (4) Exit Program\n ");
                Console.Write(" Enter menu number here: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //See all claims
                        SeeAllClaims();
                        break;
                    case "2":
                        //Take care of next claim
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        //Enter new claim
                        CreateNewClaim();
                        break;
                    case "4":
                        //Exit Program
                        Console.WriteLine("\n Exit Program");
                        loopClaimMenu = false;
                        break;
                }
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<ClaimMenu> queueOfClaims = _queueOfClaimsRepo.GetClaimsList();

            foreach (ClaimMenu claim in queueOfClaims)
            {
                Console.WriteLine($" ClaimID: {claim.ClaimID}\n" +
                    $" Type: {claim.Type}\n" +
                    $" Description: {claim.Description}\n" +
                    $" Amount: {claim.ClaimAmount}\n" +
                    $" DateOfAccident: {claim.DateOfIncident}\n" +
                    $" DateOfClaim: {claim.DateOfClaim}\n");

            }
        }

        private void TakeCareOfNextClaim()
        {
            Queue<ClaimMenu> checkNextClaim = new Queue<ClaimMenu>();
            Console.WriteLine(checkNextClaim.Peek());
        }

        private void CreateNewClaim()
        {
            ClaimMenu newClaim = new ClaimMenu();

            Console.Clear();

            Console.Write("\n Enter the claim ID: ");
            newClaim.ClaimID = Console.ReadLine();

            Console.Write("\n Claim types:\n" +
                " Auto\n" +
                " Home\n" +
                " Theft\n");
            Console.Write(" Enter the claim type here: ");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaim.Type = (ClaimType)typeAsInt;

            Console.Write("\n Enter a claim description: ");
            newClaim.Description = Console.ReadLine();

            Console.Write("\n Amount of damage: ");
            string amountAsString = Console.ReadLine();
            decimal amountAsDecimal = decimal.Parse(amountAsString);
            newClaim.ClaimAmount = amountAsDecimal;

            Console.Write("\n Date of accident (mm/dd/yyyy): ");
            string dateOfAccAsString = Console.ReadLine();
            DateTime dateOfAccAsDateTime = DateTime.Parse(dateOfAccAsString);
            newClaim.DateOfIncident = dateOfAccAsDateTime;

            Console.Write("\n Date of claim (mm/dd/yyyy): ");
            string dateOfClaimAsString = Console.ReadLine();
            DateTime dateOfClaimAsDateTime = DateTime.Parse(dateOfClaimAsString);
            newClaim.DateOfClaim = dateOfClaimAsDateTime;

            newClaim.IsValid = true;

            _queueOfClaimsRepo.AddNewClaim(newClaim);



        }

        
    }
}

