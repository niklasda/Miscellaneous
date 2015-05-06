using System;

namespace DiaryMaster
{
	/// <summary>
	/// A Day containing several entries for that day
	/// </summary>
	public class DiaryDay
	{
		/// <summary>
		/// constructor for a day
		/// </summary>
		/// <param name="p_dtEntryDate">The date</param>
		public DiaryDay(DateTime p_dtEntryDate)
		{
			_dtEntryDate = p_dtEntryDate;
			_dicEntries = new DiaryEntryDictionary();
		}

		/// <summary>
		/// The date
		/// </summary>
		public DateTime dtEntryDate
		{
			get { return _dtEntryDate; }
		}

		/// <summary>
		/// The entries for ths date
		/// </summary>
		public DiaryEntryDictionary dicEntries
		{
			get { return _dicEntries; }
		}

		/// <summary>
		/// Add an entry to this date
		/// </summary>
		/// <param name="oEntry">Entry to add</param>
		public void AddEntry(DiaryEntry oEntry)
		{
			_dicEntries.Add(oEntry);
		}

		private DateTime _dtEntryDate;
		private DiaryEntryDictionary _dicEntries;
	}
}