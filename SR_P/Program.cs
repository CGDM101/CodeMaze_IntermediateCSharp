using System;
using System.Collections.Generic;
using System.IO; // Directory, Path
using System.Linq;

namespace SR_P
{
    public class WorkReportEntry
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int SpentHours { get; set; }
    }

    public class WorkReport // Has many responsibilities related to workreporting. More can be added also... So it has more than one reason to change in the future, e g if we want to save a file in another way...
    {
        private readonly List<WorkReportEntry> _entries;

        public WorkReport() // 1. Create entries.
        {
            _entries = new List<WorkReportEntry>();
        }

        public void AddEntry(WorkReportEntry entry) => _entries.Add(entry); // 2. Add entries

        public void RemoveEntryAt(int index) => _entries.RemoveAt(index); // 3. Remove entries.

        public void SaveToFile(string directoryPath, string fileName) // 3. Save entries to file.
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(Path.Combine(directoryPath, fileName), ToString());
        }

        public override string ToString() =>
                string.Join(Environment.NewLine, _entries.Select(x => $"Code: {x.ProjectCode}, Name: {x.ProjectName}, Hours: {x.SpentHours}"));

    }

    class Program
    {
        // Maintainable and readable code - each and every class should do its own task! Not responsible for several different tasks (then it is more likely to change in the future)!
        // SRP - A class should have only one reason to change - Only one responsibility!
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
