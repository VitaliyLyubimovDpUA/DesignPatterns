using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStoreOfPrototypePattern
{
    public class Supermarket
    {
        private List<IProduct> products;
        public Supermarket()
        {
            products = new List<IProduct>
            {
                new Bread
                {
                    Name = "Бородинский",
                    Price = 10.50m
                },
                new Bread
                {
                    Name = "Днепровский",
                    Price = 16.30m
                },
                new Bread
                {
                    Name = "Простоквашино",
                    Price = 28.70m
                }
            };
        }
        public void AddProduct(IProduct product) => products.Add(product);
        public IProduct GetProduct(string name)
        {
            var product = products.Where(prod => prod.Name == name).FirstOrDefault();
            if (product is null) return null;

            return product.Clone();
        }

    }
}
