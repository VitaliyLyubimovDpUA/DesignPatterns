using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStoreOfPrototypePattern
{
    public class Bread : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public IProduct Clone()
        {
            return new Bread
            {
                Name = this.Name,
                Price = this.Price
            };
        }
    }
}
