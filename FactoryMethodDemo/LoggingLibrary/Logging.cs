using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary
{
    public class Logging
    {
        private static ILogging log;
        Logging() { }

        public static void SetCreator(ICreator creator)
        {
            log = creator.Create();
        }
        public static ILogging GetInstance() => log;
    }
}
