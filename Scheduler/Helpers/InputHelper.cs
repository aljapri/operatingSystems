using System;

namespace Scheduler.Helpers
{
    public static class InputHelper
    {
        public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out value))
                {
                    Console.WriteLine("❌ Please enter a valid integer.");
                    continue;
                }

                if (value < min || value > max)
                {
                    Console.WriteLine($"❌ Value must be between {min} and {max}.");
                    continue;
                }

                return value;
            }
        }
    }
}
