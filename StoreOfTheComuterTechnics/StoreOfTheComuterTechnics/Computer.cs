using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfTheComuterTechnics
{
    public class Computer
    {
        private List<IComponent> components { get; set; }
        public Computer()
        {
            components = new List<IComponent>();
        }
        public void DisplayConfiguration()
        {
            foreach (var component in components)
            {
                if (component != null)
                    Console.WriteLine(component);
            }
        }
        public class AppleBuilder : IComputerBuilder
        {
            private Computer computer = new Computer();

            public Computer Build() => computer;

            public IComputerBuilder BuildHardDisk(IComponent component)
            {
                computer.components.Add(component);
                return this;
            }

            public IComputerBuilder BuildMotherBoard(IComponent component)
            {
                computer.components.Add(component);
                return this;
            }

            public IComputerBuilder BuildProcessor(IComponent component)
            {
                computer.components.Add(component);
                return this;
            }

            public IComputerBuilder BuildScreen(IComponent component)
            {
                computer.components.Add(component);
                return this;
            }
        }
    }
}
