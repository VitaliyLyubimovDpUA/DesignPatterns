using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStoreOfPrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Supermarket market = new Supermarket();
            List<IProduct> cart = new List<IProduct>();
            int choice;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Show products");
                Console.WriteLine("[2] Cart");
                Console.WriteLine("[3] Exit");
                Console.Write("Your selection: ");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            market.ShowProducts();
                            Console.WriteLine("Enter the name of the product which you want to select(0 - for exit)");
                            string productName = Console.ReadLine();
                            if (productName == "0") break;
                            var selectedProduct = market.GetProduct(productName);
                            if (selectedProduct is null) Console.WriteLine("The selected product was not found");
                            else
                            {
                                cart.Add(selectedProduct);
                                Console.WriteLine("The product has been added to the cart");
                            }

                            Console.Read();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Basket products:");
                            if (cart.Count == 0)
                            {
                                Console.WriteLine("Cart is empty");
                                Console.Read();
                            }
                            else
                            {
                                foreach (var item in cart)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            Console.Read();
                            break;
                        }
                    case 3: { Environment.Exit(0); break; }
                    default:
                        Console.WriteLine("Action selected icorrectly");
                        break;
                }
            }
        }
    }
}
