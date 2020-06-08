using DevExpress.Xpo;
using NB.Core.Controller.DxSampleModelCode;
using NB.Core.Enumerator;
using NB.Core.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace NB.Core.Controller.Server
{
    public class ClientObject
    {
        public TcpClient client;
        private Session Session { get; }

        public ClientObject(TcpClient tcpClient, Session session)
        {
            client = tcpClient;
            Session = session;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64];
                
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    if (string.IsNullOrWhiteSpace(message))
                    {
                        continue;
                    }

                    if (message.Equals("GetFolderBrowserDialog"))
                    {
                        Console.WriteLine("Запрос на получение каталогов проводника.");
                        var myExplorer = new MyExplorer();
                        myExplorer.Root = "root";
                        var drives = Environment.GetLogicalDrives();
                        foreach (string s in drives)
                        {
                            myExplorer.Path.Add(s);
                        }

                        message = JsonConvert.SerializeObject(myExplorer);

                        data = Encoding.Unicode.GetBytes(message);
                        stream.Write(data, 0, data.Length);
                    }
                    else
                    {
                        if (message.Substring(0, 1).Equals($"{(int)TaskServerStatus.MyExplorerTask}"))
                        {
                            message = message.Remove(0, 1);
                            if (JsonConvert.DeserializeObject<MyExplorer>(message) is MyExplorer myExplorerIn)
                            {
                                Console.WriteLine($"Запрос на получение каталогов проводника по пути {myExplorerIn.Root}");

                                var directorys = Directory.GetDirectories(myExplorerIn.Root);

                                foreach (var item in directorys)
                                {
                                    var result = item.Replace($"{myExplorerIn.Root}", "");

                                    if (result.Contains("\\"))
                                    {
                                        result = result.Replace("\\", "");
                                    }

                                    myExplorerIn.Path.Add(result);
                                }

                                message = JsonConvert.SerializeObject(myExplorerIn);

                                data = Encoding.Unicode.GetBytes(message);
                                stream.Write(data, 0, data.Length);
                            }
                        } 
                        else if (message.Substring(0, 1).Equals($"{(int)TaskServerStatus.GetTask}"))
                        {
                            message = message.Remove(0, 1);
                            if (JsonConvert.DeserializeObject<Task>(message) is Task task)
                            {
                                Console.WriteLine($"Получена задача {task.Name} для {task.IPAddress}");

                                var taskServer = Session.GetObjectByKey<Task>(task.ServerOid);

                                if (taskServer is null)
                                {
                                    taskServer = new Task(Session);
                                    Console.WriteLine($"Создана новая задача на сервере {task.Name}");
                                }
                                else
                                {
                                    Console.WriteLine($"Задача {taskServer.Name} будет обновлена.");
                                }

                                taskServer.Name = task.Name;
                                taskServer.SaveDirectory = task.SaveDirectory;
                                taskServer.CopyDirectory = task.CopyDirectory;
                                taskServer.TaskStatus = TaskStatus.Performed;
                                taskServer.Date = task.Date;
                                taskServer.IPAddress = task.IPAddress;

                                taskServer.IsMonday = task.IsMonday;
                                taskServer.IsTuesday = task.IsTuesday;
                                taskServer.IsWednesday = task.IsWednesday;
                                taskServer.IsThursday = task.IsThursday;
                                taskServer.IsFriday = task.IsFriday;
                                taskServer.IsSaturday = task.IsSaturday;
                                taskServer.IsSunday = task.IsSunday;

                                taskServer.Save();

                                Console.WriteLine($"Возвращен Oid задачи: {taskServer.Oid}");

                                var resolver = new DxSampleModelJsonSerializationContractResolver();
                                message = $"{(int)TaskServerStatus.CreatedTask}" + JsonConvert.SerializeObject(taskServer,
                                    new JsonSerializerSettings()
                                    {
                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                        ContractResolver = resolver
                                    });

                                data = Encoding.Unicode.GetBytes(message);
                                stream.Write(data, 0, data.Length);

                                Console.WriteLine("Запуск задачи");
                                TaskScheduler.Start(taskServer);
                            }
                        }
                        else if (message.Substring(0, 1).Equals($"{(int)TaskServerStatus.StartTask}"))
                        {
                            message = message.Remove(0, 1);
                            if (JsonConvert.DeserializeObject<Task>(message) is Task task)
                            {
                                Console.WriteLine($"Получена задача {task.Name} для {task.IPAddress}");

                                var taskServer = Session.GetObjectByKey<Task>(task.ServerOid);

                                if (taskServer is null)
                                {
                                    taskServer = new Task(Session);
                                    Console.WriteLine($"Создана новая задача на сервере {task.Name}");
                                }
                                else
                                {
                                    Console.WriteLine($"Задача {taskServer.Name} будет запущена.");
                                }

                                taskServer.Name = task.Name;
                                taskServer.SaveDirectory = task.SaveDirectory;
                                taskServer.CopyDirectory = task.CopyDirectory;
                                taskServer.TaskStatus = task.TaskStatus;
                                taskServer.Date = task.Date;
                                taskServer.IPAddress = task.IPAddress;

                                taskServer.IsMonday = task.IsMonday;
                                taskServer.IsTuesday = task.IsTuesday;
                                taskServer.IsWednesday = task.IsWednesday;
                                taskServer.IsThursday = task.IsThursday;
                                taskServer.IsFriday = task.IsFriday;
                                taskServer.IsSaturday = task.IsSaturday;
                                taskServer.IsSunday = task.IsSunday;

                                taskServer.Save();

                                Console.WriteLine($"Возвращен Oid задачи: {taskServer.Oid}");

                                var resolver = new DxSampleModelJsonSerializationContractResolver();
                                message = $"{(int)TaskServerStatus.CreatedTask}" + JsonConvert.SerializeObject(taskServer,
                                    new JsonSerializerSettings()
                                    {
                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                        ContractResolver = resolver
                                    });

                                data = Encoding.Unicode.GetBytes(message);
                                stream.Write(data, 0, data.Length);

                                Console.WriteLine("Запуск задачи");
                                TaskScheduler.Start(taskServer);
                            }
                        }
                        else if (message.Substring(0, 1).Equals($"{(int)TaskServerStatus.StopTask}"))
                        {
                            message = message.Remove(0, 1);
                            if (JsonConvert.DeserializeObject<Task>(message) is Task task)
                            {
                                Console.WriteLine($"Получена задача {task.Name} для {task.IPAddress} на остановку.");

                                var taskServer = Session.GetObjectByKey<Task>(task.ServerOid);

                                if (taskServer is null)
                                {
                                    taskServer = new Task(Session);
                                    Console.WriteLine($"Задача {task.Name} уже была остановлена.");
                                }
                                else
                                {
                                    Console.WriteLine($"Задача {task.Name} была остановлена.");
                                    taskServer.Delete();
                                    taskServer.Save();
                                }
                                continue;
                            }
                        }
                        else if (message.Substring(0, 1).Equals($"{(int)TaskServerStatus.SendTaskEventLog}"))
                        {
                            message = message.Remove(0, 1);
                            if (JsonConvert.DeserializeObject<Task>(message) is Task task)
                            {
                                Console.WriteLine($"Получена задача {task.Name} для {task.IPAddress} на отправку отчета.");

                                var taskServer = Session.GetObjectByKey<Task>(task.ServerOid);

                                if (taskServer != null)
                                {
                                    taskServer.Reload();
                                    var eventLogList = new EventLogList(taskServer);

                                    var resolver = new DxSampleModelJsonSerializationContractResolver();
                                    message = $"{(int)TaskServerStatus.SendTaskEventLog}" + JsonConvert.SerializeObject(eventLogList,
                                        new JsonSerializerSettings()
                                        {
                                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                            ContractResolver = resolver
                                        });

                                    data = Encoding.Unicode.GetBytes(message);
                                    stream.Write(data, 0, data.Length);
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }
}
