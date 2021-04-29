using System;

namespace CodeMaze
{
    public partial class Student // partial
    {
        // Class members are defined within the class body
        private string _name;
        private string _lastName;

        // A default constructor:
        public Student()
        {
            _name = string.Empty; // default values
            _lastName = string.Empty;
        }
    }

    public partial class Student // partial
    {
        // Another constructor (ctor overloading):
        public Student(string name, string lastName)
        {
            _name = name;
            _lastName = lastName;
        }

        public string GetFullName()
        {
            return _name + ' ' + _lastName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The class is a reference type, so to initialise it we need to use new:
            Student student = new Student(); // Now the student object can access the members of the Student class. 
            // Here the default constructor gets called.
            Student stud = new Student("John", "Doe"); // .. and here the overloaded constructor.

            // To call the class method:
            student.GetFullName(); // ""
            stud.GetFullName(); // "John Doe"


        }
    }
}
