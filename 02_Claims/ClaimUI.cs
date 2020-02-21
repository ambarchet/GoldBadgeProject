using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    class ClaimUI
    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
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
                Console.WriteLine("Please choose an option number:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        DisplayClaims();
                        break;
                    case "2":
                        TakeCareNextClaim();
                        break;
                    case "3":
                        AddClaimToQueue();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void DisplayClaims()
        {
            Console.WriteLine($"{"ClaimID",-25}{"Claim Type",-25}{"Description",-25}{"Ammount",-12}{"Date Of Accident",-25}{"DateOfClaim",-27}{"IsValid"}");
            Queue<Claim> claimsQueue = _claimRepo.GetClaimsQueue();
            foreach (Claim claim in claimsQueue)
            {
                Console.WriteLine($"{claim.ClaimID, -25}{claim.TypeOfClaim, -25}{claim.Description, -25}{claim.ClaimAmount, -12}{claim.DateOfIncident,-25}{claim.DateOfClaim,-27}{claim.IsValid}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void AddClaimToQueue()
        {
            Claim claim = new Claim();
            Console.WriteLine("Please enter a new claim ID:");
            claim.ClaimID = Console.ReadLine();

            Console.WriteLine("Next, select a claim type from below (choose a value between 1 and 3:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    claim.TypeOfClaim = ClaimType.Car;
                    break;
                case "2":
                    claim.TypeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    claim.TypeOfClaim = ClaimType.Theft;
                    break;
                default:
                    break;
            }

            Console.WriteLine("Next, enter a claim description:");
            claim.Description = Console.ReadLine();

            Console.WriteLine("Next, enter a claim amount(Do not inlude '$')");
            claim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Next, enter the date of the incident MM/DD/YYYY:");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Next, enter the date of the claim MM/DD/YYYY:");
            claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            _claimRepo.AddClaimToClaimsQueue(claim);
            Console.WriteLine($"Claim {claim.ClaimID} has been added! Press any key to return to the main menu");
            Console.ReadKey();
        }
        private void TakeCareNextClaim()
        { Claim firstClaim = _claimRepo.GetClaimFromQueue();
            Console.WriteLine($"{firstClaim.ClaimID}\n" +
                $"{firstClaim.TypeOfClaim}\n" +
                $"{firstClaim.Description}\n" +
                $"{firstClaim.ClaimAmount}\n" +
                $"{firstClaim.DateOfIncident}\n" +
                $"{firstClaim.DateOfClaim}\n" +
                $"{firstClaim.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    _claimRepo.DequeueExistingClaim();
                    break;
                case "n":

                    break;
                default:
                    Console.WriteLine("Please enter a y or n only");
                    break;
            }
        }
    }
}
