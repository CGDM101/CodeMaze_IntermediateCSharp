using System;
using System.Collections.Generic;

namespace Visitor
{
    public enum AlertReport
    {
        NotAnalyzable = -1,
        LowRisk = 0,
        HighRisk = 1
    }
    public interface ISicknessAlertVisitable
    {
        AlertReport Accept(ISicknessAlertVisitor visitor);
    }

    public interface ISicknessAlertVisitor
    {
        AlertReport Visit(BloodSample blood);
        AlertReport Visit(XRayImage rtg);
        AlertReport Visit(EcgReading sample);
    }

    public class BloodSample : ISicknessAlertVisitable
    {
        // Blood sample-specific  data and methods
        public AlertReport Accept(ISicknessAlertVisitor visitor) => visitor.Visit(this);
    }

    public class XRayImage : ISicknessAlertVisitable
    {
        // X-ray image-specific data and methods
        public AlertReport Accept(ISicknessAlertVisitor visitor) => visitor.Visit(this);
    }

    public class EcgReading : ISicknessAlertVisitable
    {
        public AlertReport Accept(ISicknessAlertVisitor visitor) => visitor.Visit(this);
    }

    public class HivDetector : ISicknessAlertVisitor
    {
        public AlertReport Visit(BloodSample blood)
        {
            Console.WriteLine($"{GetType().Name} - Checking blood sample");
            // Analyse the blood and return correct risk value.
            return AlertReport.LowRisk;
        }

        public AlertReport Visit(XRayImage rtg)
        {
            Console.WriteLine($"{GetType().Name} - Currently cannot detect HIV based on X-Ray");
            return AlertReport.NotAnalyzable;
        }
        public AlertReport Visit(EcgReading sample)
        {
            Console.WriteLine($"{GetType().Name} - Checking blood sample");
            // Analyse the heart beats and return correct risk value.
            return AlertReport.HighRisk;
        }
    }

    public class TestResultsMonitorApp
    {
        private readonly List<ISicknessAlertVisitor> detectors;

        public TestResultsMonitorApp(List<ISicknessAlertVisitor> _detectors)
        {
            _detectors = detectors;
        }

        public List<AlertReport> AnalyzeResultsBatch(IEnumerable<ISicknessAlertVisitable> testResults)
        {
            var alertReports = new List<AlertReport>();

            foreach (var sample in testResults)
            {
                foreach (var detector in detectors) // _detectors?
                {
                    alertReports.Add(sample.Accept(detector));
                }
            }
            return alertReports;
        }
    }

    class Program
    {
        // Allows decoupling algorithms, from the objects on which they operate. - typesafe and solid! One of the most complex classic design patterns. 1) Vistor 2) Visitable/Visistee (or the Element).
        // Visitor is the class that adds the extra functionalities to the elements that it visits. Visistable is the class that can accept a visitor to become enriched with extra functionalities.
        // By creating new visitors we are extending the domain elements without changing them - Open/closed principle! Allows for creating plugins and extemsnions by external developers.

        // One of the most complex patterns. Not used too often.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
