using System;
using System.Windows.Forms;

namespace HomeAffairsDigitalIdentityProcessor
{
	public partial class Form4_About : Form
	{
		public Form4_About()
		{
			InitializeComponent();
			UpdateSystemDateTime();
		}

		private void UpdateSystemDateTime()
		{
			// Update the system info label with current date/time
			systemInfoLabel.Text = $"System Date: {DateTime.Now:dd MMM yyyy HH:mm:ss}";
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Optional: Allow ESC key to close
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}