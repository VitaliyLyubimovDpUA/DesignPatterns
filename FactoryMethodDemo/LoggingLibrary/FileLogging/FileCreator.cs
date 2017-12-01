using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary.FileLogging
{
    public class FileCreator : ICreator
    {
        public ILogging Create() => new FileLogging();
    }
}
