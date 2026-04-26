using System;
using System.Windows.Forms;

namespace HomeAffairsDigitalIdentityProcessor
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				Application.Run(new Form1());
			}
			catch (Exception ex)
			{
				MessageBox.Show($"A critical error occurred: {ex.Message}\n\nPlease restart the application.",
					"Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}