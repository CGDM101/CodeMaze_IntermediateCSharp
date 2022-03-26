using System;
using System.Collections.Generic;
using System.Linq;

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
    public class EmployeeManager : IEmployeeSearchable
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

        public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position)
            => _employees.Where(emp => emp.Gender == gender && emp.Position == position);
    }

    // higherlevel class
    public class EmployeeStatistics
    {
        private readonly IEmployeeSearchable _emp;

        public EmployeeStatistics (IEmployeeSearchable emp)
	    {
            _emp = emp;
	    }

        public int CountFemaleManagers () =>
            _emp.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
    }
    
    // Interface to decouble the EmployeeStatistics and the EmployeeManager, and let it depend on a higher abstraction. The EmployeeStatistics should not depend on the lower-level EmployeeManager, and the EmployeeManager should be able to change its behaviour.
    public interface IEmployeeSearchable
	{
        IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
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

        // Purpose of DIP is to introduce an abstraction between high and low-level components, to remove the dependencies between the components.
        static void Main(string[] args)
        {
            var empManager = new EmployeeManager();
            empManager.AddEmployee(new Employee { Name = "Lean", Gender = Gender.Female, Position = Position.Manager });
            empManager.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });

            var stats = new EmployeeStatistics(empManager);
            Console.WriteLine($"Number of female managers in our company is: {stats.CountFemaleManagers()}");
        }
    }
}
