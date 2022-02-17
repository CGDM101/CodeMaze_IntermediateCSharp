using System;
using System.Linq;

namespace Decorator
{ // Structural. Allows us to extend the behaviour of objects by placing these objects into a special wrapper class. Popular. We can dynamically add behaviours to the wrapped objects. Dels component-class och concrete component-class, och dels decorator-klass och concrete decorator-klass.
    public class RegularOrder: OrderBase // a concrete component
    {
        public override double CalculateTotalOrderPrice() // overridar abstrakta metoden.
        {
            Console.WriteLine("Calculating the total price of a regular order");
            return products.Sum(x => x.Price);
        }
    }
}
