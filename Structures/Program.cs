using System;

namespace Structures
{
    public struct Time
    {
        private int _hours, _minutes, _seconds;
        public Time(int hours, int minutes, int seconds)
        {
            _hours = hours; // In the constructor, we must initalise all three fields!
            _minutes = minutes;
            _seconds = seconds;
        }

        public void PrintTime()
        {
            Console.WriteLine($"Hours: {_hours}, Minutes: {_minutes}, Seconds: {_seconds}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // To access the structure
            Time time = new Time(3, 30, 25);
            time.PrintTime();

            //Console.ReadKey();
        }
    }
}
