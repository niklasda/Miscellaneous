using System;
using System.Drawing;
using System.Windows.Forms;

namespace FourInRow
{
	/// <summary>
	/// Summary description for Game.
	/// </summary>
	public class Game
	{
		/// <summary>
		/// constructor used when creating new Game
		/// </summary>
		public Game(FormFourInRowTable oGameForm, string sPlayer1Name, string sPlayer2Name)
		{
			m_oBoard = new Board(oGameForm);
			m_arPlayers = new Player[Settings.c_iNbrOfPlayers];
			m_arPlayers[0] = new Player(1, sPlayer1Name, Color.Red);
			m_arPlayers[1] = new Player(2, sPlayer2Name, Color.Blue);
			m_iCurrentPlayer = 0;
			m_dtStart = DateTime.Now;
			m_dtEnd = DateTime.MaxValue;
		}

		private Player[] m_arPlayers;
		private int m_iCurrentPlayer;
		private Board m_oBoard;
		private bool m_bGameOver;
		private DateTime m_dtStart;
		private DateTime m_dtEnd;

		/// <summary>
		/// flag indicating if game is or should be stopped
		/// </summary>
		public bool bGameOver
		{
			get { return m_bGameOver; }
			set { m_bGameOver = value; }
		}

		/// <summary>
		/// when this game started
		/// </summary>
		public DateTime dtStart
		{
			get { return m_dtStart; }
		}

		/// <summary>
		/// when this game ended
		/// </summary>
		public DateTime dtEnd
		{
			get { return m_dtEnd; }
		}

		/// <summary>
		/// the duration of the game
		/// </summary>
		/// <returns></returns>
		public string getGameDuration()
		{
			TimeSpan tsSpann = m_dtEnd - m_dtStart;
			DateTime dtSpann = DateTime.Parse(tsSpann.ToString());
			
			return dtSpann.ToLongTimeString();
		}

		/// <summary>
		/// check if its possible to place value in specified column
		/// </summary>
		/// <param name="iColumn"></param>
		/// <returns></returns>
		public bool isDrawLegal(int iColumn)
		{
			return m_oBoard.isColumnFree(iColumn);
		}
	
		/// <summary>
		/// place value in specified column
		/// </summary>
		/// <param name="iColumn"></param>
		public void makeDraw(int iColumn)
		{
			Player oPlayer = m_arPlayers[m_iCurrentPlayer];
			m_oBoard.placeInColumn(oPlayer, iColumn);
		}

		/// <summary>
		/// check if board is full
		/// </summary>
		/// <returns></returns>
		public bool boardIsFull()
		{
			return m_oBoard.boardIsFull();
		}

		/// <summary>
		/// check if current player has won
		/// </summary>
		/// <param name="iColumn"></param>
		/// <returns></returns>
		public bool playerHasWon(int iColumn)
		{
			Player oPlayer = m_arPlayers[m_iCurrentPlayer];
			bool bWinner = m_oBoard.playerHasWon(oPlayer, iColumn);
			if(bWinner)
				m_dtEnd = DateTime.Now;
			return bWinner;
		}

		/// <summary>
		/// pass turn to next player
		/// </summary>
		public void changePlayer()
		{
			if(m_iCurrentPlayer==0)
			{
				m_iCurrentPlayer=1;
			}
			else
			{
				m_iCurrentPlayer=0;
			}
		}

		/// <summary>
		/// return current player
		/// </summary>
		/// <returns></returns>
		public Player getCurrentPlayer()
		{
			return m_arPlayers[m_iCurrentPlayer];
		}
		
		/// <summary>
		/// return non-current player
		/// </summary>
		/// <returns></returns>
		public Player getNonCurrentPlayer()
		{
			return m_arPlayers[1-m_iCurrentPlayer];
		}
		
		/// <summary>
		/// return Player 1
		/// </summary>
		/// <returns></returns>
		public Player getPlayer1()
		{
			return m_arPlayers[0];
		}

		/// <summary>
		/// return Player 2
		/// </summary>
		/// <returns></returns>
		public Player getPlayer2()
		{
			return m_arPlayers[1];
		}

		/// <summary>
		/// add textboxes to gui container
		/// </summary>
		/// <param name="gbBoard"></param>
		public void addControls(Panel gbBoard)
		{
			m_oBoard.addControls(gbBoard);
		}

		/// <summary>
		/// enable all drop buttons
		/// </summary>
		public void enableAllDropButtons()
		{
			m_oBoard.enableAllDropButtons();
		}

		/// <summary>
		/// disable all drop buttons
		/// </summary>
		public void disableAllDropButtons()
		{
			m_oBoard.disableAllDropButtons();
		}

		/// <summary>
		/// return the best column to drop in
		/// </summary>
		/// <returns></returns>
		public BoardPositionValue getBestMove(Player oPlayer)
		{
			int iMaxValue=-1;
			int iBestColumn=-1;
			BoardPositionValue[] arPositionValues = new BoardPositionValue[Settings.c_iBoardWidth];

			for(int iColumn=0; iColumn<Settings.c_iBoardWidth; iColumn++)
			{
				int iFreePosition = m_oBoard.getFreePosition(iColumn);

				BoardPositionValue oPositionValue = null;
				if(iFreePosition>=0 && iFreePosition<Settings.c_iBoardHeight)
				{
					oPositionValue = new BoardPositionValue(m_oBoard, iColumn, iFreePosition, oPlayer);
				}

				arPositionValues[iColumn] = oPositionValue;
			}

			for(int iColumn=0; iColumn<Settings.c_iBoardWidth; iColumn++)
			{
				BoardPositionValue oPositionValue = arPositionValues[iColumn];

				if( (oPositionValue!=null) && (oPositionValue.iValue>iMaxValue) )
				{
					iMaxValue = oPositionValue.iValue;
					iBestColumn = iColumn;
				}
			}

			return arPositionValues[iBestColumn];
		}
	}
}
