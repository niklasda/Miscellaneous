using System.IO;
using ChinhDo.Transactions;

namespace MbUnitDemo
{
    /// <summary>
    /// File operations, transactional and non-transactional
    /// </summary>
	public class TxFileOp
	{
        /// <summary>
        /// Create a file using Transactional FileManager
        /// </summary>
        /// <returns>The name of the file created</returns>
		public string TxCreateFile()
		{
			IFileManager txf = new TxFileManager();

			string f1 = txf.GetTempFileName();
			const string contents1 = "123";

			txf.WriteAllText(f1, contents1);

			return f1;
		}

        /// <summary>
        /// Create a file the regular .NET way
        /// </summary>
        /// <returns>The name of the file created</returns>
		public string CreateFile()
		{
			string f1 = Path.GetFileName(Path.GetTempFileName());
			const string contents1 = "123";

			StreamWriter writer = File.CreateText(f1);
			writer.Write(contents1);
			writer.Close();
			

			return f1;
		}
	}
}