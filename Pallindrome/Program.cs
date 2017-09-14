using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pallindrome
{
    class Program
    {
        const string JustinesPalindromePhrase = "A man, a plan, a canal Panama";
        const ConsoleColor NormalBackgroundColor = ConsoleColor.Black;
        const ConsoleColor InverseBackgroundColor = ConsoleColor.DarkGray;
        const ConsoleColor NormalForegroundColor = ConsoleColor.Green;

        static void Main(string[] args)
        {
            Console.ForegroundColor = NormalForegroundColor;
            Console.BackgroundColor = NormalBackgroundColor;

            Console.WriteLine("*** Well, IS IT A PALINDROME (assuming actual words are entered) ***\r\n");
            WellIsItAPalindrome(JustinesPalindromePhrase);
            
            while (true)
            {
                Console.Write("Phrase: ");
                var phrase = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                if (string.IsNullOrWhiteSpace(phrase)) break;

                WellIsItAPalindrome(phrase);
            }
        }

        public static void WellIsItAPalindrome(string phrase)
        {
            Console.Write("Phrase: ");
            Console.BackgroundColor = InverseBackgroundColor;
            Console.Write($"{phrase}");
            Console.BackgroundColor = NormalBackgroundColor;
            Console.WriteLine($" is {(IsAPalindrome(phrase)?"A":"not a")} Palindrome");
        }

        public static bool IsAPalindrome(string phrase)
        {
            var cleanPhrase = new Regex(@"[\s.;,?%0-9]").Replace(phrase, string.Empty);
            return cleanPhrase.Equals(new string(cleanPhrase.Reverse().ToArray()), StringComparison.OrdinalIgnoreCase);         
        }
    }
}
