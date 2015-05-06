using System;
using System.Runtime.InteropServices;

namespace FourInRow
{
	/// <summary>
	/// Summary description for Beeper.
	/// </summary>
	public class Beeper
	{	
		[DllImport("kernel32.dll")]
		private static extern bool Beep(int frequency, int duration);

		/// <summary>
		/// Sound a beep
		/// </summary>
		public static void doBeep()
		{
			Beep(100, 300);
		}
		
	}
}
