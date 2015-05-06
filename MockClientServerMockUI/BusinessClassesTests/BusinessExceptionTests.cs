using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockdemo.BusinessClasses;

namespace Mockdemo.BusinessClassesTests
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class BusinessExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestBusinessException()
        {
            BusinessException be = new BusinessException("Hello excpetion");
            
            throw be;
        }
    }
}
