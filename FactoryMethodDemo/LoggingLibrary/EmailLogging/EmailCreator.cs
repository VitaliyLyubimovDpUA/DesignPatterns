using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary.EmailLogging
{
    public class EmailCreator : ICreator
    {
        public ILogging Create() => new EmailLogging();
    }
}
