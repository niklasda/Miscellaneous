using System;
using System.Drawing;
using System.Windows.Forms;

namespace FourInRow
{
	/// <summary>
	/// Summary description for BoardPositionValue.
	/// </summary>
	public class BoardPositionValue
	{
		/// <summary>
		/// constructor used when creating new BoardPositionValue
		/// </summary>
		public BoardPositionValue(Board oBoard, int iColumn, int iFreePosition, Player oPlayer)
		{
			m_iRow = iFreePosition;
			m_iColumn = iColumn;
			m_oPlayer = oPlayer;
			m_oBoard = oBoard.getBoard();

			if(m_oBoard[m_iColumn][m_iRow].isPositionFree())
			{
				m_oBoard[m_iColumn][m_iRow].setValue(m_oPlayer);

				m_iValue = calculateValue();
				m_oBoard[m_iColumn][m_iRow].resetValue();
			}
		}

		private int m_iValue;
		private int m_iRow;
		private int m_iColumn;
		private Player m_oPlayer;
		private BoardPosition[][] m_oBoard;
		private string m_ValueString;

		private int calculateValue()
		{
			int iHoriVal = calculateHorizontalValue();
			int iPotentialHoriVal = calculatePotentialHorizontalValue();
			int iVertVal = calculateVerticalValue();
			int iPotentialVertVal = calculatePotentialVerticalValue();
			int iDiagUpRightVal = calculateDiagonalUpRightValue();
			int iPotentialDiagUpRightVal = calculatePotentialDiagonalUpRightValue();
			int iDiagDownRightVal = calculateDiagonalDownRightValue();
			int iPotentialDiagDownRightVal = calculatePotentialDiagonalDownRightValue();

			int iValue = weighValues(iHoriVal, iPotentialHoriVal)+
				weighValues(iVertVal, iPotentialVertVal)+
				weighValues(iDiagUpRightVal, iPotentialDiagUpRightVal)+
				weighValues(iDiagDownRightVal, iPotentialDiagDownRightVal);

			string sValueString = "["+m_iRow+","+m_iColumn+"][H:"+iHoriVal+",V:"+iVertVal+",UR:"+iDiagUpRightVal+",DR:"+iDiagDownRightVal+"]";
			string sPotentialValueString = "[H:"+iPotentialHoriVal+",V:"+iPotentialVertVal+",UR:"+iPotentialDiagUpRightVal+",DR:"+iPotentialDiagDownRightVal+"]";
			
			m_ValueString = sValueString +""+ sPotentialValueString +"["+ iValue +"]";
			
			return iValue;
		}

		/// <summary>
		/// return intermediate values
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return m_ValueString;
		}

		private int weighValues(int iValuesInRow, int iPotentialValuesInRow)
		{
			if(iPotentialValuesInRow<Settings.c_iWinLength)
				iPotentialValuesInRow=0;

			if(iValuesInRow>=Settings.c_iWinLength)
				iValuesInRow*=2;

			return (iPotentialValuesInRow/2)+iValuesInRow*iValuesInRow;
		}

		private bool isPositionDroppable(int iColumn, int iRow)
		{
			if( (iRow==0) && m_oBoard[iColumn][iRow].isPositionFree() )
			{
				return true;
			}
			
			if( (iRow>0) && m_oBoard[iColumn][iRow].isPositionFree() && m_oBoard[iColumn][iRow-1].isPositionNotFree() )
			{
				return true;
			}

			return false;
		}

		private int calculateHorizontalValue()
		{
			int iValuesInRow=0;

			// check right
			for(int i=0; i<Settings.c_iWinLength; i++)
			{
				if( (i+m_iColumn)<Settings.c_iBoardWidth )
				{
					if(m_oBoard[i+m_iColumn][m_iRow].getValue() == m_oPlayer.getPlayerValue())
					{
						iValuesInRow++;
					}
					else
						break;
				}
			}

			// check left
			for(int i=-1; i>-Settings.c_iWinLength; i--)
			{
				if( (i+m_iColumn)>=0 )
				{
					if(m_oBoard[i+m_iColumn][m_iRow].getValue() == m_oPlayer.getPlayerValue())
					{
						iValuesInRow++;
					}
					else
						break;
				}
			}

			return iValuesInRow;
		}

