﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfTheComuterTechnics
{
    public interface IComponent
    {
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
