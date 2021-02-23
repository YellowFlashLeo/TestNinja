using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {

        // We immitate OrderService class and PlaceOrder method
        // We want to test that the same object which is passed to PlaceOrder function 
        // is also passed to Store function
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);


            var order = new Order();
            service.PlaceOrder(order);
            storage.Verify(s => s.Store(order));
        }
        
    }
}
