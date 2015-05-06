using System.Collections;

namespace PasswordManager
{
	/// <summary>
	/// Dictionary to store Password objects in
	/// </summary>
	public class PasswordDictionary: DictionaryBase
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public PasswordDictionary()
		{
		}

		/// <summary>
		/// Return the password for this ID
		/// </summary>
		public Password this[int iPasswordId] 
		{
			get 
			{ 
				return (Password)(this.Dictionary[iPasswordId]); 
			}
		}

		/// <summary>
		/// Add a password to this dictionary
		/// </summary>
		/// <param name="oPassword"></param>
		public void Add(Password oPassword) 
		{
			this.Dictionary.Add(oPassword.iPasswordId, oPassword);
		}

		/// <summary>
		/// Remove a password from this dictionary
		/// </summary>
		/// <param name="iPasswordId"></param>
		public void Remove(int iPasswordId) 
		{
			this.Dictionary.Remove(iPasswordId);
		}

		/// <summary>
		/// Check if a password exists in this dictionary
		/// </summary>
		/// <param name="iPasswordId"></param>
		/// <returns></returns>
		public bool Contains(int iPasswordId) 
		{
			return this.Dictionary.Contains(iPasswordId);
		}
	}
}