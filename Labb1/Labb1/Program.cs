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
            Random randNum = new Random(420);

            int[] ten = CreateRandomArray(10);
            int[] oneHundred = CreateRandomArray(100);
            int[] oneThousand = CreateRandomArray(1000);
            int[] oneHundredThousand = CreateRandomArray(100000);
            int[] oneMillion = CreateRandomArray(1000000);

            // todo: spara värdena i variabler
            Console.WriteLine(CountNumber(ten, 1).TotalMilliseconds.ToString());
            Console.WriteLine(CountNumber(oneHundred, 1).TotalMilliseconds.ToString());
            Console.WriteLine(CountNumber(oneThousand, 1).TotalMilliseconds.ToString());
            Console.WriteLine(CountNumber(oneHundredThousand, 1).TotalMilliseconds.ToString());
            Console.WriteLine(CountNumber(oneMillion, 1).TotalMilliseconds.ToString());
            

            int[] CreateRandomArray(int n)
            {
                int[] array = new int[n];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = randNum.Next(min, max);
                }
                return array;
            }
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
