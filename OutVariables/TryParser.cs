using System;
using System.Globalization;

using static System.FormattableString;

namespace OutVariables
{
    public interface IOrder
    {
        decimal Amount { get; set; }
        Schedule Schedule { get; set; }

        string CalculateAmount(IOrder order);
    }
    public enum Schedule
    {
        OneOff,
        Monthly,
        Quarterly,
        Annually
    }

    public class Order : IOrder
    {
        public decimal Amount { get; set; }
        public Schedule Schedule { get; set; }

        public string CalculateAmount(IOrder order) => int.TryParse(Invariant($"{order.Amount}"), out var result) 
            ? $"Order {result} with schedule {order.Schedule}" 
            : $"Order {result:C0} with schedule {order.Schedule}";

        //Doesn't work - will need to implement your own TryParse for enums!
        public string GetSchedule(IOrder order) => Enum.TryParse(order.Schedule.ToString(), out Schedule result) ? $"Order {order.Amount} with schedule {(Schedule)result}" : $"Order {Amount}";
        
        public string CalculateAmountExtension(Order order) => order.TryParse(out IOrder result) ? 
                                                                                                $"Order {result.Amount} with schedule {result.Schedule}" 
                                                                                                : "Not an IOrder type";
    }
}

//public string CalculateAmountOldWay(Order order)
//{
//    int result;
//    var isInt = int.TryParse(Amount.ToString(CultureInfo.InvariantCulture), out result);

//    return isInt ? $"Order {result} with schedule {Schedule}" : $"Order {Amount:C0}";
//}