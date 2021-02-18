using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<object> testList = new List<object>();

            testList.Add(7);
            testList.Add(28);
            testList.Add(-1);
            testList.Add(true);
            testList.Add("chair");

            int sum = 0;

            foreach (var entry in testList)
            {
                if (entry is int || entry is bool || entry is string)
                {
                    Console.WriteLine(entry);
                }
                if (entry is int)
                {
                    sum = sum + (int)entry;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
