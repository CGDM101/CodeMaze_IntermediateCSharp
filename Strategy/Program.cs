using System;
using System.Collections.Generic;

namespace Strategy
{
    class Program
    { // Behavioural. Quite common. Define different functionalities, put each functionality in a separate class and make their object interchangeable. 1) Context object (maintains the reference towards the strategy object. 2) Strategy object (interface) to define a way for the context object to execute the strategy 3) Concrete strategies objects which implement the strategy interface. 

        // We should use this patterns when we have different variations for some functionality in an object and we want to switch form one variation to another in a runtime. Also, if we have similar classes that only differ on how they execute some behaviour.
        // The Strategy Pattern lets us extract the variations of the functionality into separate classes (concrete strategies). Then we invoke them into the context class.
        static void Main(string[] args)
        {
            var reports = new List<DeveloperReport>
            {
                new DeveloperReport{ Id=1,Name="Dev1",Level=DeveloperLevel.Senior, HourlyRate=30.5, WorkingHours=160},
                new DeveloperReport{ Id=1,Name="Dev2",Level=DeveloperLevel.Junior, HourlyRate=20, WorkingHours=120},
                new DeveloperReport{ Id=1,Name="Dev3",Level=DeveloperLevel.Senior, HourlyRate=32.5, WorkingHours=130},
                new DeveloperReport{ Id=1,Name="Dev4",Level=DeveloperLevel.Junior, HourlyRate=24.5, WorkingHours=140},
            };

            var calculatorContext = new SalaryCalculator(new JuniorDevSalaryCalculator());
            var juniorTotal = calculatorContext.Calculate(reports);
            Console.WriteLine($"Total amount for junior salaries is: {juniorTotal}");


            calculatorContext.SetCalculator(new SeniorDevSalaryCalculator());
            var seniorTotal = calculatorContext.Calculate(reports);
            Console.WriteLine($"Total amount for senior salaries is: {seniorTotal}");

            Console.WriteLine($"Total cost for all the salaries is: {juniorTotal + seniorTotal}");
        }
    }
}
