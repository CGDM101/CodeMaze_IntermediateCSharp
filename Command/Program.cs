using System;

namespace Command
{ // Behavioural. To turn a request into an object, which contains all the information about the request. Popular. Especially when wanting to delay or queue a request's execution, or when we want to keep track of our operations. This possibility to keep track of our operations gives us the possibility to undo them as well.

    class Program // klientklassen annat ord? Instansierar...
    {
        static void Main(string[] args)
        {
            // The command design patterns states that we should not use receiver classes directly. We use the command class (which contains all teh request details).
            // inte product produ = new product alltså

            var modifyPrice = new ModifyPrice(); // invoker class
            var product = new Product("Phone", 500);

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 2500));

            Console.WriteLine(product);
            Console.WriteLine();

            modifyPrice.UndoActions();
            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
