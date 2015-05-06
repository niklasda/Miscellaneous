using System;
using System.Security.Cryptography;
using System.Text;

namespace DiaryMaster
{
	/// <summary>
	/// Handles Ecryption and decryption of textstrings
	/// </summary>
	public sealed class Encrypter
	{
		private Encrypter()
		{
		}

		private static readonly string sPassword = "HelloIAmYourKey!";

		/// <summary>
		/// The name of the crypto algorithm, displayed in the status bar
		/// </summary>
		public static readonly string sCryptoName = "TripleDES";


		/// <summary>
		/// Encrypt a string using 3DES and Base-64
		/// </summary>
		/// <param name="sOriginal">Plain text to be encrypted</param>
		/// <returns></returns>
		public static string Encrypt(string sOriginal)
		{
			return Encrypt(sOriginal, sPassword);
		}
		
		private static string Encrypt(string sOriginal, string sPassword)
		{
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
			ASCIIEncoding textConverter = new ASCIIEncoding();
			byte[] pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sPassword));
			byte[] buff;

			des.Key = pwdhash;
			des.Mode = CipherMode.ECB;

			buff = ASCIIEncoding.Unicode.GetBytes(sOriginal);

			string sEncrypted = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));

			return sEncrypted;
		}

		/// <summary>
		/// Decrypt and decode an 3DES encrypted and Base-64 encoded string 
		/// </summary>
		/// <param name="sEncrypted">3DES encoded text that has been Base-64 encoded</param>
		/// <returns>Plain text</returns>
		public static string Decrypt(string sEncrypted)
		{
			return Decrypt(sEncrypted, sPassword);
		}
		
		private static string Decrypt(string sEncrypted, string sPassword)
		{
			ASCIIEncoding textConverter = new ASCIIEncoding();
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
			byte[] pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sPassword));
			byte[] buff;

			des.Key = pwdhash;
			des.Mode = CipherMode.ECB;

			buff = Convert.FromBase64String(sEncrypted);

			string sDecrypted = UnicodeEncoding.Unicode.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));

			return sDecrypted;
		}

	}
}