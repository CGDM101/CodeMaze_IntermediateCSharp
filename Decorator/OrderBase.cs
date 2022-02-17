using System.Collections.Generic;

namespace Decorator
{ // Structural. Allows us to extend the behaviour of objects by placing these objects into a special wrapper class. Popular. We can dynamically add behaviours to the wrapped objects. Dels component-class och concrete component-class, och dels decorator-klass och concrete decorator-klass.
    public abstract class OrderBase // component class. Will be shared with other concrete component classes.
    {
        protected List<Product> products = new List<Product>
        {
            new Product {Name="Phone", Price=587},
            new Product{Name="Tablet",Price=800},
            new Product {Name="PC", Price=1200}
        };

        public abstract double CalculateTotalOrderPrice(); // abstract method.
    }
}
