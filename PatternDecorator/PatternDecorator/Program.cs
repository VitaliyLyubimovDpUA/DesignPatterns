using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatternDecorator
{
    interface Pizza
    {
        string Name { get; set; }
        decimal Price { get; set; }
    }

    class PlainPizza : Pizza
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PlainPizza()
        {
            Name = "Пицца";
        }
    }

    class ToppingPizza: Pizza
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    abstract class ToppingDecorator: Pizza
    {
        private Pizza pizza;
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ToppingDecorator(Pizza pizza, string name)
        {
            this.pizza = pizza;
            this.pizza.Name = name;
        }
        public override string ToString()
        {
            return $"{pizza.Name}, {pizza.Price}";
        }
    }

    class CheeseToppings : ToppingDecorator
    {
        public CheeseToppings(Pizza pizza) : base(pizza, $"{pizza.Name}, с сыром")
        {
            pizza.Price = 79.20m;
        }
    }
    class ChickenToppings : ToppingDecorator
    {
        public ChickenToppings(Pizza pizza) : base(pizza, $"{pizza.Name}, с курицей")
        {
            pizza.Price = 102.60m;
        }
    }
    class MushroomsToppings : ToppingDecorator
    {
        public MushroomsToppings(Pizza pizza) : base(pizza, $"{pizza.Name}, с грибами")
        {
            pizza.Price = 107.90m;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            
            Pizza pizzaСheese = new PlainPizza();
            pizzaСheese = new CheeseToppings(pizzaСheese);
            Console.WriteLine(pizzaСheese);

            Pizza pizzaChicken = new PlainPizza();
            pizzaChicken = new ChickenToppings(pizzaChicken);
            Console.WriteLine(pizzaChicken);

            Pizza pizzaMushrooms = new PlainPizza();
            pizzaMushrooms = new MushroomsToppings(pizzaMushrooms);
            Console.WriteLine(pizzaMushrooms);

            Console.ReadLine();
        }
    }
}
