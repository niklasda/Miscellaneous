namespace DiaryMaster
{
	/// <summary>
	/// An entry for a day
	/// </summary>
	public class DiaryEntry
	{

		/// <summary>
		/// Contructor for an entry
		/// </summary>
		/// <param name="p_iEntryId"></param>
		/// <param name="p_sEntry"></param>
		/// <param name="p_eRecurring"></param>
		public DiaryEntry(int p_iEntryId, string p_sEntry, Recurrance p_eRecurring)
		{
			_iEntryId = p_iEntryId;
			//	_sTitle = p_sTitle;
			_sEntry = p_sEntry;
			_eRecurring = p_eRecurring;
		}

		/// <summary>
		/// the id of this entry
		/// </summary>
		public int iEntryId
		{
			get { return _iEntryId; }
			set { _iEntryId = value; }
		}

		/// <summary>
		/// the recurrance for this entry
		/// </summary>
		public Recurrance eRecurring
		{
			get { return _eRecurring; }
			set { _eRecurring = value; }
		}
		
		//		public string sTitle
		//		{
		//			get { return _sTitle; }
		//			set { _sTitle = value; }
		//		}
		
		/// <summary>
		/// the text for this entry
		/// </summary>
		public string sEntry
		{
			get { return _sEntry; }
			set { _sEntry = value; }
		}

		/// <summary>
		/// returns the first line of this entry text
		/// </summary>
		/// <returns></returns>
		public override string  ToString()
		{
			return Settings.GetFirstLine(_sEntry);
		}
		

		private int _iEntryId;
		private Recurrance _eRecurring;
		//	private string _sTitle;
		private string _sEntry;

	}
}