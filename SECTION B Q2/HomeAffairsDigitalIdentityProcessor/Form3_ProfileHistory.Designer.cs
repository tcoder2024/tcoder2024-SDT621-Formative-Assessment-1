namespace HomeAffairsDigitalIdentityProcessor
{
	partial class Form3_ProfileHistory
	{
		private System.ComponentModel.IContainer components = null;

		// Main layout containers
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label subtitleLabel;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.Button refreshButton;

		private System.Windows.Forms.Panel searchPanel;
		private System.Windows.Forms.Label searchLabel;
		private System.Windows.Forms.TextBox searchTextBox;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.Button clearSearchButton;
		private System.Windows.Forms.Label resultCountLabel;

		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private System.Windows.Forms.DataGridView profilesDataGridView;
		private System.Windows.Forms.RichTextBox detailRichTextBox;

		private System.Windows.Forms.Panel actionPanel;
		private System.Windows.Forms.Button viewDetailsButton;
		private System.Windows.Forms.Button deleteProfileButton;
		private System.Windows.Forms.Button exportAllButton;
		private System.Windows.Forms.Button openStorageButton;

		private System.Windows.Forms.Panel statusPanel;
		private System.Windows.Forms.Label statusMessageLabel;
		private System.Windows.Forms.Label statsLabel;

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
			this.Text = "Home Affairs Digital Identity Processor - Profile History";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
			this.MinimumSize = new System.Drawing.Size(1280, 800);

			// HEADER PANEL
			this.headerPanel = new System.Windows.Forms.Panel();
			this.headerPanel.BackColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Height = 90;
			this.headerPanel.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);

			this.titleLabel = new System.Windows.Forms.Label();
			this.titleLabel.Text = "PROFILE HISTORY DATABASE";
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
			this.titleLabel.ForeColor = System.Drawing.Color.White;
			this.titleLabel.AutoSize = true;
			this.titleLabel.Location = new System.Drawing.Point(25, 15);

			this.subtitleLabel = new System.Windows.Forms.Label();
			this.subtitleLabel.Text = "View, search, and manage all processed digital identities";
			this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
			this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
			this.subtitleLabel.AutoSize = true;
			this.subtitleLabel.Location = new System.Drawing.Point(27, 48);

			this.backButton = new System.Windows.Forms.Button();
			this.backButton.Text = "← BACK TO DASHBOARD";
			this.backButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.backButton.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
			this.backButton.ForeColor = System.Drawing.Color.White;
			this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.backButton.FlatAppearance.BorderSize = 0;
			this.backButton.Size = new System.Drawing.Size(200, 45);
			this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.backButton.Click += new System.EventHandler(this.BackButton_Click);

			this.refreshButton = new System.Windows.Forms.Button();
			this.refreshButton.Text = "⟳ REFRESH";
			this.refreshButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.refreshButton.BackColor = System.Drawing.Color.FromArgb(0, 128, 128);
			this.refreshButton.ForeColor = System.Drawing.Color.White;
			this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.refreshButton.FlatAppearance.BorderSize = 0;
			this.refreshButton.Size = new System.Drawing.Size(140, 45);
			this.refreshButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);

			this.headerPanel.Controls.Add(this.titleLabel);
			this.headerPanel.Controls.Add(this.subtitleLabel);
			this.headerPanel.Controls.Add(this.backButton);
			this.headerPanel.Controls.Add(this.refreshButton);

			// SEARCH PANEL
			this.searchPanel = new System.Windows.Forms.Panel();
			this.searchPanel.BackColor = System.Drawing.Color.White;
			this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.searchPanel.Height = 70;
			this.searchPanel.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);

			this.searchLabel = new System.Windows.Forms.Label();
			this.searchLabel.Text = "SEARCH:";
			this.searchLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.searchLabel.ForeColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.searchLabel.Location = new System.Drawing.Point(25, 20);
			this.searchLabel.Size = new System.Drawing.Size(80, 30);

			this.searchTextBox = new System.Windows.Forms.TextBox();
			this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
			this.searchTextBox.Location = new System.Drawing.Point(110, 18);
			this.searchTextBox.Size = new System.Drawing.Size(350, 27);
			this.searchTextBox.PlaceholderText = "Search by name or ID number...";
			this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);

			this.searchButton = new System.Windows.Forms.Button();
			this.searchButton.Text = "SEARCH";
			this.searchButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.searchButton.BackColor = System.Drawing.Color.FromArgb(0, 128, 128);
			this.searchButton.ForeColor = System.Drawing.Color.White;
			this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.searchButton.Size = new System.Drawing.Size(100, 28);
			this.searchButton.Location = new System.Drawing.Point(470, 18);
			this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);

			this.clearSearchButton = new System.Windows.Forms.Button();
			this.clearSearchButton.Text = "CLEAR";
			this.clearSearchButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.clearSearchButton.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
			this.clearSearchButton.ForeColor = System.Drawing.Color.White;
			this.clearSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.clearSearchButton.Size = new System.Drawing.Size(80, 28);
			this.clearSearchButton.Location = new System.Drawing.Point(580, 18);
			this.clearSearchButton.Click += new System.EventHandler(this.ClearSearchButton_Click);

			this.resultCountLabel = new System.Windows.Forms.Label();
			this.resultCountLabel.Text = "Showing all profiles";
			this.resultCountLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.resultCountLabel.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
			this.resultCountLabel.Location = new System.Drawing.Point(680, 22);
			this.resultCountLabel.Size = new System.Drawing.Size(400, 25);

			this.searchPanel.Controls.Add(this.searchLabel);
			this.searchPanel.Controls.Add(this.searchTextBox);
			this.searchPanel.Controls.Add(this.searchButton);
			this.searchPanel.Controls.Add(this.clearSearchButton);
			this.searchPanel.Controls.Add(this.resultCountLabel);

			// MAIN SPLIT CONTAINER - Left: DataGridView, Right: Details
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.SplitterDistance = 650;
			this.mainSplitContainer.SplitterWidth = 5;
			this.mainSplitContainer.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

			// DATA GRID VIEW
			this.profilesDataGridView = new System.Windows.Forms.DataGridView();
			this.profilesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.profilesDataGridView.BackgroundColor = System.Drawing.Color.White;
			this.profilesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.profilesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.profilesDataGridView.GridColor = System.Drawing.Color.FromArgb(230, 235, 240);
			this.profilesDataGridView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.profilesDataGridView.RowHeadersVisible = false;
			this.profilesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.profilesDataGridView.MultiSelect = false;
			this.profilesDataGridView.AllowUserToAddRows = false;
			this.profilesDataGridView.AllowUserToDeleteRows = false;
			this.profilesDataGridView.ReadOnly = true;
			this.profilesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.profilesDataGridView.SelectionChanged += new System.EventHandler(this.ProfilesDataGridView_SelectionChanged);

			// DETAIL RICH TEXT BOX
			this.detailRichTextBox = new System.Windows.Forms.RichTextBox();
			this.detailRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detailRichTextBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular);
			this.detailRichTextBox.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			this.detailRichTextBox.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
			this.detailRichTextBox.ReadOnly = true;
			this.detailRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.detailRichTextBox.Text = "Select a profile from the list to view details.";

			// Add to split container
			this.mainSplitContainer.Panel1.Controls.Add(this.profilesDataGridView);
			this.mainSplitContainer.Panel2.Controls.Add(this.detailRichTextBox);

			// ACTION PANEL
			this.actionPanel = new System.Windows.Forms.Panel();
			this.actionPanel.BackColor = System.Drawing.Color.White;
			this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.actionPanel.Height = 70;
			this.actionPanel.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);

			this.viewDetailsButton = new System.Windows.Forms.Button();
			this.viewDetailsButton.Text = "VIEW FULL DETAILS";
			this.viewDetailsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.viewDetailsButton.BackColor = System.Drawing.Color.FromArgb(26, 42, 79);
			this.viewDetailsButton.ForeColor = System.Drawing.Color.White;
			this.viewDetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.viewDetailsButton.Size = new System.Drawing.Size(170, 45);
			this.viewDetailsButton.Location = new System.Drawing.Point(25, 12);
			this.viewDetailsButton.Enabled = false;
			this.viewDetailsButton.Click += new System.EventHandler(this.ViewDetailsButton_Click);

			this.deleteProfileButton = new System.Windows.Forms.Button();
			this.deleteProfileButton.Text = "DELETE PROFILE";
			this.deleteProfileButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.deleteProfileButton.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
			this.deleteProfileButton.ForeColor = System.Drawing.Color.White;
			this.deleteProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.deleteProfileButton.Size = new System.Drawing.Size(170, 45);
			this.deleteProfileButton.Location = new System.Drawing.Point(210, 12);
			this.deleteProfileButton.Enabled = false;
			this.deleteProfileButton.Click += new System.EventHandler(this.DeleteProfileButton_Click);

			this.exportAllButton = new System.Windows.Forms.Button();
			this.exportAllButton.Text = "EXPORT ALL TO CSV";
			this.exportAllButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.exportAllButton.BackColor = System.Drawing.Color.FromArgb(60, 70, 90);
			this.exportAllButton.ForeColor = System.Drawing.Color.White;
			this.exportAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.exportAllButton.Size = new System.Drawing.Size(180, 45);
			this.exportAllButton.Location = new System.Drawing.Point(850, 12);
			this.exportAllButton.Click += new System.EventHandler(this.ExportAllButton_Click);

			this.openStorageButton = new System.Windows.Forms.Button();
			this.openStorageButton.Text = "OPEN STORAGE";
			this.openStorageButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.openStorageButton.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
			this.openStorageButton.ForeColor = System.Drawing.Color.White;
			this.openStorageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.openStorageButton.Size = new System.Drawing.Size(160, 45);
			this.openStorageButton.Location = new System.Drawing.Point(1045, 12);
			this.openStorageButton.Click += new System.EventHandler(this.OpenStorageButton_Click);

			this.actionPanel.Controls.Add(this.viewDetailsButton);
			this.actionPanel.Controls.Add(this.deleteProfileButton);
			this.actionPanel.Controls.Add(this.exportAllButton);
			this.actionPanel.Controls.Add(this.openStorageButton);

			// STATUS PANEL
			this.statusPanel = new System.Windows.Forms.Panel();
			this.statusPanel.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
			this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.statusPanel.Height = 40;

			this.statusMessageLabel = new System.Windows.Forms.Label();
			this.statusMessageLabel.Text = "Ready. Select a profile to view details.";
			this.statusMessageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
			this.statusMessageLabel.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
			this.statusMessageLabel.Location = new System.Drawing.Point(25, 10);
			this.statusMessageLabel.Size = new System.Drawing.Size(600, 25);

			this.statsLabel = new System.Windows.Forms.Label();
			this.statsLabel.Text = "";
			this.statsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
			this.statsLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
			this.statsLabel.Location = new System.Drawing.Point(650, 10);
			this.statsLabel.Size = new System.Drawing.Size(550, 25);
			this.statsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

			this.statusPanel.Controls.Add(this.statusMessageLabel);
			this.statusPanel.Controls.Add(this.statsLabel);

			// Position right-aligned buttons
			this.backButton.Left = this.ClientSize.Width - 240;
			this.refreshButton.Left = this.ClientSize.Width - 370;
			this.headerPanel.Resize += (s, e) => {
				this.backButton.Left = this.headerPanel.Width - 240;
				this.refreshButton.Left = this.headerPanel.Width - 370;
			};

			// Add all controls to form
			this.Controls.Add(this.mainSplitContainer);
			this.Controls.Add(this.searchPanel);
			this.Controls.Add(this.actionPanel);
			this.Controls.Add(this.statusPanel);
			this.Controls.Add(this.headerPanel);

			// Setup DataGridView columns IMMEDIATELY
			SetupDataGridViewColumns();
		}

		private void SetupDataGridViewColumns()
		{
			// Clear existing columns
			this.profilesDataGridView.Columns.Clear();

			// Create and add columns
			DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
			colName.Name = "FullName";
			colName.HeaderText = "FULL NAME";
			colName.FillWeight = 25;

			DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
			colID.Name = "IDNumber";
			colID.HeaderText = "ID NUMBER";
			colID.FillWeight = 18;

			DataGridViewTextBoxColumn colAge = new DataGridViewTextBoxColumn();
			colAge.Name = "Age";
			colAge.HeaderText = "AGE";
			colAge.FillWeight = 8;

			DataGridViewTextBoxColumn colGender = new DataGridViewTextBoxColumn();
			colGender.Name = "Gender";
			colGender.HeaderText = "GENDER";
			colGender.FillWeight = 12;

			DataGridViewTextBoxColumn colCitizenship = new DataGridViewTextBoxColumn();
			colCitizenship.Name = "Citizenship";
			colCitizenship.HeaderText = "CITIZENSHIP";
			colCitizenship.FillWeight = 18;

			DataGridViewTextBoxColumn colValidated = new DataGridViewTextBoxColumn();
			colValidated.Name = "Validated";
			colValidated.HeaderText = "STATUS";
			colValidated.FillWeight = 10;

			DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
			colDate.Name = "CreatedDate";
			colDate.HeaderText = "CREATED DATE";
			colDate.FillWeight = 9;

			this.profilesDataGridView.Columns.Add(colName);
			this.profilesDataGridView.Columns.Add(colID);
			this.profilesDataGridView.Columns.Add(colAge);
			this.profilesDataGridView.Columns.Add(colGender);
			this.profilesDataGridView.Columns.Add(colCitizenship);
			this.profilesDataGridView.Columns.Add(colValidated);
			this.profilesDataGridView.Columns.Add(colDate);
		}
	}
}