using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStoreOfPrototypePattern
{
    public interface IProductPrototype
    {
        IProduct Clone();
    }
}
