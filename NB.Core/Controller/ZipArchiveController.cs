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
        public static string AddZipArchive(string pathIn, string pathOut)
        {
            try
            {
                var date = DateTime.Now;

                if (pathOut.LastIndexOf("\\") != pathOut.Length - 1)
                {
                    pathOut = $"{pathOut}\\";
                }

                var archivePath = $"{Path.GetFullPath(pathOut)}{Path.GetFileName(pathIn)}_({date.ToString("dd.MM.yyyy_HH.mm.ss")}).zip";
                ZipFile.CreateFromDirectory(pathIn, archivePath);
                return archivePath;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }            
        }

        /// <summary>
        /// Асинхронное архивирование каталога в ZIP.
        /// </summary>
        /// <param name="pathIn">Каталог который нужно архивировать.</param>
        /// <param name="pathOut">Каталог куда сохранить архив.</param>
        /// <returns></returns>
        public async static Task AddZipArchiveAsync(string pathIn, string pathOut)
        {
            await Task.Run(() => AddZipArchive(pathIn, pathOut));
        }

        public async Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string pathIn = dataMap.GetString("pathIn");
            string pathOut = dataMap.GetString("pathOut");
            await AddZipArchiveAsync(pathIn, pathOut);
        }
    }
}
