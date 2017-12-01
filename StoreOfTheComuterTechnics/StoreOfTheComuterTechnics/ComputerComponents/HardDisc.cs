using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfTheComuterTechnics.ComputerComponents
{
    public class HardDisc : IComponent
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Size { get; set; }

        public override string ToString()
        {
            return $"HardDics\nНазвание: {Name} Цена: {Price} {Size}ТБ";
        }
    }
}
