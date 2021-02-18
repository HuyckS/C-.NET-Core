using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // RandomArray();
            // Console.WriteLine(TossCoin());
            Console.WriteLine(TossMultipleCoins(3));
            // List<string> names = Names();
            // foreach (string person in names)
            // {
            //     Console.WriteLine($"Name list includes: {person}");
            // }
        }

        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] randArr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                randArr[i] = rand.Next(5, 25);
            }
            int max = randArr[0];
            int min = randArr[0];
            int sum = 0;
            for (int j = 0; j < randArr.Length; j++)
            {
                if (randArr[j] > max)
                {
                    max = randArr[j];
                }
                if (randArr[j] < min)
                {
                    min = randArr[j];
                }
                sum = sum + randArr[j];
            }
            Console.WriteLine($"Min: {min}, Max: {max}, Sum: {sum}");
            return randArr;
        }

        public static string TossCoin()
        {
            Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int result = rand.Next(2);
            string output;
            if (result == 0)
            {
                Console.WriteLine("Heads!");
                output = "Heads!";
            }
            else
            {
                Console.WriteLine("Tails!");
                output = "Tails!";
            }
            return output;
        }

        public static double TossMultipleCoins(int num)
        {
            int num1 = 0;
            int num2 = 0;
            for (int i = 0; i < num; i++)
            {
                string result = TossCoin();
                if (result == "Heads!")
                {
                    num1 = num1 + 1;
                }
                else
                {
                    num2 = num2 + 1;
                }
            }
            double output = (double)num1 / num2;
            return output;
        }

        public static List<string> Names()
        {
            List<string> output = new List<string>();

            output.Add("Todd");
            output.Add("Tiffany");
            output.Add("Charlie");
            output.Add("Geneva");
            output.Add("Sydney");

            Random rand = new Random();


            for (int i = 0; i < 5; i++)
            {
                int randIdx = rand.Next(0, 5);
                string temp = output[i];
                output[i] = output[randIdx];
                output[randIdx] = temp;
            }

            for (int j = 0; j < 5; j++)
            {
                if (output[j].Length < 5)
                {
                    output.Remove(output[j]);
                }
            }
            return output;
        }
    }
}
