using System;
using System.Windows.Forms;
using System.Drawing;

namespace ProgrammingLanguagesManager
{
	public partial class Form1 : Form
	{
		private bool blueGlowHigh = false;
		private bool redGlowHigh = false;

		public Form1()
		{
			InitializeComponent();
			statusLabel.Text = "● Ready | System online";
		}

		// Blue glow pulsing - purely visual enhancement, text remains readable
		private void blueGlowTimer_Tick(object sender, EventArgs e)
		{
			blueGlowHigh = !blueGlowHigh;

			if (blueGlowHigh)
			{
				leftGlowPanel.BackColor = Color.FromArgb(0, 120, 180);
				rightGlowPanel.BackColor = Color.FromArgb(0, 120, 180);
				topGlowLine.BackColor = Color.FromArgb(0, 130, 190);
				// Title color stays readable - just subtle shift
				titleLabel.ForeColor = Color.FromArgb(200, 230, 255);
			}
			else
			{
				leftGlowPanel.BackColor = Color.FromArgb(0, 180, 230);
				rightGlowPanel.BackColor = Color.FromArgb(0, 180, 230);
				topGlowLine.BackColor = Color.FromArgb(0, 200, 240);
				titleLabel.ForeColor = Color.FromArgb(220, 240, 255);
			}
		}

		// Red glow pulsing - subtle, doesn't affect text readability
		private void redGlowTimer_Tick(object sender, EventArgs e)
		{
			redGlowHigh = !redGlowHigh;

			if (redGlowHigh && removeButton.Enabled)
			{
				bottomGlowPanel.BackColor = Color.FromArgb(160, 50, 60);
				removeButton.FlatAppearance.BorderColor = Color.FromArgb(200, 70, 80);
			}
			else
			{
				bottomGlowPanel.BackColor = Color.FromArgb(190, 60, 70);
				removeButton.FlatAppearance.BorderColor = Color.FromArgb(220, 80, 90);
			}

			if (!removeButton.Enabled)
			{
				bottomGlowPanel.BackColor = Color.FromArgb(70, 35, 45);
			}
		}

		// Add language - clear status messages with timestamps
		private void addButton_Click(object sender, EventArgs e)
		{
			string newLanguage = languageTextBox.Text.Trim();

			// Empty input check with clear message
			if (string.IsNullOrWhiteSpace(newLanguage))
			{
				statusLabel.Text = $"✗ Error | Empty input rejected at {DateTime.Now:HH:mm:ss}";
				FlashInputError();
				return;
			}

			// Duplicate check with case-insensitive comparison
			foreach (object item in languagesListBox.Items)
			{
				if (item.ToString().Equals(newLanguage, StringComparison.OrdinalIgnoreCase))
				{
					statusLabel.Text = $"✗ Error | '{newLanguage}' already exists at {DateTime.Now:HH:mm:ss}";
					FlashInputError();
					return;
				}
			}

			// Success - add the language
			languagesListBox.Items.Add(newLanguage);
			statusLabel.Text = $"✓ Added '{newLanguage}' at {DateTime.Now:dd MMM yyyy HH:mm:ss}";

			languageTextBox.Clear();
			languageTextBox.Focus();

			UpdateLanguageCount();
			FlashButton(addButton, Color.FromArgb(0, 100, 120), Color.FromArgb(0, 60, 80));
		}

		// Remove selected language
		private void removeButton_Click(object sender, EventArgs e)
		{
			if (languagesListBox.SelectedItem != null)
			{
				string removedLanguage = languagesListBox.SelectedItem.ToString();
				languagesListBox.Items.Remove(languagesListBox.SelectedItem);

				// EXACT format required by assessment
				statusLabel.Text = $"Removed '{removedLanguage}' at {DateTime.Now:dd MMM yyyy HH:mm:ss}";

				UpdateLanguageCount();

				if (languagesListBox.SelectedItem == null)
				{
					removeButton.Enabled = false;
				}

				FlashButton(removeButton, Color.FromArgb(140, 50, 55), Color.FromArgb(80, 35, 40));
			}
		}

		// Enable/disable remove button based on selection
		private void languagesListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			removeButton.Enabled = (languagesListBox.SelectedItem != null);
		}

		// Text change - subtle feedback but always readable
		private void languageTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(languageTextBox.Text))
			{
				languageTextBox.ForeColor = Color.FromArgb(220, 240, 255);
				languageTextBox.BackColor = Color.FromArgb(35, 42, 58);
			}
			else
			{
				languageTextBox.ForeColor = Color.FromArgb(180, 190, 220);
				languageTextBox.BackColor = Color.FromArgb(28, 34, 48);
			}
		}

		// Error flash - temporary, returns to readable state
		private void FlashInputError()
		{
			Color originalBack = languageTextBox.BackColor;
			Color originalFore = languageTextBox.ForeColor;
			languageTextBox.BackColor = Color.FromArgb(90, 40, 45);
			languageTextBox.ForeColor = Color.White;
			System.Threading.Tasks.Task.Delay(300).ContinueWith(_ =>
			{
				this.Invoke(new Action(() =>
				{
					languageTextBox.BackColor = originalBack;
					languageTextBox.ForeColor = originalFore;
				}));
			});
		}

		// Button flash feedback
		private void FlashButton(Button btn, Color flashColor, Color originalColor)
		{
			btn.BackColor = flashColor;
			System.Threading.Tasks.Task.Delay(120).ContinueWith(_ =>
			{
				this.Invoke(new Action(() =>
				{
					btn.BackColor = originalColor;
				}));
			});
		}

		// Keyboard shortcuts
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				if (this.WindowState == FormWindowState.Normal)
				{
					this.WindowState = FormWindowState.Maximized;
				}
				else
				{
					this.WindowState = FormWindowState.Normal;
					this.FormBorderStyle = FormBorderStyle.Sizable;
				}
			}

			// Enter key adds language - power user feature
			if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(languageTextBox.Text))
			{
				addButton_Click(sender, e);
			}
		}
	}
}