		private int calculatePotentialHorizontalValue()
		{
			int iPotentialValuesInRow=0;

			// potential right
			for(int x=0; x<Settings.c_iWinLength; x++)
			{
				if( (x+m_iColumn)<Settings.c_iBoardWidth )
				{
					if( m_oBoard[x+m_iColumn][m_iRow].getValue()==m_oPlayer.getPlayerValue() )
					{
						iPotentialValuesInRow++;
					}
					else if( isPositionDroppable(x+m_iColumn, m_iRow) )
					//else if( (m_oBoard[i+m_iColumn][m_iRow].isPositionFree() && m_iRow==0) || (m_iRow>0 && m_oBoard[i+m_iColumn][m_iRow-1].getValue()!=Settings.c_iFreePositionValue) )
					{
						iPotentialValuesInRow++;
					}
					else
						break;
				}
			}

			// potential left
			for(int x=-1; x>-Settings.c_iWinLength; x--)
			{
				if( (x+m_iColumn)>=0 )
				{
					if( m_oBoard[x+m_iColumn][m_iRow].getValue()==m_oPlayer.getPlayerValue() )
					{
						iPotentialValuesInRow++;
					}
					else if( isPositionDroppable(x+m_iColumn, m_iRow) )
						//else if( (m_oBoard[i+m_iColumn][m_iRow].isPositionFree() && m_iRow==0) || (m_iRow>0 && m_oBoard[i+m_iColumn][m_iRow-1].getValue()!=Settings.c_iFreePositionValue) )
					{
						iPotentialValuesInRow++;
					}
					else
						break;
				}
			}

			return iPotentialValuesInRow;
		}

		private int calculateVerticalValue()
		{
			int iValuesInRow=0;

			// check up
			for(int i=0; i<Settings.c_iWinLength; i++)
			{
				if( (i+m_iRow)<Settings.c_iBoardHeight )
				{
					if(m_oBoard[m_iColumn][i+m_iRow].getValue() == m_oPlayer.getPlayerValue())
					{
						iValuesInRow++;
					}
					else
						break;
				}
			}

			// check down
			for(int i=-1; i>-Settings.c_iWinLength; i--)
			{
				if( (i+m_iRow)>=0 )
				{
					if(m_oBoard[m_iColumn][i+m_iRow].getValue() == m_oPlayer.getPlayerValue())
					{
						iValuesInRow++;
					}
					else
						break;
				}
			}

			return iValuesInRow;
		}

		private int calculatePotentialVerticalValue()
		{
			int iPotentialValuesInRow=0;

			// potential up
			for(int y=0; y<Settings.c_iWinLength; y++)
			{
				if( (y+m_iRow)<Settings.c_iBoardHeight )
				{
					if( m_oBoard[m_iColumn][y+m_iRow].getValue()==m_oPlayer.getPlayerValue() )
					{
						iPotentialValuesInRow++;
					}
					else if( isPositionDroppable(m_iColumn, y+m_iRow) )
						//else if( (m_oBoard[m_iColumn][i+m_iRow].isPositionFree() && (i+m_iRow)==0) || ((i+m_iRow>0) && m_oBoard[m_iColumn][i+m_iRow-1].getValue()!=Settings.c_iFreePositionValue) )
					{
						iPotentialValuesInRow++;
					}
					else
						break;
				}
			}

			// potential down
			for(int y=-1; y>-Settings.c_iWinLength; y--)
			{
				if( (y+m_iRow)>=0 )
				{
					if( m_oBoard[m_iColumn][y+m_iRow].getValue()==m_oPlayer.getPlayerValue() )
					{
						iPotentialValuesInRow++;
					}
					else if( isPositionDroppable(m_iColumn, y+m_iRow) )
						//else if( (m_oBoard[m_iColumn][i+m_iRow].isPositionFree() && (i+m_iRow)==0) || ((i+m_iRow>0) && m_oBoard[m_iColumn][i+m_iRow-1].getValue()!=Settings.c_iFreePositionValue) )
					{
						iPotentialValuesInRow++;
					}
					else
						break;
				}
			}

			return iPotentialValuesInRow;
		}	
		
		private int calculateDiagonalUpRightValue()
		{
			int iValuesInRow=0;

			// check up right
			for(int x=0, y=0; x<Settings.c_iWinLength && y<Settings.c_iWinLength; x++, y++)
			{
				if( (x+m_iColumn)<Settings.c_iBoardWidth && (y+m_iRow)<Settings.c_iBoardHeight )
				{
					if(m_oBoard[x+m_iColumn][y+m_iRow].getValue() == m_oPlayer.getPlayerValue())
					{
						iValuesInRow++;
					}
					else
						break;
				}
			}

			// check down left
			for(int x=-1, y=-1; x>-Settings.c_iWinLength && y>-Settings.c_iWinLength; x--, y--)
			{
				if( (y+m_iRow)>=0 && (x+m_iColumn)>=0 )
				{
					if(m_oBoard[x+m_iColumn][y+m_iRow].getValue() == m_oPlayer.getPlayerValue())
					{
						iValuesInRow++;
					}
					else
						break;
				}
			}

			return iValuesInRow;
		}

