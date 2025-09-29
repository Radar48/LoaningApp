using System;
using System.Collections.Generic;

namespace APP
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Farmer ID:");
            string farmerId = Console.ReadLine();

            Console.WriteLine("Enter Farmer Income:");
            double income = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Training Level (none, highschool, bachelor, master):");
            string trainingLevel = Console.ReadLine();

            Console.WriteLine("Enter number of seasons for yield history:");
            int seasons = Convert.ToInt32(Console.ReadLine());

            double[] yieldHistory = new double[seasons];
            double totalYield = 0;

            for (int season = 0; season < seasons; season++)
            {
                Console.WriteLine("Enter yield for season " + (season + 1) + ":");
                double yield = Convert.ToDouble(Console.ReadLine());
                yieldHistory[season] = yield;
                totalYield += yield;
            }

            double averageYield = seasons > 0 ? totalYield / seasons : 0;

            // eligibility
            bool isEligible = false;

            if (income >= 20000)
            {
                switch (trainingLevel.ToLower())
                {
                    case "none":
                        if (averageYield >= 500) isEligible = true;
                        break;
                    case "highschool":
                        if (averageYield >= 1000) isEligible = true;
                        break;
                    case "bachelor":
                        if (averageYield >= 1500) isEligible = true;
                        break;
                    case "master":
                        if (averageYield >= 2000) isEligible = true;
                        break;
                    default:
                        Console.WriteLine("Unknown training level.");
                        break;
                }
            }

            // Output
            if (isEligible)
            {
                Console.WriteLine("Loan Approved!");
                Console.WriteLine("Enter Loan Amount:");
                double loanAmount = Convert.ToDouble(Console.ReadLine());

                string dateIssued = DateTime.Now.ToString("yyyy-MM-dd");

                Console.WriteLine("LOAN REPORT");
                Console.WriteLine("Farmer ID: " + farmerId);
                Console.WriteLine("Income: " + income);
                Console.WriteLine("Training Level: " + trainingLevel);
                Console.WriteLine("Average Yield: " + averageYield);
                Console.WriteLine("Loan Amount: " + loanAmount);
                Console.WriteLine("Date Issued: " + dateIssued);
            }
            else
            {
                Console.WriteLine("Loan Denied. Farmer does not meet eligibility criteria.");
            }
        }
    }
}
