using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DiaryMaster
{
	/// <summary>
	/// Loads and saves settings
	/// </summary>
	public sealed class Settings
	{
		/// <summary>
		/// private constructor since all members are static
		/// </summary>
		private Settings()
		{}

		/// <summary>
		/// Name of file to serialize MRU to
		/// </summary>
		public static readonly string sMruDataFileName = "MRUDataFile.dat";

		/// <summary>
		/// Name of application including version number. Used in titlebars.
		/// </summary>
		public static readonly string sApplicationName = "Diary master v1.00";

		/// <summary>
		/// Should the diary entries be encrypted in file
		/// </summary>
		public static bool bUseEncryption = true;

		/// <summary>
		/// Check if a file exists and is writable
		/// </summary>
		/// <param name="sFileName">Name of file to check</param>
		/// <returns>True if file exists and is writable</returns>
		public static bool isFileWritable(string sFileName)
		{
			FileInfo oInfo = new FileInfo(sFileName);

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

		private static string generateXml(DiaryDayDictionary dicDiaryDays, string sDatelessNote)
		{
			if(dicDiaryDays!=null)
			{
				StringBuilder sXmlDocBuilder=new StringBuilder("<diarymaster>\n<days>\n");

				foreach(DictionaryEntry oDayEntry in dicDiaryDays)
				{
					DiaryDay oDay = (DiaryDay)oDayEntry.Value;

					if(oDay.dicEntries.Count>0)
					{
						sXmlDocBuilder.Append("<day ");
						sXmlDocBuilder.Append("date=\""+ oDay.dtEntryDate.ToFileTime().ToString() +"\">");

						foreach(DictionaryEntry oEntry in oDay.dicEntries)
						{
							DiaryEntry oDiaryEntry = (DiaryEntry)oEntry.Value;
				
							string sXmlSafeEntry = Encrypter.Encrypt(oDiaryEntry.sEntry);
							//	string sXmlSafeEntry = oDiaryEntry.sEntry.Replace("<","&lt;").Replace(">","&gt;").Replace("\"","&quot;");

							sXmlDocBuilder.Append("<entry ");
							sXmlDocBuilder.Append("id=\""+ oDiaryEntry.iEntryId.ToString() +"\" ");
							sXmlDocBuilder.Append("entry=\""+ sXmlSafeEntry +"\" ");
							sXmlDocBuilder.Append("recurring=\""+ ((int)oDiaryEntry.eRecurring).ToString() +"\" ");
							sXmlDocBuilder.Append("/>");
						}
						

						sXmlDocBuilder.Append("</day>\r\n");
					}
				}

				string sXmlSafeNote = Encrypter.Encrypt(sDatelessNote);
				//		string sXmlSafeNote = sDatelessNote.Replace("<","&lt;").Replace(">","&gt;").Replace("\"","&quot;");

				sXmlDocBuilder.Append("</days>");
				sXmlDocBuilder.Append("<datelessnotes>\n");
				sXmlDocBuilder.Append("<datelessnote note=\""+ sXmlSafeNote +"\"/>\n");
				sXmlDocBuilder.Append("</datelessnotes>\n");
				sXmlDocBuilder.Append("</diarymaster>\n");

				return sXmlDocBuilder.ToString();
			}
			return "";
		}

		/// <summary>
		/// write the password dictionary to file
		/// </summary>
		/// <param name="dicDiaryDays"></param>
		/// <param name="sDatelessNote"></param>
		/// <param name="sSettingsFileName"></param>
		public static void WriteDiaryDays(DiaryDayDictionary dicDiaryDays, string sDatelessNote, string sSettingsFileName)
		{
			try
			{
				string sXml = generateXml(dicDiaryDays, sDatelessNote);
				
				if(sXml.Length>0)
				{
					XmlDocument oXmlDocument = new XmlDocument();
					oXmlDocument.PreserveWhitespace=true;
					oXmlDocument.LoadXml(sXml); // throws if not XML

					DialogResult eResult = DialogResult.No;
					if(!isFileWritable(sSettingsFileName))
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
						MessageBox.Show("Error writing diary xml to "+ sSettingsFileName +"\n\n"+ ex.ToString(), Settings.sApplicationName);
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
				MessageBox.Show("Error writing diary xml to "+ sSettingsFileName +"\n\n"+ ex.ToString(), Settings.sApplicationName);
			}
		}

		/// <summary>
		/// returns first line of a multiline text
		/// </summary>
		/// <param name="sNote"></param>
		/// <returns></returns>
		public static string GetFirstLine(string sNote)
		{
			int NewLinePosition = sNote.IndexOf("\n");
			string FirstLine = sNote;
			
			if(NewLinePosition>0)
			{
				FirstLine = sNote.Substring(0,NewLinePosition);
			}

			return FirstLine;
		}

		/// <summary>
		/// Read diary entries from file
		/// </summary>
		/// <param name="sSettingsFileName"></param>
		/// <returns>Dictionary containing diary entries</returns>
		public static DiaryDayDictionary ReadDiaryDays(string sSettingsFileName)
		{
			int iId;
			string sEntry;
			DateTime dtDate;
			Recurrance eRecurring;
			DiaryDayDictionary dicDiaryDays = new DiaryDayDictionary();

			if(!isFileWritable(sSettingsFileName))
				MessageBox.Show("File "+ sSettingsFileName +" read only", Settings.sApplicationName);

			string sDiary="";
			StreamReader myStream=null;
			try
			{
				if((myStream = new StreamReader(sSettingsFileName)) != null)
				{
					sDiary =  myStream.ReadToEnd();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error reading diary xml from "+ sSettingsFileName +"\n\n"+ ex.ToString(), Settings.sApplicationName );
			}
			finally
			{
				if(myStream!=null)
					myStream.Close();
			}

			if(sDiary.Length>0)
			{
				XmlDocument oXmlDocument = new XmlDocument();
				oXmlDocument.LoadXml(sDiary); // throws if not XML

				XmlElement currDayElement = oXmlDocument.DocumentElement["days"];
			
				if(currDayElement!=null)
				{
					XmlElement currEntryElement;
					currDayElement = currDayElement["day"];

					while(currDayElement!=null && (currDayElement.NodeType==XmlNodeType.Element) && currDayElement.HasAttributes)
					{
						try
						{
							dtDate = DateTime.FromFileTime(long.Parse(currDayElement.Attributes["date"].Value));
							DiaryDay oDay = new DiaryDay(dtDate);
						
							if(currDayElement.HasChildNodes)
							{
								currEntryElement = currDayElement["entry"];
								while(currEntryElement!=null && (currEntryElement.NodeType==XmlNodeType.Element) && currEntryElement.HasAttributes)
								{
									iId = int.Parse(currEntryElement.Attributes["id"].Value);
									sEntry =  Encrypter.Decrypt(currEntryElement.Attributes["entry"].Value);
									//	sEntry =  currEntryElement.Attributes["entry"].Value;
									eRecurring = (Recurrance)int.Parse(currEntryElement.Attributes["recurring"].Value);
						
									DiaryEntry oEntry = new DiaryEntry(iId, sEntry, eRecurring);
									oDay.AddEntry(oEntry);

									currEntryElement = (XmlElement)currEntryElement.NextSibling;
								}
							}
						
							dicDiaryDays.Add(oDay);
						}
						catch(Exception ex)
						{
							MessageBox.Show("Error reading diary xml from "+ sSettingsFileName +"\nline: "+ currDayElement.Name +"\n\n"+ ex.ToString(), Settings.sApplicationName );
						}
				
						currDayElement = (XmlElement)currDayElement.NextSibling;
					}
				}
			}

			return dicDiaryDays;
		}

	
		/// <summary>
		/// Read diary entries from file
		/// </summary>
		/// <returns>Dictionary containing diary entries</returns>
		public static string ReadDatelessNote(string sSettingsFileName)
		{
			if(!isFileWritable(sSettingsFileName))
				MessageBox.Show("File "+ sSettingsFileName +" read only", Settings.sApplicationName);

			string sDateless="";
			StreamReader myStream=null;
			try
			{
				if((myStream = new StreamReader(sSettingsFileName)) != null)
				{
					sDateless = myStream.ReadToEnd();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error reading diary xml from "+ sSettingsFileName +"\n\n"+ ex.ToString(), Settings.sApplicationName );
			}
			finally
			{
				if(myStream!=null)
					myStream.Close();
			}

			string sDatelessNote = "";
			if(sDateless.Length>0)
			{
				XmlDocument oXmlDocument = new XmlDocument();
				oXmlDocument.LoadXml(sDateless); // throws if not XML

				XmlElement currDatelessElement = oXmlDocument.DocumentElement["datelessnotes"];

				if(currDatelessElement!=null)
				{
					currDatelessElement = currDatelessElement["datelessnote"];

					if(currDatelessElement!=null && (currDatelessElement.NodeType==XmlNodeType.Element) && currDatelessElement.HasAttributes)
					{
						sDatelessNote = Encrypter.Decrypt(currDatelessElement.Attributes["note"].Value);
						//	sDatelessNote = currDatelessElement.Attributes["note"].Value;
 				
					}
				}
			}

			return sDatelessNote;
		}
	}
}