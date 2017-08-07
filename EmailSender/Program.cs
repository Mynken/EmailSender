using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;
using Quartz;
using Quartz.Impl;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpMail oMail = new SmtpMail("test");
            SmtpClient oSmtp = new SmtpClient();

            oMail.From = "waldes7k@gmail.com";

            oMail.To = "dima.konyshev911@gmail.com";

            oMail.Subject = "hello";

            oMail.TextBody = "text body";

            SmtpServer oServer = new SmtpServer("smtp.gmail.com");

            // Set 587 port, if you want to use 25 port, please change 587 5o 25
            oServer.Port = 587;

            // detect SSL/TLS automatically
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            oServer.User = "waldes7k@gmail.com";
            oServer.Password = "password";
            try
            {
                Console.WriteLine("start to send email over SSL ...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");

            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
            Console.ReadKey();
        }
    }
}
