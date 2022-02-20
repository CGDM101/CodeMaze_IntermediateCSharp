using System.Collections.Generic;

namespace Strategy
{
    public interface ISalaryCalculator
    {
        double CalculateTotalSalary(IEnumerable<DeveloperReport> reports);
    }
}
