namespace HomeAffairsDigitalIdentityProcessor
{
	partial class Form2_IdentityProcessor
	{
		private System.ComponentModel.IContainer components = null;

		// Main layout containers
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label formSubtitleLabel;
		private System.Windows.Forms.Button backButton;

		private System.Windows.Forms.Panel mainSplitContainer;
		private System.Windows.Forms.Panel leftInputPanel;
		private System.Windows.Forms.Panel rightOutputPanel;
		private System.Windows.Forms.Panel bottomActionPanel;
		private System.Windows.Forms.Panel statusPanel;

		// Left Panel - Input Controls
		private System.Windows.Forms.Label fullNameLabel;
		private System.Windows.Forms.TextBox fullNameTextBox;
		private System.Windows.Forms.Label idNumberLabel;
		private System.Windows.Forms.TextBox idNumberTextBox;
		private System.Windows.Forms.Label citizenshipLabel;
		private System.Windows.Forms.ComboBox citizenshipComboBox;
		private System.Windows.Forms.Label validationStatusLabel;
		private System.Windows.Forms.Panel validationIndicatorPanel;
		private System.Windows.Forms.Label validationIndicatorText;
		private System.Windows.Forms.GroupBox idInfoGroup;
		private System.Windows.Forms.Label genderPreviewLabel;
		private System.Windows.Forms.Label agePreviewLabel;

		// Right Panel - Output Display
		private System.Windows.Forms.Label outputTitleLabel;
		private System.Windows.Forms.RichTextBox outputRichTextBox;
		private System.Windows.Forms.Label generatedTimestampLabel;

		// Bottom Panel - Action Buttons
		private System.Windows.Forms.Button validateButton;
		private System.Windows.Forms.Button generateProfileButton;
		private System.Windows.Forms.Button clearFormButton;
		private System.Windows.Forms.Button saveProfileButton;
		private System.Windows.Forms.Button exportButton;

		// Status Bar
		private System.Windows.Forms.Label statusMessageLabel;
		private System.Windows.Forms.Label liveFeedbackLabel;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();

			// FORM SETTINGS - FULL SCREEN
			this.Text = "Home Affairs Digital Identity Processor - Application Form";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
			this.MinimumSize = new System.Drawing.Size(1280, 800);

			// HEADER PANEL - Fixed height, full width
			this.headerPanel = new System.Windows.Forms.Panel();
			this.headerPanel.BackColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Height = 90;
			this.headerPanel.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);

			this.titleLabel = new System.Windows.Forms.Label();
			this.titleLabel.Text = "DIGITAL IDENTITY PROCESSOR";
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
			this.titleLabel.ForeColor = System.Drawing.Color.White;
			this.titleLabel.AutoSize = true;
			this.titleLabel.Location = new System.Drawing.Point(25, 15);

			this.formSubtitleLabel = new System.Windows.Forms.Label();
			this.formSubtitleLabel.Text = "South African Identity Validation & Profile Generation";
			this.formSubtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
			this.formSubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
			this.formSubtitleLabel.AutoSize = true;
			this.formSubtitleLabel.Location = new System.Drawing.Point(27, 48);

			this.backButton = new System.Windows.Forms.Button();
			this.backButton.Text = "← BACK TO DASHBOARD";
			this.backButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.backButton.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
			this.backButton.ForeColor = System.Drawing.Color.White;
			this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.backButton.FlatAppearance.BorderSize = 0;
			this.backButton.Size = new System.Drawing.Size(200, 45);
			this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.backButton.Location = new System.Drawing.Point(0, 22);
			this.backButton.Click += new System.EventHandler(this.BackButton_Click);

			this.headerPanel.Controls.Add(this.titleLabel);
			this.headerPanel.Controls.Add(this.formSubtitleLabel);
			this.headerPanel.Controls.Add(this.backButton);

