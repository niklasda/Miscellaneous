using System.Drawing;
using System.Windows.Forms;

namespace FourInRow
{
	/// <summary>
	/// Summary description for Board.
	/// </summary>
	public class Board
	{
		/// <summary>
		/// constructor used when creating new Board
		/// </summary>
		public Board(FormFourInRowTable oGameForm)
		{
			m_oForm = oGameForm;

			m_oDropButtons = new Button[Settings.c_iBoardWidth];
			m_mxBoard = new BoardPosition[Settings.c_iBoardWidth][];
			for( int i=0; i<Settings.c_iBoardWidth; i++)
			{
				m_mxBoard[i] = new BoardPosition[Settings.c_iBoardHeight];
			}

			for(int x=0; x<Settings.c_iBoardWidth; x++)
			{
				for(int y=0; y<Settings.c_iBoardHeight; y++)
				{
					m_mxBoard[x][y] = new BoardPosition(oGameForm, x, y, m_oForm.getPlayer1Image(), m_oForm.getPlayer2Image(), m_oForm.getEmptyImage());
				}
			}
		}

		private FormFourInRowTable m_oForm;
		private BoardPosition[][] m_mxBoard;
		private Button[] m_oDropButtons;

		/// <summary>
		/// The Board positions matrix
		/// </summary>
		/// <returns></returns>
		public BoardPosition[][] getBoard()
		{
			return m_mxBoard;
		}

		/// <summary>
		/// get the free position in this column
		/// if no position is free c_iBoardWidth is returned
		/// </summary>
		/// <param name="iColumn">column to check</param>
		/// <returns></returns>
		public int getFreePosition(int iColumn)
		{
			int iFreePosition=0;
			if(iColumn>=0 && iColumn<Settings.c_iBoardWidth)
			{
				BoardPosition[] arColumn = m_mxBoard[iColumn];
				
				for(iFreePosition=0; iFreePosition<Settings.c_iBoardHeight; iFreePosition++)
				{
					if(arColumn[iFreePosition].getValue()==Settings.c_iFreePositionValue)
						break;
				}
			}
			return iFreePosition;
		}

		/// <summary>
		/// check if a position is available in the specified column
		/// </summary>
		/// <param name="iColumn">column to check</param>
		/// <returns></returns>
		public bool isColumnFree(int iColumn)
		{
			if(iColumn>=0 && iColumn<Settings.c_iBoardWidth)
			{
				int iFreePosition = getFreePosition(iColumn);

				if(iFreePosition>=0 && iFreePosition<Settings.c_iBoardHeight)
				{
					return true;
				}
			}
			
			return false;
		}
	
		/// <summary>
		/// place value in specified column
		/// </summary>
		/// <param name="oPlayer">player to put</param>
		/// <param name="iColumn">column to place in</param>
		public void placeInColumn(Player oPlayer, int iColumn)
		{
			int iFreePosition = getFreePosition(iColumn);

			if(iFreePosition>=0 && iFreePosition<Settings.c_iBoardHeight)
			{
				BoardPosition[] arColumn = m_mxBoard[iColumn];
				arColumn[iFreePosition].setValueAndImage(oPlayer);
				oPlayer.incrementPlayerMoves();
			}
		}

