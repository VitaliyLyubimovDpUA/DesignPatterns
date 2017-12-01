using StoreOfTheComuterTechnics.ComputerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfTheComuterTechnics
{
    public enum CompType
    {
        Apple, Desctop, Laptop
    }
    public class ComputerShop
    {
        private Storage storage = new Storage();
        IComputerBuilder builder;
        public CompType CompType
        {
            set
            {
                switch (value)
                {
                    case CompType.Apple:
                        builder = new Computer.AppleBuilder();
                        break;
                    default:
                        break;
                }
            }
        } 
        public Computer ConstructComputer()
        {
            return builder?.Build();
        }

        public void MakeOrder(HardDisc hardDisc, MotherBoard motherBoard, Processor processor, Screen screen)
        {
            builder.BuildHardDisk(storage.SearchHardDisc(hardDisc))
                   .BuildMotherBoard(storage.SearchMotherBoard(motherBoard))
                   .BuildProcessor(storage.SearchProcessor(processor))
                   .BuildScreen(storage.SearchScreen(screen));
        }
    }
}
