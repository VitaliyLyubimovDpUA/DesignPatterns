using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStoreOfPrototypePattern
{
    public class Milk : IProduct
    {
        public string Name { get ; set; }
        public decimal Price { get; set; }

        public IProduct Clone()
        {
            return new Milk
            {
                Name = this.Name,
                Price = this.Price
            };
        }
        public override string ToString()
        {
            return $"{Name} {Price}{Supermarket.Currency.ToString()}";
        }
    }
}
