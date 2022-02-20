using System.Collections.Generic;
using System.Linq;

namespace Strategy
{
    // one concrete strategy objects:
    public class JuniorDevSalaryCalculator : ISalaryCalculator
    {
        public double CalculateTotalSalary(IEnumerable<DeveloperReport> reports)
            => reports
                .Where(r => r.Level == DeveloperLevel.Junior)
                .Select(r => r.CalculateSalary())
                .Sum();
    }
}
