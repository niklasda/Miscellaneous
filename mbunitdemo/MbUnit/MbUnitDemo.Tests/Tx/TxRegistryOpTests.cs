using System;
using System.Runtime.InteropServices;
using Gallio.Framework;
using MbUnit.Framework;
using Microsoft.Win32;

namespace MbUnitDemo.Tests.Tx
{
    public class TxRegistryOpTests
    {

        //[DllImport("advapi32.dll", EntryPoint = "RegDeleteKeyTransactedW")]
        //static extern long RegDeleteKeyTransactedW(uint hkey, [MarshalAs(UnmanagedType.LPWStr)]string subkey, RegSam sam, uint reserved, IntPtr transaction, IntPtr reserved2);

        [SetUp]
        public void SetupTests()
        {
            string[] keys = Registry.CurrentUser.GetSubKeyNames();
            Assert.DoesNotContain(keys, "MyNames");

            // This fails because regular registry operations are not transactional
        }


        [Test]
        [Rollback]
        public void RegCreate()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("MyNames");
            key.SetValue("MyName", "Niklas");
            key.Close();
        }
    }
}