using System;
using System.Collections.Generic;

namespace Facade
{
    public class Order
    {
        public string DishName { get; set; }
        public double DishPrice { get; set; }
        public string User { get; set; }
        public string ShippingAddress { get; set; }
        public double ShippingPrice { get; set; }

        public override string ToString()
        {
            return string.Format("User {0} ordered {1}. The full price is {2} dollars.",
                User, DishName, DishPrice + ShippingPrice);
        }
    }

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
    class Program
    {
        // Structural. A facade for the end user to simplify the usage of the subsystems that are poorly designed and/or too complicated, by hiding their implementation details. It also compes in handy when working with complex libraries and API:s.
        // Represented by a single-class interface that is simple, easy to read and use, without the trouble of changing the subsystems themselves. However, we must be careful since limiting the usage of the subsystem's funtionalities may not be enough for the power-users.
        static void Main(string[] args)
        {
            var restaurant = new OnlineRestaurant();
            var shippingService = new ShippingService();

            var chickenOrder = new Order() { DishName = "Chicken with rice", DishPrice = 20.0, User = "User1", ShippingAddress = "Random street 123" };
            var sushiOrder = new Order() { DishName = "Sushi", DishPrice = 52.0, User = "User2", ShippingAddress = "More random street 321" };

            restaurant.AddOrderToCart(chickenOrder);
            restaurant.AddOrderToCart(sushiOrder);
            restaurant.CompleteOrder();

            shippingService.AcceptOrder(chickenOrder);
            shippingService.CalculateShippingExpenses();
            shippingService.ShipOrder();

            shippingService.AcceptOrder(sushiOrder);
            shippingService.CalculateShippingExpenses();
            shippingService.ShipOrder();

            Console.ReadLine();
        }
    }
}
