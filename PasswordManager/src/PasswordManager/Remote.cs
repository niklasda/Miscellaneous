using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PasswordManager
{
	/// <summary>
	/// Handles URLs
	/// </summary>
	public sealed class Remote
	{
		/// <summary>
		/// Constructor
		/// </summary>
		private Remote()
		{}

		/// <summary>
		/// Validate an Url and open it in a browser
		/// </summary>
		/// <param name="sUrl">the url to goto</param>
		public static void gotoUrl(string sUrl)
		{
			try
			{
				Uri uUrl = new Uri(sUrl); // for validation, trows if invalid
				Process.Start(sUrl);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), Settings.sApplicationName);
			}
		}
	}
}