// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace APP
{
    class LoanEvaluator
    {
        public bool EvaluateLoanEligibility(double income, string trainingLevel, List<double> yieldHistory)
        {
            double averageYield = yieldHistory.Average();

            if (income < 20000)
            {
                return false;
            }

            switch (trainingLevel.ToLower())
            {
                case "none": return averageYield >= 500;
                case "highschool": return averageYield >= 1000;
                case "bachelor": return averageYield >= 1500;
                case "master": return averageYield >= 2000;
                default: return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Farmer ID: ");
            string farmerId = Console.ReadLine();

            Console.WriteLine("Enter Farmer Income: ");
            double income = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Training Level: ");
            string trainingLevel = Console.ReadLine();

            Console.WriteLine("Enter number of seasons for yield History: ");
            int seasons = Convert.ToInt32(Console.ReadLine());

            List<double> yieldHistory = new List<double>();
            for (int i = 0; i < seasons; i++)
            {
                Console.WriteLine($"Enter yield for season {i + 1}: ");
                double yield = Convert.ToDouble(Console.ReadLine());
                yieldHistory.Add(yield);
            }

            LoanEvaluator evaluator = new LoanEvaluator();
            bool isEligible = evaluator.EvaluateLoanEligibility(income, trainingLevel, yieldHistory);

            if (isEligible)
            {
                Console.WriteLine("Farmer is eligible for the loan.");
                Console.WriteLine("Enter Loan Amount: ");
                double loanAmount = Convert.ToDouble(Console.ReadLine());

                string dateIssued = DateTime.Now.ToString("yyyy-MM-dd");

                Console.WriteLine("\n--- Loan Report ---");
                Console.WriteLine($"Farmer ID: {farmerId}");
                Console.WriteLine($"Income: {income}");
                Console.WriteLine($"Training Level: {trainingLevel}");
                Console.WriteLine($"Average Yield: {yieldHistory.Average()}");
                Console.WriteLine($"Loan Amount: {loanAmount}");
                Console.WriteLine($"Date Issued: {dateIssued}");
            }
            else
            {
                Console.WriteLine("\nLoan Denied. Farmer does not meet eligibility criteria.");
            }
        }
    }
}
