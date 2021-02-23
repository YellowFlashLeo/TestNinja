using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();
            logger.Log("a");
            Assert.That(logger.LastError, Is.EqualTo("a")); // we want to see if prop vakue was changed
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();

            //When trying to test methods which has null as input param we need to use delegate
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            // we can use other exceptions like Throws.Exception.TypeOf<DivideByZeroException>
        }
        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvemt()
        {
            var logger = new ErrorLogger();
            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; }; // so when logger function is executed we assign guid value to id
            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty)); // here we check if id has any values, if yes it means that logger function was executed
        }
    }
}
