using DevExpress.Xpo;
using NB.Core.Controller;
using NB.Core.Controller.Server;
using NB.Core.Model;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NB.ServerConsole
{
    class Program
    {
        public static Session Session { get; set; }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        const int port = 15000;
        static TcpListener listener;

        static void Main(string[] args)
        {
            StartServer();
        }

        private static void StartServer()
        {
            try
            {
                using (Session = SessionController.GetSessionSimpleDataLayer())
                {
                    Session.CreateObjectTypeRecords();
                    Session.UpdateSchema();
                }

                Session = SessionController.GetSessionThreadSafeDataLayer();

                var tasks = new XPCollection<Task>(Session);

                foreach (var task in tasks)
                {
                    TaskScheduler.Start(task);
                }

                var ip = GetLocalIPAddress();

                //listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener = new TcpListener(IPAddress.Parse(ip), port);
                listener.Start();
                Console.WriteLine($"Сервер запущен на {ip}");
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client, Session);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}
