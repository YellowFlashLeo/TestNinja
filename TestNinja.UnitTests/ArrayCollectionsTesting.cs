using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
   public class ArrayCollectionsTesting
    {
        private Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result =_math.GetOddNumbers(5);
            //General
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Unique);
            Assert.That(result, Is.Ordered);
            //Specific
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            // or same as 3 lines before
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
        }
    }
}
