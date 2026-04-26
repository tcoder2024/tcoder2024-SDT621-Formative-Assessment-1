namespace ProgrammingLanguagesManager
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		// Professional control declarations
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Panel footerPanel;
		private System.Windows.Forms.Panel leftGlowPanel;
		private System.Windows.Forms.Panel rightGlowPanel;
		private System.Windows.Forms.Panel bottomGlowPanel;
		private System.Windows.Forms.Panel topGlowLine;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label subtitleLabel;
		private System.Windows.Forms.ListBox languagesListBox;
		private System.Windows.Forms.Label inputLabel;
		private System.Windows.Forms.TextBox languageTextBox;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label countLabel;
		private System.Windows.Forms.Timer blueGlowTimer;
		private System.Windows.Forms.Timer redGlowTimer;
		private System.Windows.Forms.Panel inputPanel;
		private System.Windows.Forms.Label dividerLine;
		private System.Windows.Forms.Label instructionLabel;
		private System.Windows.Forms.Label helpLabel;

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
			this.headerPanel = new System.Windows.Forms.Panel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.subtitleLabel = new System.Windows.Forms.Label();
			this.topGlowLine = new System.Windows.Forms.Panel();
			this.footerPanel = new System.Windows.Forms.Panel();
			this.countLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.leftGlowPanel = new System.Windows.Forms.Panel();
			this.rightGlowPanel = new System.Windows.Forms.Panel();
			this.bottomGlowPanel = new System.Windows.Forms.Panel();
			this.languagesListBox = new System.Windows.Forms.ListBox();
			this.inputPanel = new System.Windows.Forms.Panel();
			this.inputLabel = new System.Windows.Forms.Label();
			this.instructionLabel = new System.Windows.Forms.Label();
			this.languageTextBox = new System.Windows.Forms.TextBox();
			this.helpLabel = new System.Windows.Forms.Label();
			this.addButton = new System.Windows.Forms.Button();
			this.removeButton = new System.Windows.Forms.Button();
			this.dividerLine = new System.Windows.Forms.Label();
			this.blueGlowTimer = new System.Windows.Forms.Timer(this.components);
			this.redGlowTimer = new System.Windows.Forms.Timer(this.components);
			this.headerPanel.SuspendLayout();
			this.footerPanel.SuspendLayout();
			this.inputPanel.SuspendLayout();
			this.SuspendLayout();

			// ========== FORM SETTINGS ==========
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			// High contrast dark background - easier on eyes and accessible
			this.BackColor = System.Drawing.Color.FromArgb(15, 18, 28);
			this.Text = "Programming Languages Manager";
			this.KeyPreview = true;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);

			// ========== HEADER PANEL ==========
			this.headerPanel.BackColor = System.Drawing.Color.FromArgb(22, 28, 42);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Height = 95;
			this.headerPanel.Controls.Add(this.titleLabel);
			this.headerPanel.Controls.Add(this.subtitleLabel);
			this.headerPanel.Controls.Add(this.topGlowLine);

			// Title Label - High contrast white/cyan for readability
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
			this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(220, 240, 255);
			this.titleLabel.Location = new System.Drawing.Point(45, 22);
			this.titleLabel.Text = "Language Collection Manager";
			this.titleLabel.BackColor = System.Drawing.Color.Transparent;

			// Subtitle Label - Lighter gray for hierarchy but readable
			this.subtitleLabel.AutoSize = true;
			this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(170, 180, 210);
			this.subtitleLabel.Location = new System.Drawing.Point(48, 58);
			this.subtitleLabel.Text = "Manage your programming language preferences | Add | Remove | Track";
			this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;

			// Top Glow Line - Blue accent
			this.topGlowLine.BackColor = System.Drawing.Color.FromArgb(0, 180, 230);
			this.topGlowLine.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.topGlowLine.Height = 2;

			// ========== FOOTER PANEL ==========
			this.footerPanel.BackColor = System.Drawing.Color.FromArgb(18, 24, 36);
			this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.footerPanel.Height = 55;
			this.footerPanel.Controls.Add(this.countLabel);
			this.footerPanel.Controls.Add(this.statusLabel);

			// Count Label - Bright but not harsh
			this.countLabel.AutoSize = true;
			this.countLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.countLabel.ForeColor = System.Drawing.Color.FromArgb(150, 220, 240);
			this.countLabel.Location = new System.Drawing.Point(45, 18);
			this.countLabel.Text = "LANGUAGE COUNT: 0";
			this.countLabel.BackColor = System.Drawing.Color.Transparent;

			// Status Label - Good contrast gray
			this.statusLabel.AutoSize = true;
			this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(180, 190, 220);
			this.statusLabel.Location = new System.Drawing.Point(280, 19);
			this.statusLabel.Text = "● Ready";
			this.statusLabel.BackColor = System.Drawing.Color.Transparent;

			// ========== GLOW PANELS ==========
			this.leftGlowPanel.BackColor = System.Drawing.Color.FromArgb(0, 160, 210);
			this.leftGlowPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftGlowPanel.Width = 3;

			this.rightGlowPanel.BackColor = System.Drawing.Color.FromArgb(0, 160, 210);
			this.rightGlowPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.rightGlowPanel.Width = 3;

			this.bottomGlowPanel.BackColor = System.Drawing.Color.FromArgb(190, 60, 70);
			this.bottomGlowPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bottomGlowPanel.Height = 2;

			// ========== LANGUAGE LIST BOX ==========
			this.languagesListBox.BackColor = System.Drawing.Color.FromArgb(18, 22, 35);
			this.languagesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.languagesListBox.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular);
			// High contrast text - bright cyan on dark background
			this.languagesListBox.ForeColor = System.Drawing.Color.FromArgb(100, 230, 255);
			this.languagesListBox.Location = new System.Drawing.Point(60, 130);
			this.languagesListBox.Size = new System.Drawing.Size(480, 392);
			this.languagesListBox.TabIndex = 0;
			this.languagesListBox.SelectedIndexChanged += new System.EventHandler(this.languagesListBox_SelectedIndexChanged);

			// ========== INPUT PANEL ==========
			this.inputPanel.BackColor = System.Drawing.Color.FromArgb(18, 22, 35);
			this.inputPanel.Location = new System.Drawing.Point(570, 130);
			this.inputPanel.Size = new System.Drawing.Size(480, 392);

			// Input Label - Bold and readable
			this.inputLabel.AutoSize = true;
			this.inputLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.inputLabel.ForeColor = System.Drawing.Color.FromArgb(180, 220, 255);
			this.inputLabel.Location = new System.Drawing.Point(35, 25);
			this.inputLabel.Text = "ENTER LANGUAGE";

			// Instruction Label - Subtle but readable
			this.instructionLabel.AutoSize = true;
			this.instructionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.instructionLabel.ForeColor = System.Drawing.Color.FromArgb(150, 160, 190);
			this.instructionLabel.Location = new System.Drawing.Point(37, 52);
			this.instructionLabel.Text = "Type a programming language name and click Add";

			// Language TextBox - High contrast input field
			this.languageTextBox.BackColor = System.Drawing.Color.FromArgb(28, 34, 48);
			this.languageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.languageTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
			this.languageTextBox.ForeColor = System.Drawing.Color.FromArgb(220, 240, 255);
			this.languageTextBox.Location = new System.Drawing.Point(40, 85);
			this.languageTextBox.Size = new System.Drawing.Size(400, 27);
			this.languageTextBox.TabIndex = 1;
			this.languageTextBox.TextChanged += new System.EventHandler(this.languageTextBox_TextChanged);

			// Help Label - Keyboard shortcuts info
			this.helpLabel.AutoSize = true;
			this.helpLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
			this.helpLabel.ForeColor = System.Drawing.Color.FromArgb(120, 130, 160);
			this.helpLabel.Location = new System.Drawing.Point(38, 340);
			this.helpLabel.Text = "Tip: Press ENTER to quickly add | ESC to toggle fullscreen";

			// Add Button - High contrast, bold text
			this.addButton.BackColor = System.Drawing.Color.FromArgb(0, 60, 80);
			this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 180, 230);
			this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 90, 110);
			this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 75, 95);
			this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.addButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			// White text for maximum contrast
			this.addButton.ForeColor = System.Drawing.Color.White;
			this.addButton.Location = new System.Drawing.Point(40, 135);
			this.addButton.Size = new System.Drawing.Size(190, 45);
			this.addButton.Text = "ADD LANGUAGE";
			this.addButton.UseVisualStyleBackColor = false;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);

			// Remove Button - Dark red background, white text for contrast
			this.removeButton.BackColor = System.Drawing.Color.FromArgb(80, 35, 40);
			this.removeButton.Enabled = false;
			this.removeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 80, 90);
			this.removeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(140, 50, 55);
			this.removeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(110, 45, 50);
			this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.removeButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			// White text for maximum readability
			this.removeButton.ForeColor = System.Drawing.Color.White;
			this.removeButton.Location = new System.Drawing.Point(250, 135);
			this.removeButton.Size = new System.Drawing.Size(190, 45);
			this.removeButton.Text = "REMOVE SELECTED";
			this.removeButton.UseVisualStyleBackColor = false;
			this.removeButton.Click += new System.EventHandler(this.removeButton_Click);

			// Divider Line
			this.dividerLine.BackColor = System.Drawing.Color.FromArgb(50, 60, 80);
			this.dividerLine.Location = new System.Drawing.Point(30, 210);
			this.dividerLine.Size = new System.Drawing.Size(420, 1);

			// Add controls to input panel
			this.inputPanel.Controls.Add(this.inputLabel);
			this.inputPanel.Controls.Add(this.instructionLabel);
			this.inputPanel.Controls.Add(this.languageTextBox);
			this.inputPanel.Controls.Add(this.addButton);
			this.inputPanel.Controls.Add(this.removeButton);
			this.inputPanel.Controls.Add(this.dividerLine);
			this.inputPanel.Controls.Add(this.helpLabel);

			// ========== TIMERS FOR GLOW EFFECTS ==========
			this.blueGlowTimer.Interval = 800;
			this.blueGlowTimer.Tick += new System.EventHandler(this.blueGlowTimer_Tick);
			this.blueGlowTimer.Start();

			this.redGlowTimer.Interval = 600;
			this.redGlowTimer.Tick += new System.EventHandler(this.redGlowTimer_Tick);
			this.redGlowTimer.Start();

			// ========== INITIAL SAMPLE DATA ==========
			this.languagesListBox.Items.AddRange(new object[] {
			"C#",
			"Python",
			"Java",
			"JavaScript",
			"Go"
			});

			this.UpdateLanguageCount();

			// ========== ADD CONTROLS TO FORM ==========
			this.Controls.Add(this.languagesListBox);
			this.Controls.Add(this.inputPanel);
			this.Controls.Add(this.leftGlowPanel);
			this.Controls.Add(this.rightGlowPanel);
			this.Controls.Add(this.bottomGlowPanel);
			this.Controls.Add(this.headerPanel);
			this.Controls.Add(this.footerPanel);

			this.headerPanel.ResumeLayout(false);
			this.headerPanel.PerformLayout();
			this.footerPanel.ResumeLayout(false);
			this.footerPanel.PerformLayout();
			this.inputPanel.ResumeLayout(false);
			this.inputPanel.PerformLayout();
			this.ResumeLayout(false);
		}

		private void UpdateLanguageCount()
		{
			this.countLabel.Text = $"LANGUAGE COUNT: {this.languagesListBox.Items.Count}";
		}
	}
}