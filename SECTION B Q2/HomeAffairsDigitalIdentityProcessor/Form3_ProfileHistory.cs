using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace HomeAffairsDigitalIdentityProcessor
{
	public partial class Form3_ProfileHistory : Form
	{
		private CSVStorage storage;
		private List<CitizenProfile> currentDisplayList;
		private CitizenProfile selectedProfile;

		public Form3_ProfileHistory(CSVStorage existingStorage)
		{
			InitializeComponent();
			storage = existingStorage;
			currentDisplayList = new List<CitizenProfile>();
			LoadAllProfiles();
			UpdateStatsDisplay();
		}

		private void LoadAllProfiles()
		{
			try
			{
				// Make sure columns exist before loading data
				if (this.profilesDataGridView.Columns.Count == 0)
				{
					SetupDataGridViewColumns();
				}

				currentDisplayList = new List<CitizenProfile>(storage.SavedProfiles);
				RefreshDataGridView();
				resultCountLabel.Text = $"Showing {currentDisplayList.Count} profile(s)";

				if (currentDisplayList.Count == 0)
				{
					statusMessageLabel.Text = "No profiles found in database. Create profiles using the Identity Processor.";
					detailRichTextBox.Text = "No profiles available.\n\nPlease go back to the main dashboard and create profiles using the Digital Identity Processor.\n\nOnce you create and save profiles, they will appear here.";
				}
				else
				{
					statusMessageLabel.Text = $"Loaded {currentDisplayList.Count} profile(s) from storage.";
				}
			}
			catch (Exception ex)
			{
				statusMessageLabel.Text = $"Error loading profiles: {ex.Message}";
				MessageBox.Show($"Failed to load profiles: {ex.Message}\n\nPlease ensure you have saved profiles first.",
					"Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void RefreshDataGridView()
		{
			// Clear existing rows
			this.profilesDataGridView.Rows.Clear();

			foreach (CitizenProfile profile in currentDisplayList)
			{
				int rowIndex = this.profilesDataGridView.Rows.Add();
				DataGridViewRow row = this.profilesDataGridView.Rows[rowIndex];

				row.Cells["FullName"].Value = profile.FullName;
				row.Cells["IDNumber"].Value = profile.IDNumber;
				row.Cells["Age"].Value = $"{profile.Age} yrs";
				row.Cells["Gender"].Value = profile.Gender;
				row.Cells["Citizenship"].Value = profile.CitizenshipStatus;
				row.Cells["Validated"].Value = profile.IsValidated ? "Valid" : "Pending";
				row.Cells["CreatedDate"].Value = profile.ProfileCreatedDate.ToString("dd MMM yyyy");

				// Color coding for validation status
				if (profile.IsValidated)
				{
					row.Cells["Validated"].Style.ForeColor = System.Drawing.Color.FromArgb(0, 128, 0);
					row.Cells["Validated"].Style.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
				}
				else
				{
					row.Cells["Validated"].Style.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
				}

				// Store profile reference in row tag
				row.Tag = profile;
			}

			// Clear selection
			selectedProfile = null;
			viewDetailsButton.Enabled = false;
			deleteProfileButton.Enabled = false;

			if (currentDisplayList.Count > 0 && this.profilesDataGridView.Rows.Count > 0)
			{
				this.profilesDataGridView.Rows[0].Selected = true;
			}
		}

		private void UpdateStatsDisplay()
		{
			if (storage.SavedProfiles.Count > 0)
			{
				int maleCount = 0;
				int femaleCount = 0;
				int citizenCount = 0;
				int totalAge = 0;

				foreach (CitizenProfile profile in storage.SavedProfiles)
				{
					if (profile.Gender == "Male") maleCount++;
					if (profile.Gender == "Female") femaleCount++;
					if (profile.CitizenshipStatus == "Citizen") citizenCount++;
					totalAge += profile.Age;
				}

				double avgAge = (double)totalAge / storage.SavedProfiles.Count;

				statsLabel.Text = $"Total: {storage.SavedProfiles.Count} | Male: {maleCount} | Female: {femaleCount} | Citizens: {citizenCount} | Avg Age: {avgAge:F1}";
			}
			else
			{
				statsLabel.Text = "No profiles in database";
			}
		}

		private void SearchTextBox_TextChanged(object sender, EventArgs e)
		{
			PerformSearch();
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			PerformSearch();
		}

		private void PerformSearch()
		{
			string searchTerm = searchTextBox.Text.Trim();

			if (string.IsNullOrWhiteSpace(searchTerm))
			{
				currentDisplayList = new List<CitizenProfile>(storage.SavedProfiles);
				resultCountLabel.Text = $"Showing {currentDisplayList.Count} profile(s)";
			}
			else
			{
				currentDisplayList = storage.SearchProfiles(searchTerm);
				resultCountLabel.Text = $"Found {currentDisplayList.Count} profile(s) matching '{searchTerm}'";
			}

			RefreshDataGridView();
			statusMessageLabel.Text = currentDisplayList.Count > 0
				? $"Search completed. {currentDisplayList.Count} profile(s) found."
				: "No profiles match your search criteria.";

			// Clear detail panel when searching
			detailRichTextBox.Text = "Select a profile from the list to view details.";
			selectedProfile = null;
			viewDetailsButton.Enabled = false;
			deleteProfileButton.Enabled = false;
		}

		private void ClearSearchButton_Click(object sender, EventArgs e)
		{
			searchTextBox.Clear();
			PerformSearch();
		}

		private void ProfilesDataGridView_SelectionChanged(object sender, EventArgs e)
		{
			if (this.profilesDataGridView.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = this.profilesDataGridView.SelectedRows[0];
				selectedProfile = selectedRow.Tag as CitizenProfile;

				if (selectedProfile != null)
				{
					viewDetailsButton.Enabled = true;
					deleteProfileButton.Enabled = true;

					// Show quick preview in detail panel
					DisplayQuickPreview(selectedProfile);
					statusMessageLabel.Text = $"Selected: {selectedProfile.FullName} (ID: {selectedProfile.IDNumber})";
				}
			}
			else
			{
				selectedProfile = null;
				viewDetailsButton.Enabled = false;
				deleteProfileButton.Enabled = false;
				detailRichTextBox.Text = "Select a profile from the list to view details.";
				statusMessageLabel.Text = "Select a profile from the list to view details.";
			}
		}

		private void DisplayQuickPreview(CitizenProfile profile)
		{
			string preview = "";
			preview += "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n";
			preview += "           PROFILE QUICK VIEW\r\n";
			preview += "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n\r\n";
			preview += $"Full Name        : {profile.FullName}\r\n";
			preview += $"ID Number        : {profile.IDNumber}\r\n";
			preview += $"Age              : {profile.Age} years\r\n";
			preview += $"Gender           : {profile.Gender}\r\n";
			preview += $"Citizenship      : {profile.CitizenshipStatus}\r\n";
			preview += $"Validation Status: {(profile.IsValidated ? "Verified" : "Pending")}\r\n";
			preview += $"Created On       : {profile.ProfileCreatedDate:dd MMM yyyy HH:mm:ss}\r\n";
			preview += $"Last Validated   : {(profile.LastValidatedDate == DateTime.MinValue ? "Never" : profile.LastValidatedDate.ToString("dd MMM yyyy HH:mm:ss"))}\r\n";

			detailRichTextBox.Text = preview;
		}

		private void ViewDetailsButton_Click(object sender, EventArgs e)
		{
			if (selectedProfile != null)
			{
				string fullDetails = selectedProfile.GetFormattedProfile();
				fullDetails += "\r\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n";
				fullDetails += $"STORAGE INFORMATION\r\n";
				fullDetails += $"Storage Location : {storage.StorageDirectory}\r\n";
				fullDetails += $"File Location    : {storage.StorageFilePath}\r\n";

				MessageBox.Show(fullDetails,
					$"Profile Details - {selectedProfile.FullName}",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		private void DeleteProfileButton_Click(object sender, EventArgs e)
		{
			if (selectedProfile == null)
			{
				MessageBox.Show("Please select a profile to delete.",
					"No Selection",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			DialogResult result = MessageBox.Show(
				$"Are you sure you want to delete the profile for:\n\n{selectedProfile.FullName}\nID: {selectedProfile.IDNumber}\n\nThis action cannot be undone.",
				"Confirm Deletion",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning);

			if (result == DialogResult.Yes)
			{
				try
				{
					string deleteMessage;
					bool success = storage.DeleteProfile(selectedProfile.IDNumber, out deleteMessage);

					if (success)
					{
						MessageBox.Show(deleteMessage,
							"Delete Successful",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information);

						// Refresh all data
						LoadAllProfiles();
						UpdateStatsDisplay();
						detailRichTextBox.Text = "Select a profile from the list to view details.";
						selectedProfile = null;
						viewDetailsButton.Enabled = false;
						deleteProfileButton.Enabled = false;
						statusMessageLabel.Text = deleteMessage;
					}
					else
					{
						MessageBox.Show(deleteMessage,
							"Delete Failed",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error deleting profile: {ex.Message}",
						"Delete Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		private void ExportAllButton_Click(object sender, EventArgs e)
		{
			if (storage.SavedProfiles.Count == 0)
			{
				MessageBox.Show("No profiles available to export.",
					"Export Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			try
			{
				SaveFileDialog saveDialog = new SaveFileDialog();
				saveDialog.Title = "Export All Profiles to CSV";
				saveDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
				saveDialog.DefaultExt = "csv";
				saveDialog.FileName = $"HomeAffairs_AllProfiles_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

				if (saveDialog.ShowDialog() == DialogResult.OK)
				{
					string exportMessage;
					bool success = storage.ExportAllToCSV(saveDialog.FileName, out exportMessage);

					if (success)
					{
						MessageBox.Show(exportMessage,
							"Export Successful",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information);
						statusMessageLabel.Text = exportMessage;
					}
					else
					{
						MessageBox.Show($"Export failed: {exportMessage}",
							"Export Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Unexpected error during export: {ex.Message}",
					"Export Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void OpenStorageButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (Directory.Exists(storage.StorageDirectory))
				{
					System.Diagnostics.Process.Start("explorer.exe", storage.StorageDirectory);
					statusMessageLabel.Text = $"Opened storage folder: {storage.StorageDirectory}";
				}
				else
				{
					MessageBox.Show($"Storage directory does not exist: {storage.StorageDirectory}",
						"Directory Not Found",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Failed to open storage folder: {ex.Message}",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void RefreshButton_Click(object sender, EventArgs e)
		{
			// Reload storage to get latest data
			storage = new CSVStorage();
			LoadAllProfiles();
			UpdateStatsDisplay();
			statusMessageLabel.Text = "Database refreshed successfully.";
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}