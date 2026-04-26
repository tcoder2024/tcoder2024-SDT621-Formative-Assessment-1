using System;
using System.Collections.Generic;

namespace EmfuleniMunicipality
{
	class Program
	{
		static UtilitiesManager manager;

		static void Main(string[] args)
		{
			Console.Title = "Emfuleni Municipality Service Management System";

			InitializeSystem();

			bool systemRunning = true;
			while (systemRunning)
			{
				DisplayMainMenu();
				string userChoice = GetUserInput("Select option", false);

				switch (userChoice)
				{
					case "1":
						CaptureResidentsAndRequests();
						break;
					case "2":
						DisplayAndProcessRequests();
						break;
					case "3":
						ViewStatisticsAndReports();
						break;
					case "4":
						DataStorageMenu();
						break;
					case "5":
						systemRunning = false;
						DisplayFarewell();
						break;
					default:
						DisplayError("Invalid selection. Please choose 1-5.");
						break;
				}
			}
		}

		static void InitializeSystem()
		{
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Clear();
			Console.WriteLine("Emfuleni Municipality Service Management System");
			Console.WriteLine($"Initialized: {DateTime.Now:dd MMM yyyy HH:mm:ss}");
			Console.ResetColor();

			manager = new UtilitiesManager();

			Console.WriteLine("System ready. Loading previous data if available...");
			string loadMsg;
			manager.LoadFromFile(out loadMsg);
			Console.WriteLine(loadMsg);

			PressAnyKey();
		}

		static void DisplayMainMenu()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("EMFULENI MUNICIPALITY - SERVICE DESK");
			Console.WriteLine(new string('=', 50));
			Console.ResetColor();
			Console.WriteLine();
			Console.WriteLine("  [1] Register New Residents & Log Service Requests");
			Console.WriteLine("  [2] Process Pending Service Requests");
			Console.WriteLine("  [3] View Statistics & Reports");
			Console.WriteLine("  [4] Data Storage (Backup/Load)");
			Console.WriteLine("  [5] Exit System");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine($"Current Status: {manager.Residents.Count} residents | {manager.PendingRequests.Count} pending | {manager.ProcessedRequests.Count} processed");
			Console.ResetColor();
			Console.WriteLine();
		}

		static void CaptureResidentsAndRequests()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("REGISTER NEW RESIDENTS AND SERVICE REQUESTS");
			Console.WriteLine(new string('-', 50));
			Console.ResetColor();

			// Capture residents
			int residentCount = GetValidatedInteger("How many residents do you want to register?");

			for (int i = 0; i < residentCount; i++)
			{
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine($"--- Resident {i + 1} ---");
				Console.ResetColor();

				string name = GetUserInput("Name", true);
				string address = GetUserInput("Address", true);
				string accountNumber = GetUserInput("Account Number", true);
				double utilityUsage = GetValidatedDouble("Monthly Utility Usage (kWh or litres)");

				try
				{
					Resident newResident = new Resident(name, address, accountNumber, utilityUsage);
					manager.AddResident(newResident);
					DisplaySuccess($"Resident {name} registered successfully.");
				}
				catch (Exception ex)
				{
					DisplayError(ex.Message);
					i--;
				}
			}

			if (manager.Residents.Count == 0)
			{
				DisplayError("No residents registered. Cannot log service requests.");
				PressAnyKey();
				return;
			}

			// Capture service requests
			int requestCount = GetValidatedInteger("How many service requests do you want to log?");

			for (int i = 0; i < requestCount; i++)
			{
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine($"--- Service Request {i + 1} ---");
				Console.ResetColor();

				DisplayResidentList();
				int residentIndex = GetValidatedInteger($"Select resident by number (1 to {manager.Residents.Count})") - 1;

				if (residentIndex < 0 || residentIndex >= manager.Residents.Count)
				{
					DisplayError("Invalid resident selection. Request not logged.");
					i--;
					continue;
				}

				Resident selectedResident = manager.Residents[residentIndex];
				string requestType = GetUserInput("Request Type (e.g., Water Outage, Burst Pipe)", true);
				int priority = GetValidatedIntegerInRange("Priority Level (1-5)", 1, 5);
				int severity = GetValidatedIntegerInRange("Severity Level (1-10)", 1, 10);
				double estimatedHours = GetValidatedDouble("Estimated Resolution Hours");

				try
				{
					ServiceRequest newRequest = new ServiceRequest(selectedResident, requestType, priority, severity, estimatedHours);
					manager.AddServiceRequest(newRequest);
					DisplaySuccess($"Service request logged successfully. Urgency Score: {newRequest.CalculateUrgencyScore()}");
				}
				catch (Exception ex)
				{
					DisplayError(ex.Message);
					i--;
				}
			}

