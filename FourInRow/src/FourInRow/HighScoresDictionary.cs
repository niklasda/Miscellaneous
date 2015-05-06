using System.Collections;

namespace FourInRow
{	
	/// <summary>
	/// Dictionary for Note objects.
	/// i.e. all the loaded Notes
	/// </summary>
	public class HighScoresDictionary : ArrayList
	{
		/// <summary>
		/// Type-safe version of IDictionary.Item
		/// </summary>
		public new HighScore this[int highScoreId] 
		{
			get { return (HighScore)(base[highScoreId]); }
		//	set { base[highScoreId] = value; }
		}

		/// <summary>
		///  Type-safe version of IDictionary.Add
		/// </summary>
		/// <param name="oHighScore">the Note</param>
		public void Add(HighScore oHighScore) 
		{
			base.Add(oHighScore);
		}

	}
}