		private int calculatePotentialDiagonalUpRightValue()
		{
			int iPotentialValuesInRow=0;

			// potential up right
			for(int x=0, y=0; x<Settings.c_iWinLength && y<Settings.c_iWinLength; x++, y++)
			{
				if( (x+m_iColumn)<Settings.c_iBoardWidth && (y+m_iRow)<Settings.c_iBoardHeight )
				{
					if( m_oBoard[x+m_iColumn][y+m_iRow].getValue()==m_oPlayer.getPlayerValue() )
					{
						iPotentialValuesInRow++;
					}
					else if( isPositionDroppable(x+m_iColumn, y+m_iRow) )
						//else if( (m_oBoard[x+m_iColumn][y+m_iRow].isPositionFree() && (y+m_iRow)==0) || ((y+m_iRow>0) && (m_oBoard[x+m_iColumn][y+m_iRow-1].getValue()!=Settings.c_iFreePositionValue)) )
					{
						iPotentialValuesInRow++;
					}
					else
						break;
				}
			}

			// potential down left
			for(int x=-1, y=-1; x>-Settings.c_iWinLength && y>-Settings.c_iWinLength; x--, y--)
			{
				if( (y+m_iRow)>=0 && (x+m_iColumn)>=0 )
				{
					if( m_oBoard[x+m_iColumn][y+m_iRow].getValue()==m_oPlayer.getPlayerValue() )
					{
						iPotentialValuesInRow++;
					}
					else if( isPositionDroppable(x+m_iColumn, y+m_iRow) )
						//else if( (m_oBoard[x+m_iColumn][y+m_iRow].isPositionFree() && (y+m_iRow)==0) || ((y+m_iRow>0) && (m_oBoard[x+m_iColumn][y+m_iRow-1].getValue()!=Settings.c_iFreePositionValue)) )
					{
						iPotentialValuesInRow++;
					}
					else
						break;
				}
			}

			return iPotentialValuesInRow;
		}

		private int calculateDiagonalDownRightValue()
		{
			int iValuesInRow=0;

			for(int x=0, y=0; x<Settings.c_iWinLength && y<Settings.c_iWinLength; x++, y--)
			{
				if( (x+m_iColumn)<Settings.c_iBoardWidth && (y+m_iRow)>=0 )
				{
					if(m_oBoard[x+m_iColumn][y+m_iRow].getValue() == m_oPlayer.getPlayerValue())
					{
						iValuesInRow++;
					}
					else
						break;
				}
			}

			for(int x=-1, y=1; x>-Settings.c_iWinLength && y>-Settings.c_iWinLength; x--, y++)
			{
				if( (x+m_iColumn)>=0 && (y+m_iRow)<Settings.c_iBoardHeight )
				{
					if(m_oBoard[x+m_iColumn][y+m_iRow].getValue() == m_oPlayer.getPlayerValue())
					{
						iValuesInRow++;
					}
					else
						break;
				}
			}

			return iValuesInRow;
		}

		private int calculatePotentialDiagonalDownRightValue()
		{
			int iPotentialValuesInRow=0;

			for(int x=0, y=0; x<Settings.c_iWinLength && y<Settings.c_iWinLength; x++, y--)
			{
				if( (x+m_iColumn)<Settings.c_iBoardWidth && (y+m_iRow)>=0 )
				{
					if( m_oBoard[x+m_iColumn][y+m_iRow].getValue()==m_oPlayer.getPlayerValue() )
					{
						iPotentialValuesInRow++;
					}
					else if( isPositionDroppable(x+m_iColumn, y+m_iRow) )
						//else if( (m_oBoard[x+m_iColumn][y+m_iRow].isPositionFree() && (y+m_iRow)==0) || ((y+m_iRow>0) && (m_oBoard[x+m_iColumn][y+m_iRow-1].getValue()!=Settings.c_iFreePositionValue)) )
					{
						iPotentialValuesInRow++;
					}
					else
						break;
				}
			}

			for(int x=-1, y=1; x>-Settings.c_iWinLength && y>-Settings.c_iWinLength; x--, y++)
			{
				if( (x+m_iColumn)>=0 && (y+m_iRow)<Settings.c_iBoardHeight )
				{
					if( m_oBoard[x+m_iColumn][y+m_iRow].getValue()==m_oPlayer.getPlayerValue() )
					{
						iPotentialValuesInRow++;
					}
					else if( isPositionDroppable(x+m_iColumn, y+m_iRow) )
						//else if( (m_oBoard[x+m_iColumn][y+m_iRow].isPositionFree() && (y+m_iRow)==0) || ((y+m_iRow>0) && (m_oBoard[x+m_iColumn][y+m_iRow-1].getValue()!=Settings.c_iFreePositionValue)) )
					{
						iPotentialValuesInRow++;
					}
					else
						break;
				}
			}

			return iPotentialValuesInRow;
		}

		/// <summary>
		/// The value for this position for the specified player
		/// </summary>
		public int iValue
		{
			get { return m_iValue; }
		}

		/// <summary>
		/// The column this value is for
		/// </summary>
		public int iColumn
		{
			get { return m_iColumn; }
		}
	}
}
