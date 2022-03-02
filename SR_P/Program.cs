using System;
using System.Collections.Generic;
using System.IO; // Directory, Path
using System.Linq;
using static SR_P.FileSaver;

namespace SR_P
{
    public interface IEntryManager<T>  // add to workreport
    {
        void AddEntry(T entry);
        void RemoveEntryAt(int index);
    }
    public class WorkReportEntry
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int SpentHours { get; set; }
    }

    public class WorkReport : IEntryManager<WorkReportEntry> // Interface is added
                                                             // Has many responsibilities related to workreporting. More can be added also... So it has more than one reason to change in the future, e g if we want to save a file in another way...
    {
        private readonly List<WorkReportEntry> _entries;

        public WorkReport() // 1. Create entries.
        {
            _entries = new List<WorkReportEntry>();
        }

        public void AddEntry(WorkReportEntry entry) => _entries.Add(entry); // 2. Add entries

        public void RemoveEntryAt(int index) => _entries.RemoveAt(index); // 3. Remove entries.

        // Removed into new class and modified.
        /*
        public void SaveToFile(string directoryPath, string fileName) // 3. Save entries to file.
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(Path.Combine(directoryPath, fileName), ToString());
        }*/

        public override string ToString() =>
                string.Join(Environment.NewLine, _entries.Select(x => $"Code: {x.ProjectCode}, Name: {x.ProjectName}, Hours: {x.SpentHours}"));
    }

    public class FileSaver // New class for filesaving
    {
        /*
        public void SaveToFile(string directoryPath, string fileName, WorkReport report) // obs workreport cs!
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(Path.Combine(directoryPath, fileName), report.ToString()); // workreport
        }*/

        // After interface.
        public void SaveToFile<T>(string directoryPath, string fileName, IEntryManager<T> workReport)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(Path.Combine(directoryPath, fileName), workReport.ToString()); // workreport is T now
        }

        public class ScheduleTask // Simple to add this class/feature/task if we have the new interface.
        {
            public int TaskId { get; set; }
            public string Content { get; set; }
            public DateTime ExecuteOn { get; set; }
        }

        public class Scheduler : IEntryManager<ScheduleTask>
        {
            private readonly List<ScheduleTask> _scheduleTasks;

            public Scheduler()
            {
                _scheduleTasks = new List<ScheduleTask>();
            }

            public void AddEntry(ScheduleTask entry) => _scheduleTasks.Add(entry);

            public void RemoveEntryAt(int index) => _scheduleTasks.RemoveAt(index);

            public override string ToString() =>
                string.Join(Environment.NewLine, _scheduleTasks.Select(x => $"Task with id: {x.TaskId} with content: {x.Content} is going to be executed on: {x.ExecuteOn}"));

        }
    }

    class Program
    {
        // Maintainable and readable code - each and every class should do its own task! Not responsible for several different tasks (then it is more likely to change in the future)!
        // SRP - A class should have only one reason to change - Only one responsibility!
        // Separation of concerns!
        // Testing becomes easier.
        // Decoupled classes - independent of eachother.
        // Methods become highly related (coherent) - different methods are joinged to do one thing and do it well.

        // In projects that are already written, it is difficult to implement SRP.
        // Complact classes with tiny methods, but that can create organisational risk! - Group them well!
        static void Main(string[] args)
        {
            var report = new WorkReport();
            report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
            report.AddEntry(new WorkReportEntry { ProjectCode = "987FC", ProjectName = "Project2", SpentHours = 3 });

            //
            var scheduler = new Scheduler();
            scheduler.AddEntry(new ScheduleTask { TaskId = 1, Content = "Do something now.", ExecuteOn = DateTime.Now.AddDays(5) });
            scheduler.AddEntry(new ScheduleTask { TaskId = 2, Content = "Don't forget to...", ExecuteOn = DateTime.Now.AddDays(2) });
            //

            Console.WriteLine(report.ToString());
            Console.WriteLine(scheduler.ToString()); //

            var saver = new FileSaver();
            saver.SaveToFile(@"Reports", "WorkReport.txt", report);
            saver.SaveToFile(@"Schedulers", "Schedule.txt", scheduler); //
        }
    }
}
