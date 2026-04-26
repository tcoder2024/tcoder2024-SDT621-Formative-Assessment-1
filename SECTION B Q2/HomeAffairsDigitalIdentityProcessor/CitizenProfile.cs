using System;
using System.Text.RegularExpressions;

namespace HomeAffairsDigitalIdentityProcessor
{
	public class CitizenProfile
	{
		// Private fields
		private string fullNameValue;
		private string idNumberValue;
		private int ageValue;
		private string genderValue;
		private string citizenshipStatusValue;
		private bool isValidated;
		private string validationMessage;
		private DateTime profileCreatedDate;
		private DateTime lastValidatedDate;

		// Properties
		public string FullName
		{
			get { return fullNameValue; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Full name cannot be empty");

				if (value.Length < 2)
					throw new ArgumentException("Name must be at least 2 characters");

				// Allow letters, spaces, hyphens, and apostrophes only
				if (!Regex.IsMatch(value, @"^[a-zA-Z\s\-']+$"))
					throw new ArgumentException("Name can only contain letters, spaces, hyphens, and apostrophes");

				fullNameValue = value.Trim();
			}
		}

		public string IDNumber
		{
			get { return idNumberValue; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("ID number cannot be empty");

				// Remove any spaces or dashes first
				string cleanedId = value.Replace(" ", "").Replace("-", "");

				if (cleanedId.Length != 13)
					throw new ArgumentException("ID number must be exactly 13 digits");

				if (!Regex.IsMatch(cleanedId, @"^\d{13}$"))
					throw new ArgumentException("ID number must contain only digits");

				idNumberValue = cleanedId;
			}
		}

		public int Age
		{
			get { return ageValue; }
			private set { ageValue = value; }
		}

		public string Gender
		{
			get { return genderValue; }
			private set { genderValue = value; }
		}

		public string CitizenshipStatus
		{
			get { return citizenshipStatusValue; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Citizenship status cannot be empty");

				string[] validStatuses = { "Citizen", "Permanent Resident", "Visitor" };
				bool isValid = false;
				foreach (string status in validStatuses)
				{
					if (status.Equals(value, StringComparison.OrdinalIgnoreCase))
					{
						isValid = true;
						break;
					}
				}

				if (!isValid)
					throw new ArgumentException("Invalid citizenship status. Must be Citizen, Permanent Resident, or Visitor");

				citizenshipStatusValue = value;
			}
		}

		public bool IsValidated
		{
			get { return isValidated; }
			private set { isValidated = value; }
		}

		public string ValidationMessage
		{
			get { return validationMessage; }
			private set { validationMessage = value; }
		}

		public DateTime ProfileCreatedDate
		{
			get { return profileCreatedDate; }
		}

		public DateTime LastValidatedDate
		{
			get { return lastValidatedDate; }
		}

		// Constructor
		public CitizenProfile(string name, string idNumber, string citizenship)
		{
			FullName = name;
			IDNumber = idNumber;
			CitizenshipStatus = citizenship;

			// Extract birth date and calculate age
			CalculateAgeFromID();

			// Extract gender from ID
			ExtractGenderFromID();

			profileCreatedDate = DateTime.Now;
			lastValidatedDate = DateTime.MinValue;
			isValidated = false;
			validationMessage = "Not yet validated";
		}

		// Calculate age from first 6 digits of ID (YYMMDD)
		private void CalculateAgeFromID()
		{
			try
			{
				string birthDatePart = idNumberValue.Substring(0, 6);
				int yearTwoDigit = int.Parse(birthDatePart.Substring(0, 2));
				int month = int.Parse(birthDatePart.Substring(2, 2));
				int day = int.Parse(birthDatePart.Substring(4, 2));

				// Determine century (00-24 = 2000s, 25-99 = 1900s)
				int yearFourDigit;
				if (yearTwoDigit >= 0 && yearTwoDigit <= 24)
				{
					yearFourDigit = 2000 + yearTwoDigit;
				}
				else
				{
					yearFourDigit = 1900 + yearTwoDigit;
				}

				// Validate date is real (e.g., not 31 Feb)
				if (!IsValidDate(yearFourDigit, month, day))
				{
					throw new ArgumentException("Invalid birth date in ID number");
				}

				DateTime birthDate = new DateTime(yearFourDigit, month, day);

				// Check if birth date is in the future
				if (birthDate > DateTime.Now)
				{
					throw new ArgumentException("Birth date cannot be in the future");
				}

				// Calculate age
				DateTime today = DateTime.Now;
				Age = today.Year - birthDate.Year;
				if (birthDate.Date > today.AddYears(-Age))
				{
					Age--;
				}

				// Check for unrealistic age (over 120)
				if (Age > 120)
				{
					throw new ArgumentException("Age exceeds 120 years - invalid ID");
				}
			}
			catch (Exception ex)
			{
				throw new ArgumentException($"Failed to calculate age: {ex.Message}");
			}
		}

