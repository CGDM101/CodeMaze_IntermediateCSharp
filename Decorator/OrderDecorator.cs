using System;

namespace Decorator
{ // Structural. Allows us to extend the behaviour of objects by placing these objects into a special wrapper class. Popular. We can dynamically add behaviours to the wrapped objects. Dels component-class och concrete component-class, och dels decorator-klass och concrete decorator-klass.
  // Decorator class, to allow 10 percent discount to premium users for preorder.
  // It wraps the OrderBase object.
    public class OrderDecorator : OrderBase
    {
        protected OrderBase order;

        public OrderDecorator(OrderBase order)
        {
            this.order = order;
        }

        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine($"Calculating the total price in a decorator class.");
            return order.CalculateTotalOrderPrice();
        }
    }
}
