using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PasswordManager
{
	/// <summary>
	/// Load and save settings
	/// </summary>
	public sealed class Settings
	{
		/// <summary>
		/// Constructor
		/// </summary>
		private Settings()
		{}

		/// <summary>
		/// Name of application including version number. Used in titlebars.
		/// </summary>
		public static readonly string sApplicationName = "Password manager v1.00";

		/// <summary>
		/// Name of file to serialize MRU to
		/// </summary>
		public static readonly string sMruDataFileName = "MRUDataFile.dat";

		/// <summary>
		/// Should passwords be shown in GUI or ******
		/// </summary>
		public static bool bShowPasswords = true;

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

		private static string generateXml(PasswordDictionary dicPasswords)
		{
			if(dicPasswords!=null)
			{
				StringBuilder sXmlDocBuilder=new StringBuilder("<passwordmanager>\n<passwords>\n");

				foreach(DictionaryEntry oEntry in dicPasswords)
				{
					Password oNote = (Password)oEntry.Value;

					string sXmlSafeUsername = Encrypter.Encrypt(oNote.sUsername);
					string sXmlSafePassword = Encrypter.Encrypt(oNote.sPassword);
					string sXmlSafeUrl = Encrypter.Encrypt(oNote.sUrl);
					string sXmlSafeDescription = Encrypter.Encrypt(oNote.sDescription);

					sXmlDocBuilder.Append("<password ");
					sXmlDocBuilder.Append("id=\""+ oNote.iPasswordId +"\" ");
					sXmlDocBuilder.Append("title=\""+ oNote.sTitle +"\" ");
					sXmlDocBuilder.Append("description=\""+ sXmlSafeDescription +"\" ");
					sXmlDocBuilder.Append("username=\""+ sXmlSafeUsername +"\" ");
					sXmlDocBuilder.Append("password=\""+ sXmlSafePassword +"\" ");
					sXmlDocBuilder.Append("category=\""+ oNote.sCategory +"\" ");
					sXmlDocBuilder.Append("url=\""+ sXmlSafeUrl +"\" ");

					sXmlDocBuilder.Append("/>\r\n");
				}
			
				sXmlDocBuilder.Append("</passwords>\n</passwordmanager>\n");
				return sXmlDocBuilder.ToString();
			}
			return "";
		}

		/// <summary>
		/// write the password dictionary to file
		/// </summary>
		/// <param name="dicPasswords">Dictionary of Passwords to save</param>
		/// <param name="sSettingsFileName">Filename to write to</param>
		public static void WritePasswords(PasswordDictionary dicPasswords, string sSettingsFileName)
		{
			try
			{
				string sXml = generateXml(dicPasswords);
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
				MessageBox.Show("Error writing password xml to "+ sSettingsFileName +"\n\n"+ ex.ToString(), Settings.sApplicationName);
			}
		}

		/// <summary>
		/// Read passwords from file
		/// </summary>
		/// <param name="sSettingsFileName">Filename to read from</param>
		/// <returns>Dictionary containing passwords</returns>
		public static PasswordDictionary ReadPasswords(string sSettingsFileName)
		{
			int iId;
			string sTitle;
			string sDescription;
			string sUsername;
			string sPassword;
			string sUrl;
			string sCategory;
			PasswordDictionary dicPasswords = new PasswordDictionary();

			if(!isFileWritable(sSettingsFileName))
			{
				MessageBox.Show("File "+ sSettingsFileName +" does not exist or is read only", Settings.sApplicationName);
			}
			else
			{
				string sPasswords="";
				StreamReader myStream=null;
				try
				{
					if((myStream = new StreamReader(sSettingsFileName)) != null)
					{
						sPasswords = myStream.ReadToEnd();
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error reading password xml from "+ sSettingsFileName +"\n\n"+ ex.ToString(), Settings.sApplicationName);
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

					XmlElement currElement = oXmlDocument.DocumentElement["passwords"];
					currElement = currElement["password"];

					while(currElement!=null && currElement.HasAttributes)
					{
						if((currElement.NodeType==XmlNodeType.Element) && currElement.HasAttributes)
						{
							try
							{
								iId = int.Parse(currElement.Attributes["id"].Value);
								sTitle = currElement.Attributes["title"].Value;
								sDescription = Encrypter.Decrypt(currElement.Attributes["description"].Value);
								sUsername = Encrypter.Decrypt(currElement.Attributes["username"].Value);
								sPassword = Encrypter.Decrypt(currElement.Attributes["password"].Value);
								sCategory = currElement.Attributes["category"].Value;
								sUrl = Encrypter.Decrypt(currElement.Attributes["url"].Value);
												
								Password oNote = new Password(iId, sTitle, sDescription, sUsername, sPassword, sUrl, sCategory);
								dicPasswords.Add(oNote);
							}
							catch(Exception ex)
							{
								MessageBox.Show("Error reading password xml from "+ sSettingsFileName +"\nline: "+ currElement.Name +"\n\n"+ ex.ToString(), Settings.sApplicationName );
							}
						}

						currElement = (XmlElement) currElement.NextSibling;
					}
				}
			}

			return dicPasswords;
		}
	}
}