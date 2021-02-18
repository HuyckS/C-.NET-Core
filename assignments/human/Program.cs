using System;
using System.Collections.Generic;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Kakashi = new Human("Kakashi", 10, 10, 10, 130);
            Human Guy = new Human("Guy", 10, 10, 10, 110);
            Console.WriteLine(Kakashi.healthPoints);
            Console.WriteLine(Kakashi.Attack(Guy));
            Ninja Naruto = new Ninja("Naruto", 10, 10, 100);
        }
    }
    public class Human
    {
        // Fields for Human
        public string Name; 
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health { get; set; }

        // add a public "getter" property to access health
        public int healthPoints
        {
            get
            {
                return health;
            }
        }
        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;

        }
        // Add a constructor to assign custom values to all fields
        public Human(string name, int stren, int intel, int dex, int hp)
        {
            Name = name;
            Strength = stren;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;

        }
        // Build Attack method
        public int Attack(Human target)
        {
            int damage = 5 * this.Strength;
            int currentHp = target.healthPoints;
            target.health = currentHp - damage;
            Console.WriteLine($"You've taken damage! Your health is currently at {target.health}");
            return target.health;
        }
    }

    public class Ninja : Human
    {
        public Ninja(string name, int stren, int dex = 175, int intel, int hp) : base(Name, Strength, Intelligence, Dexterity, health)
        {


        }
    }

    // public class Wizard : Human
    // {

    // }

    // public class Samurai: Human
    // {

    // }
}

