using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // initialize a random number generator with a fixed seed
            Random randNum = new Random(420);
            int min = 0;
            int max = 10;

            TimeSpan[] allTen = new TimeSpan[100];
            TimeSpan[] allOneHundred = new TimeSpan[100];
            TimeSpan[] allOneThousand = new TimeSpan[100];
            TimeSpan[] allOneHundredThousand = new TimeSpan[100];
            TimeSpan[] allOneMillion = new TimeSpan[100];

            for (int i = 0; i < 100; i++)
            {
                int[] ten = CreateRandomArray(10, randNum, min, max);
                int[] oneHundred = CreateRandomArray(100, randNum, min, max);
                int[] oneThousand = CreateRandomArray(1000, randNum, min, max);
                int[] oneHundredThousand = CreateRandomArray(100000, randNum, min, max);
                int[] oneMillion = CreateRandomArray(1000000, randNum, min, max);

                TimeSpan resultTen = CountNumber(ten, 1);
                allTen[i] = resultTen;

                TimeSpan resultOneHundred = CountNumber(oneHundred, 1);
                allOneHundred[i] = resultOneHundred;

                TimeSpan resultOneThousand = CountNumber(oneThousand, 1);
                allOneThousand[i] = resultOneThousand;

                TimeSpan resultOneHundredThousand = CountNumber(oneHundredThousand, 1);
                allOneHundredThousand[i] = resultOneHundredThousand;

                TimeSpan resultOneMillion = CountNumber(oneMillion, 1);
                allOneMillion[i] = resultOneMillion;
            }

            double averageTen = allTen.Average(timeSpan => timeSpan.TotalMilliseconds);
            double averageOneHundred = allOneHundred.Average(timeSpan => timeSpan.TotalMilliseconds);
            double averageOneThousand = allOneThousand.Average(timeSpan => timeSpan.TotalMilliseconds);
            double averageOneHundredThousand = allOneHundredThousand.Average(timeSpan => timeSpan.TotalMilliseconds);
            double averageOneMillion = allOneMillion.Average(timeSpan => timeSpan.TotalMilliseconds);

            Console.WriteLine($"Average time for 10: {averageTen}");
            Console.WriteLine($"Average time for 100: {averageOneHundred}");
            Console.WriteLine($"Average time for 1000: {averageOneThousand}");
            Console.WriteLine($"Average time for 100000: {averageOneHundredThousand}");
            Console.WriteLine($"Average time for 1000000: {averageOneMillion}");
        }

        static int[] CreateRandomArray(int n, Random randNum, int min, int max)
        {
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(min, max);
            }
            return array;
        }

        // O(n) time complexity
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
            //Console.WriteLine(count);
            return elapsed;
        }
    }
}
