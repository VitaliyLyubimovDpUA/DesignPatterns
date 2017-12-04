﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
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

        public virtual void Debug(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) {}
        public virtual void Warning(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) { }
        public virtual void Info(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) { }
        public virtual void Error(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) { }
        public virtual void Verbose(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) { }
    }

    public interface LoggerImpl
    {
        void ConsoleLog(string msg, Level lvl, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void FileLog(string msg, Level lvl, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void SocketLog(string msg, Level lvl, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
    }

    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LoggerImpl implementator) 
            : base(implementator) { }
        public override void Debug(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) 
            => implementator.ConsoleLog(msg, Level.Debug, sourceFilePath, sourceLineNumber);
        public override void Warning(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
            => implementator.ConsoleLog(msg, Level.Warning, sourceFilePath, sourceLineNumber);
        public override void Info(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
            => implementator.ConsoleLog(msg, Level.Info, sourceFilePath, sourceLineNumber);
        public override void Error(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) 
            => implementator.ConsoleLog(msg, Level.Error, sourceFilePath, sourceLineNumber);
        public override void Verbose(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
            => implementator.ConsoleLog(msg, Level.Verbose, sourceFilePath, sourceLineNumber);
    }

    public class FileLogger : Logger
    {
        public FileLogger(LoggerImpl implementator) 
            : base(implementator) { }
        public override void Debug(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) 
            => implementator.FileLog(msg, Level.Debug);
        public override void Warning(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
            => implementator.FileLog(msg, Level.Warning);
        public override void Info(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) 
            => implementator.FileLog(msg, Level.Info);
        public override void Error(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) 
            => implementator.FileLog(msg, Level.Error);
        public override void Verbose(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
            => implementator.FileLog(msg, Level.Verbose);
    }

    public class SocketLogger : Logger
    {
        public SocketLogger(LoggerImpl implementator)
            : base(implementator) { }
        public override void Debug(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
            => implementator.SocketLog(msg, Level.Debug);
        public override void Warning(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) 
            => implementator.SocketLog(msg, Level.Warning);
        public override void Info(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) 
            => implementator.SocketLog(msg, Level.Info);
        public override void Error(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) 
            => implementator.SocketLog(msg, Level.Error);
        public override void Verbose(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
            => implementator.SocketLog(msg, Level.Verbose);
    }

    public class ST_LoggerImpl : LoggerImpl
    {
        string template = "";
        public ST_LoggerImpl()
        {
            template = ConfigurationManager.AppSettings["writeTemplate"];
        }
        private string MsgToSendText(string msg, Level lvl, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return template.Replace("%T", lvl.ToString())
                                  .Replace("%D", DateTime.Now.ToShortDateString())
                                  .Replace("%t", DateTime.Now.ToShortTimeString())
                                  .Replace("%F", sourceFilePath)
                                  .Replace("%l", sourceLineNumber.ToString())
                                  .Replace("%m", msg + "\r\n");
        }
        public void ConsoleLog(string msg, Level lvl, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            lock (this)
            {
                Console.WriteLine(MsgToSendText(msg, lvl, sourceFilePath, sourceLineNumber));
            }
        }
        public void FileLog(string msg, Level lvl, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            string outputFilePath = ConfigurationManager.AppSettings["outputFilePath"];
            lock (this)
            {
                File.AppendAllText(outputFilePath, MsgToSendText(msg, lvl, sourceFilePath, sourceLineNumber));
            }
        }
        public void SocketLog(string msg, Level lvl, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            MailAddress from = new MailAddress(ConfigurationManager.AppSettings["fromEmail"], ConfigurationManager.AppSettings["fromName"]);
            MailAddress to = new MailAddress(ConfigurationManager.AppSettings["toEmail"]);
            MailMessage message = new MailMessage(from, to);
            lock (this)
            {
                message.Body = MsgToSendText(msg, lvl, sourceFilePath, sourceLineNumber);
                message.Subject = ConfigurationManager.AppSettings["subject"];
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(from.Address, ConfigurationManager.AppSettings["fromPassword"]);
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }

    //public class MT_LoggerImpl : LoggerImpl
    //{
    //    public void ConsoleLog(string msg, Level lvl, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    //    {
    //        Console.WriteLine("MT Console log");
    //    }
    //    public void FileLog(string msg, Level lvl)
    //    {
    //        Console.WriteLine("MT File log");
    //    }
    //    public void SocketLog(string msg, Level lvl)
    //    {
    //        Console.WriteLine("MT Socket log");
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Logger consoleLogger = new ConsoleLogger(new ST_LoggerImpl());
            consoleLogger.Info("Good evening");

            Logger fileLogger = new FileLogger(new ST_LoggerImpl());
            fileLogger.Verbose("Some text");

            //Logger socketLogger = new SocketLogger(new ST_LoggerImpl());
            //socketLogger.Debug("");



            Console.Read();
        }
    }
}
