using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary
{
    public class ConsoleCreator : ICreator
    {
        public ILogging Create() => new ConsoleLogging();
    }
}