			Console.WriteLine();
			DisplaySuccess($"Registration complete. Total residents: {manager.Residents.Count} | Total requests: {manager.AllRequests.Count}");
			PressAnyKey();
		}

		static void DisplayAndProcessRequests()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("PROCESS PENDING SERVICE REQUESTS");
			Console.WriteLine(new string('-', 50));
			Console.ResetColor();

			if (manager.PendingRequests.Count == 0)
			{
				DisplayError("No pending service requests to process.");
				PressAnyKey();
				return;
			}

			// Display queue
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("PENDING REQUESTS QUEUE:");
			Console.ResetColor();

			List<string> queue = manager.GetPendingQueueDisplay();
			foreach (string item in queue)
			{
				Console.WriteLine($"  {item}");
			}

			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine($"Total pending: {manager.PendingRequests.Count}");
			Console.ResetColor();

			// Interactive processing
			bool continueProcessing = true;
			while (continueProcessing && manager.PendingRequests.Count > 0)
			{
				Console.WriteLine();
				int requestNumber = GetValidatedIntegerInRange($"Enter request number to process (1 to {manager.PendingRequests.Count}) [0 to finish]", 0, manager.PendingRequests.Count);

				if (requestNumber == 0)
				{
					continueProcessing = false;
					break;
				}

				try
				{
					ServiceRequest processed = manager.ProcessRequest(requestNumber - 1);
					Console.WriteLine();
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("=== SERVICE REPORT ===");
					Console.ResetColor();
					Console.WriteLine(processed.GetFullReport());
					Console.WriteLine();
					DisplaySuccess("Request processed successfully.");
				}
				catch (Exception ex)
				{
					DisplayError(ex.Message);
				}
			}

			// Show final summary after processing
			if (manager.ProcessedRequests.Count > 0)
			{
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine(manager.GetFinalSummary());
				Console.ResetColor();
			}

			PressAnyKey();
		}

		static void ViewStatisticsAndReports()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("STATISTICS AND REPORTS");
			Console.WriteLine(new string('-', 50));
			Console.ResetColor();

			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("RESIDENT REGISTRY:");
			Console.ResetColor();

			if (manager.Residents.Count == 0)
			{
				Console.WriteLine("  No residents registered.");
			}
			else
			{
				for (int i = 0; i < manager.Residents.Count; i++)
				{
					Console.WriteLine($"  [{i + 1}] {manager.Residents[i].GetDisplayInfo()}");
				}
			}

			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("SERVICE REQUEST LOG:");
			Console.ResetColor();

			if (manager.AllRequests.Count == 0)
			{
				Console.WriteLine("  No service requests logged.");
			}
			else
			{
				foreach (ServiceRequest req in manager.AllRequests)
				{
					Console.WriteLine($"  • {req.RequestType} | Resident: {req.AssociatedResident.ResidentName} | Status: {req.RequestStatus} | Urgency: {req.CalculateUrgencyScore()}");
				}
			}

			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("SYSTEM STATISTICS:");
			Console.ResetColor();
			Console.WriteLine(manager.GetStatisticsReport());

			PressAnyKey();
		}

		static void DataStorageMenu()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("DATA STORAGE MANAGEMENT");
			Console.WriteLine(new string('-', 50));
			Console.ResetColor();

			Console.WriteLine();
			Console.WriteLine("  [1] Save current data to file");
			Console.WriteLine("  [2] View backup information");
			Console.WriteLine("  [3] Return to main menu");
			Console.WriteLine();

			string choice = GetUserInput("Select option", false);

			switch (choice)
			{
				case "1":
					try
					{
						manager.SaveToFile();
						DisplaySuccess("Data saved successfully to municipal_data.txt");
					}
					catch (Exception ex)
					{
						DisplayError($"Save failed: {ex.Message}");
					}
					break;
				case "2":
					string loadMsg;
					manager.LoadFromFile(out loadMsg);
					Console.WriteLine();
					Console.ForegroundColor = ConsoleColor.DarkGray;
					Console.WriteLine(loadMsg);
					Console.ResetColor();
					break;
				case "3":
					return;
				default:
					DisplayError("Invalid option");
					break;
			}

			PressAnyKey();
		}

		// ========== HELPER METHODS ==========

		static string GetUserInput(string prompt, bool required)
		{
			string input = "";
			bool valid = false;

			while (!valid)
			{
				Console.Write($"{prompt}: ");
				input = Console.ReadLine();

				if (required && string.IsNullOrWhiteSpace(input))
				{
					DisplayError("This field cannot be empty. Please try again.");
				}
				else
				{
					valid = true;
				}
			}

			return input;
		}

		static int GetValidatedInteger(string prompt)
		{
			int result = 0;
			bool valid = false;

			while (!valid)
			{
				Console.Write($"{prompt}: ");
				string input = Console.ReadLine();

				if (int.TryParse(input, out result) && result > 0)
				{
					valid = true;
				}
				else
				{
					DisplayError("Please enter a valid positive number.");
				}
			}

			return result;
		}

		static int GetValidatedIntegerInRange(string prompt, int min, int max)
		{
			int result = 0;
			bool valid = false;

			while (!valid)
			{
				Console.Write($"{prompt}: ");
				string input = Console.ReadLine();

				if (int.TryParse(input, out result) && result >= min && result <= max)
				{
					valid = true;
				}
				else
				{
					DisplayError($"Please enter a number between {min} and {max}.");
				}
			}

			return result;
		}

		static double GetValidatedDouble(string prompt)
		{
			double result = 0;
			bool valid = false;

			while (!valid)
			{
				Console.Write($"{prompt}: ");
				string input = Console.ReadLine();

				if (double.TryParse(input, out result) && result > 0)
				{
					valid = true;
				}
				else
				{
					DisplayError("Please enter a valid positive number.");
				}
			}

			return result;
		}

		static void DisplayResidentList()
		{
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("Registered residents:");
			for (int i = 0; i < manager.Residents.Count; i++)
			{
				Console.WriteLine($"  [{i + 1}] {manager.Residents[i].ResidentName}");
			}
			Console.ResetColor();
		}

		static void DisplaySuccess(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"[SUCCESS] {message}");
			Console.ResetColor();
		}

		static void DisplayError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"[ERROR] {message}");
			Console.ResetColor();
		}

		static void PressAnyKey()
		{
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write("Press any key to continue...");
			Console.ReadKey();
			Console.ResetColor();
		}

		static void DisplayFarewell()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Thank you for using the Emfuleni Municipality Service Desk.");
			Console.WriteLine($"System session ended: {DateTime.Now:dd MMM yyyy HH:mm:ss}");
			Console.ResetColor();
			Console.WriteLine();
		}
	}
}