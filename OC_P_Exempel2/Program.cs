using System;
using System.Collections.Generic;
using System.Linq;

namespace OC_P_Exempel2
{
    public enum MonitorType
    {
        OLED,
        LCD,
        LED
    }

    public enum Screen
    {
        WideScreen,
        CurvedScreen
    }

    public class ComputerMonitor
    {
        public string Name { get; set; }
        public MonitorType Type { get; set; }
        public Screen Screen { get; set; }
    }

    public class MonitorFilter : IFilter<ComputerMonitor>
    {
        public List<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> monitors, ISpecification<ComputerMonitor> specification) =>
                monitors.Where(m => specification.isSatisfied(m)).ToList();
        public List<ComputerMonitor> FilterByType(IEnumerable<ComputerMonitor> monitors, MonitorType type) =>
            monitors.Where(m => m.Type == type).ToList();

        // Om vi behöver filtrera på screen också, förutom monitortype:
        public List<ComputerMonitor> FilterByScreen(IEnumerable<ComputerMonitor> monitors, Screen screen) =>
            monitors.Where(m => m.Screen == screen).ToList();
       
    }

    public interface ISpecification<T>
    {
        bool isSatisfied(T item);
    }

    public interface IFilter<T>
    {
        List<T> Filter(IEnumerable<T> monitors, ISpecification<T> specification);
    }

    public class MonitorTypeSpecification: ISpecification<ComputerMonitor>
    {
        private readonly MonitorType _type;

        public MonitorTypeSpecification(MonitorType type)
        {
            _type = type;
        }

        public bool isSatisfied(ComputerMonitor item) => item.Type == _type;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var monitors = new List<ComputerMonitor>
            {
                new ComputerMonitor{Name="Samsung S345", Screen=Screen.CurvedScreen,Type=MonitorType.OLED },
                new ComputerMonitor{Name="Philips P532", Screen=Screen.WideScreen,Type=MonitorType.LCD },
                new ComputerMonitor{Name="LG L888", Screen=Screen.WideScreen,Type=MonitorType.LED },
                new ComputerMonitor{Name="Samsung S999", Screen=Screen.WideScreen,Type=MonitorType.OLED },
                new ComputerMonitor{Name="Dell D2J47", Screen=Screen.CurvedScreen,Type=MonitorType.LCD }
            };

            var filter = new MonitorFilter();

            var lcdMonitors = filter.Filter(monitors, new MonitorTypeSpecification(MonitorType.LCD));
                        
            Console.WriteLine("All LCD monitors");
            foreach (var monitor in lcdMonitors)
            {
                Console.WriteLine($"Name: {monitor.Name}, Type: {monitor.Type}, Screen: {monitor.Screen}");
            }
        }
    }
}