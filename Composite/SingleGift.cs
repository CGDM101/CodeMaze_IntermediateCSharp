using System;

namespace Composite
{ // Structural. Compose object into a tree structure, and then work with that structure as if it is a single object. Consists of three parts; component (interface with operations), leaf, composite (many leaves. Communicates not via its leaves but via component) and finally client.
    public class SingleGift : GiftBase // gåvan är lövet.
    {
        public SingleGift(string name, int price) : base(name, price)
        {

        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with the price {price}");

            return price;
        }
    }
}
