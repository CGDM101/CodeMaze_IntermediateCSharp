using System.Collections.Generic;

namespace Facade
{
    public class Facade // Added facade class with the implementation logic. This facade class acts as a middleware between the user and the complexity of the system, without changing the business logic. Then we can simplify the Main class (see changes!). This means we have freed the user of the unnecessary pressure of knowing all the required steps for the food to arrive.
    {
        private readonly OnlineRestaurant _restaurant;
        private readonly ShippingService _shippingService;

        public Facade(OnlineRestaurant restaurant, ShippingService shippingService)
        {
            _restaurant = restaurant;
            _shippingService = shippingService;
        }

        public void OrderFood(List<Order> orders)
        {
            foreach (var order in orders)
            {
                _restaurant.AddOrderToCart(order);
            }

            _restaurant.CompleteOrder();

            foreach (var order in orders)
            {
                _shippingService.AcceptOrder(order);
                _shippingService.CalculateShippingExpenses();
                _shippingService.ShipOrder();
            }
        }
    }
}
