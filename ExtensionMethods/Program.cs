using System;

namespace ExtensionMethods
{
    // EXAMPLE WITHOUT EXTENSTION METHOD:
    /*
    class Program
    {
        private static string FirstLetterOrUppercase(string word)
        {
            char letter = Char.ToUpper(word[0]);
            string remaining = word.Substring(1);

            return letter + remaining;
        }

        static void Main(string[] args)
        {
            string word = "football";
            string newWord = FirstLetterOrUppercase(word);
        }
    }*/

    // EXAMPLE WITH EXTENSION METHOD
    public static class StringExtensions
    {
        public static string FirstLetterOrUppercase(this string word) // this framför (första) parametern
        {
            char letter = Char.ToUpper(word[0]);
            string remaining = word.Substring(1);

            return letter + remaining;
        }
    }
    public class Program
    {
        static void Main()
        {
            string word = "football".FirstLetterOrUppercase(); // The extension method (a utility method).

            Console.WriteLine(word);
            Console.ReadKey();
        }
    }
}
