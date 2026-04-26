using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeAffairsDigitalIdentityProcessor
{
	public class CSVStorage
	{
		private string storageDirectory;
		private string storageFilePath;
		private List<CitizenProfile> savedProfiles;

		public CSVStorage()
		{
			savedProfiles = new List<CitizenProfile>();

			// Set storage location to user's Documents folder
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			storageDirectory = Path.Combine(documentsPath, "HomeAffairsProfiles");

			// Create directory if it doesn't exist
			if (!Directory.Exists(storageDirectory))
			{
				Directory.CreateDirectory(storageDirectory);
			}

			// Generate filename with today's date
			string todayDate = DateTime.Now.ToString("yyyyMMdd");
			storageFilePath = Path.Combine(storageDirectory, $"profiles_{todayDate}.csv");

			// Load existing profiles from file
			LoadProfilesFromFile();
		}

		public string StorageDirectory
		{
			get { return storageDirectory; }
		}

		public string StorageFilePath
		{
			get { return storageFilePath; }
		}

		public List<CitizenProfile> SavedProfiles
		{
			get { return savedProfiles; }
		}

		// Load profiles from CSV file
		private void LoadProfilesFromFile()
		{
			if (!File.Exists(storageFilePath))
			{
				return;
			}

			try
			{
				string[] lines = File.ReadAllLines(storageFilePath, Encoding.UTF8);

				// Skip header line
				for (int i = 1; i < lines.Length; i++)
				{
					string line = lines[i];
					if (string.IsNullOrWhiteSpace(line))
						continue;

					string[] parts = line.Split(',');
					if (parts.Length >= 8)
					{
						try
						{
							// Recreate profile from saved data
							string name = parts[0];
							string idNumber = parts[1];
							string citizenship = parts[4];

							CitizenProfile profile = new CitizenProfile(name, idNumber, citizenship);

							// Note: We don't overwrite validation state from file for security
							// Instead, profiles are re-validated when loaded
							profile.ValidateID();

							savedProfiles.Add(profile);
						}
						catch (Exception)
						{
							// Skip invalid entries but continue loading others
						}
					}
				}
			}
			catch (Exception)
			{
				// Silent fail - just means no profiles loaded
			}
		}

		// Save a single profile (appends to CSV)
		public bool SaveProfile(CitizenProfile profile, out string message)
		{
			if (profile == null)
			{
				message = "Cannot save null profile";
				return false;
			}

			// Check for duplicate ID (optional warning)
			bool isDuplicate = false;
			foreach (CitizenProfile existing in savedProfiles)
			{
				if (existing.IDNumber == profile.IDNumber)
				{
					isDuplicate = true;
					break;
				}
			}

			try
			{
				// Add to in-memory list
				savedProfiles.Add(profile);

				// Write all profiles to file (overwrite with full list)
				WriteAllProfilesToFile();

				if (isDuplicate)
				{
					message = $"Profile saved successfully (Note: ID {profile.IDNumber} already exists in database)";
				}
				else
				{
					message = $"Profile saved successfully to {storageFilePath}";
				}
				return true;
			}
			catch (Exception ex)
			{
				message = $"Failed to save profile: {ex.Message}";
				return false;
			}
		}

		// Write all profiles to CSV file
		private void WriteAllProfilesToFile()
		{
			using (StreamWriter writer = new StreamWriter(storageFilePath, false, Encoding.UTF8))
			{
				// Write header
				writer.WriteLine(CitizenProfile.GetCSVHeader());

				// Write each profile
				foreach (CitizenProfile profile in savedProfiles)
				{
					writer.WriteLine(profile.ToCSVString());
				}
			}
		}

		// Export all profiles to a specified file
		public bool ExportAllToCSV(string exportPath, out string message)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(exportPath, false, Encoding.UTF8))
				{
					writer.WriteLine(CitizenProfile.GetCSVHeader());
					foreach (CitizenProfile profile in savedProfiles)
					{
						writer.WriteLine(profile.ToCSVString());
					}
				}
				message = $"Successfully exported {savedProfiles.Count} profiles to {exportPath}";
				return true;
			}
			catch (Exception ex)
			{
				message = $"Export failed: {ex.Message}";
				return false;
			}
		}

		// Get statistics about saved profiles
		public string GetStatistics()
		{
			if (savedProfiles.Count == 0)
			{
				return "No profiles saved yet";
			}

			int maleCount = 0;
			int femaleCount = 0;
			int citizenCount = 0;
			int totalAge = 0;
			int validatedCount = 0;

			foreach (CitizenProfile profile in savedProfiles)
			{
				if (profile.Gender == "Male") maleCount++;
				if (profile.Gender == "Female") femaleCount++;
				if (profile.CitizenshipStatus == "Citizen") citizenCount++;
				totalAge += profile.Age;
				if (profile.IsValidated) validatedCount++;
			}

			double avgAge = (double)totalAge / savedProfiles.Count;

			return $"Total Profiles: {savedProfiles.Count}\n" +
				   $"Male: {maleCount} | Female: {femaleCount}\n" +
				   $"South African Citizens: {citizenCount}\n" +
				   $"Average Age: {avgAge:F1} years\n" +
				   $"Validated Profiles: {validatedCount}\n" +
				   $"Storage Location: {storageDirectory}";
		}

		// Search profiles by name or ID
		public List<CitizenProfile> SearchProfiles(string searchTerm)
		{
			if (string.IsNullOrWhiteSpace(searchTerm))
			{
				return new List<CitizenProfile>(savedProfiles);
			}

			searchTerm = searchTerm.ToLower();

			List<CitizenProfile> results = new List<CitizenProfile>();
			foreach (CitizenProfile profile in savedProfiles)
			{
				if (profile.FullName.ToLower().Contains(searchTerm) ||
					profile.IDNumber.Contains(searchTerm))
				{
					results.Add(profile);
				}
			}
			return results;
		}

		// Delete a profile from storage
		public bool DeleteProfile(string idNumber, out string message)
		{
			for (int i = 0; i < savedProfiles.Count; i++)
			{
				if (savedProfiles[i].IDNumber == idNumber)
				{
					savedProfiles.RemoveAt(i);
					WriteAllProfilesToFile();
					message = $"Profile with ID {idNumber} deleted successfully";
					return true;
				}
			}
			message = $"Profile with ID {idNumber} not found";
			return false;
		}

		// Get today's profile count
		public int GetTodayProfilesCount()
		{
			DateTime today = DateTime.Now.Date;
			int count = 0;
			foreach (CitizenProfile profile in savedProfiles)
			{
				if (profile.ProfileCreatedDate.Date == today)
				{
					count++;
				}
			}
			return count;
		}
	}
}