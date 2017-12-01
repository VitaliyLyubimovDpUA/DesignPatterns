using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfTheComuterTechnics.ComputerComponents
{
    public class Processor: IComponent
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"Processor\nНазвание: %{Name} Цена: {Price}";
        }
    }
}
