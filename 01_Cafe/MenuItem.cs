using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuItem
    {
        public MenuItem() { }
        public MenuItem(string name, int number, string description, List<string> ingredients, decimal price)
        {
            Name = name;
            Number = number;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }
    }
}
