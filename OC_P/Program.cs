using System;
using System.Collections; // IEnumerable
using System.Collections.Generic; // IEnumerable<>

namespace OC_P
{
    public class DeveloperReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int WorkingHours { get; set; }
        public double HourlyRate { get; set; }
    }

    public class SalaryCalculator
    {
        private readonly IEnumerable<DeveloperReport> _developerReports;

        public SalaryCalculator(List<DeveloperReport> developerReports)
        {
            _developerReports = developerReports;
        }

        public double CalculateTotalSalaries()
        {
            double totaSalaries = 0D;

            foreach (var devReport in _developerReports)
            {
                // Modification of existing method due to changed requirements - not OCP!
                if (devReport.Level=="Senior developer")
                {
                    totaSalaries += devReport.HourlyRate * devReport.WorkingHours * 1.2;
                }
                else
                {
                    totaSalaries += devReport.HourlyRate * devReport.WorkingHours;
                }
            }

            return totaSalaries;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // OCP:The software entities (classes or methods) should be open for extension, but closed for modification. Extend it - not modify!

            var devReports = new List<DeveloperReport>
            {
                new DeveloperReport{ Id=1,Name="Dev1",Level="Senior developer", HourlyRate=30.5,WorkingHours=160},
                new DeveloperReport{ Id=2,Name="Dev2",Level="Junior developer", HourlyRate=20,WorkingHours=150},
                new DeveloperReport{ Id=3,Name="Dev3",Level="Senior developer", HourlyRate=30.5,WorkingHours=180}
            };

            var calculator = new SalaryCalculator(devReports);
            Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");
        }
    }
}
