namespace HomeAffairsDigitalIdentityProcessor
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		// Dashboard controls
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label subtitleLabel;
		private System.Windows.Forms.Label dateLabel;
		private System.Windows.Forms.Label timeLabel;

		private System.Windows.Forms.Panel welcomePanel;
		private System.Windows.Forms.Label welcomeTitle;
		private System.Windows.Forms.Label welcomeMessage;
		private System.Windows.Forms.Label namePromptLabel;
		private System.Windows.Forms.TextBox visitorNameTextBox;

		private System.Windows.Forms.Panel statsPanel;
		private System.Windows.Forms.Label statsTitle;
		private System.Windows.Forms.Label totalProfilesLabel;
		private System.Windows.Forms.Label todayProfilesLabel;
		private System.Windows.Forms.Label avgAgeLabel;
		private System.Windows.Forms.Label storageLocationLabel;

		private System.Windows.Forms.Panel actionPanel;
		private System.Windows.Forms.Button startProcessorButton;
		private System.Windows.Forms.Button viewHistoryButton;
		private System.Windows.Forms.Button aboutButton;
		private System.Windows.Forms.Button exitButton;

		private System.Windows.Forms.Panel footerPanel;
		private System.Windows.Forms.Label footerLabel;

		private System.Windows.Forms.Timer clockTimer;

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

			// Form1 settings - FULL SCREEN FIX
			this.Text = "Home Affairs Digital Identity Processor - Dashboard";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
			this.MinimumSize = new System.Drawing.Size(1024, 768);

			// Header Panel - Anchored to Top
			this.headerPanel = new System.Windows.Forms.Panel();
			this.headerPanel.BackColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Height = 120;
			this.headerPanel.Padding = new System.Windows.Forms.Padding(30, 20, 30, 10);

			// Title Label
			this.titleLabel = new System.Windows.Forms.Label();
			this.titleLabel.Text = "HOME AFFAIRS";
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
			this.titleLabel.ForeColor = System.Drawing.Color.White;
			this.titleLabel.AutoSize = true;
			this.titleLabel.Location = new System.Drawing.Point(30, 20);

			// Subtitle Label
			this.subtitleLabel = new System.Windows.Forms.Label();
			this.subtitleLabel.Text = "Digital Identity Processing System";
			this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
			this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
			this.subtitleLabel.AutoSize = true;
			this.subtitleLabel.Location = new System.Drawing.Point(32, 60);

			// Date Label - Anchored to Top Right
			this.dateLabel = new System.Windows.Forms.Label();
			this.dateLabel.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
			this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
			this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(200, 215, 240);
			this.dateLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.dateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.dateLabel.Location = new System.Drawing.Point(0, 20);
			this.dateLabel.Size = new System.Drawing.Size(280, 25);

			// Time Label
			this.timeLabel = new System.Windows.Forms.Label();
			this.timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
			this.timeLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
			this.timeLabel.ForeColor = System.Drawing.Color.FromArgb(0, 200, 200);
			this.timeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.timeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.timeLabel.Location = new System.Drawing.Point(0, 50);
			this.timeLabel.Size = new System.Drawing.Size(280, 35);

			// Fix date/time positioning
			this.dateLabel.Location = new System.Drawing.Point(this.headerPanel.Width - 310, 20);
			this.timeLabel.Location = new System.Drawing.Point(this.headerPanel.Width - 310, 55);
			this.headerPanel.Resize += (s, e) => {
				this.dateLabel.Left = this.headerPanel.Width - 310;
				this.timeLabel.Left = this.headerPanel.Width - 310;
			};

			this.headerPanel.Controls.Add(this.titleLabel);
			this.headerPanel.Controls.Add(this.subtitleLabel);
			this.headerPanel.Controls.Add(this.dateLabel);
			this.headerPanel.Controls.Add(this.timeLabel);

			// Welcome Panel - Anchored to Top Left with percentage width
			this.welcomePanel = new System.Windows.Forms.Panel();
			this.welcomePanel.BackColor = System.Drawing.Color.White;
			this.welcomePanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
			this.welcomePanel.Location = new System.Drawing.Point(30, 140);
			this.welcomePanel.Width = (int)(this.ClientSize.Width * 0.42);
			this.welcomePanel.Height = 220;
			this.welcomePanel.Padding = new System.Windows.Forms.Padding(20);

			this.welcomeTitle = new System.Windows.Forms.Label();
			this.welcomeTitle.Text = "WELCOME";
			this.welcomeTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.welcomeTitle.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.welcomeTitle.Location = new System.Drawing.Point(20, 20);
			this.welcomeTitle.Size = new System.Drawing.Size(380, 30);

			this.welcomeMessage = new System.Windows.Forms.Label();
			this.welcomeMessage.Text = "South African Identity Verification System";
			this.welcomeMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.welcomeMessage.ForeColor = System.Drawing.Color.FromArgb(100, 120, 150);
			this.welcomeMessage.Location = new System.Drawing.Point(20, 55);
			this.welcomeMessage.Size = new System.Drawing.Size(380, 25);

			this.namePromptLabel = new System.Windows.Forms.Label();
			this.namePromptLabel.Text = "Your Name:";
			this.namePromptLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.namePromptLabel.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.namePromptLabel.Location = new System.Drawing.Point(20, 95);
			this.namePromptLabel.Size = new System.Drawing.Size(100, 25);

			this.visitorNameTextBox = new System.Windows.Forms.TextBox();
			this.visitorNameTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
			this.visitorNameTextBox.Location = new System.Drawing.Point(20, 125);
			this.visitorNameTextBox.Size = new System.Drawing.Size(380, 27);
			this.visitorNameTextBox.Text = "Officer";
			this.visitorNameTextBox.TextChanged += new System.EventHandler(this.VisitorNameTextBox_TextChanged);

			this.welcomePanel.Controls.Add(this.welcomeTitle);
			this.welcomePanel.Controls.Add(this.welcomeMessage);
			this.welcomePanel.Controls.Add(this.namePromptLabel);
			this.welcomePanel.Controls.Add(this.visitorNameTextBox);

			// Stats Panel - Anchored to Top Right
			this.statsPanel = new System.Windows.Forms.Panel();
			this.statsPanel.BackColor = System.Drawing.Color.White;
			this.statsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.statsPanel.Location = new System.Drawing.Point(0, 140);
			this.statsPanel.Width = (int)(this.ClientSize.Width * 0.42);
			this.statsPanel.Height = 220;
			this.statsPanel.Padding = new System.Windows.Forms.Padding(20);

			this.statsTitle = new System.Windows.Forms.Label();
			this.statsTitle.Text = "SYSTEM STATISTICS";
			this.statsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.statsTitle.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.statsTitle.Location = new System.Drawing.Point(20, 20);
			this.statsTitle.Size = new System.Drawing.Size(380, 25);

			this.totalProfilesLabel = new System.Windows.Forms.Label();
			this.totalProfilesLabel.Text = "Total Profiles: Loading...";
			this.totalProfilesLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
			this.totalProfilesLabel.ForeColor = System.Drawing.Color.FromArgb(60, 70, 90);
			this.totalProfilesLabel.Location = new System.Drawing.Point(20, 60);
			this.totalProfilesLabel.Size = new System.Drawing.Size(380, 25);

			this.todayProfilesLabel = new System.Windows.Forms.Label();
			this.todayProfilesLabel.Text = "Today's Profiles: Loading...";
			this.todayProfilesLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
			this.todayProfilesLabel.ForeColor = System.Drawing.Color.FromArgb(60, 70, 90);
			this.todayProfilesLabel.Location = new System.Drawing.Point(20, 90);
			this.todayProfilesLabel.Size = new System.Drawing.Size(380, 25);

			this.avgAgeLabel = new System.Windows.Forms.Label();
			this.avgAgeLabel.Text = "Average Age: Loading...";
			this.avgAgeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
			this.avgAgeLabel.ForeColor = System.Drawing.Color.FromArgb(60, 70, 90);
			this.avgAgeLabel.Location = new System.Drawing.Point(20, 120);
			this.avgAgeLabel.Size = new System.Drawing.Size(380, 25);

			this.storageLocationLabel = new System.Windows.Forms.Label();
			this.storageLocationLabel.Text = "Storage: Loading...";
			this.storageLocationLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
			this.storageLocationLabel.ForeColor = System.Drawing.Color.FromArgb(120, 130, 160);
			this.storageLocationLabel.Location = new System.Drawing.Point(20, 160);
			this.storageLocationLabel.Size = new System.Drawing.Size(380, 20);

			this.statsPanel.Controls.Add(this.statsTitle);
			this.statsPanel.Controls.Add(this.totalProfilesLabel);
			this.statsPanel.Controls.Add(this.todayProfilesLabel);
			this.statsPanel.Controls.Add(this.avgAgeLabel);
			this.statsPanel.Controls.Add(this.storageLocationLabel);

			// Reposition stats panel to right side
			this.statsPanel.Location = new System.Drawing.Point(this.ClientSize.Width - (int)(this.ClientSize.Width * 0.42) - 30, 140);
			this.Resize += (s, e) => {
				this.welcomePanel.Width = (int)(this.ClientSize.Width * 0.42);
				this.statsPanel.Width = (int)(this.ClientSize.Width * 0.42);
				this.statsPanel.Left = this.ClientSize.Width - this.statsPanel.Width - 30;
				this.actionPanel.Width = this.ClientSize.Width - 60;
			};

			// Action Panel - Anchored to fill remaining space
			this.actionPanel = new System.Windows.Forms.Panel();
			this.actionPanel.BackColor = System.Drawing.Color.Transparent;
			this.actionPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.actionPanel.Location = new System.Drawing.Point(30, 380);
			this.actionPanel.Width = this.ClientSize.Width - 60;
			this.actionPanel.Height = 160;

			this.startProcessorButton = new System.Windows.Forms.Button();
			this.startProcessorButton.Text = "START NEW APPLICATION";
			this.startProcessorButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.startProcessorButton.BackColor = System.Drawing.Color.FromArgb(0, 128, 128);
			this.startProcessorButton.ForeColor = System.Drawing.Color.White;
			this.startProcessorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.startProcessorButton.FlatAppearance.BorderSize = 0;
			this.startProcessorButton.Location = new System.Drawing.Point(0, 20);
			this.startProcessorButton.Width = (this.actionPanel.Width - 20) / 2;
			this.startProcessorButton.Height = 55;
			this.startProcessorButton.Click += new System.EventHandler(this.StartProcessorButton_Click);

			this.viewHistoryButton = new System.Windows.Forms.Button();
			this.viewHistoryButton.Text = "VIEW PROFILE HISTORY";
			this.viewHistoryButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.viewHistoryButton.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
			this.viewHistoryButton.ForeColor = System.Drawing.Color.White;
			this.viewHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.viewHistoryButton.FlatAppearance.BorderSize = 0;
			this.viewHistoryButton.Location = new System.Drawing.Point((this.actionPanel.Width - 20) / 2 + 20, 20);
			this.viewHistoryButton.Width = (this.actionPanel.Width - 20) / 2;
			this.viewHistoryButton.Height = 55;
			this.viewHistoryButton.Click += new System.EventHandler(this.ViewHistoryButton_Click);

			this.aboutButton = new System.Windows.Forms.Button();
			this.aboutButton.Text = "ABOUT & HELP";
			this.aboutButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
			this.aboutButton.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
			this.aboutButton.ForeColor = System.Drawing.Color.White;
			this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.aboutButton.FlatAppearance.BorderSize = 0;
			this.aboutButton.Location = new System.Drawing.Point(0, 95);
			this.aboutButton.Width = (this.actionPanel.Width - 20) / 3;
			this.aboutButton.Height = 45;
			this.aboutButton.Click += new System.EventHandler(this.AboutButton_Click);

			this.exitButton = new System.Windows.Forms.Button();
			this.exitButton.Text = "EXIT SYSTEM";
			this.exitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
			this.exitButton.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
			this.exitButton.ForeColor = System.Drawing.Color.White;
			this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.exitButton.FlatAppearance.BorderSize = 0;
			this.exitButton.Location = new System.Drawing.Point(((this.actionPanel.Width - 20) / 3) * 2 + 20, 95);
			this.exitButton.Width = (this.actionPanel.Width - 20) / 3;
			this.exitButton.Height = 45;
			this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);

			// Reposition buttons on resize
			this.actionPanel.Resize += (s, e) => {
				this.startProcessorButton.Width = (this.actionPanel.Width - 20) / 2;
				this.viewHistoryButton.Left = (this.actionPanel.Width - 20) / 2 + 20;
				this.viewHistoryButton.Width = (this.actionPanel.Width - 20) / 2;
				this.aboutButton.Width = (this.actionPanel.Width - 20) / 3;
				this.exitButton.Left = ((this.actionPanel.Width - 20) / 3) * 2 + 20;
				this.exitButton.Width = (this.actionPanel.Width - 20) / 3;
			};

			this.actionPanel.Controls.Add(this.startProcessorButton);
			this.actionPanel.Controls.Add(this.viewHistoryButton);
			this.actionPanel.Controls.Add(this.aboutButton);
			this.actionPanel.Controls.Add(this.exitButton);

			// Footer Panel
			this.footerPanel = new System.Windows.Forms.Panel();
			this.footerPanel.BackColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.footerPanel.Height = 45;

			this.footerLabel = new System.Windows.Forms.Label();
			this.footerLabel.Text = "Department of Home Affairs | Digital Identity Processing System | Version 1.0";
			this.footerLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.footerLabel.ForeColor = System.Drawing.Color.FromArgb(150, 170, 200);
			this.footerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.footerLabel.Dock = System.Windows.Forms.DockStyle.Fill;

			this.footerPanel.Controls.Add(this.footerLabel);

			// Clock Timer
			this.clockTimer = new System.Windows.Forms.Timer(this.components);
			this.clockTimer.Interval = 1000;
			this.clockTimer.Tick += new System.EventHandler(this.ClockTimer_Tick);
			this.clockTimer.Start();

			// Add controls to form
			this.Controls.Add(this.headerPanel);
			this.Controls.Add(this.welcomePanel);
			this.Controls.Add(this.statsPanel);
			this.Controls.Add(this.actionPanel);
			this.Controls.Add(this.footerPanel);
		}
	}
}