using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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

            int[] arrSizes = [10, 100, 1000, 10000, 100000, 1000000];
            TimeSpan[][] timeSpans = new TimeSpan[arrSizes.Length][];
            int[][] randArr = new int[arrSizes.Length][];

            for (int i = 0; i < arrSizes.Length; i++)
            {
                randArr[i] = CreateRandomArray(arrSizes[i], randNum, min, max);
            }

            for (int i = 0; i < arrSizes.Length; i++)
            {
                timeSpans[i] = new TimeSpan[100];
                for (int j = 0; j < 100; j++)
                {
                    timeSpans[i][j] = CountNumber(randArr[i], 1);
                }

            }

            double[] averageExecutionTime = new double[arrSizes.Length];
            string[] lines = new string[arrSizes.Length +1];
            lines[0] = "Data size;Average execution time (ms)";
            string filePath = "stats.csv";
            for (int i = 0; i < arrSizes.Length; i++)
            {
                averageExecutionTime[i] = Math.Round(timeSpans[i].Average(timeSpan => timeSpan.TotalMilliseconds), 5);
                Console.WriteLine($"Average execution time for {arrSizes[i]}: {averageExecutionTime[i]}");
                lines[i+1] = $"{arrSizes[i]};{averageExecutionTime[i]}";
            }

            File.WriteAllLines(filePath, lines);

        }

        static int[] CreateRandomArray(int sampleSize, Random randNum, int min, int max)
        {
            int[] array = new int[sampleSize];
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
            return elapsed;
        }
    }
}