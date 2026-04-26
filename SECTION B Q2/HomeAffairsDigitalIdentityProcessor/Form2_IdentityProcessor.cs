using System;
using System.Windows.Forms;
using System.Drawing;

namespace HomeAffairsDigitalIdentityProcessor
{
    public partial class Form2_IdentityProcessor : Form
    {
        private CSVStorage storage;
        private CitizenProfile currentProfile;
        private string officerName;
        
        public Form2_IdentityProcessor(CSVStorage existingStorage, string loggedInOfficer)
        {
            InitializeComponent();
            storage = existingStorage;
            officerName = string.IsNullOrWhiteSpace(loggedInOfficer) ? "Officer" : loggedInOfficer;
            
            // Set welcome message in status
            statusMessageLabel.Text = $"Welcome, {officerName}. Ready to process digital identities.";
            
            // Setup keyboard shortcuts
            this.KeyPreview = true;
            this.KeyDown += Form2_IdentityProcessor_KeyDown;
        }
        
        // Real-time validation feedback as user types
        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fullNameTextBox.Text) && fullNameTextBox.Text.Length >= 2)
            {
                liveFeedbackLabel.Text = "✓ Name looks valid";
                liveFeedbackLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
            }
            else if (!string.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
                liveFeedbackLabel.Text = "⚠ Name must be at least 2 characters";
                liveFeedbackLabel.ForeColor = System.Drawing.Color.FromArgb(212, 175, 55);
            }
            else
            {
                liveFeedbackLabel.Text = "";
            }
        }
        
        private void IdNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            string id = idNumberTextBox.Text;
            
            if (id.Length == 13 && IsAllNumeric(id))
            {
                // Try to extract gender and age preview
                try
                {
                    string genderDigits = id.Substring(6, 4);
                    int genderCode = int.Parse(genderDigits);
                    string gender = (genderCode >= 5000) ? "Male" : "Female";
                    
                    // Calculate age preview
                    string birthPart = id.Substring(0, 6);
                    int yearTwoDigit = int.Parse(birthPart.Substring(0, 2));
                    int month = int.Parse(birthPart.Substring(2, 2));
                    int day = int.Parse(birthPart.Substring(4, 2));
                    
                    int yearFourDigit = (yearTwoDigit >= 0 && yearTwoDigit <= 24) ? 2000 + yearTwoDigit : 1900 + yearTwoDigit;
                    
                    if (IsValidDate(yearFourDigit, month, day))
                    {
                        DateTime birthDate = new DateTime(yearFourDigit, month, day);
                        int age = DateTime.Now.Year - birthDate.Year;
                        if (birthDate.Date > DateTime.Now.AddYears(-age)) age--;
                        
                        UpdateIdPreview(gender, age);
                        liveFeedbackLabel.Text = "✓ ID format valid. Ready for validation.";
                        liveFeedbackLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
                    }
                    else
                    {
                        ResetIdPreview();
                        liveFeedbackLabel.Text = "⚠ Invalid birth date in ID";
                        liveFeedbackLabel.ForeColor = System.Drawing.Color.FromArgb(212, 175, 55);
                    }
                }
                catch
                {
                    ResetIdPreview();
                    liveFeedbackLabel.Text = "⚠ Unable to parse ID";
                    liveFeedbackLabel.ForeColor = System.Drawing.Color.FromArgb(212, 175, 55);
                }
            }
            else if (id.Length > 0 && id.Length < 13)
            {
                liveFeedbackLabel.Text = $"⚠ ID must be 13 digits ({id.Length}/13)";
                liveFeedbackLabel.ForeColor = System.Drawing.Color.FromArgb(212, 175, 55);
                ResetIdPreview();
            }
            else
            {
                liveFeedbackLabel.Text = "";
                ResetIdPreview();
            }
        }
        
        private void CitizenshipComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            liveFeedbackLabel.Text = $"Citizenship set to: {citizenshipComboBox.SelectedItem}";
            liveFeedbackLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
        }
        
        // VALIDATE ID BUTTON
        private void ValidateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear any previous validation styling
                ResetValidationIndicator();
                
                // Validate inputs before creating profile
                string name = fullNameTextBox.Text.Trim();
                string idNumber = idNumberTextBox.Text.Trim();
                string citizenship = citizenshipComboBox.SelectedItem?.ToString();
                
                if (string.IsNullOrWhiteSpace(name))
                {
                    ShowValidationResult(false, "Full name is required");
                    fullNameTextBox.Focus();
                    return;
                }
                
                if (name.Length < 2)
                {
                    ShowValidationResult(false, "Name must be at least 2 characters");
                    fullNameTextBox.Focus();
                    return;
                }
                
                if (string.IsNullOrWhiteSpace(idNumber))
                {
                    ShowValidationResult(false, "ID number is required");
                    idNumberTextBox.Focus();
                    return;
                }
                
                if (idNumber.Length != 13)
                {
                    ShowValidationResult(false, "ID number must be exactly 13 digits");
                    idNumberTextBox.Focus();
                    return;
                }
                
                if (!IsAllNumeric(idNumber))
                {
                    ShowValidationResult(false, "ID number must contain only digits");
                    idNumberTextBox.Focus();
                    return;
                }
                
                if (string.IsNullOrWhiteSpace(citizenship))
                {
                    ShowValidationResult(false, "Please select citizenship status");
                    citizenshipComboBox.Focus();
                    return;
                }
                
                // Create profile and validate
                currentProfile = new CitizenProfile(name, idNumber, citizenship);
                string validationResult = currentProfile.ValidateID();
                
                if (currentProfile.IsValidated)
                {
                    ShowValidationResult(true, validationResult);
                    
                    // Update the ID info preview with accurate data
                    UpdateIdPreview(currentProfile.Gender, currentProfile.Age);
                    
                    // Enable generate button visually
                    generateProfileButton.BackColor = System.Drawing.Color.FromArgb(26, 42, 79);
                    statusMessageLabel.Text = "Validation successful. Click 'Generate Profile' to continue.";
                }
                else
                {
                    ShowValidationResult(false, validationResult);
                    currentProfile = null;
                    generateProfileButton.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
                    statusMessageLabel.Text = "Validation failed. Please correct the ID number.";
                }
            }
            catch (Exception ex)
            {
                ShowValidationResult(false, $"Validation error: {ex.Message}");
                currentProfile = null;
            }
        }
        
        // GENERATE PROFILE BUTTON
        private void GenerateProfileButton_Click(object sender, EventArgs e)
        {
            if (currentProfile == null || !currentProfile.IsValidated)
            {
                MessageBox.Show("Please validate the ID number first before generating a profile.",
                    "Validation Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                string profileOutput = currentProfile.GetFormattedProfile();
                outputRichTextBox.Text = profileOutput;
                
                string timestamp = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");
                generatedTimestampLabel.Text = $"Profile generated on: {timestamp} by {officerName}";
                
                // Enable save and export buttons
                saveProfileButton.Enabled = true;
                exportButton.Enabled = true;
                saveProfileButton.BackColor = System.Drawing.Color.FromArgb(212, 175, 55);
                exportButton.BackColor = System.Drawing.Color.FromArgb(60, 70, 90);
                
                statusMessageLabel.Text = "Profile generated successfully. You can now save or export.";
                liveFeedbackLabel.Text = "✓ Profile ready for saving";
                liveFeedbackLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate profile: {ex.Message}",
                    "Generation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        // CLEAR FORM BUTTON
        private void ClearFormButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all form data? Unsaved changes will be lost.",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                fullNameTextBox.Clear();
                idNumberTextBox.Clear();
                citizenshipComboBox.SelectedIndex = 0;
                outputRichTextBox.Clear();
                generatedTimestampLabel.Text = "Awaiting profile generation";
                statusMessageLabel.Text = "Form cleared. Ready for new entry.";
                liveFeedbackLabel.Text = "";
                
                currentProfile = null;
                saveProfileButton.Enabled = false;
                exportButton.Enabled = false;
                saveProfileButton.BackColor = System.Drawing.Color.FromArgb(200, 180, 100);
                exportButton.BackColor = System.Drawing.Color.FromArgb(100, 110, 130);
                generateProfileButton.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
                
                ResetValidationIndicator();
                ResetIdPreview();
                
                fullNameTextBox.Focus();
            }
        }
        
        // SAVE PROFILE BUTTON
        private void SaveProfileButton_Click(object sender, EventArgs e)
        {
            if (currentProfile == null || !currentProfile.IsValidated)
            {
                MessageBox.Show("No valid profile to save. Please validate and generate a profile first.",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                string saveMessage;
                bool success = storage.SaveProfile(currentProfile, out saveMessage);
                
                if (success)
                {
                    MessageBox.Show(saveMessage,
                        "Profile Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    
                    statusMessageLabel.Text = saveMessage;
                    
                    // Add a note to the output that it was saved
                    outputRichTextBox.Text += $"\n\n[SAVED] Profile stored on {DateTime.Now:dd MMM yyyy HH:mm:ss}";
                }
                else
                {
                    MessageBox.Show($"Failed to save: {saveMessage}",
                        "Save Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error while saving: {ex.Message}",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        // EXPORT TO CSV BUTTON
        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (storage.SavedProfiles.Count == 0 && currentProfile == null)
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
                saveDialog.Title = "Export Profiles to CSV";
                saveDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                saveDialog.DefaultExt = "csv";
                saveDialog.FileName = $"HomeAffairs_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                
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
        
        // BACK BUTTON
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // HELPER METHODS
        private bool IsAllNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        
        private bool IsValidDate(int year, int month, int day)
        {
            if (month < 1 || month > 12) return false;
            if (day < 1 || day > 31) return false;
            
            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            
            if (isLeapYear && month == 2)
                return day <= 29;
            
            return day <= daysInMonth[month - 1];
        }
        
        private void ShowValidationResult(bool isValid, string message)
        {
            if (isValid)
            {
                validationIndicatorPanel.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
                validationIndicatorText.Text = $"✓ {message}";
                validationIndicatorText.ForeColor = System.Drawing.Color.FromArgb(0, 100, 0);
                validationIndicatorPanel.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                validationIndicatorPanel.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
                validationIndicatorText.Text = $"✗ {message}";
                validationIndicatorText.ForeColor = System.Drawing.Color.FromArgb(180, 0, 0);
                validationIndicatorPanel.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        
        private void ResetValidationIndicator()
        {
            validationIndicatorPanel.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);
            validationIndicatorText.Text = "⚡ Awaiting validation";
            validationIndicatorText.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
        }

		// Keyboard shortcuts
		private void Form2_IdentityProcessor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.V)
			{
				ValidateButton_Click(sender, e);
				e.SuppressKeyPress = true;
			}
			else if (e.Control && e.KeyCode == Keys.G)
			{
				GenerateProfileButton_Click(sender, e);
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.F5)
			{
				ClearFormButton_Click(sender, e);
				e.SuppressKeyPress = true;
			}
			else if (e.Control && e.KeyCode == Keys.S)
			{
				if (saveProfileButton.Enabled)
					SaveProfileButton_Click(sender, e);
				e.SuppressKeyPress = true;
			}
		}
	}
}