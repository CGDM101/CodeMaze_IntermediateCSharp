using System;
using System.Collections.Generic;

namespace Facade
{
    class Program
    {
        // Structural. A facade for the end user to simplify the usage of the subsystems that are poorly designed and/or too complicated, by hiding their implementation details. It also compes in handy when working with complex libraries and API:s.
        // Represented by a single-class interface that is simple, easy to read and use, without the trouble of changing the subsystems themselves. However, we must be careful since limiting the usage of the subsystem's funtionalities may not be enough for the power-users.
        static void Main(string[] args)
        {
            var restaurant = new OnlineRestaurant();
            var shippingService = new ShippingService();

            var facade = new Facade(restaurant, shippingService);

            var chickenOrder = new Order() { DishName = "Chicken with rice", DishPrice = 20.0, User = "User1", ShippingAddress = "Random street 123" };
            var sushiOrder = new Order() { DishName = "Sushi", DishPrice = 52.0, User = "User2", ShippingAddress = "More random street 321" };

            facade.OrderFood(new List<Order>() { chickenOrder, sushiOrder });

            //restaurant.AddOrderToCart(chickenOrder);
            //restaurant.AddOrderToCart(sushiOrder);
            //restaurant.CompleteOrder();

            //shippingService.AcceptOrder(chickenOrder);
            //shippingService.CalculateShippingExpenses();
            //shippingService.ShipOrder();

            //shippingService.AcceptOrder(sushiOrder);
            //shippingService.CalculateShippingExpenses();
            //shippingService.ShipOrder();

            Console.ReadLine();
        }
    }
}
