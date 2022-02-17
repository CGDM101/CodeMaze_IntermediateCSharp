namespace Decorator
{ // Structural. Allows us to extend the behaviour of objects by placing these objects into a special wrapper class. Popular. We can dynamically add behaviours to the wrapped objects. Dels component-class och concrete component-class, och dels decorator-klass och concrete decorator-klass.
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
