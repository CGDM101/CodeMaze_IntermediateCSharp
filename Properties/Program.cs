using System;

namespace Properties
{
    public class Student
    {
        private string _name;
        private string _lastName;

        public string Name
        {
            get { return _name; }
            set { _name = value; } // - name = CheckValue(value) example of condition
        }
        // private int CheckValue(int val) { code executuon }

        public string LastName
        {
            get { return _lastName; } // read actions
            set { _lastName = value; } // set actions
        }

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
            Student student = new Student("John", "Doe");

            // Read private field with the object's public property
            string name = student.Name; // Call to a get block of the Name property
            string lastName = student.LastName; // call to a get block

            // Write to private field...
            student.Name = "David"; // Call to a set block of the Name property
            student.LastName = "Dauni"; // Call to a set block
        }
    }
}
