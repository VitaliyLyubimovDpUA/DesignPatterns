using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.IO;

namespace LoggingLibrary
{
    public class ConsoleLogging : ILogging
    {
        private string template = "";
        public ConsoleLogging()
        {
            template = ConfigurationManager.AppSettings["writeTemplate"];
        }
        private void SendMessage(string msg, LevelMsg lvl, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            string text = template.Replace("%T", lvl.ToString())
                                  .Replace("%D", DateTime.Now.ToShortDateString())
                                  .Replace("%t", DateTime.Now.ToShortTimeString())
                                  .Replace("%F", sourceFilePath)
                                  .Replace("%l", sourceLineNumber.ToString())
                                  .Replace("%m", msg + "\r\n");

            lock (this)
            {
                Console.WriteLine(text);
            }
        }

        public void Verbose(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Verbose, sourceFilePath, sourceLineNumber);

        public void Info(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Info, sourceFilePath, sourceLineNumber);

        public void Warning(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Warning, sourceFilePath, sourceLineNumber);

        public void Debug(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Debug, sourceFilePath, sourceLineNumber);

        public void Error(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Error, sourceFilePath, sourceLineNumber);
    }
}
