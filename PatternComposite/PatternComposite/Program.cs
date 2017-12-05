using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite
{
    interface IComponent
    {
        string Name { get; set; }
        string Report();
    }

    class Department: IComponent
    {
        public string Name { get; set; }
        private List<IComponent> Components { get; set; } = new List<IComponent>();
        
        public string Report()
        {
            StringBuilder builder = new StringBuilder();
            if (Name != null)
            {
                if (Name.Contains("-=")) builder.Append($"{Name}\n");
                else builder.Append($"\t{Name}\n");
            }

            Components.ForEach(new Action<IComponent>((arg) =>
            {
                builder.Append(arg.Report());
            }));
            return builder.ToString();
        }

        public void Add(IComponent component) => Components.Add(component);
        public bool Remove(IComponent component) => Components.Remove(component);
    }

   
    class Team : IComponent
    {
        public string Name { get; set; }
        public string Report() => $"\t\t{Name}\n";
    }




    class Program
    {
        static void Main(string[] args)
        {
            Department company = new Department();

            Department development = new Department { Name = "-= Development =-" };
            Department design = new Department { Name = "-= Design =-" };
            Department testing = new Department { Name = "-= Testing =-" };
            Department marketing = new Department { Name = "-= Marketing =-" };

            Department game = new Department { Name = "Game" };
            game.Add(new Team { Name = "Team 1" });
            game.Add(new Team { Name = "Team 2" });
            development.Add(game);

            Department mobile = new Department { Name = "Mobile" };
            mobile.Add(new Team { Name = "Android Team" });
            mobile.Add(new Team { Name = "IOS Team" });
            development.Add(mobile);

            Department desktop = new Department { Name = "Desktop" };
            desktop.Add(new Team { Name = "Desktop Team" });
            development.Add(desktop);

            design.Add(new Team { Name = "Design Team" });

            testing.Add(new Team { Name = "Mobile Testing Team" });
            testing.Add(new Team { Name = "Game Testing Team" });
            testing.Add(new Team { Name = "Desktop Testing Team" });

            marketing.Add(new Team { Name = "Marketing Team" });

            company.Add(development);
            company.Add(design);
            company.Add(testing);
            company.Add(marketing);

            Console.WriteLine(company.Report());

            Console.Read();
        }
    }
}
