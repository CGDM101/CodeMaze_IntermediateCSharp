using System;

namespace Facade
{
    // Accepts the order and ships them to the address stored in the ShippingAddress property insider the Orcer class. The ShippingService also calculates the shipping expenses and displays them to the user.
    public class ShippingService
    {
        private Order _order;

        public void AcceptOrder(Order order)
        {
            _order = order;
        }

        public void CalculateShippingExpenses()
        {
            _order.ShippingPrice = 15.5;
        }

        public void ShipOrder()
        {
            Console.WriteLine(_order.ToString());
            Console.WriteLine("Order is being shipped to {0}...", _order.ShippingAddress);
        }
    }
}
