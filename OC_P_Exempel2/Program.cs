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

    public class MonitorFilter
    {
        public List<ComputerMonitor> FilterByType(IEnumerable<ComputerMonitor> monitors, MonitorType type) =>
            monitors.Where(m => m.Type == type).ToList();
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

            var lcdMonitors = filter.FilterByType(monitors, MonitorType.LCD);
            Console.WriteLine("All LCD monitors");
            foreach (var monitor in lcdMonitors)
            {
                Console.WriteLine($"Name: {monitor.Name}, Type: {monitor.Type}, Screen: {monitor.Screen}");
            }
        }
    }
}
