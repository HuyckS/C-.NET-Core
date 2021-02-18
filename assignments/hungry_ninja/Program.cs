using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet AllYouCanEat = new Buffet();
            Ninja Naruto = new Ninja("Naruto");
            Food item1 = AllYouCanEat.Serve();
            Food item2 = AllYouCanEat.Serve();
            Food item3 = AllYouCanEat.Serve();
            Food item4 = AllYouCanEat.Serve();
            Food item5 = AllYouCanEat.Serve();
            Food item6 = AllYouCanEat.Serve();
            Food item7 = AllYouCanEat.Serve();
            Naruto.Eat(item1);
            Naruto.Eat(item2);
            Naruto.Eat(item3);
            Naruto.Eat(item4);
            Naruto.Eat(item5);
            Naruto.Eat(item6);
            Naruto.Eat(item7);
            Naruto.Eat(item4);
            Naruto.Eat(item5);
            Naruto.Eat(item6);
            Naruto.Eat(item7);
            Naruto.Eat(item4);
            Naruto.Eat(item5);
            Naruto.Eat(item6);
            Naruto.Eat(item7);
            Console.WriteLine(Naruto.isFull());
        }
    }


    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy;
        public bool IsSweet;
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string name, int cals, bool spicy, bool sweet)
        {
            Name = name;
            Calories = cals;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }

    class Buffet
    {
        public List<Food> Menu;

        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
        {
            new Food("Pizza", 100, false, false),
            new Food("Sushi", 50, true, false),
            new Food("Tacos", 70, true, false),
            new Food("Snacks", 90, true, true),
            new Food("BBQ", 110, true, true),
            new Food("Pho", 50, true, false),
            new Food("Gyros", 80, true, false),

        };
        }

        public Food Serve()
        {
            Random rand = new Random();

            return Menu[rand.Next(0, 7)];
        }
    }

    class Ninja
    {
        public string NinjaName;
        private int calorieIntake;
        public List<Food> FoodHistory;

        // add a constructor
        public Ninja(string name)
        {
            NinjaName = name;
            calorieIntake = 0;
            FoodHistory = new List<Food>() { };

        }
        // add a public "getter" property called "IsFull"
        public bool isFull()
        {
            bool output = false;
            if (this.calorieIntake >= 1200)
            {
                output = true;
            }
            return output;

        }
        // build out the Eat method
        public void Eat(Food item)
        {
            if (!this.isFull())
            {
                this.calorieIntake = this.calorieIntake + item.Calories;
                this.FoodHistory.Add(item);
                string result1 = "was not";
                string result2 = "was not";
                if (item.IsSpicy == true)
                {
                    result1 = "was";
                }
                if (item.IsSweet == true)
                {
                    result2 = "was";
                }
                Console.WriteLine($"{this.NinjaName} just enjoyed eating {item.Name}. It {result1} spicy and {result2} sweet.");
            }
            else
            {
                Console.WriteLine("Tum tum full -- no more snacky snack.");
            }
        }
    }
}



