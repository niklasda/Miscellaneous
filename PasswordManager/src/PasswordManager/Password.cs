namespace PasswordManager
{
	/// <summary>
	/// A password
	/// </summary>
	public class Password
	{
		/// <summary>
		/// Constructor for a empty password
		/// </summary>
		/// <param name="p_iPasswordId"></param>
		public Password(int p_iPasswordId)
		{
			_iPasswordId = p_iPasswordId;
			_sCategory = "";
		}

		/// <summary>
		/// Constructor for populated passwords
		/// </summary>
		/// <param name="p_iPasswordId"></param>
		/// <param name="p_sTitle"></param>
		/// <param name="p_sDescription"></param>
		/// <param name="p_sUsername"></param>
		/// <param name="p_sPassword"></param>
		/// <param name="p_sUrl"></param>
		/// <param name="p_sCategory"></param>
		public Password(int p_iPasswordId, string p_sTitle, string p_sDescription, string p_sUsername, string p_sPassword, string p_sUrl, string p_sCategory)
		{
			_iPasswordId = p_iPasswordId;
			_sTitle = p_sTitle;
			_sDescription = p_sDescription;
			_sUsername = p_sUsername;
			_sPassword = p_sPassword;
			_sUrl = p_sUrl;
			_sCategory = p_sCategory;
		}

		/// <summary>
		/// password id
		/// </summary>
		public int iPasswordId
		{
			get { return _iPasswordId; }
			set { _iPasswordId = value; }
		}

		/// <summary>
		/// username to use with password
		/// </summary>
		public string sUsername
		{
			get { return _sUsername; }
			set { _sUsername = value; }
		}

		/// <summary>
		/// password to use with username
		/// </summary>
		public string sPassword
		{
			get { return _sPassword; }
			set { _sPassword = value; }
		}

		/// <summary>
		/// title used to present the Password
		/// </summary>
		public string sTitle
		{
			get { return _sTitle; }
			set { _sTitle = value; }
		}
		
		/// <summary>
		/// description for the password
		/// </summary>
		public string sDescription
		{
			get { return _sDescription; }
			set { _sDescription = value; }
		}
        
		/// <summary>
		/// url probably leading to the site where the password can be used
		/// </summary>
		public string sUrl
		{
			get { return _sUrl; }
			set { _sUrl = value; }
		}

		/// <summary>
		/// category to sort the password under
		/// </summary>
		public string sCategory
		{
			get { return _sCategory; }
			set { _sCategory = value; }
		}

		private int _iPasswordId;
		private string _sUsername;
		private string _sPassword;
		private string _sTitle;
		private string _sDescription;
		private string _sUrl;
		private string _sCategory;

	}
}