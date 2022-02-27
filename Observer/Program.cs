using System;
using System.Linq;

namespace Observer
{
    class Program
    {
        // Behavioural. Allows us to establish a notification mechanism between objects. Enables multiple objects to subscribe to another object and get notified when an event occurs to this observed object.
        // 1) Provider (Subject/Publisher) - the observed object.
        // 2) Observer/-s -subscribes to the provider; gets notified whenever a predefined condition happens, usually an event or a state change.
        // Helpful when we want to implement some kind of distributed notification system.
        // Interfaces IObserver<T> and IObservable<T>.
        static void Main(string[] args)
        {
            var observer1 = new HRSpecialist("Bill");
            var observer2 = new HRSpecialist("John");

            var provider = new ApplicationHandler();

            observer1.Subscribe(provider);
            observer2.Subscribe(provider);
            provider.AddApplication(new Application(1, "Jesus"));
            provider.AddApplication(new Application(2, "Dave"));

            observer1.ListApplications();
            observer2.ListApplications();

            observer1.Unsubscribe();

            Console.WriteLine();
            Console.WriteLine($"{observer1.Name} unsubscribed");
            Console.WriteLine();

            provider.AddApplication(new Application(3, "Sofia"));

            observer1.ListApplications();
            observer2.ListApplications();

            Console.WriteLine();

            provider.CloseApplications();
        }
    }
}
