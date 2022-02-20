using System.Collections.Generic;
using System.Linq;

namespace Strategy
{
    // yet another strategy object:
    public class SeniorDevSalaryCalculator : ISalaryCalculator
    {
        public double CalculateTotalSalary(IEnumerable<DeveloperReport> reports)
            => reports
                .Where(r => r.Level == DeveloperLevel.Senior)
                .Select(r => r.CalculateSalary() * 1.2)
                .Sum();
    }
}
