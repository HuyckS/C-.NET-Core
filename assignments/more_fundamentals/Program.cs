using System;
using System.Collections.Generic;

namespace more_fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] numArr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.Write(numArr[3]);

            string[] nameArr = { "Tim", "Martin", "Nikki", "Sara" };

            Console.WriteLine(nameArr[3]);

            bool[] boolArr = { true, false, true, false, true, false, true, false, true, false };

            Console.WriteLine(boolArr[9]);

            List<string> flavors = new List<string>();

            flavors.Add("chocolate");
            flavors.Add("vanilla");
            flavors.Add("peanut butter");
            flavors.Add("cookie dough");
            flavors.Add("mint chocolate chip");

            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.Remove(flavors[2]);
            Console.WriteLine(flavors.Count);

            Dictionary<string, string> userInfo = new Dictionary<string, string>();
            Random rand = new Random();

            foreach (string name in nameArr)
            {
                userInfo.Add(name, flavors[rand.Next(0, 4)]);
            }

            foreach (var entry in userInfo)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
