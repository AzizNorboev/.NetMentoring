using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SmtpLogger
    {
        private readonly ILogger logger;

        public SmtpLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public void SendMessage(string message)
        {
            // отсылка сообщения

            logger.Log(string.Format("Отправлено '{0}'", message));
        }
    }
}
