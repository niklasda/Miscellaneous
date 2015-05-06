using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.News
{
    [TestClass]
    public class NumericsTests
    {
        [TestMethod]
        public void ComplexMath()
        {
            var cplx = new Complex(3, 4);
            Assert.AreEqual(3, cplx.Real);
            Assert.AreEqual(4, cplx.Imaginary);
            Assert.AreEqual(5, cplx.Magnitude);

            Complex abs = Complex.Abs(cplx);
            Assert.AreEqual(5, abs);
        }








        [TestMethod]
        public void BigxMath()
        {
            var big = new BigInteger(long.MaxValue);
            BigInteger bigger = BigInteger.Multiply(big, big);

            Assert.AreEqual("85070591730234615847396907784232501249", bigger.ToString());
        }
    }
}


