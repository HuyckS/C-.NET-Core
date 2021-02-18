using System;
using System.Collections.Generic;

namespace basic_13
{
    public class Program
    {
        public static void PrintNumbers()
        {
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void PrintOdds()
        {
            for (int i = 1; i < 256; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        public static void PrintSum()
        {
            int sum = 0;
            for (int i = 1; i < 256; i++)
            {
                sum = sum + i;
                Console.WriteLine($"New number: {i} Sum: {sum}");
            }
        }
        public static void LoopArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        public static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }
        public static void GetAverage(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum = sum + i;
            }
            int result = sum / numbers.Length;
            Console.WriteLine(result);
        }
        public static int[] OddArray()
        {
            int[] oddNums = new int[255 / 2 + 1];
            int pos = 0;
            for (int i = 1; i < 256; i++)
            {
                if (i % 2 != 0)
                {
                    oddNums[pos] = i;
                    Console.WriteLine(oddNums[pos]);
                    pos = pos + 1;

                }
            }
            return oddNums;
        }
        public static int GreaterThanY(int[] numbers, int y)
        {
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > y)
                {
                    counter = counter + 1;
                }
            }
            return counter;
        }
        public static void SquareArrayValues(int[] numbers)
        {
            int[] squaredArr = new int[numbers.Length];
            int pos = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                squaredArr[pos] = numbers[i] * numbers[i];
                Console.WriteLine(squaredArr[pos]);
                pos = pos + 1;
            }
            Console.WriteLine(squaredArr);
        }
        public static void EliminateNegatives(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine(numbers);
        }
        public static void MinMaxAverage(int[] numbers)
        {
            int max = numbers[0];
            int min = numbers[0];
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                sum = sum + numbers[i];
            }
            int avg = sum / numbers.Length;
            Console.WriteLine($"Max: {max}, Min: {min}, Average: {avg}");
        }
        public static int[] ShiftValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1)
                {
                    numbers[i] = 0;
                }
                else
                {
                    numbers[i] = numbers[i + 1];
                }
                Console.WriteLine(numbers[i]);
            }
            return numbers;
        }

        public static object[] NumToString(int[] numbers)
        {
            object[] updatedArr = new object[numbers.Length];
            int pos = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    updatedArr[pos] = "Dojo";
                    pos = pos + 1;
                }
                else
                {
                    updatedArr[pos] = numbers[i];
                    pos = pos + 1;
                }
            }
            return updatedArr;
        }


        static void Main(string[] args)
        {
            int[] testNumbers = { 1, 2, -3, 4, 5 };
            // PrintNumbers();
            // PrintOdds();
            // PrintSum();
            // LoopArray(testNumbers);
            // Console.WriteLine(FindMax(testNumbers));
            // GetAverage(testNumbers);
            // Console.WriteLine(OddArray());
            // Console.WriteLine(GreaterThanY(testNumbers, 3));
            // SquareArrayValues(testNumbers);
            // EliminateNegatives(testNumbers);
            // MinMaxAverage(testNumbers);
            int[] shifted = ShiftValues(testNumbers);
            // object[] results = NumToString(testNumbers);
            foreach (int entry in shifted)
            {
                Console.WriteLine($"This is my shifted numbers: {entry}");
            }
        }
    }
}
