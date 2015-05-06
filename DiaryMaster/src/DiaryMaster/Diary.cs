using System;

namespace DiaryMaster
{
	/// <summary>
	/// A Diary containing several days and notes
	/// </summary>
	public class Diary
	{
		/// <summary>
		/// constructor for a diary
		/// </summary>
		public Diary(string sSettingsFileName)
		{
			_sSettingsFileName = sSettingsFileName;
			_dicDiaryDays = Settings.ReadDiaryDays(sSettingsFileName);
			_sDatelessNote = Settings.ReadDatelessNote(sSettingsFileName);
			_bIsModified = false;
		}

		private string _sSettingsFileName;
		private DiaryDayDictionary _dicDiaryDays;
		private string _sDatelessNote;
		private bool _bIsModified;

		/// <summary>
		/// Number of DiaryDays in the dictionary
		/// </summary>
		public int DayCount
		{
			get { return _dicDiaryDays.Count; }
		}

		/// <summary>
		/// The dictionary containing the Days in the Diary 
		/// </summary>
		public DiaryDayDictionary dicDiaryDays
		{
			get { return _dicDiaryDays; }
		}

		/// <summary>
		/// The entry not connected to a date
		/// </summary>
		public string sDatelessNote
		{
			get { return _sDatelessNote; }
			set { _sDatelessNote = value; }
		}

		/// <summary>
		/// Flag indicating if the Diary is modified
		/// </summary>
		public bool bIsModified
		{
			get { return _bIsModified; }
			set { _bIsModified = value; }
		}

		/// <summary>
		/// Saves the diary to file
		/// </summary>
		public void Save()
		{
			Settings.WriteDiaryDays(_dicDiaryDays, _sDatelessNote, _sSettingsFileName);
		}
	}
}