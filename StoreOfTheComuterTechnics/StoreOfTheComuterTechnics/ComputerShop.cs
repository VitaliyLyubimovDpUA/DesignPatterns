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
        Apple, Desktop, Laptop
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
                    case CompType.Desktop:
                        builder = new Computer.DesktopBuilder();
                        break;
                    case CompType.Laptop:
                        builder = new Computer.LaptopBuilder();
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
