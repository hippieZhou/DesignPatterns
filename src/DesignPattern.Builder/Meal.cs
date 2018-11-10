using System;
using System.Collections.Generic;
using DesignPattern.Builder.Interfaces;

namespace DesignPattern.Builder
{
    public class Meal
    {
        private List<IItem> items = new List<IItem>();

        public void AddItem(IItem item)
        {
            if (item != null) items.Add(item);
        }

        public float GetCost()
        {
            float cost = 0.0f;
            foreach (IItem item in items)
            {
                cost += item.Price();
            }

            return cost;
        }

        public void ShowItems()
        {
            foreach (IItem item in items)
            {
                Console.WriteLine($"Name:{item.Name()}");
                Console.WriteLine($"Packing:{item.Packing()}");
                Console.WriteLine($"Price:{item.Price()}");
            }
        }
    }
}
