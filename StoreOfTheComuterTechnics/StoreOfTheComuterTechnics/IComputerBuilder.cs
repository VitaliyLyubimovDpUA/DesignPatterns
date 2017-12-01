using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfTheComuterTechnics
{
    public interface IComputerBuilder
    {
        IComputerBuilder BuildHardDisk(IComponent component);
        IComputerBuilder BuildMotherBoard(IComponent component);
        IComputerBuilder BuildProcessor(IComponent component);
        IComputerBuilder BuildScreen(IComponent component);
        Computer Build();
    }
}
