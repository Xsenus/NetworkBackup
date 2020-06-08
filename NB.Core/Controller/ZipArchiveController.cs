using DevExpress.Xpo;
using Quartz;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace NB.Core.Controller
{
    /// <summary>
    /// Работа с архивами.
    /// </summary>
    public class ZipArchiveController : IJob
    {
        public ZipArchiveController() { }

        /// <summary>
        /// Архивирование каталога в ZIP.
        /// </summary>
        /// <param name="pathIn">Каталог который нужно архивировать.</param>
        /// <param name="pathOut">Каталог куда сохранить архив.</param>
        /// <returns></returns>
        public static string AddZipArchive(string pathIn, string pathOut, int? taskOid = null)
        {
            var session = default(Session);

            try
            {
                var date = DateTime.Now;

                if (pathOut.LastIndexOf("\\") != pathOut.Length - 1)
                {
                    pathOut = $"{pathOut}\\";
                }

                var archivePath = $"{Path.GetFullPath(pathOut)}{Path.GetFileName(pathIn)}_({date.ToString("dd.MM.yyyy_HH.mm.ss")}).zip";
                ZipFile.CreateFromDirectory(pathIn, archivePath);

                if (taskOid != null && taskOid > 0)
                {
                    session = SessionController.GetSessionSimpleDataLayer();
                    var task = session.GetObjectByKey<Model.Task>(taskOid);
                    task.EventLogs.Add(new Model.EventLog(session)
                    {
                        Date = DateTime.Now,
                        Event = Enumerator.Event.Archiving,
                        Description = $"Успешная архивация каталога {pathIn} в архив {archivePath}"
                    });
                    task.Save();
                }

                return archivePath;
            }
            catch (Exception ex)
            {
                if (taskOid != null && taskOid > 0)
                {
                    session = SessionController.GetSessionSimpleDataLayer();
                    var task = session.GetObjectByKey<Model.Task>(taskOid);
                    task.EventLogs.Add(new Model.EventLog(session)
                    {
                        Date = DateTime.Now,
                        Event = Enumerator.Event.Error,
                        Description = $"Ошибка архивация каталога {pathIn}"
                    });
                    task.Save();
                }

                return ex.ToString();
            }
            finally
            {
                session?.Disconnect();
                session?.Dispose();
            }
        }

        /// <summary>
        /// Асинхронное архивирование каталога в ZIP.
        /// </summary>
        /// <param name="pathIn">Каталог который нужно архивировать.</param>
        /// <param name="pathOut">Каталог куда сохранить архив.</param>
        /// <returns></returns>
        public async static Task AddZipArchiveAsync(string pathIn, string pathOut, int? taskOid = null)
        {
            await Task.Run(() => AddZipArchive(pathIn, pathOut, taskOid));
        }

        public async Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string pathIn = dataMap.GetString("pathIn");
            string pathOut = dataMap.GetString("pathOut");
            int? taskOid = dataMap.GetInt("taskOid");
            await AddZipArchiveAsync(pathIn, pathOut, taskOid);
        }
    }
}
