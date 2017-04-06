using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OutVariables;

namespace Out_Variables
{
    [TestClass]
    public class TryParserTests
    {
        public IOrder Order { get; } = new Order
        {
            Amount = 100M,
            Schedule = Schedule.Monthly
        };

        [TestMethod]
        public void GetResultWhenGivenAnInterfaceType()
        {
            var result = Order.TryParse(out IOrder orderOut);
            var orderReturned = orderOut;

            Assert.IsTrue(result);
            Assert.IsNotNull(orderReturned);
        }

        [TestMethod]
        public void CalculateAmount()
        {
            var order = new Order();

            var result = order.CalculateAmount(Order);

            Assert.AreEqual(result, "Order 100 with schedule Monthly");
        }

        [TestMethod]
        public void GetSchedule()
        {
            var order = new Order();

            var result = order.GetSchedule(Order);

            Assert.AreEqual(result, "Order 100 with schedule Monthly");
        }

        [TestMethod]
        public void CalculateAmountExtension()
        {
            var order = new Order();

            var result = order.GetSchedule(Order);

            Assert.AreEqual(result, "Order 100 with schedule Monthly");
        }
    }
}
