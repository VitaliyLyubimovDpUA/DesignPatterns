using StoreOfTheComuterTechnics.ComputerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfTheComuterTechnics
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerShop shop = new ComputerShop();
            shop.CompType = CompType.Apple;
            shop.MakeOrder(new HardDisc { Name = "Seagate", Price = 2459, Size = 2 }, null, null, null);
            Computer comp = shop.ConstructComputer();
            comp.DisplayConfiguration();
            Console.Read();
        }
    }
}
