using System;

namespace Decorator
{ // Structural. Allows us to extend the behaviour of objects by placing these objects into a special wrapper class. Popular. We can dynamically add behaviours to the wrapped objects. Dels component-class och concrete component-class, och dels decorator-klass och concrete decorator-klass.
  // Concrete decorator class:
    public class PremiumPreorder : OrderDecorator
    {
        public PremiumPreorder(OrderBase order) : base(order)
        {

        }

        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine($"Calculating the total price in the {nameof(PremiumPreorder)} class.");
            var preOrderPrice = base.CalculateTotalOrderPrice();

            Console.WriteLine("Adding additional discount to a preorder price");
            return preOrderPrice * 0.9;
        }
    }
}
