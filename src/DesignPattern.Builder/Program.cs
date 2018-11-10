using System;

namespace DesignPattern.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            MealBuilder builder = new MealBuilder();

            Meal vegMeal = builder.PrepareVegMeal();
            Console.WriteLine("Veg Meal");
            vegMeal.ShowItems();
            Console.WriteLine($"Total Cost:{vegMeal.GetCost()}");

            Console.WriteLine("-----------------");

            Meal nonVegMeal = builder.PrepareNonMeal();
            Console.WriteLine("Non-Veg Meal");
            nonVegMeal.ShowItems();
            Console.WriteLine($"Total Cost:{nonVegMeal.GetCost()}");

            Console.ReadKey();
        }
    }
}
