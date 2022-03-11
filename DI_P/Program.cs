using System;

namespace DI_P
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum Position
    {
        Administrator,
        Manager,
        Executive
    }

    public class Employee
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
    }

    // low level class:
    public class EmployeeManager
    {
        private readonly List<Employee> _employees;

        public EmployeeManager()
        {
            _employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
    }

    // higherlevel class
    public class EmployeeStatistics
    {
        private readonly EmployeeManager _empManager;

        public EmployeeStatistics(EmployeeManager empManager)
        {
            _empManager = empManager;
        }

        public int CountFemaleManagers()
        {
            // logic goes here.
        }
    }

    class Program
    {
        // We should create the higher-level modules with its complex logic in such a way to be reusable and unaffected by any change from the lower-level modules.
        // Abstraction decouples higher-level from lower-level modules.

        // High-level modules should not depend on low-level modules, both should depend on abstractions.
        // Abstractions should not depend on details. Details should depend on abstractions.

        // High-level modules have more abstract nature and contains more logic. They orchestrate low-level modules. The low-level modules contain more individual components focusing on details and smaller parts. These modules are used inside the high-level modules.

        // DIP creates a decoupled structure between high-level and low-level modules by introducing abstraction between them.

        // DEPENDENCY INJECTION is one way of implementing the DIP.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
