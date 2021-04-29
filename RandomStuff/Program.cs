using System;

namespace RandomStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            // An object of an anonymous class
            var myAnonymousObj = new { Name = "John", Age = 32 };

            // To declare a value type as a nullable value type:
            int? number = null;

            // Properties of nullable types
            int? num = null;
            num = 101; // Comment to print else block

            if(num.HasValue)
                Console.WriteLine(num.Value);
            else
                Console.WriteLine("num is null");
        }
    }
}
