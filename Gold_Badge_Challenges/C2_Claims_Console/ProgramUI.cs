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

            Console.WriteLine(" {0,-15}{1,-10}{2,-30}{3,-19}{4,-20}{5,-20}{6,-10}", "Claim ID", "Type", "Description", "Amount", "Date of accident", "Date of claim", "Is valid");
            foreach (ClaimMenu claim in queueOfClaims)
            {
                Console.WriteLine(" {0,-15}{1,-10}{2,-30}{3,-1}{4,-18:F2}{5,-20}{6,-20}{7,-10}", claim.ClaimID, claim.Type, claim.Description,
                    "$",claim.ClaimAmount, claim.DateOfIncident.ToString("d"), claim.DateOfClaim.ToString("d"), claim.IsValid);
            }
            Console.Write("\n Press any key to continue... ");
            Console.ReadKey();
            Console.Clear();
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<ClaimMenu> checkNextClaim = _queueOfClaimsRepo.GetClaimsList();            
            var nextClaim = checkNextClaim.Peek();
            Console.WriteLine($" Claim ID: {nextClaim.ClaimID}");
            Console.WriteLine($" Type: {nextClaim.Type}");
            Console.WriteLine($" Description: {nextClaim.Description}");
            Console.WriteLine($" Claim amount: ${nextClaim.ClaimAmount}");
            Console.WriteLine($" Date of Accident: {nextClaim.DateOfIncident.Date.ToString("d")}");
            Console.WriteLine($" Date of claim: {nextClaim.DateOfClaim.Date:d}"); //Intellisense suggestion for code in line 81

            Console.Write("\n Would you like to handle this claim now? (y/n): " );
            string input = Console.ReadLine();
            if (input == "y")
            {
                _queueOfClaimsRepo.RemoveFromQueue(); 
            }
            Console.Clear();
        }

        private void CreateNewClaim()
        {
            ClaimMenu newClaim = new ClaimMenu();

            Console.Clear();

            Console.Write("\n Enter the claim ID: ");
            newClaim.ClaimID = Console.ReadLine();

            bool validData = true;
            while (validData)
            {            
            Console.Write("\n Claim types:\n" +
                " Auto\n" +
                " Home\n" +
                " Theft\n");
            Console.Write(" Enter the claim type here: ");
            string typeAsString = Console.ReadLine();
            ClaimType value = ConvertFromStringToType(typeAsString);
            if ( value == 0)
                {
                    Console.WriteLine("\n Please enter a valid choice.");                    
                }
                else
                {
                    newClaim.Type = value;
                    validData = false;
                }            
            }

            Console.Write(" Enter a claim description: ");
            newClaim.Description = Console.ReadLine();

            Console.Write(" Amount of damage: ");
            string amountAsString = Console.ReadLine();
            newClaim.ClaimAmount = ConvertStringToDecimal(amountAsString);

            Console.Write(" Date of accident (mm/dd/yyyy): ");
            string dateOfAccAsString = Console.ReadLine();
            DateTime dateOfAccAsDateTime = DateTime.Parse(dateOfAccAsString);
            newClaim.DateOfIncident = dateOfAccAsDateTime.Date;

            Console.Write(" Date of claim (mm/dd/yyyy): ");
            string dateOfClaimAsString = Console.ReadLine();
            DateTime dateOfClaimAsDateTime = DateTime.Parse(dateOfClaimAsString);
            newClaim.DateOfClaim = dateOfClaimAsDateTime.Date;

            var isValid = IsValid(newClaim.DateOfClaim, newClaim.DateOfIncident);
            if (isValid == true)
            {
                newClaim.IsValid = true;                
            }
            else
            {
                newClaim.IsValid = false;                
            }

            _queueOfClaimsRepo.AddNewClaim(newClaim);

            Console.Clear();

        }

        //Claim Type conversion method
        private ClaimType ConvertFromStringToType(string typeAsString)
        {
            int typeAsInt;
            if (typeAsString.ToLower() == "auto")
            {
                typeAsInt = 1; 
            }
            else if (typeAsString.ToLower() == "home")
            {
                typeAsInt = 2;
            }
            else if (typeAsString.ToLower() == "theft")
            {
                typeAsInt = 3;
            }
            else
            {
                typeAsInt = 0;
            }

            return (ClaimType)typeAsInt;

        }

        //Amount of Damage string to decimal conversion method
        private decimal ConvertStringToDecimal(string valueAsString)
        {
            if (valueAsString.StartsWith("$"))
            {
                valueAsString = valueAsString.Substring(1);
            }

            decimal valueAsDecimal = decimal.Parse(valueAsString);            
            return valueAsDecimal;
        }

        //Is the claim valid (30 days)
        private bool IsValid(DateTime dateOfClaim, DateTime dateOfAccident)
        {
            TimeSpan days = dateOfClaim - dateOfAccident;
            if (days.TotalDays <= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

