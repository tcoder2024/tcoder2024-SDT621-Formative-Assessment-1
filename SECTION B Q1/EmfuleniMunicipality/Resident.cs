using System;

namespace EmfuleniMunicipality
{
	public class Resident
	{
		// Private fields with validation backing
		private string residentName;
		private string residentAddress;
		private string accountNumberValue;
		private double monthlyUtilityConsumption;

		// Constructor with validation
		public Resident(string name, string address, string accountNumber, double utilityUsage)
		{
			ResidentName = name;
			ResidentAddress = address;
			AccountNumber = accountNumber;
			MonthlyUtilityUsage = utilityUsage;
		}

		// Public properties with built-in validation
		public string ResidentName
		{
			get { return residentName; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Resident name cannot be empty");
				residentName = value.Trim();
			}
		}

		public string ResidentAddress
		{
			get { return residentAddress; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Address cannot be empty");
				residentAddress = value.Trim();
			}
		}

		public string AccountNumber
		{
			get { return accountNumberValue; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Account number cannot be empty");
				accountNumberValue = value.Trim();
			}
		}

		public double MonthlyUtilityUsage
		{
			get { return monthlyUtilityConsumption; }
			set
			{
				if (value < 0)
					throw new ArgumentException("Utility usage cannot be negative");
				monthlyUtilityConsumption = value;
			}
		}

		// Helper method for displaying resident info
		public string GetDisplayInfo()
		{
			return $"{ResidentName} | Acc: {AccountNumber} | Usage: {MonthlyUtilityUsage:F2} units";
		}

		public override string ToString()
		{
			return $"{ResidentName}, {ResidentAddress}, Account: {AccountNumber}, Usage: {MonthlyUtilityUsage:F2}";
		}
	}
}