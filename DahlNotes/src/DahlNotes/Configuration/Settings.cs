using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DahlNotes.Notes;

namespace DahlNotes.Configuration
{
    /// <summary>
    /// Class used to load and save settings to an XML file.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// name of the application including version number. Used in title-bars.
        /// </summary>
        public const string ApplicationName = "DahlNotes v1.8";

        /// <summary>
        /// Name of file to save notes to. 
        /// </summary>
        private static readonly string SettingsFileName = string.Format("DahlNotesSettings_{0}.xml", Environment.MachineName);

        private const string SharedSettingsFileName = "DahlNotesSettings_Shared.xml";

        /// <summary>
        /// Write a dictionary of notes to file
        /// </summary>
        /// <param name="dicNotes">the notes to save</param>
        /// <returns>True if saved, false if no need to save</returns>
        public static bool WriteNotes(IdNotesDictionary dicNotes)
        {
            try
            {
                string xml = GenerateXml(dicNotes);
                if (xml.Length > 0)
                {
                    var oldXml = File.ReadAllText(SettingsFileName);

                    var xmlDocument = new XmlDocument();
                    xmlDocument.PreserveWhitespace = true;
                    xmlDocument.LoadXml(xml);

                    if (oldXml.Equals(xmlDocument.OuterXml))
                    {
                        return false;
                    }

                    using (var myStream = new StreamWriter(SettingsFileName))
                    {
                        myStream.Write(xmlDocument.OuterXml);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing notes xml to " + SettingsFileName + Environment.NewLine + ex.Message, ApplicationName);
            }

            return false;
        }

        /// <summary>
        /// Read all notes, machine specific + shared
        /// </summary>
        /// <returns></returns>
        public static IdNotesDictionary ReadAllNotes()
        {
            var notes = ReadNotes(SettingsFileName);
            var sharedNotes = ReadSharedNotes(SharedSettingsFileName);

            return notes.AddSharedNotes(sharedNotes);
        }

        /// <summary>
        /// Read all notes, machine specific + shared + extra
        /// </summary>
        /// <returns></returns>
        public static IdNotesDictionary ReadAllNotes(string extraNoteFile)
        {
            var extraNotes = ReadSharedNotes(extraNoteFile);
            var notes = ReadNotes(SettingsFileName);
            var sharedNotes = ReadSharedNotes(SharedSettingsFileName);

            return notes.AddSharedNotes(sharedNotes).AddSharedNotes(extraNotes);
        }

        private static IdNotesDictionary ReadSharedNotes(string fileName)
        {
            var notes = ReadNotes(fileName);
            foreach (KeyValuePair<int, Note> kvpNote in notes.TheNotes)
            {
                kvpNote.Value.IsReadOnly = true;
            }

            return notes;
        }

        /// <summary>
        /// Read notes from file to dictionary
        /// </summary>
        /// <returns>a dictionary of notes</returns>
        private static IdNotesDictionary ReadNotes(string fileName)
        {
            var dicNotes = new IdNotesDictionary();
            XmlTextReader reader = null;
            try
            {
                var allErrors = new StringBuilder();
                reader = new XmlTextReader(fileName);

                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && reader.HasAttributes)
                    {
                        try
                        {
                            int iId = int.Parse(reader["id"]);
                            int iOpacity = int.Parse(reader["opacity"]);
                            bool bAlwaysOnTop = bool.Parse(reader["alwaysontop"]);
                            string sNote = reader["note"];
                            Color cBackColor = Color.FromArgb(int.Parse(reader["backcolor"]));
                            Color cTextColor = Color.FromArgb(int.Parse(reader["textcolor"]));

                            Font oFont;
                            if (reader["textfontfamily"] != null && reader["textfontpointsize"] != null)
                            {
                                // some fonts does not support style = regular
                                var eStyle = (FontStyle)Enum.Parse(typeof(FontStyle), reader["textfontstyle"]);

                                oFont = new Font(reader["textfontfamily"], float.Parse(reader["textfontpointsize"]), eStyle);
                            }
                            else
                            {
                                oFont = new Font("Microsoft Sans Serif", 9F);
                            }

                            int iX = int.Parse(reader["top"]);
                            int iY = int.Parse(reader["left"]);
                            int iW = int.Parse(reader["width"]);
                            int iH = int.Parse(reader["height"]);
                            bool bStartOpened = bool.Parse(reader["startopened"]);

                            var oNote = new Note(iId, sNote, cBackColor, cTextColor, oFont, iOpacity, bAlwaysOnTop, iX, iY, iW, iH, bStartOpened);

                            dicNotes.Add(oNote);
                        }
                        catch (Exception ex)
                        {
                            if (allErrors.Length < 1000)
                            {
                                allErrors.AppendFormat("Error on line: {0}; {1}", reader.LineNumber, ex.Message);
                                allErrors.AppendLine();
                            }
                        }
                    }
                }

                if (allErrors.Length > 0)
                {
                    string errors = string.Format("Error reading notes xml from {0}{1}{2}", fileName, Environment.NewLine, allErrors.ToString());
                    MessageBox.Show(errors, ApplicationName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading notes xml from " + fileName + Environment.NewLine + ex.Message, ApplicationName);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return dicNotes;
        }

        /// <summary>
        /// Check if Settings file exists and is writable, so settings can be saves.
        /// </summary>
        /// <returns>true if settings file exists and is writable</returns>
        public static bool IsSettingsFileAvailableAndWritable()
        {
            IsFileWritable(SharedSettingsFileName);

            if (!IsFileWritable(SettingsFileName))
            {
                DialogResult eResult = MessageBox.Show("Settings file is read only." + Environment.NewLine + "Do you want to make it writable?" + Environment.NewLine + "If you select No the application will exit.", ApplicationName, MessageBoxButtons.YesNo);

                if (eResult == DialogResult.Yes)
                {
                    MakeWritable(SettingsFileName);

                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        private static string GenerateXml(IdNotesDictionary dicNotes)
        {
            if (dicNotes != null)
            {
                var sXmlDocBuilder = new StringBuilder("<dahlnotes>");
                sXmlDocBuilder.AppendLine();
                sXmlDocBuilder.AppendLine(" <notes>");
                foreach (var oEntry in dicNotes.TheNotes)
                {
                    Note oNote = oEntry.Value;
                    if (!oNote.IsReadOnly)
                    {
                        string sXmlSafeNote =
                            oNote.NoteText.Replace("&", "&amp;")
                                .Replace("<", "&lt;")
                                .Replace(">", "&gt;")
                                .Replace("\"", "&quot;");

                        sXmlDocBuilder.Append("  <note ");
                        sXmlDocBuilder.Append("id=\"" + oNote.Id + "\" ");
                        sXmlDocBuilder.Append("opacity=\"" + oNote.Opacity + "\" ");
                        sXmlDocBuilder.Append("alwaysontop=\"" + oNote.AlwaysOnTop + "\" ");
                        sXmlDocBuilder.Append("top=\"" + oNote.Location.X + "\" ");
                        sXmlDocBuilder.Append("left=\"" + oNote.Location.Y + "\" ");
                        sXmlDocBuilder.Append("width=\"" + oNote.Size.Width + "\" ");
                        sXmlDocBuilder.Append("height=\"" + oNote.Size.Height + "\" ");
                        sXmlDocBuilder.Append("startopened=\"" + oNote.StartOpened + "\" ");
                        sXmlDocBuilder.Append("textfontfamily=\"" + oNote.TextFont.FontFamily + "\" ");
                        sXmlDocBuilder.Append("textfontpointsize=\"" + oNote.TextFont.SizeInPoints + "\" ");
                        sXmlDocBuilder.Append("textfontstyle=\"" + ((int)oNote.TextFont.Style) + "\" ");
                        sXmlDocBuilder.Append("backcolor=\"" + oNote.BackColor.ToArgb() + "\" ");
                        sXmlDocBuilder.Append("textcolor=\"" + oNote.TextColor.ToArgb() + "\" ");
                        sXmlDocBuilder.Append("note=\"" + sXmlSafeNote + "\" ");

                        sXmlDocBuilder.AppendLine("/>");
                    }
                }

                sXmlDocBuilder.AppendLine(" </notes>");
                sXmlDocBuilder.AppendLine("</dahlnotes>");

                return sXmlDocBuilder.ToString();
            }

            return string.Empty;
        }

        private static bool IsFileWritable(string fileName)
        {
            var oInfo = new FileInfo(fileName);

            if (oInfo.Exists && !oInfo.IsReadOnly)
            {
                return true;
            }

            if (!oInfo.Exists)
            {
                StreamWriter oWriter = oInfo.CreateText();
                oWriter.Write("<dahlnotes></dahlnotes>");
                oWriter.Close();

                return true;
            }

            return false;
        }

        private static void MakeWritable(string fileName)
        {
            var oInfo = new FileInfo(fileName);

            if (oInfo.Exists && oInfo.IsReadOnly)
            {
                oInfo.IsReadOnly = false;
            }
        }
    }
}
