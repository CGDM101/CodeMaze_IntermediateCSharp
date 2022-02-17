using System;

namespace Decorator
{ // Structural. Allows us to extend the behaviour of objects by placing these objects into a special wrapper class. Popular. We can dynamically add behaviours to the wrapped objects. Dels component-class och concrete component-class, och dels decorator-klass och concrete decorator-klass.
    class Program
    {
        static void Main(string[] args)
        {
            var regularOrder = new RegularOrder();
            Console.WriteLine(regularOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var preOrder = new Preorder();
            Console.WriteLine(preOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var premiumOrder = new PremiumPreorder(preOrder);
            Console.WriteLine(premiumOrder.CalculateTotalOrderPrice());
            // With this premiumOrder object we are wrapping the preOrder object to which we add an additional behaviour.
        }
    }
}
