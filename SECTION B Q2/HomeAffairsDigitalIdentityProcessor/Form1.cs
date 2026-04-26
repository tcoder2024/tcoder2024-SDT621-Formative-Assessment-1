using System;
using System.Windows.Forms;

namespace HomeAffairsDigitalIdentityProcessor
{
	public partial class Form1 : Form
	{
		private CSVStorage storage;

		public Form1()
		{
			InitializeComponent();
			InitializeStorage();
			UpdateStatistics();
		}

		private void InitializeStorage()
		{
			try
			{
				storage = new CSVStorage();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Failed to initialize storage system: {ex.Message}",
					"Storage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				storage = null;
			}
		}

		private void UpdateStatistics()
		{
			if (storage != null)
			{
				totalProfilesLabel.Text = $"Total Profiles: {storage.SavedProfiles.Count}";
				todayProfilesLabel.Text = $"Today's Profiles: {storage.GetTodayProfilesCount()}";

				// Calculate average age
				if (storage.SavedProfiles.Count > 0)
				{
					int totalAge = 0;
					foreach (var profile in storage.SavedProfiles)
					{
						totalAge += profile.Age;
					}
					double avgAge = (double)totalAge / storage.SavedProfiles.Count;
					avgAgeLabel.Text = $"Average Age: {avgAge:F1} years";
				}
				else
				{
					avgAgeLabel.Text = "Average Age: No data yet";
				}

				storageLocationLabel.Text = $"Storage: {storage.StorageDirectory}";
			}
			else
			{
				totalProfilesLabel.Text = "Total Profiles: Storage unavailable";
				todayProfilesLabel.Text = "Today's Profiles: Storage unavailable";
				avgAgeLabel.Text = "Average Age: Storage unavailable";
				storageLocationLabel.Text = "Storage: Initialization failed";
			}


		}


		private void VisitorNameTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(visitorNameTextBox.Text))
			{
				welcomeMessage.Text = $"Welcome, {visitorNameTextBox.Text.Trim()}! Ready to process digital identities.";
				welcomeMessage.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
			}
			else
			{
				welcomeMessage.Text = "South African Identity Verification System";
				welcomeMessage.ForeColor = System.Drawing.Color.FromArgb(100, 120, 150);
			}
		}

		private void StartProcessorButton_Click(object sender, EventArgs e)
		{
			try
			{
				Form2_IdentityProcessor processor = new Form2_IdentityProcessor(storage, visitorNameTextBox.Text.Trim());
				processor.ShowDialog();

				// Refresh statistics after returning from processor
				if (storage != null)
				{
					storage = new CSVStorage();
					UpdateStatistics();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error opening Identity Processor: {ex.Message}",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ViewHistoryButton_Click(object sender, EventArgs e)
		{
			if (storage == null)
			{
				MessageBox.Show("Storage system is not available. Cannot view history.",
					"Storage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				Form3_ProfileHistory historyForm = new Form3_ProfileHistory(storage);
				historyForm.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error opening Profile History: {ex.Message}",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AboutButton_Click(object sender, EventArgs e)
		{
			try
			{
				Form4_About aboutForm = new Form4_About();
				aboutForm.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error opening About window: {ex.Message}",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(
				"Are you sure you want to exit the Home Affairs Digital Identity Processing System?",
				"Confirm Exit",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void ClockTimer_Tick(object sender, EventArgs e)
		{
			dateLabel.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
			timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
		}
	}
}