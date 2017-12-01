using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary.EmailLogging
{
    public class EmailLogging: ILogging
    {
        private string template = "";
        MailAddress from;
        MailAddress to;
        MailMessage message;
        public EmailLogging()
        {
            from = new MailAddress(ConfigurationManager.AppSettings["fromEmail"], ConfigurationManager.AppSettings["fromName"]);
            to = new MailAddress(ConfigurationManager.AppSettings["toEmail"]);
            message = new MailMessage(from, to);

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
                message.Body = text;
                message.Subject = ConfigurationManager.AppSettings["subject"];
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential(from.Address, ConfigurationManager.AppSettings["fromPassword"]);
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
        public void Debug(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Debug, sourceFilePath, sourceLineNumber);

        public void Error(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Error, sourceFilePath, sourceLineNumber);

        public void Info(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Info, sourceFilePath, sourceLineNumber);

        public void Verbose(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Verbose, sourceFilePath, sourceLineNumber);

        public void Warning(string msg, [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        => SendMessage(msg, LevelMsg.Warning, sourceFilePath, sourceLineNumber);
    }
}
