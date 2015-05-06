using System;
using System.IO;
using System.Runtime.InteropServices;
using Gallio.Framework;
using MbUnit.Framework;
using Microsoft.Win32;

namespace MbUnitDemo.Tests.Tx
{
    public class TxFileOpTests
    {
        private string _txFileName;

        [Test]
        [Rollback]
        public void TxFileCreate()
        {
            TxFileOp tx = new TxFileOp();
            _txFileName = tx.TxCreateFile();

            TestLog.WriteLine("Created a new file: " + _txFileName);
        }

        [TearDown]
        public void TearDownTest()
        {
            Assert.IsFalse(File.Exists(_txFileName));
        }

        //        [DllImport("Kernel32.dll")]
        //        static extern bool DeleteFileTransactedW([MarshalAs(UnmanagedType.LPWStr)]string file, IntPtr transaction);

    }
}