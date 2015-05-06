using System;
using System.Drawing;
using System.Windows.Forms;

namespace FourInRow
{
	/// <summary>
	/// Class describing aposition on the board
	/// </summary>
	public class BoardPosition
	{
		private int m_iValue;
		private PictureBox m_pbBoard;
	//	private PictureBox m_pbRender;
		private FormFourInRowTable m_oForm;
		private Image m_imPlayer1;
		private Image m_imPlayer2;
		private Image m_imEmpty;

		/// <summary>
		/// constructor for a position on the board
		/// </summary>
		/// <param name="oGameForm">the board form</param>
		/// <param name="x">x coordinate</param>
		/// <param name="y">y coordinate</param>
		/// <param name="imPlayer1">image for player 1</param>
		/// <param name="imPlayer2">image for player 2</param>
		/// <param name="imEmpty">image for empty position</param>
		public BoardPosition(FormFourInRowTable oGameForm, int x, int y, Image imPlayer1, Image imPlayer2, Image imEmpty)
		{
			m_oForm = oGameForm;
			m_imPlayer1 = imPlayer1;
			m_imPlayer2 = imPlayer2;
			m_imEmpty = imEmpty;
			
			m_iValue = Settings.c_iFreePositionValue;
		
			m_pbBoard = new PictureBox();
			m_pbBoard.Tag = x.ToString();
			m_pbBoard.Location = new Point(x*48+0, y*48+40);
			m_pbBoard.Size = new Size(48, 48);
			m_pbBoard.Click += new EventHandler(m_pbBoard_Click);
		}

		/// <summary>
		/// empty this position
		/// </summary>
		public void resetValue()
		{
			m_iValue = Settings.c_iFreePositionValue;
		}

		/// <summary>
		/// is this position free
		/// </summary>
		public bool isPositionFree()
		{
			if(m_iValue == Settings.c_iFreePositionValue)
				return true;
			else
				return false;
		}

		/// <summary>
		/// is this position occupied
		/// </summary>
		public bool isPositionNotFree()
		{
			if(m_iValue != Settings.c_iFreePositionValue)
				return true;
			else
				return false;
		}

		/// <summary>
		/// set the value of a player on this board position 
		/// </summary>
		/// <param name="oPlayer">player who's value to set</param>
		public void setValue(Player oPlayer)
		{
			m_iValue = oPlayer.getPlayerValue();
		}

		/// <summary>
		/// set the value of a player on this board position and render
		/// player's image
		/// </summary>
		/// <param name="oPlayer">player who's value to set</param>
		public void setValueAndImage(Player oPlayer)
		{
			m_iValue = oPlayer.getPlayerValue();
			if(m_iValue==1)
				m_pbBoard.Image = m_imPlayer1;
			else
				m_pbBoard.Image = m_imPlayer2;
		}

		/// <summary>
		/// returns the value for this position
		/// </summary>
		/// <returns></returns>
		public int getValue()
		{
			return m_iValue;
		}

		/// <summary>
		/// add a board position control (PictureBox) to container (Panel)
		/// </summary>
		/// <param name="gbBoard">the containing control</param>
		public void addControl(Panel gbBoard)
		{
			int x = m_pbBoard.Location.X;
			int y = m_pbBoard.Location.Y;

			Image imEmpty = m_imEmpty;
			m_pbBoard.Image = imEmpty;

			m_pbBoard.Location = new Point(x, gbBoard.Height-y-24);
			gbBoard.Controls.Add(m_pbBoard);
		}

		private void m_pbBoard_Click(object sender, EventArgs e)
		{
			PictureBox pbTarget = (PictureBox)sender;
			int iColumn = int.Parse(pbTarget.Tag.ToString());

			m_oForm.doDropIfDrag(iColumn);
		}
	}
}
