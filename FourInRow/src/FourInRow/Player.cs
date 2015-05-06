using System.Drawing;

namespace FourInRow
{
	/// <summary>
	/// Summary description for Player.
	/// </summary>
	public class Player
	{
		/// <summary>
		/// constructor used when creating new Player
		/// </summary>
		public Player(int p_iId, string sPlayerName, Color p_cColor)
		{
			m_iId = p_iId;
			m_cColor = p_cColor;
			m_sPlayerName = sPlayerName;
			m_iMoves = 0;
		}
 
		private int m_iId;
		private Color m_cColor;
		private string m_sPlayerName;
		private int m_iMoves;

		/// <summary>
		/// return the name of the player
		/// </summary>
		/// <returns></returns>
		public string getPlayerName()
		{
			return m_sPlayerName;
		}

		/// <summary>
		/// return the number of moves the player has made
		/// </summary>
		/// <returns></returns>
		public int getPlayerMoves()
		{
			return m_iMoves;
		}

		/// <summary>
		/// increment the number of moves the player has made
		/// </summary>
		public void incrementPlayerMoves()
		{
			m_iMoves++;
		}

		/// <summary>
		/// set number of moves to zero
		/// </summary>
		public void resetPlayerMoves()
		{
			m_iMoves=0;
		}

		/// <summary>
		/// set a new name for the player
		/// </summary>
		/// <param name="sNewName">the new name</param>
		public void setPlayerName(string sNewName)
		{
			m_sPlayerName = sNewName;
		}

		/// <summary>
		/// return the value used on the board by the player
		/// </summary>
		/// <returns></returns>
		public int getPlayerValue()
		{
			return m_iId;
		}

		/// <summary>
		/// return the color used by the player
		/// </summary>
		/// <returns></returns>
		public Color getPlayerColor()
		{
			return m_cColor;
		}
	}
}
