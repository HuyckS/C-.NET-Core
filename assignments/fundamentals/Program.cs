using System;

namespace fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int num1 = 5;
            int num2 = 10;
            int sum = 0;
            int sum2 = 50;
            for (int i = num1; i < num2; i++)
            {
                Console.WriteLine(i);
                sum = sum + i;
            }
            Console.WriteLine(sum);

            while (num1 < num2)
            {
                sum2 = sum2 - num1;
                num1 = num1 + 1;
            }
            Console.WriteLine(sum2);

            if (sum <= sum2)
            {
                Console.WriteLine($"Actually, {sum} is less than {sum2}");
            }
            else
            {
                Console.WriteLine($"The number {sum} is greater than {sum2}");
            }
        }
    }
}
