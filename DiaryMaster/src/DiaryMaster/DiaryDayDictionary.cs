using System;
using System.Collections;

namespace DiaryMaster
{
	/// <summary>
	/// Dictionary to store diary day objects in
	/// </summary>
	public class DiaryDayDictionary: DictionaryBase
	{

		/// <summary>
		/// return a DiaryDay for this date
		/// </summary>
		public DiaryDay this[DateTime dtEntryDate] 
		{
			get 
			{ 
				return (DiaryDay)(this.Dictionary[dtEntryDate.ToShortDateString()]); 
			}
		}

		/// <summary>
		/// Add a DiaryDay to this dictionary
		/// </summary>
		/// <param name="oDiaryDay"></param>
		public void Add(DiaryDay oDiaryDay) 
		{
			if(!Contains(oDiaryDay.dtEntryDate))
				base.Dictionary.Add(oDiaryDay.dtEntryDate.ToShortDateString(), oDiaryDay);

		}

		/// <summary>
		/// Remove a DiaryDay to this dictionary
		/// </summary>
		/// <param name="oDiaryDay"></param>
		public void Remove(DiaryDay oDiaryDay) 
		{
			this.Dictionary.Remove(oDiaryDay.dtEntryDate.ToShortDateString());
		}

		/// <summary>
		/// Check if this dictionary contain a specific date
		/// </summary>
		/// <param name="dtEntryDate"></param>
		/// <returns></returns>
		public bool Contains(DateTime dtEntryDate) 
		{
			return this.Dictionary.Contains(dtEntryDate.ToShortDateString());
		}

		/// <summary>
		/// Returns the Keys collection from the InnerHashTable
		/// </summary>
		/// <returns></returns>
		public ICollection getKeys()
		{
			return base.InnerHashtable.Keys;
		}
	}
}