		/// <summary>
		/// check if the board is full
		/// </summary>
		/// <returns></returns>
		public bool boardIsFull()
		{
			for(int x=0; x<Settings.c_iBoardWidth; x++)
			{
				for(int y=0; y<Settings.c_iBoardHeight; y++)
				{
					if(m_mxBoard[x][y].getValue()==Settings.c_iFreePositionValue)
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// add textboxed to the gui container
		/// </summary>
		/// <param name="gbBoard"></param>
		public void addControls(Panel gbBoard)
		{
			gbBoard.SuspendLayout();
			gbBoard.Controls.Clear();
			for(int x=0; x<Settings.c_iBoardWidth; x++)
			{
				addDropButton(gbBoard, x);
				for(int y=0; y<Settings.c_iBoardHeight; y++)
				{
					m_mxBoard[x][y].addControl(gbBoard);
				}
			}
			gbBoard.ResumeLayout();
		}

		private void addDropButton(Control gbBoard, int iColumn)
		{
			Button oButton = new Button();
			oButton.FlatStyle = FlatStyle.System;
			oButton.Location = new Point(iColumn*48+0, 0);
			oButton.Size = new Size(46, 24);
			oButton.Tag = iColumn.ToString();
			oButton.Text = "drop &"+ (iColumn+1);
			oButton.Click += new System.EventHandler(this.btnDrop_Click);

			m_oDropButtons[iColumn]=oButton;
			gbBoard.Controls.Add(oButton);
		}

		private void btnDrop_Click(object sender, System.EventArgs e)
		{
			Button oButton = (Button)sender;
			int iColumn = int.Parse(oButton.Tag.ToString());
			if(!m_oForm.doDrop(iColumn))
			{
				// print faulty move
			}
			else
			{
				// ok 
			}
		}

		/// <summary>
		/// enable all drop buttons
		/// </summary>
		public void enableAllDropButtons()
		{
			for(int i=0; i<Settings.c_iBoardWidth; i++)
			{
				m_oDropButtons[i].Enabled=true;
			}
		}

		/// <summary>
		/// disable all drop buttons
		/// </summary>
		public void disableAllDropButtons()
		{
			for(int i=0; i<Settings.c_iBoardWidth; i++)
			{
				m_oDropButtons[i].Enabled=false;
			}
		}

		/// <summary>
		/// check if specified player has won
		/// </summary>
		/// <param name="oPlayer"></param>
		/// <param name="iColumn"></param>
		/// <returns></returns>
		public bool playerHasWon(Player oPlayer, int iColumn)
		{
			if(verticalWin(oPlayer.getPlayerValue(), iColumn))
				return true;

			if(HorizontalWin(oPlayer.getPlayerValue(), iColumn))
				return true;

			if(DiagonalWin(oPlayer.getPlayerValue(), iColumn))
				return true;

			return false;
		}

		private bool verticalWin(int iValue, int iColumn)
		{
			int iValuesInRow=0;
			BoardPosition[] arColumn = m_mxBoard[iColumn];
			for(int y=0; y<Settings.c_iBoardHeight; y++)
			{
				if(arColumn[y].getValue()==iValue)
					iValuesInRow++;
				else
					iValuesInRow=0;

				if(iValuesInRow>=Settings.c_iWinLength)
					return true;
			}

			return false;
		}

		private bool HorizontalWin(int iValue, int iColumn)
		{
			BoardPosition[] arColumn = m_mxBoard[iColumn];
			for(int y=Settings.c_iBoardHeight-1; y>=0; y--)
			{
				if(arColumn[y].getValue()==iValue)
				{
					int iValuesInRow=0;
					for(int x=0; x<Settings.c_iBoardWidth; x++)
					{
						if(m_mxBoard[x][y].getValue()==iValue)
							iValuesInRow++;
						else
							iValuesInRow=0;

						if(iValuesInRow>=Settings.c_iWinLength)
							return true;
					}
					return false;
				}
			}

			return false;
		}

		private bool DiagonalWin(int iValue, int iColumn)
		{
			if(DiagonalWinDownRight(iValue, iColumn))
				return true;

			if(DiagonalWinUpRight(iValue, iColumn))
				return true;

			return false;
		}

		private bool DiagonalWinDownRight(int iValue, int iColumn)
		{
			int ix=iColumn;
			int iy=getFreePosition(iColumn)-1;
			int iValuesInRow=0;
			for(int x=0, y=iy+ix; x<=iy+ix && y>=0; x++, y--)
			{
				if(x>=0 && y>=0 && x<Settings.c_iBoardWidth && y<Settings.c_iBoardHeight)
				{
					if(m_mxBoard[x][y].getValue()==iValue)
						iValuesInRow++;
					else
						iValuesInRow=0;

					if(iValuesInRow>=Settings.c_iWinLength)
						return true;
				}
			}

			return false;
		}

		private bool DiagonalWinUpRight(int iValue, int iColumn)
		{
			int ix=iColumn;
			int iy=getFreePosition(iColumn)-1;
			int iValuesInRow=0;
			for(int y=0, x=ix-iy; x<=Settings.c_iBoardWidth && y<=Settings.c_iBoardHeight; x++, y++)
			{
				if(x>=0 && y>=0 && x<Settings.c_iBoardWidth && y<Settings.c_iBoardHeight)
				{
					if(m_mxBoard[x][y].getValue()==iValue)
						iValuesInRow++;
					else
						iValuesInRow=0;

					if(iValuesInRow>=Settings.c_iWinLength)
						return true;
				}
			}

			return false;
		}
	}
}