			// MAIN CONTENT AREA - Fill remaining space
			this.mainSplitContainer = new System.Windows.Forms.Panel();
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);

			// LEFT INPUT PANEL - 45% width
			this.leftInputPanel = new System.Windows.Forms.Panel();
			this.leftInputPanel.BackColor = System.Drawing.Color.White;
			this.leftInputPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;
			this.leftInputPanel.Padding = new System.Windows.Forms.Padding(25);

			// Full Name
			this.fullNameLabel = new System.Windows.Forms.Label();
			this.fullNameLabel.Text = "FULL NAME";
			this.fullNameLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.fullNameLabel.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.fullNameLabel.Location = new System.Drawing.Point(25, 30);
			this.fullNameLabel.Size = new System.Drawing.Size(400, 22);

			this.fullNameTextBox = new System.Windows.Forms.TextBox();
			this.fullNameTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
			this.fullNameTextBox.Location = new System.Drawing.Point(25, 55);
			this.fullNameTextBox.Size = new System.Drawing.Size(400, 27);
			this.fullNameTextBox.PlaceholderText = "Enter full name as per ID document";
			this.fullNameTextBox.TextChanged += new System.EventHandler(this.FullNameTextBox_TextChanged);

			// ID Number
			this.idNumberLabel = new System.Windows.Forms.Label();
			this.idNumberLabel.Text = "ID NUMBER (13 DIGITS)";
			this.idNumberLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.idNumberLabel.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.idNumberLabel.Location = new System.Drawing.Point(25, 105);
			this.idNumberLabel.Size = new System.Drawing.Size(400, 22);

			this.idNumberTextBox = new System.Windows.Forms.TextBox();
			this.idNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
			this.idNumberTextBox.Location = new System.Drawing.Point(25, 130);
			this.idNumberTextBox.Size = new System.Drawing.Size(400, 27);
			this.idNumberTextBox.PlaceholderText = "Enter 13-digit South African ID number";
			this.idNumberTextBox.MaxLength = 13;
			this.idNumberTextBox.TextChanged += new System.EventHandler(this.IdNumberTextBox_TextChanged);

			// Citizenship Status
			this.citizenshipLabel = new System.Windows.Forms.Label();
			this.citizenshipLabel.Text = "CITIZENSHIP STATUS";
			this.citizenshipLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.citizenshipLabel.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.citizenshipLabel.Location = new System.Drawing.Point(25, 180);
			this.citizenshipLabel.Size = new System.Drawing.Size(400, 22);

			this.citizenshipComboBox = new System.Windows.Forms.ComboBox();
			this.citizenshipComboBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
			this.citizenshipComboBox.Location = new System.Drawing.Point(25, 205);
			this.citizenshipComboBox.Size = new System.Drawing.Size(400, 28);
			this.citizenshipComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.citizenshipComboBox.Items.AddRange(new object[] {
				"Citizen",
				"Permanent Resident",
				"Visitor"
			});
			this.citizenshipComboBox.SelectedIndex = 0;
			this.citizenshipComboBox.SelectedIndexChanged += new System.EventHandler(this.CitizenshipComboBox_SelectedIndexChanged);

			// Validation Status Panel
			this.validationStatusLabel = new System.Windows.Forms.Label();
			this.validationStatusLabel.Text = "VALIDATION STATUS";
			this.validationStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.validationStatusLabel.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.validationStatusLabel.Location = new System.Drawing.Point(25, 255);
			this.validationStatusLabel.Size = new System.Drawing.Size(400, 22);

			this.validationIndicatorPanel = new System.Windows.Forms.Panel();
			this.validationIndicatorPanel.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);
			this.validationIndicatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.validationIndicatorPanel.Location = new System.Drawing.Point(25, 280);
			this.validationIndicatorPanel.Size = new System.Drawing.Size(400, 55);

			this.validationIndicatorText = new System.Windows.Forms.Label();
			this.validationIndicatorText.Text = "Awaiting validation";
			this.validationIndicatorText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.validationIndicatorText.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
			this.validationIndicatorText.Location = new System.Drawing.Point(12, 18);
			this.validationIndicatorText.Size = new System.Drawing.Size(375, 25);
			this.validationIndicatorText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

			this.validationIndicatorPanel.Controls.Add(this.validationIndicatorText);

			// ID Information Group Box
			this.idInfoGroup = new System.Windows.Forms.GroupBox();
			this.idInfoGroup.Text = "ID INFORMATION PREVIEW";
			this.idInfoGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.idInfoGroup.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.idInfoGroup.Location = new System.Drawing.Point(25, 355);
			this.idInfoGroup.Size = new System.Drawing.Size(400, 110);

			this.genderPreviewLabel = new System.Windows.Forms.Label();
			this.genderPreviewLabel.Text = "Gender: Not yet entered";
			this.genderPreviewLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.genderPreviewLabel.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
			this.genderPreviewLabel.Location = new System.Drawing.Point(15, 35);
			this.genderPreviewLabel.Size = new System.Drawing.Size(370, 25);

			this.agePreviewLabel = new System.Windows.Forms.Label();
			this.agePreviewLabel.Text = "Age: Not yet calculated";
			this.agePreviewLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.agePreviewLabel.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
			this.agePreviewLabel.Location = new System.Drawing.Point(15, 65);
			this.agePreviewLabel.Size = new System.Drawing.Size(370, 25);

			this.idInfoGroup.Controls.Add(this.genderPreviewLabel);
			this.idInfoGroup.Controls.Add(this.agePreviewLabel);

			// Add all to left panel
			this.leftInputPanel.Controls.Add(this.fullNameLabel);
			this.leftInputPanel.Controls.Add(this.fullNameTextBox);
			this.leftInputPanel.Controls.Add(this.idNumberLabel);
			this.leftInputPanel.Controls.Add(this.idNumberTextBox);
			this.leftInputPanel.Controls.Add(this.citizenshipLabel);
			this.leftInputPanel.Controls.Add(this.citizenshipComboBox);
			this.leftInputPanel.Controls.Add(this.validationStatusLabel);
			this.leftInputPanel.Controls.Add(this.validationIndicatorPanel);
			this.leftInputPanel.Controls.Add(this.idInfoGroup);

			// RIGHT OUTPUT PANEL - 50% width
			this.rightOutputPanel = new System.Windows.Forms.Panel();
			this.rightOutputPanel.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			this.rightOutputPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
			this.rightOutputPanel.Padding = new System.Windows.Forms.Padding(20);

			this.outputTitleLabel = new System.Windows.Forms.Label();
			this.outputTitleLabel.Text = "PROFILE OUTPUT";
			this.outputTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.outputTitleLabel.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.outputTitleLabel.Location = new System.Drawing.Point(20, 20);
			this.outputTitleLabel.Size = new System.Drawing.Size(500, 25);

			this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
			this.outputRichTextBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular);
			this.outputRichTextBox.BackColor = System.Drawing.Color.FromArgb(252, 253, 254);
			this.outputRichTextBox.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
			this.outputRichTextBox.Location = new System.Drawing.Point(20, 55);
			this.outputRichTextBox.Size = new System.Drawing.Size(500, 350);
			this.outputRichTextBox.ReadOnly = true;
			this.outputRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

			this.generatedTimestampLabel = new System.Windows.Forms.Label();
			this.generatedTimestampLabel.Text = "Awaiting profile generation";
			this.generatedTimestampLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
			this.generatedTimestampLabel.ForeColor = System.Drawing.Color.FromArgb(120, 130, 160);
			this.generatedTimestampLabel.Location = new System.Drawing.Point(20, 420);
			this.generatedTimestampLabel.Size = new System.Drawing.Size(500, 20);
			this.generatedTimestampLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

			this.rightOutputPanel.Controls.Add(this.outputTitleLabel);
			this.rightOutputPanel.Controls.Add(this.outputRichTextBox);
			this.rightOutputPanel.Controls.Add(this.generatedTimestampLabel);

			// BOTTOM ACTION PANEL - Fixed height, full width
			this.bottomActionPanel = new System.Windows.Forms.Panel();
			this.bottomActionPanel.BackColor = System.Drawing.Color.White;
			this.bottomActionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bottomActionPanel.Height = 80;
			this.bottomActionPanel.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);

			// Validate Button
			this.validateButton = new System.Windows.Forms.Button();
			this.validateButton.Text = "VALIDATE ID";
			this.validateButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.validateButton.BackColor = System.Drawing.Color.FromArgb(0, 128, 128);
			this.validateButton.ForeColor = System.Drawing.Color.White;
			this.validateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.validateButton.FlatAppearance.BorderSize = 0;
			this.validateButton.Size = new System.Drawing.Size(170, 50);
			this.validateButton.Location = new System.Drawing.Point(25, 15);
			this.validateButton.Click += new System.EventHandler(this.ValidateButton_Click);

			// Generate Profile Button
			this.generateProfileButton = new System.Windows.Forms.Button();
			this.generateProfileButton.Text = "GENERATE PROFILE";
			this.generateProfileButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.generateProfileButton.BackColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.generateProfileButton.ForeColor = System.Drawing.Color.White;
			this.generateProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.generateProfileButton.FlatAppearance.BorderSize = 0;
			this.generateProfileButton.Size = new System.Drawing.Size(190, 50);
			this.generateProfileButton.Location = new System.Drawing.Point(210, 15);
			this.generateProfileButton.Click += new System.EventHandler(this.GenerateProfileButton_Click);

			// Clear Form Button
			this.clearFormButton = new System.Windows.Forms.Button();
			this.clearFormButton.Text = "CLEAR FORM";
			this.clearFormButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.clearFormButton.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
			this.clearFormButton.ForeColor = System.Drawing.Color.White;
			this.clearFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.clearFormButton.FlatAppearance.BorderSize = 0;
			this.clearFormButton.Size = new System.Drawing.Size(160, 50);
			this.clearFormButton.Location = new System.Drawing.Point(415, 15);
			this.clearFormButton.Click += new System.EventHandler(this.ClearFormButton_Click);

			// Save Profile Button
			this.saveProfileButton = new System.Windows.Forms.Button();
			this.saveProfileButton.Text = "SAVE PROFILE";
			this.saveProfileButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.saveProfileButton.BackColor = System.Drawing.Color.FromArgb(212, 175, 55);
			this.saveProfileButton.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.saveProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.saveProfileButton.FlatAppearance.BorderSize = 0;
			this.saveProfileButton.Size = new System.Drawing.Size(170, 50);
			this.saveProfileButton.Location = new System.Drawing.Point(590, 15);
			this.saveProfileButton.Enabled = false;
			this.saveProfileButton.Click += new System.EventHandler(this.SaveProfileButton_Click);

			// Export Button
			this.exportButton = new System.Windows.Forms.Button();
			this.exportButton.Text = "EXPORT TO CSV";
			this.exportButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.exportButton.BackColor = System.Drawing.Color.FromArgb(60, 70, 90);
			this.exportButton.ForeColor = System.Drawing.Color.White;
			this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.exportButton.FlatAppearance.BorderSize = 0;
			this.exportButton.Size = new System.Drawing.Size(170, 50);
			this.exportButton.Location = new System.Drawing.Point(775, 15);
			this.exportButton.Enabled = false;
			this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);

			this.bottomActionPanel.Controls.Add(this.validateButton);
			this.bottomActionPanel.Controls.Add(this.generateProfileButton);
			this.bottomActionPanel.Controls.Add(this.clearFormButton);
			this.bottomActionPanel.Controls.Add(this.saveProfileButton);
			this.bottomActionPanel.Controls.Add(this.exportButton);

			// STATUS PANEL - Bottom fixed
			this.statusPanel = new System.Windows.Forms.Panel();
			this.statusPanel.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
			this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.statusPanel.Height = 40;

			this.statusMessageLabel = new System.Windows.Forms.Label();
			this.statusMessageLabel.Text = "Ready. Enter applicant details to begin.";
			this.statusMessageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.statusMessageLabel.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
			this.statusMessageLabel.Location = new System.Drawing.Point(25, 10);
			this.statusMessageLabel.Size = new System.Drawing.Size(600, 25);

			this.liveFeedbackLabel = new System.Windows.Forms.Label();
			this.liveFeedbackLabel.Text = "";
			this.liveFeedbackLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
			this.liveFeedbackLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
			this.liveFeedbackLabel.Location = new System.Drawing.Point(650, 10);
			this.liveFeedbackLabel.Size = new System.Drawing.Size(500, 25);
			this.liveFeedbackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

			this.statusPanel.Controls.Add(this.statusMessageLabel);
			this.statusPanel.Controls.Add(this.liveFeedbackLabel);

			// Position back button to right
			this.backButton.Left = this.ClientSize.Width - 240;
			this.headerPanel.Resize += (s, e) => {
				this.backButton.Left = this.headerPanel.Width - 240;
			};

			// Position left and right panels based on form size
			this.mainSplitContainer.Resize += (s, e) => {
				int availableWidth = this.mainSplitContainer.ClientSize.Width - 50;
				this.leftInputPanel.Width = (int)(availableWidth * 0.42);
				this.leftInputPanel.Height = this.mainSplitContainer.ClientSize.Height - 30;
				this.rightOutputPanel.Left = this.leftInputPanel.Width + 40;
				this.rightOutputPanel.Width = (int)(availableWidth * 0.52);
				this.rightOutputPanel.Height = this.mainSplitContainer.ClientSize.Height - 30;
			};

			// Add panels to main container
			this.mainSplitContainer.Controls.Add(this.leftInputPanel);
			this.mainSplitContainer.Controls.Add(this.rightOutputPanel);

			// Add all to form
			this.Controls.Add(this.mainSplitContainer);
			this.Controls.Add(this.headerPanel);
			this.Controls.Add(this.bottomActionPanel);
			this.Controls.Add(this.statusPanel);

			// Initialize with default sizes
			this.mainSplitContainer.Resize += (s, e) => { };
			this.Shown += (s, e) => {
				int availableWidth = this.mainSplitContainer.ClientSize.Width - 50;
				this.leftInputPanel.Width = (int)(availableWidth * 0.42);
				this.leftInputPanel.Height = this.mainSplitContainer.ClientSize.Height - 30;
				this.rightOutputPanel.Left = this.leftInputPanel.Width + 40;
				this.rightOutputPanel.Width = (int)(availableWidth * 0.52);
				this.rightOutputPanel.Height = this.mainSplitContainer.ClientSize.Height - 30;
			};
		}

		// Public methods for updating preview (called from Form2.cs)
		public void UpdateIdPreview(string gender, int age)
		{
			if (genderPreviewLabel != null)
			{
				genderPreviewLabel.Text = $"Gender: {gender}";
				genderPreviewLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
			}
			if (agePreviewLabel != null)
			{
				agePreviewLabel.Text = $"Age: {age} years";
				agePreviewLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
			}
		}

		public void ResetIdPreview()
		{
			if (genderPreviewLabel != null)
			{
				genderPreviewLabel.Text = "Gender: Not yet entered";
				genderPreviewLabel.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
			}
			if (agePreviewLabel != null)
			{
				agePreviewLabel.Text = "Age: Not yet calculated";
				agePreviewLabel.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
			}
		}
	}
}