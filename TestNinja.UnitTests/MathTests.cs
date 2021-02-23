using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
   public class MathTests
    {
        private Math _math;
        [TestInitialize]
        public void SetUp()
        {
            _math = new Math();
        }
        [TestMethod]
        [Ignore("For the sake of demonstration")]
        public void Add_WhenCalled_ReturnTheSumOfArgummnets()
        {
           // var math = new Math();
             var result = _math.Add(1, 2);

            Assert.AreEqual(3, result);
        }

        [DataTestMethod]
        [DataRow(2,1,2)]
        [DataRow(1,2,2)]
        [DataRow(1,1,1)]
        public void Max_WhenCalled_ReturnTheGreaterArgumnet(int a, int b, int expectedResult)
        {
            //var math = new Math();
            var result = _math.Max(a, b);
            Assert.AreEqual(result, expectedResult);
        }
        //[TestMethod]
        //public void Max_FirstArgumnetIsGreater_ReturnTheSecondArgumnet()
        //{
        //    //var math = new Math();
        //    var result = _math.Max(1, 2);
        //    Assert.AreEqual(result, 2);
        //}
        //[TestMethod]
        //public void Max_ArgumentsAreEqual_ReturnTheSameArgumnet()
        //{
        //   // var math = new Math();
        //    var result = _math.Max(1, 1);
        //    Assert.AreEqual(result, 1);
        //}
    }
}
