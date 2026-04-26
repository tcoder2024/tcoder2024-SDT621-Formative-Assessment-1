using System;

namespace EmfuleniMunicipality
{
	public class ServiceRequest
	{
		private string requestTypeValue;
		private int priorityLevelValue;
		private int severityLevelValue;
		private double estimatedHoursValue;
		private Resident associatedResident;
		private DateTime requestDateLogged;
		private string requestStatus;

		// Constructor
		public ServiceRequest(Resident resident, string requestType, int priority, int severity, double estimatedHours)
		{
			AssociatedResident = resident;
			RequestType = requestType;
			PriorityLevel = priority;
			SeverityLevel = severity;
			EstimatedResolutionHours = estimatedHours;
			requestDateLogged = DateTime.Now;
			requestStatus = "Pending";
		}

		// Properties with validation
		public Resident AssociatedResident
		{
			get { return associatedResident; }
			set
			{
				if (value == null)
					throw new ArgumentException("Resident cannot be null");
				associatedResident = value;
			}
		}

		public string RequestType
		{
			get { return requestTypeValue; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Request type cannot be empty");
				requestTypeValue = value.Trim();
			}
		}

		public int PriorityLevel
		{
			get { return priorityLevelValue; }
			set
			{
				if (value < 1 || value > 5)
					throw new ArgumentException("Priority must be between 1 and 5");
				priorityLevelValue = value;
			}
		}

		public int SeverityLevel
		{
			get { return severityLevelValue; }
			set
			{
				if (value < 1 || value > 10)
					throw new ArgumentException("Severity must be between 1 and 10");
				severityLevelValue = value;
			}
		}

		public double EstimatedResolutionHours
		{
			get { return estimatedHoursValue; }
			set
			{
				if (value <= 0)
					throw new ArgumentException("Estimated hours must be positive");
				estimatedHoursValue = value;
			}
		}

		public DateTime RequestDateLogged
		{
			get { return requestDateLogged; }
		}

		public string RequestStatus
		{
			get { return requestStatus; }
			set { requestStatus = value; }
		}

		// Core calculation methods
		public int CalculateUrgencyScore()
		{
			// Formula based on screenshot: (Priority × 10) + (Severity × 3) = 40 + 24 = 64
			return (PriorityLevel * 10) + (SeverityLevel * 3);
		}

		public double CalculateAdjustedResolution()
		{
			//  Adjusted based on urgency - higher urgency = faster response 
			int urgency = CalculateUrgencyScore();
			double adjustmentFactor = 1.0 - (urgency / 100.0);
			double adjusted = EstimatedResolutionHours * (1 + adjustmentFactor);
			return Math.Round(adjusted, 1);
		}

		public double CalculateHouseholdImpactScore()
		{
			// Impact = Utility usage × (Urgency / 10)
			double impact = AssociatedResident.MonthlyUtilityUsage * (CalculateUrgencyScore() / 10.0);
			return Math.Round(impact, 2);
		}

		public string GetQueueDisplayInfo(int queuePosition)
		{
			return $"[{queuePosition}] {RequestType} | Resident: {AssociatedResident.ResidentName} | Urgency: {CalculateUrgencyScore()} | Priority: {PriorityLevel} | Severity: {SeverityLevel}";
		}

		public string GetFullReport()
		{
			return $"Resident: {AssociatedResident.ResidentName}\n" +
				   $"Address: {AssociatedResident.ResidentAddress}\n" +
				   $"Account: {AssociatedResident.AccountNumber}\n" +
				   $"Service Type: {RequestType}\n" +
				   $"Priority Level: {PriorityLevel}/5\n" +
				   $"Severity Level: {SeverityLevel}/10\n" +
				   $"Estimated Resolution: {EstimatedResolutionHours} hours\n" +
				   $"Urgency Score: {CalculateUrgencyScore()}\n" +
				   $"Adjusted Resolution: {CalculateAdjustedResolution()} hours\n" +
				   $"Household Impact Score: {CalculateHouseholdImpactScore():F2}\n" +
				   $"Date Logged: {RequestDateLogged:dd MMM yyyy HH:mm:ss}\n" +
				   $"Status: {RequestStatus}";
		}

		public string GetSummaryLine()
		{
			return $"• {RequestType} for {AssociatedResident.ResidentName} | Urgency: {CalculateUrgencyScore()} | Impact: {CalculateHouseholdImpactScore():F2}";
		}
	}
}