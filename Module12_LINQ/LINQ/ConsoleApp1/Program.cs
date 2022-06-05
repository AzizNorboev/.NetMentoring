using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new Logger();
            ILogger log1 = new DbLogger();
            SmtpLogger smtp = new SmtpLogger(log);
            smtp.SendMessage("whatever logging");

            SmtpLogger smtp1 = new SmtpLogger(log1);
            smtp1.SendMessage("whatever logging DB");
        }
    }
}
