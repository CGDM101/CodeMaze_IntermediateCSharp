using System;
using System.Collections.Generic;

namespace Facade
{
    // Provides methods for adding orders to the cart.
    public class OnlineRestaurant
    {
        private readonly List<Order> _cart;

        public OnlineRestaurant()
        {
            _cart = new List<Order>();
        }

        public void AddOrderToCart(Order order)
        {
            _cart.Add(order);
        }

        public void CompleteOrder()
        {
            Console.WriteLine("Order completed. Dispatch in progress...");
        }
    }
}