		// Extract gender from digits 7-10 (0000-4999 = Female, 5000-9999 = Male)
		private void ExtractGenderFromID()
		{
			try
			{
				string genderDigits = idNumberValue.Substring(6, 4);
				int genderCode = int.Parse(genderDigits);

				if (genderCode >= 0 && genderCode <= 4999)
				{
					Gender = "Female";
				}
				else if (genderCode >= 5000 && genderCode <= 9999)
				{
					Gender = "Male";
				}
				else
				{
					Gender = "Unknown";
				}
			}
			catch (Exception)
			{
				Gender = "Unable to determine";
			}
		}

		// Helper method to validate date
		private bool IsValidDate(int year, int month, int day)
		{
			if (month < 1 || month > 12) return false;
			if (day < 1 || day > 31) return false;

			int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

			// Check for leap year
			bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
			if (isLeapYear && month == 2)
			{
				return day <= 29;
			}

			return day <= daysInMonth[month - 1];
		}

		// Validate the entire ID with comprehensive checks
		public string ValidateID()
		{
			List<string> errors = new List<string>();

			// Check 1: Exactly 13 digits (already done in property)
			if (idNumberValue.Length != 13)
			{
				errors.Add("ID must be exactly 13 digits");
			}

			// Check 2: All numeric (already done in property)
			if (!Regex.IsMatch(idNumberValue, @"^\d{13}$"))
			{
				errors.Add("ID must contain only numbers");
			}

			// Check 3: Valid birth date
			try
			{
				string birthDatePart = idNumberValue.Substring(0, 6);
				int yearTwoDigit = int.Parse(birthDatePart.Substring(0, 2));
				int month = int.Parse(birthDatePart.Substring(2, 2));
				int day = int.Parse(birthDatePart.Substring(4, 2));

				int yearFourDigit = (yearTwoDigit >= 0 && yearTwoDigit <= 24) ? 2000 + yearTwoDigit : 1900 + yearTwoDigit;

				if (!IsValidDate(yearFourDigit, month, day))
				{
					errors.Add("Invalid birth date in ID");
				}
			}
			catch (Exception)
			{
				errors.Add("Could not parse birth date from ID");
			}

			// Check 4: Age reasonable (already handled in CalculateAgeFromID)
			if (Age < 0 || Age > 120)
			{
				errors.Add($"Invalid age: {Age} years");
			}

			// Check 5: Citizenship digit (digit 11: 0 = SA citizen, 1 = permanent resident)
			if (idNumberValue.Length >= 11)
			{
				char citizenshipDigit = idNumberValue[10];
				if (citizenshipDigit != '0' && citizenshipDigit != '1')
				{
					errors.Add($"Invalid citizenship digit (must be 0 or 1, found '{citizenshipDigit}')");
				}
			}

			// Determine validation result
			if (errors.Count == 0)
			{
				IsValidated = true;
				ValidationMessage = "VALID - South African ID number verified";
				lastValidatedDate = DateTime.Now;
				return ValidationMessage;
			}
			else
			{
				IsValidated = false;
				ValidationMessage = $"INVALID - {string.Join("; ", errors)}";
				return ValidationMessage;
			}
		}

		// Get formatted profile summary
		public string GetFormattedProfile()
		{
			string separator = new string('-', 40);
			string profile = "";

			profile += "DIGITAL CITIZEN PROFILE\n";
			profile += separator + "\n";
			profile += $"Full Name        : {FullName}\n";
			profile += $"ID Number        : {IDNumber}\n";
			profile += $"Age              : {Age} years\n";
			profile += $"Gender           : {Gender}\n";
			profile += $"Citizenship      : {CitizenshipStatus}\n";
			profile += separator + "\n";
			profile += $"Validation Status: {(IsValidated ? "Verified" : "Pending")}\n";
			profile += $"Validated On     : {(LastValidatedDate == DateTime.MinValue ? "Not yet validated" : LastValidatedDate.ToString("dd MMM yyyy HH:mm:ss"))}\n";
			profile += $"Profile Created  : {ProfileCreatedDate:dd MMM yyyy HH:mm:ss}\n";

			return profile;
		}

		// Get CSV-ready string for export
		public string ToCSVString()
		{
			return $"{FullName},{IDNumber},{Age},{Gender},{CitizenshipStatus},{LastValidatedDate:yyyy-MM-dd},{ValidationMessage},{ProfileCreatedDate:yyyy-MM-dd HH:mm:ss}";
		}

		// Get CSV header
		public static string GetCSVHeader()
		{
			return "FullName,IDNumber,Age,Gender,CitizenshipStatus,DateValidated,ValidationResult,ProfileCreatedTimestamp";
		}

		public override string ToString()
		{
			return $"{FullName} ({IDNumber}) - {Age} years, {Gender}, {CitizenshipStatus}";
		}
	}
}