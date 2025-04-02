using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 10;
            int[] ten = new int[100000];
            Random randNum = new Random(420);
            for (int i = 0; i < ten.Length; i++)
            {
                ten[i] = randNum.Next(min, max);
            }

            string timeTaken = (CountNumber(ten, 1).TotalMilliseconds).ToString();
            Console.WriteLine("Miliseconds: "+ timeTaken);

        }
        static TimeSpan CountNumber(int[] allNumbers, int desiredNumber)
        {
            var timer = new Stopwatch();
            
            int count = 0;
            timer.Start();
            for (int i = 0; i < allNumbers.Length; i++)
            {
                if (allNumbers[i] == desiredNumber)
                {
                    count++;
                }
            }
            timer.Stop();
            TimeSpan elapsed = timer.Elapsed;
            Console.WriteLine(count);
            return elapsed;
        }
    }
}
