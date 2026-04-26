using System;
using System.Globalization;

namespace CTUSimpleATMSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			// set console title for professional feel
			Console.Title = "CTU Simple ATM System - Banking Transaction Processor";

			// header styling - matching Q1 but with ATM theme
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
			Console.WriteLine("║                  ==== CTU SIMPLE ATM SYSTEM ====           ║");
			Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
			Console.ResetColor();

			Console.WriteLine();

			// user greeting section - get customer name
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("HI, WHAT IS YOUR NAME? ");
			Console.ResetColor();

			string customerName = Console.ReadLine();

			// name validation - handle empty input
			if (string.IsNullOrWhiteSpace(customerName))
			{
				customerName = "Valued Customer";
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("  [using default greeting]");
				Console.ResetColor();
			}

			// welcome message with color
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"WELCOME {customerName.ToUpper()}!");
			Console.ResetColor();

			// get account balance with validation
			double accountBalance = GetValidatedAmount("Enter account balance: ");

			// get withdrawal amount with validation
			double withdrawalRequest = GetValidatedAmount("Enter withdrawal amount: ");

			// process the transaction
			double updatedBalance = 0;
			bool transactionSuccessful = false;
			string transactionMessage = "";

			// check if withdrawal is possible
			if (withdrawalRequest <= accountBalance)
			{
				updatedBalance = accountBalance - withdrawalRequest;
				transactionSuccessful = true;
				transactionMessage = "Withdrawal successful!";
			}
			else
			{
				transactionSuccessful = false;
				transactionMessage = "Withdrawal failed! Insufficient funds.";
			}

			// display results with proper formatting
			Console.WriteLine();

			if (transactionSuccessful)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(transactionMessage);
				Console.ResetColor();

				// format balance with 2 decimal places and comma for SA locale
				string formattedUpdatedBalance = updatedBalance.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ",");

				Console.WriteLine($"Updated Balance: {formattedUpdatedBalance}");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(transactionMessage);
				Console.ResetColor();

				// show current balance so user knows what they have
				string formattedCurrentBalance = accountBalance.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ",");
				Console.WriteLine($"Your current balance is: {formattedCurrentBalance}");
				Console.WriteLine($"Requested amount: {withdrawalRequest.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ",")}");
			}

			// transaction timestamp - exactly as shown in screenshot
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine($"Transaction Time: {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
			Console.ResetColor();

			// professional footer
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("═══════════════════════════════════════════════════════════════");
			Console.WriteLine("Thank you for using CTU ATM System. Have a great day!");
			Console.WriteLine("═══════════════════════════════════════════════════════════════");
			Console.ResetColor();

			// exit prompt
			Console.Write("\nPress any key to exit... ");
			Console.ReadKey();
		}

		// validated amount method - handles numbers, decimals, negative values
		static double GetValidatedAmount(string promptMessage)
		{
			double amountValue = -1;
			bool isValid = false;

			while (!isValid)
			{
				Console.Write(promptMessage);
				string rawInput = Console.ReadLine();

				// try to parse the input as a number
				if (double.TryParse(rawInput, NumberStyles.Any, CultureInfo.InvariantCulture, out amountValue))
				{
					// check if amount is positive (no negative balances or withdrawals)
					if (amountValue >= 0)
					{
						isValid = true;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"  [ERROR] Amount cannot be negative. You entered: {amountValue}");
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
			return amountValue;
		}
	}
}