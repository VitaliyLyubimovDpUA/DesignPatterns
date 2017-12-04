using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBridge
{
    public enum Level
    {
        Debug, Error, Warning, Info, Verbose
    }
    public abstract class Logger
    {
        protected LoggerImpl implementator;
        public Logger(LoggerImpl implementator)
        {
            this.implementator = implementator;
        }

        public virtual void Debug() => implementator.Debug();

        public virtual void Error() => implementator.Error();

        public virtual void Info() => implementator.Info();

        public virtual void Verbose() => implementator.Verbose();

        public virtual void Warning() => implementator.Warning();
    }

    public abstract class LoggerImpl
    {
        public abstract void Debug();
        public abstract void Error();
        public abstract void Warning();
        public abstract void Info();
        public abstract void Verbose();
    }

    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LoggerImpl implementator) 
            : base(implementator) { }
        public override void Debug() => implementator.Debug();
    }
    //public class SocketLogger: Logger
    //{

    //}
    //public class FileLogger: Logger
    //{

    //}


    public class ST_LoggerImpl : LoggerImpl
    {
        public override void Debug()
        {
            Console.WriteLine("Debug");
        }

        public override void Error()
        {
            throw new NotImplementedException();
        }

        public override void Info()
        {
            throw new NotImplementedException();
        }

        public override void Verbose()
        {
            throw new NotImplementedException();
        }

        public override void Warning()
        {
            throw new NotImplementedException();
        }
    }
    public class MT_LoggerImpl
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new ConsoleLogger(new ST_LoggerImpl());
            logger.Debug();
        }
    }
}
