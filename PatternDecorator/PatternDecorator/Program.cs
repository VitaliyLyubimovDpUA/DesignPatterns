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
        public CheeseToppings(Pizza pizza) : base(pizza, $"{pizza.Name}, с сыром") { }
    }
    class ChickenToppings
    {

    }
    class MushroomsToppings
    {

    }



    class Program
    {
        static void Main(string[] args)
        {
            
            Pizza pizza = new PlainPizza();
            pizza = new CheeseToppings(pizza);
            Console.WriteLine(pizza);
                        


            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
