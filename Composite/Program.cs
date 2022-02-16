using System;

namespace Composite
{ // Structural. Compose object into a tree structure, and then work with that structure as if it is a single object. Consists of three parts; component (interface with operations), leaf, composite (many leaves. Communicates not via its leaves but via component) and finally client.

    internal class Program
    {
        static void Main(string[] args) // Klient-delen
        {
            var phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            // composite gift:
            var rootBox = new CompositeGift("Rootbox", 0);
            var truckToy = new SingleGift("TruckToy", 289);
            var plainToy = new SingleGift("PlainToy", 587);
            rootBox.Add(truckToy);
            rootBox.Add(plainToy);
            var childBox = new CompositeGift("ChildBox", 0);
            var soldierToy = new SingleGift("SoldierToy", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");


            // The client does not have to worry about the concrete class it works with.
        }
    }
}
