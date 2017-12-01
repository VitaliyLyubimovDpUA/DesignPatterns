using StoreOfTheComuterTechnics.ComputerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfTheComuterTechnics
{
    public class Storage
    {
        public List<HardDisc> HardDiscs { get; set; } = new List<HardDisc>();
        public List<Processor> Processors { get; set; } = new List<Processor>();
        public List<MotherBoard> MotherBoards { get; set; } = new List<MotherBoard>();
        public List<Screen> Screens { get; set; } = new List<Screen>();
        public Storage()
        {
            /* -= Инициализация жестких дисков =- */
            HardDiscs.AddRange(new HardDisc[] 
            {
                new HardDisc { Name = "Seagate", Price = 2459, Size = 2 },
                new HardDisc { Name = "Western Digital", Price = 2599, Size = 2 },
                new HardDisc { Name = "Western Digital", Price = 3129, Size = 2 },
                new HardDisc { Name = "Apacer", Price = 2653, Size = 2 }
            });
            /* -= Инициализация процессоров =- */
            Processors.AddRange(new Processor[]
            {
                new Processor { Name = "Intel Core i9", Price = 31896 },
                new Processor { Name = "Intel Core i7", Price = 10720 },
                new Processor { Name = "Intel Core i5", Price = 6055 }
            });
            /* -= Инициализация материнских плат =- */
            MotherBoards.AddRange(new MotherBoard[]
            {
                new MotherBoard { Name = "Asus", Price = 4061 },
                new MotherBoard { Name = "MSI", Price = 3878 },
                new MotherBoard { Name = "Gigabyte", Price = 3658 },
            });
            /* -= Инициализация мониторов =- */
            Screens.AddRange(new Screen[]
            {
                new Screen { Name = "Samsung", Price = 4899 },
                new Screen { Name = "Philips", Price = 4199 }
            });
        }
        public Screen SearchScreen(Screen screen) 
            => Screens.Where(s => s.Name == screen?.Name && s.Price == screen?.Price).FirstOrDefault();
        public MotherBoard SearchMotherBoard(MotherBoard motherBoard)
            => MotherBoards.Where(m => m.Name == motherBoard?.Name && m.Price == motherBoard?.Price).FirstOrDefault();
        public HardDisc SearchHardDisc(HardDisc hardDisc)
            => HardDiscs.Where(h => h.Name == hardDisc?.Name && h.Price == hardDisc?.Price && h.Size == hardDisc?.Size).FirstOrDefault();
        public Processor SearchProcessor(Processor processor)
            => Processors.Where(p => p.Name == processor?.Name && p.Price == processor?.Price).FirstOrDefault();
    }
}
