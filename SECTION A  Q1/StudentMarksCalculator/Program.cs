using System;
using System.Globalization;

namespace StudentMarksCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			// set console title and basic styling
			Console.Title = "Student Marks Calculator - Academic Assessment System";

			// apply some subtle visual styling - professional but not loud
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
			Console.WriteLine("║           STUDENT MARKS CALCULATION SYSTEM                 ║");
			Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
			Console.ResetColor();

			// display current date and time as shown in your example
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine($"\nDate: {DateTime.Now.ToString("dd MMMM yyyy")}");
			Console.WriteLine($"Time: {DateTime.Now.ToString("h:mm tt").ToLower()}");
			Console.ResetColor();

			Console.WriteLine();

			// get student name with basic validation
			Console.Write("Enter Student Name: ");
			string studentFullName = Console.ReadLine();

			// simple name validation - if empty, use a default
			if (string.IsNullOrWhiteSpace(studentFullName))
			{
				studentFullName = "Unnamed Student";
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("  [using default name]");
				Console.ResetColor();
			}

			// get three subject marks with full validation
			double markOne = GetValidatedMark("Enter Subject 1 Mark: ");
			double markTwo = GetValidatedMark("Enter Subject 2 Mark: ");
			double markThree = GetValidatedMark("Enter Subject 3 Mark: ");

			// calculations
			double totalMarksSum = markOne + markTwo + markThree;
			double averageScore = totalMarksSum / 3.0;

			// determine result with the rule: average >= 50 = PASS
			string finalResult = (averageScore >= 50) ? "PASS" : "FAIL";

			// generate a performance message based on the average
			string performanceMessage = GetPerformanceMessage(averageScore);

			// format the average to show 2 decimal places
			string formattedAverage = averageScore.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ",");

			// display results section
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("═══════════════════════════════════════════════════════════════");
			Console.WriteLine("                          RESULTS                               ");
			Console.WriteLine("═══════════════════════════════════════════════════════════════");
			Console.ResetColor();

			Console.WriteLine($"\nStudent Name: {studentFullName}");
			Console.WriteLine($"Subject 1: {markOne}");
			Console.WriteLine($"Subject 2: {markTwo}");
			Console.WriteLine($"Subject 3: {markThree}");

			Console.WriteLine("\n───────────────────────────────────────────────────────────────");

			Console.WriteLine($"Total Marks: {totalMarksSum}");
			Console.WriteLine($"Average Marks: {formattedAverage}");

			// color code the result for visual impact
			if (finalResult == "PASS")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"Final Result: {finalResult}");
				Console.ResetColor();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Final Result: {finalResult}");
				Console.ResetColor();
			}

			Console.WriteLine($"Status: {performanceMessage}");

			Console.WriteLine("\n───────────────────────────────────────────────────────────────");

			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine($"Report Generated: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
			Console.ResetColor();

			Console.WriteLine("\n═══════════════════════════════════════════════════════════════");

			// professional exit message
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write("\nPress any key to exit the application... ");
			Console.ReadKey();
		}

		// robust mark validation method with range checking
		static double GetValidatedMark(string promptText)
		{
			double userMark = -1;
			bool isValid = false;

			while (!isValid)
			{
				Console.Write(promptText);
				string rawInput = Console.ReadLine();

				// attempt to parse the input
				if (double.TryParse(rawInput, NumberStyles.Any, CultureInfo.InvariantCulture, out userMark))
				{
					// check if mark falls within valid range (0-100)
					if (userMark >= 0 && userMark <= 100)
					{
						isValid = true;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"  [ERROR] Mark must be between 0 and 100. You entered: {userMark}");
						Console.ResetColor();
					}
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"  [ERROR] Invalid input. '{rawInput}' is not a valid number.");
					Console.ResetColor();
				}
			}
			return userMark;
		}

		// helper method that returns a tailored message based on performance
		static string GetPerformanceMessage(double averageValue)
		{
			if (averageValue >= 85)
			{
				return "Outstanding achievement! You have excelled.";
			}
			else if (averageValue >= 70)
			{
				return "Very good performance. Keep up the momentum.";
			}
			else if (averageValue >= 50)
			{
				return "Congratulations! You have passed.";
			}
			else if (averageValue >= 40)
			{
				return "Below passing threshold. Additional effort required.";
			}
			else
			{
				return "Academic support strongly recommended.";
			}
		}
	}
}