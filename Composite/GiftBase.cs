namespace Composite
{ // Structural. Compose object into a tree structure, and then work with that structure as if it is a single object. Consists of three parts; component (interface with operations), leaf, composite (many leaves. Communicates not via its leaves but via component) and finally client.
    public abstract class GiftBase // component. Used as an interface between the leaf and the composite.
    {
        protected string name;
        protected int price;

        public GiftBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract int CalculateTotalPrice();
    }
}
