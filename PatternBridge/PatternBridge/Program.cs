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
        public LoggerImpl implementator;
        public Logger(LoggerImpl implementator)
        {
            this.implementator = implementator;
        }

        public virtual void Debug(string msg) {}
        public virtual void Warning(string msg) { }
        public virtual void Info(string msg) { }
        public virtual void Error(string msg) { }
        public virtual void Verbose(string msg) { }
    }

    public interface LoggerImpl
    {
        void ConsoleLog(string msg, Level lvl);
        void FileLog(string msg, Level lvl);
        void SocketLog(string msg, Level lvl);
    }

    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LoggerImpl implementator) 
            : base(implementator) { }
        public override void Debug(string msg) => implementator.ConsoleLog(msg, Level.Debug);
        public override void Warning(string msg) => implementator.ConsoleLog(msg, Level.Warning);
        public override void Info(string msg) => implementator.ConsoleLog(msg, Level.Info);
        public override void Error(string msg) => implementator.ConsoleLog(msg, Level.Error);
        public override void Verbose(string msg) => implementator.ConsoleLog(msg, Level.Verbose);
    }

    public class FileLogger : Logger
    {
        public FileLogger(LoggerImpl implementator) 
            : base(implementator) { }
        public override void Debug(string msg) => implementator.FileLog(msg, Level.Debug);
        public override void Warning(string msg) => implementator.FileLog(msg, Level.Warning);
        public override void Info(string msg) => implementator.FileLog(msg, Level.Info);
        public override void Error(string msg) => implementator.FileLog(msg, Level.Error);
        public override void Verbose(string msg) => implementator.FileLog(msg, Level.Verbose);
    }

    public class SocketLogger : Logger
    {
        public SocketLogger(LoggerImpl implementator)
            : base(implementator) { }
        public override void Debug(string msg) => implementator.SocketLog(msg, Level.Debug);
        public override void Warning(string msg) => implementator.SocketLog(msg, Level.Warning);
        public override void Info(string msg) => implementator.SocketLog(msg, Level.Info);
        public override void Error(string msg) => implementator.SocketLog(msg, Level.Error);
        public override void Verbose(string msg) => implementator.SocketLog(msg, Level.Verbose);
    }

    public class ST_LoggerImpl : LoggerImpl
    {
        public void ConsoleLog(string msg, Level lvl)
        {
            Console.WriteLine("ST Console log");
        }
        public void FileLog(string msg, Level lvl)
        {
            Console.WriteLine("ST File log");
        }
        public void SocketLog(string msg, Level lvl)
        {
            Console.WriteLine("ST Socket log");
        }
    }

    public class MT_LoggerImpl : LoggerImpl
    {
        public void ConsoleLog(string msg, Level lvl)
        {
            Console.WriteLine("MT Console log");
        }
        public void FileLog(string msg, Level lvl)
        {
            Console.WriteLine("MT File log");
        }
        public void SocketLog(string msg, Level lvl)
        {
            Console.WriteLine("MT Socket log");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger consoleLogger = new ConsoleLogger(new ST_LoggerImpl());
            consoleLogger.Debug("");

            Logger fileLogger = new FileLogger(new ST_LoggerImpl());
            fileLogger.Debug("");

            Logger socketLogger = new SocketLogger(new ST_LoggerImpl());
            socketLogger.Debug("");



            Console.Read();
        }
    }
}
