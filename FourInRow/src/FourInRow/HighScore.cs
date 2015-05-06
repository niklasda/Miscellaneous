using System;
using System.Drawing;

namespace FourInRow
{
	/// <summary>
	/// Summary description for HighScore.
	/// </summary>
	public class HighScore : IComparable
	{
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="sName"></param>
		/// <param name="sGameTime"></param>
		/// <param name="sBoard"></param>
		/// <param name="iMoves"></param>
		public HighScore(string sName, string sGameTime, string sBoard, int iMoves)
		{
			m_sName = sName;
			m_sGameTime = sGameTime;
			m_sBoard = sBoard;
			m_iMoves = iMoves;
		}

		private string m_sName;
		private string m_sGameTime;
		private string m_sBoard;
		private int m_iMoves;

		/// <summary>
		/// name of player holding this score
		/// </summary>
		public string sName
		{
			get { return m_sName; }
		}

		/// <summary>
		/// the board resulting in this score
		/// </summary>
		public string sBoard
		{
			get { return m_sBoard; }
		}

		/// <summary>
		/// result time for this players score
		/// </summary>
		public string sGameTime
		{
			get { return m_sGameTime; }
		}

		/// <summary>
		/// number of moves for this players score
		/// </summary>
		public int iMoves
		{
			get { return m_iMoves; }
		}

		/// <summary>
		///  IComparable Members
		/// </summary>
		/// <param name="obj">another HighScore object to compare to</param>
		/// <returns></returns>
		public int CompareTo(object obj)
		{
			HighScore oOtherScore = (HighScore)obj;
			return m_sGameTime.CompareTo(oOtherScore.m_sGameTime);
		}
	}
}
