using System;

namespace FluentBuilder_WithRecursiveGenerics
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Position: {Position}, Salary: {Salary}";
        }
    }

    /*
    /// <summary>
    /// A builder class to build the Name part of the object.
    /// </summary>
    public class EmployeeInfoBuilder
    {
        protected Employee employee = new Employee();

        public EmployeeInfoBuilder SetName(string name)
        {
            employee.Name = name;
            return this;
        }
    }
    */
    public class EmployeeInfoBuilder<T>: EmployeeBuilder where T: EmployeeInfoBuilder<T>
    {
        public T SetName(string name)
        {
            employee.Name = name;
            return (T)this;
        }
    }

    public abstract class EmployeeBuilder
    {
        protected Employee employee;

        public EmployeeBuilder()
        {
            employee = new Employee();
        }

        public Employee Build() => employee;
    }

    /*
    /// <summary>
    /// Another builder class to build the Position part. It inherits from EmployeeInfoBuilder, because we want to reuse our employee object.
    /// </summary>
    public class EmployeePositionBuilder : EmployeeInfoBuilder
    {
        public EmployeePositionBuilder AtPosition(string position)
        {
            employee.Position = position;
            return this;
        }
    } 
    */
    public class EmployeePositionBuilder<T>: EmployeeInfoBuilder<EmployeePositionBuilder<T>> where T: EmployeePositionBuilder<T>
    {
        public T AtPosition(string position)
        {
            employee.Position = position;
            return (T)this;
        }
    }

    public class EmployeeSalaryBuilder<T>: EmployeePositionBuilder<EmployeeSalaryBuilder<T>> where T: EmployeeSalaryBuilder<T>
    {
        public T WithSalary(double salary)
        {
            employee.Salary = salary;
            return (T)this;
        }
    }

    public class EmployeeBuilderDirector : EmployeeSalaryBuilder<EmployeeBuilderDirector>
    {
        public static EmployeeBuilderDirector NewEmployee => new EmployeeBuilderDirector();
    }


    class Program
    {
        static void Main(string[] args)
        {
            /*
            var employee = new EmployeeInfoBuilder();
            employee
                .SetName("Nick")
                .AtPosition(); // rött
            */
            
            var emp = EmployeeBuilderDirector
                .NewEmployee
                .SetName("Maks")
                .AtPosition("Software Developer")
                .WithSalary(3500)
                .Build();

            Console.WriteLine(emp);
        }
    }
}
