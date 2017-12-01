using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingLibrary;
using System.Net.Mail;
using LoggingLibrary.FileLogging;
using LoggingLibrary.EmailLogging;

namespace FactoryMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logging.SetCreator(new ConsoleCreator());
            //ILogging log = Logging.GetInstance();
            //log.Verbose("Hello");

            //Logging.SetCreator(new FileCreator());
            //ILogging log = Logging.GetInstance();
            //log.Verbose("Good evening");

            Logging.SetCreator(new EmailCreator());
            ILogging log = Logging.GetInstance();
            log.Verbose("Good evening");

            Console.ReadLine();
        }
    }
}
