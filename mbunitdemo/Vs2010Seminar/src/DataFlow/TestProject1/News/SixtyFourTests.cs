using System;
using Microsoft.Win32;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.News
{
    [TestClass]
    public class SixtyFourTests
    {
        [TestMethod]
        public void SixtyFourTest()
        {
            bool os64 = Environment.Is64BitOperatingSystem;
            bool p64 = Environment.Is64BitProcess;

            RegistryKey key = 
                RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, 
                                        RegistryView.Registry64);
            
            Assert.AreEqual(os64, p64);
            Assert.IsNotNull(key);
        }
    }
}


