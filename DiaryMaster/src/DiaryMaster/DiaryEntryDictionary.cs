using System.Collections;

namespace DiaryMaster
{
	/// <summary>
	/// Dictionary to store DiaryEntry objects in
	/// </summary>
	public class DiaryEntryDictionary: DictionaryBase
	{

		/// <summary>
		/// get entry with specified id
		/// </summary>
		public DiaryEntry this[int iEntryId] 
		{
			get 
			{ 
				return (DiaryEntry)(this.Dictionary[iEntryId]); 
			}
		}

		/// <summary>
		/// add entry to this dictionary
		/// </summary>
		/// <param name="oEntry"></param>
		public void Add(DiaryEntry oEntry) 
		{
			this.Dictionary.Add(oEntry.iEntryId, oEntry);
		}

		/// <summary>
		/// remove entry from this dictionary
		/// </summary>
		/// <param name="oEntry"></param>
		public void Remove(DiaryEntry oEntry) 
		{
			this.Dictionary.Remove(oEntry.iEntryId);
		}

		/// <summary>
		/// check if this dictionary contains specified entry
		/// </summary>
		/// <param name="oEntry"></param>
		/// <returns></returns>
		public bool Contains(DiaryEntry oEntry) 
		{
			return this.Dictionary.Contains(oEntry.iEntryId);
		}
	}
}