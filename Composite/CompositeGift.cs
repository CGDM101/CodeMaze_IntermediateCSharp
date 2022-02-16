using System;
using System.Collections.Generic;

namespace Composite
{ // Structural. Compose object into a tree structure, and then work with that structure as if it is a single object. Consists of three parts; component (interface with operations), leaf, composite (many leaves. Communicates not via its leaves but via component) and finally client.
    public class CompositeGift : GiftBase, IGiftOperations // composite
    {
        private List<GiftBase> _gifts;

        public CompositeGift(string name, int price) : base(name, price)
        {
            _gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{name} contains the following products with prices:");

            foreach (var gift in _gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}
