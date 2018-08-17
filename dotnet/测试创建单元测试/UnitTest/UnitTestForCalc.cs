using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTestForCalc
    {
        [TestMethod]
        public void Test_Calc_Add()
        {
            const int aX = 1;
            const int aY = 2;
            const int aExpectValue = 3;

            var aValue = Calc.Add(aX, aY);

            Assert.AreEqual(aValue, aExpectValue);
            //Assert.Inconclusive("验证此测试方法的正确性！");
        }
    }
}