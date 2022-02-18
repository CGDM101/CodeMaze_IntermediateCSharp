using System;

namespace Command
{ // Behavioural. To turn a request into an object, which contains all the information about the request. Popular. Especially when wanting to delay or queue a request's execution, or when we want to keep track of our operations. This possibility to keep track of our operations gives us the possibility to undo them as well.
  // Consist of 1) invoker class 2) command class/interface 3) concrete command classes 4) receiver class

    // We can decouple classes that invoke operations, from classes that perform these operations. And if we want to introduce new commands, we do not have to modify existing classes, we can just add those new command classes to our project.

    public class Product // the receiver class (product receiver). Contains the logic.
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void IncreasePrice(int amount)
        {
            Price += amount;
            Console.WriteLine($"The price for the {Name} has been increased by {amount}$");
        }

        public bool DecreasePrice(int amount)
        {
            if (amount < Price)
            {
                Price -= amount;
                Console.WriteLine($"The price for the {Name} has been  decreased by {amount}$");
                return true;
            }
            return false;
        }

        public override string ToString() => $"Current price for the {Name} product is {Price}$.";
    }
}
