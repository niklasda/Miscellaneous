using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace FourInRow
{
	/// <summary>
	/// Class used.
	/// </summary>
	public sealed class Settings
	{
		private Settings()
		{
		}

		/// <summary>
		/// name of the application including version number. Used in titlebars.
		/// </summary>
		public static readonly string sApplicationName = "Four-In-A-Row v1.00";
		
		/// <summary>
		/// Name of file to save notes to. 
		/// </summary>
		public static readonly string sSettingsFileName = "FourInRowSettings.xml";

		/// <summary>
		/// number of players for this game (do absolutely not change)
		/// </summary>
		public static readonly int c_iNbrOfPlayers=2;
		
		/// <summary>
		/// width of the board for this game (do rather not change)
		/// allowed values are 7 and 8
		/// </summary>
		public static int c_iBoardWidth=7;
		
		/// <summary>
		/// height of the board for this game (do rather not change)
		/// allowed values are 6 and 7
		/// </summary>
		public static int c_iBoardHeight=6;
		
		/// <summary>
		/// value in free positions on the board
		/// do not change to any value user by the players (1 or 2)
		/// </summary>
		public static readonly int c_iFreePositionValue=-1;

		/// <summary>
		/// number of values in a row to win
		/// </summary>
		public static int c_iWinLength=4;

		/// <summary>
		/// Check if a file exists and is writable
		/// </summary>
		/// <param name="sFilename">Name of file to check</param>
		/// <returns>True if file exists and is writable</returns>
		public static bool isFileWritable(string sFilename)
		{
			FileInfo oInfo = new FileInfo(sFilename);

			if(oInfo.Exists && (oInfo.Attributes&FileAttributes.ReadOnly)==0)
				return true;
			else
				return false;
		}

		private static void makeWritable(string sFileName)
		{
			FileInfo oInfo = new FileInfo(sFileName);

			if(oInfo.Exists && (oInfo.Attributes&FileAttributes.ReadOnly)!=0)
				oInfo.Attributes = FileAttributes.Normal;
		}

		private static string generateXml(HighScoresDictionary dicHighScores, string sPlayer1Name, string sPlayer2Name)
		{
			if(dicHighScores!=null)
			{
				StringBuilder sXmlDocBuilder=new StringBuilder("<fourinrow>\n<players>\n");
				sXmlDocBuilder.Append("<player ");
				sXmlDocBuilder.Append("id=\"1\" ");
				sXmlDocBuilder.Append("name=\""+ sPlayer1Name +"\" ");
				sXmlDocBuilder.Append("/>\r\n");
				sXmlDocBuilder.Append("<player ");
				sXmlDocBuilder.Append("id=\"2\" ");
				sXmlDocBuilder.Append("name=\""+ sPlayer2Name +"\" ");
				sXmlDocBuilder.Append("/>\r\n");
				sXmlDocBuilder.Append("</players>\r\n");

				sXmlDocBuilder.Append("<highscores>\n");

				foreach(HighScore oHighScore in dicHighScores)
				{
					string sXmlSafeName = Encrypter.Encrypt(oHighScore.sName);
					string sXmlSafeTime = Encrypter.Encrypt(oHighScore.sGameTime);
					string sXmlSafeBoard = Encrypter.Encrypt(oHighScore.sBoard);
					string sXmlSafeMoves = Encrypter.Encrypt(oHighScore.iMoves.ToString());

					sXmlDocBuilder.Append("<highscore ");
					sXmlDocBuilder.Append("name=\""+ sXmlSafeName +"\" ");
					sXmlDocBuilder.Append("gametime=\""+ sXmlSafeTime +"\" ");
					sXmlDocBuilder.Append("board=\""+ sXmlSafeBoard +"\" ");
					sXmlDocBuilder.Append("moves=\""+ sXmlSafeMoves +"\" ");
					sXmlDocBuilder.Append("/>\r\n");
				}
			
				sXmlDocBuilder.Append("</highscores>\n</fourinrow>\n");
				return sXmlDocBuilder.ToString();
			}
			return "";
		}

		/// <summary>
		/// write the password dictionary to file
		/// </summary>
		/// <param name="dicPasswords">Dictionary of Passwords to save</param>
		/// <param name="sPlayer1Name">name of player 1</param>
		/// <param name="sPlayer2Name">name of player 2</param>
		public static void saveHighScores(HighScoresDictionary dicPasswords, string sPlayer1Name, string sPlayer2Name)
		{
			try
			{
				string sXml = generateXml(dicPasswords, sPlayer1Name, sPlayer2Name);
				if(sXml.Length>0)
				{
					XmlDocument oXmlDocument = new XmlDocument();
					oXmlDocument.PreserveWhitespace=true;
					oXmlDocument.LoadXml(sXml); // throws if not XML

					DialogResult eResult = DialogResult.No;
					if(!isFileWritable(Settings.sSettingsFileName))
						eResult = MessageBox.Show("Settings file is read only. Do you want to make it writable?", Settings.sApplicationName, MessageBoxButtons.YesNoCancel);

					if(eResult == DialogResult.Yes)
						makeWritable(sSettingsFileName);

					else if(eResult == DialogResult.Cancel)
						return;

					
					StreamWriter myStream=null;
					try
					{
						if((myStream = new StreamWriter(sSettingsFileName)) != null)
						{
							myStream.Write(oXmlDocument.OuterXml);
						}
					}
					catch(Exception ex)
					{
						MessageBox.Show("Error writing password xml to "+ sSettingsFileName +"\n\n"+ ex.ToString(), Settings.sApplicationName);
					}
					finally
					{
						if(myStream!=null)
							myStream.Close();
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error writing high scores xml to "+ sSettingsFileName +"\n\n"+ ex.ToString(), Settings.sApplicationName);
			}
		}

		/// <summary>
		/// Read high scores from file
		/// </summary>
		/// <param name="sPlayer1Name">out name of player 1</param>
		/// <param name="sPlayer2Name">out name of player 2</param>
		/// <returns>Dictionary containing high scores</returns>
		public static HighScoresDictionary loadHighScores(out string sPlayer1Name, out string sPlayer2Name)
		{
			sPlayer1Name = ""; 
			sPlayer2Name = "";

			int iId;
			string sName;
			string sBoard;
			string sGameTime;
			int iMoves;
			HighScoresDictionary dicHighScores = new HighScoresDictionary();

			if(!isFileWritable(Settings.sSettingsFileName))
			{
				MessageBox.Show("File "+ Settings.sSettingsFileName +" does not exist or is read only", Settings.sApplicationName);
			}
			else
			{
				string sPasswords="";
				StreamReader myStream=null;
				try
				{
					if((myStream = new StreamReader(Settings.sSettingsFileName)) != null)
					{
						sPasswords = myStream.ReadToEnd();
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error reading password xml from "+ Settings.sSettingsFileName +"\n\n"+ ex.ToString(), Settings.sApplicationName);
				}
				finally
				{
					if(myStream!=null)
						myStream.Close();
				}

				if(sPasswords.Length>0)
				{
					XmlDocument oXmlDocument = new XmlDocument();
					oXmlDocument.LoadXml(sPasswords); // throws if not XML

					XmlElement currElement = oXmlDocument.DocumentElement["players"];
					currElement = currElement["player"];

					while(currElement!=null && currElement.HasAttributes)
					{
						if((currElement.NodeType==XmlNodeType.Element) && currElement.HasAttributes)
						{
							try
							{
								iId = int.Parse(currElement.Attributes["id"].Value);
								sName = currElement.Attributes["name"].Value;
								
								if(iId==1)
									sPlayer1Name = sName;
								if(iId==2)
									sPlayer2Name = sName;
							}
							catch(Exception ex)
							{
								MessageBox.Show("Error reading high scores xml from "+ sSettingsFileName +"\nline: "+ currElement.Name +"\n\n"+ ex.ToString(), Settings.sApplicationName );
							}
						}

						currElement = (XmlElement) currElement.NextSibling;
					}



					currElement = oXmlDocument.DocumentElement["highscores"];
					currElement = currElement["highscore"];

					while(currElement!=null && currElement.HasAttributes)
					{
						if((currElement.NodeType==XmlNodeType.Element) && currElement.HasAttributes)
						{
							try
							{
								sName = Encrypter.Decrypt(currElement.Attributes["name"].Value);
								sGameTime = Encrypter.Decrypt(currElement.Attributes["gametime"].Value);
								sBoard = Encrypter.Decrypt(currElement.Attributes["board"].Value);
								iMoves = int.Parse(Encrypter.Decrypt(currElement.Attributes["moves"].Value));

								HighScore oHighScore = new HighScore(sName, sGameTime, sBoard, iMoves);
								dicHighScores.Add(oHighScore);
							}
							catch(Exception ex)
							{
								MessageBox.Show("Error reading high scores xml from "+ sSettingsFileName +"\nline: "+ currElement.Name +"\n\n"+ ex.ToString(), Settings.sApplicationName );
							}
						}

						currElement = (XmlElement) currElement.NextSibling;
					}
				}
			}

			return dicHighScores;
		}
	}
}
