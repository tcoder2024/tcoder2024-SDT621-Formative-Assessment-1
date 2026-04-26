namespace HomeAffairsDigitalIdentityProcessor
{
	partial class Form4_About
	{
		private System.ComponentModel.IContainer components = null;

		// Form controls
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Button closeButton;

		private System.Windows.Forms.Panel contentPanel;
		private System.Windows.Forms.Label appTitleLabel;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Label deptLabel;
		private System.Windows.Forms.Panel logoPanel;
		private System.Windows.Forms.Label logoLabel;

		private System.Windows.Forms.GroupBox idGuideGroup;
		private System.Windows.Forms.Label idGuideTitle;
		private System.Windows.Forms.Label idFormatLabel;
		private System.Windows.Forms.Label idExampleLabel;
		private System.Windows.Forms.Label digitBreakdownLabel;

		private System.Windows.Forms.GroupBox featuresGroup;
		private System.Windows.Forms.Label featuresListLabel;

		private System.Windows.Forms.GroupBox shortcutsGroup;
		private System.Windows.Forms.Label shortcutsListLabel;

		private System.Windows.Forms.GroupBox creditsGroup;
		private System.Windows.Forms.Label creditsLabel;

		private System.Windows.Forms.Label footerLabel;
		private System.Windows.Forms.Label systemInfoLabel;

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
			// Form settings
			this.Text = "Home Affairs Digital Identity Processor - About & Help";
			this.Size = new System.Drawing.Size(650, 700);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

			// HEADER PANEL
			this.headerPanel = new System.Windows.Forms.Panel();
			this.headerPanel.BackColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Height = 70;
			this.headerPanel.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);

			this.titleLabel = new System.Windows.Forms.Label();
			this.titleLabel.Text = "ABOUT & HELP";
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
			this.titleLabel.ForeColor = System.Drawing.Color.White;
			this.titleLabel.Location = new System.Drawing.Point(20, 18);
			this.titleLabel.Size = new System.Drawing.Size(350, 35);

			this.closeButton = new System.Windows.Forms.Button();
			this.closeButton.Text = "CLOSE";
			this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.closeButton.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
			this.closeButton.ForeColor = System.Drawing.Color.White;
			this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.closeButton.FlatAppearance.BorderSize = 0;
			this.closeButton.Size = new System.Drawing.Size(100, 35);
			this.closeButton.Location = new System.Drawing.Point(510, 18);
			this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

			this.headerPanel.Controls.Add(this.titleLabel);
			this.headerPanel.Controls.Add(this.closeButton);

			// CONTENT PANEL
			this.contentPanel = new System.Windows.Forms.Panel();
			this.contentPanel.BackColor = System.Drawing.Color.Transparent;
			this.contentPanel.AutoScroll = true;
			this.contentPanel.Location = new System.Drawing.Point(15, 85);
			this.contentPanel.Size = new System.Drawing.Size(620, 570);
			this.contentPanel.Padding = new System.Windows.Forms.Padding(10);

			// App Title Section
			this.appTitleLabel = new System.Windows.Forms.Label();
			this.appTitleLabel.Text = "DIGITAL IDENTITY PROCESSOR";
			this.appTitleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
			this.appTitleLabel.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.appTitleLabel.Location = new System.Drawing.Point(10, 10);
			this.appTitleLabel.Size = new System.Drawing.Size(580, 35);
			this.appTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			this.versionLabel = new System.Windows.Forms.Label();
			this.versionLabel.Text = "Version 1.0.0 | Build 2026.04.26";
			this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
			this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(100, 120, 150);
			this.versionLabel.Location = new System.Drawing.Point(10, 48);
			this.versionLabel.Size = new System.Drawing.Size(580, 22);
			this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			this.deptLabel = new System.Windows.Forms.Label();
			this.deptLabel.Text = "Department of Home Affairs - South Africa";
			this.deptLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.deptLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
			this.deptLabel.Location = new System.Drawing.Point(10, 72);
			this.deptLabel.Size = new System.Drawing.Size(580, 22);
			this.deptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			// Logo/Decorative Panel
			this.logoPanel = new System.Windows.Forms.Panel();
			this.logoPanel.BackColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.logoPanel.Location = new System.Drawing.Point(230, 105);
			this.logoPanel.Size = new System.Drawing.Size(140, 50);

			this.logoLabel = new System.Windows.Forms.Label();
			this.logoLabel.Text = "HOME AFFAIRS";
			this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.logoLabel.ForeColor = System.Drawing.Color.FromArgb(0, 200, 200);
			this.logoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.logoLabel.Dock = System.Windows.Forms.DockStyle.Fill;

			this.logoPanel.Controls.Add(this.logoLabel);

			// ID NUMBER GUIDE GROUP
			this.idGuideGroup = new System.Windows.Forms.GroupBox();
			this.idGuideGroup.Text = "SOUTH AFRICAN ID NUMBER FORMAT";
			this.idGuideGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.idGuideGroup.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.idGuideGroup.Location = new System.Drawing.Point(10, 170);
			this.idGuideGroup.Size = new System.Drawing.Size(580, 150);

			this.idFormatLabel = new System.Windows.Forms.Label();
			this.idFormatLabel.Text = "Format: YYMMDD GGGG S C A Z (13 digits)";
			this.idFormatLabel.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
			this.idFormatLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
			this.idFormatLabel.Location = new System.Drawing.Point(15, 28);
			this.idFormatLabel.Size = new System.Drawing.Size(550, 22);

			this.idExampleLabel = new System.Windows.Forms.Label();
			this.idExampleLabel.Text = "Example: 800101 5082 0 8 0 8";
			this.idExampleLabel.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular);
			this.idExampleLabel.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
			this.idExampleLabel.Location = new System.Drawing.Point(15, 52);
			this.idExampleLabel.Size = new System.Drawing.Size(550, 22);

			this.digitBreakdownLabel = new System.Windows.Forms.Label();
			this.digitBreakdownLabel.Text =
				"Digit 1-6   : Birth date (YYMMDD)\n" +
				"Digit 7-10  : Gender (0000-4999 = Female, 5000-9999 = Male)\n" +
				"Digit 11    : Citizenship (0 = SA Citizen, 1 = Permanent Resident)\n" +
				"Digit 12-13 : Checksum (for validation purposes)";
			this.digitBreakdownLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.digitBreakdownLabel.ForeColor = System.Drawing.Color.FromArgb(60, 70, 90);
			this.digitBreakdownLabel.Location = new System.Drawing.Point(15, 80);
			this.digitBreakdownLabel.Size = new System.Drawing.Size(550, 60);

			this.idGuideGroup.Controls.Add(this.idFormatLabel);
			this.idGuideGroup.Controls.Add(this.idExampleLabel);
			this.idGuideGroup.Controls.Add(this.digitBreakdownLabel);

			// FEATURES GROUP
			this.featuresGroup = new System.Windows.Forms.GroupBox();
			this.featuresGroup.Text = "SYSTEM FEATURES";
			this.featuresGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.featuresGroup.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.featuresGroup.Location = new System.Drawing.Point(10, 335);
			this.featuresGroup.Size = new System.Drawing.Size(280, 180);

			this.featuresListLabel = new System.Windows.Forms.Label();
			this.featuresListLabel.Text =
				"• SA ID Number Validation\n" +
				"• Automatic Age Calculation\n" +
				"• Gender Extraction from ID\n" +
				"• Citizenship Status Selection\n" +
				"• Real-time Validation Feedback\n" +
				"• Profile Generation & Storage\n" +
				"• CSV Export (Excel Compatible)\n" +
				"• Search & Filter Functionality\n" +
				"• Data Persistence with Backup";
			this.featuresListLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.featuresListLabel.ForeColor = System.Drawing.Color.FromArgb(60, 70, 90);
			this.featuresListLabel.Location = new System.Drawing.Point(15, 28);
			this.featuresListLabel.Size = new System.Drawing.Size(250, 140);

			this.featuresGroup.Controls.Add(this.featuresListLabel);

			// KEYBOARD SHORTCUTS GROUP
			this.shortcutsGroup = new System.Windows.Forms.GroupBox();
			this.shortcutsGroup.Text = "KEYBOARD SHORTCUTS";
			this.shortcutsGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.shortcutsGroup.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.shortcutsGroup.Location = new System.Drawing.Point(310, 335);
			this.shortcutsGroup.Size = new System.Drawing.Size(280, 180);

			this.shortcutsListLabel = new System.Windows.Forms.Label();
			this.shortcutsListLabel.Text =
				"Ctrl + V     : Validate ID\n" +
				"Ctrl + G     : Generate Profile\n" +
				"Ctrl + S     : Save Profile\n" +
				"F5           : Clear Form\n" +
				"Enter        : Quick Add (in processor)\n" +
				"ESC          : Close dialog / Back";
			this.shortcutsListLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular);
			this.shortcutsListLabel.ForeColor = System.Drawing.Color.FromArgb(60, 70, 90);
			this.shortcutsListLabel.Location = new System.Drawing.Point(15, 28);
			this.shortcutsListLabel.Size = new System.Drawing.Size(250, 140);

			this.shortcutsGroup.Controls.Add(this.shortcutsListLabel);

			// CREDITS GROUP
			this.creditsGroup = new System.Windows.Forms.GroupBox();
			this.creditsGroup.Text = "DEVELOPMENT CREDITS";
			this.creditsGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.creditsGroup.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.creditsGroup.Location = new System.Drawing.Point(10, 530);
			this.creditsGroup.Size = new System.Drawing.Size(580, 100);

			this.creditsLabel = new System.Windows.Forms.Label();
			this.creditsLabel.Text =
				"Application: Home Affairs Digital Identity Processor\n" +
				"Course: SDT621 - Formative Assessment\n" +
				"Developer: Software Engineering Student\n" +
				"Academic Year: 2026\n" +
				"Architecture: Windows Forms .NET Framework";
			this.creditsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.creditsLabel.ForeColor = System.Drawing.Color.FromArgb(60, 70, 90);
			this.creditsLabel.Location = new System.Drawing.Point(15, 28);
			this.creditsLabel.Size = new System.Drawing.Size(550, 60);

			this.creditsGroup.Controls.Add(this.creditsLabel);

			// FOOTER
			this.footerLabel = new System.Windows.Forms.Label();
			this.footerLabel.Text = "This system complies with South African identity verification standards.";
			this.footerLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
			this.footerLabel.ForeColor = System.Drawing.Color.FromArgb(120, 130, 160);
			this.footerLabel.Location = new System.Drawing.Point(10, 640);
			this.footerLabel.Size = new System.Drawing.Size(580, 20);
			this.footerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			this.systemInfoLabel = new System.Windows.Forms.Label();
			this.systemInfoLabel.Text = $"System Date: {DateTime.Now:dd MMM yyyy HH:mm:ss}";
			this.systemInfoLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
			this.systemInfoLabel.ForeColor = System.Drawing.Color.FromArgb(150, 160, 180);
			this.systemInfoLabel.Location = new System.Drawing.Point(10, 660);
			this.systemInfoLabel.Size = new System.Drawing.Size(580, 20);
			this.systemInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			// Add all controls to content panel
			this.contentPanel.Controls.Add(this.appTitleLabel);
			this.contentPanel.Controls.Add(this.versionLabel);
			this.contentPanel.Controls.Add(this.deptLabel);
			this.contentPanel.Controls.Add(this.logoPanel);
			this.contentPanel.Controls.Add(this.idGuideGroup);
			this.contentPanel.Controls.Add(this.featuresGroup);
			this.contentPanel.Controls.Add(this.shortcutsGroup);
			this.contentPanel.Controls.Add(this.creditsGroup);
			this.contentPanel.Controls.Add(this.footerLabel);
			this.contentPanel.Controls.Add(this.systemInfoLabel);

			// Add to form
			this.Controls.Add(this.headerPanel);
			this.Controls.Add(this.contentPanel);
		}
	}
}