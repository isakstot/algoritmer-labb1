using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Deluppgift 1
            BigOTester(CountNumber, "countNumberStats.csv");
            //Deluppgfit 2
            BigOTester(BruteForceBiggestDifference, "bruteforceStats.csv");
            BigOTester(BiggestDifference, "biggestDifferenceStats.csv");
        }

        static void BigOTester(Func<int[], double> method, string filePath)
        {
            Random randNum = new Random(420);
            int min = 0;
            int max = 10;

            int[] arrSizes = [10, 1000, 10000, 100000, 1000000];
            double[][] timeSpans = new double[arrSizes.Length][];
            int[][] randArr = new int[arrSizes.Length][];

            for (int i = 0; i < arrSizes.Length; i++)
            {
                randArr[i] = CreateRandomArray(arrSizes[i], randNum, min, max);
            }

            for (int i = 0; i < arrSizes.Length; i++)
            {
                timeSpans[i] = new double[100];
                for (int j = 0; j < 100; j++)
                {
                    timeSpans[i][j] = method(randArr[i]);
                }

            }

            double[] averageExecutionTime = new double[arrSizes.Length];
            string[] lines = new string[arrSizes.Length + 1];
            lines[0] = "Data size;Average execution time (ms)";
            for (int i = 0; i < arrSizes.Length; i++)
            {
                averageExecutionTime[i] = Math.Round(timeSpans[i].Average(), 5);
                Console.WriteLine($"Average execution time for {arrSizes[i]}: {averageExecutionTime[i]}");
                lines[i + 1] = $"{arrSizes[i]};{averageExecutionTime[i]}";
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

        // O(n)
        static double CountNumber(int[] allNumbers)
        {
            var timer = new Stopwatch();
            int desiredNumber = 1;
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

            return timer.Elapsed.TotalMilliseconds;
        }

        // O(n^2)
        static double BruteForceBiggestDifference(int[] arr)
        {
            var timer = new Stopwatch();
            int difference = 0;

            timer.Start();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] - arr[j] > difference)
                        difference = arr[i] - arr[j];
                }
            }
            timer.Stop();

            return timer.Elapsed.TotalMilliseconds;
        }

        // O(n)
        static double BiggestDifference(int[] arr)
        {
            var timer = new Stopwatch();
            int max = 0;
            int difference = 0;

            timer.Start();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (difference < max - arr[i])
                    difference = max - arr[i];
            }
            timer.Stop();

            return timer.Elapsed.TotalMilliseconds;
        }
    }
}