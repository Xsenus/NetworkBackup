﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using NB.Core.Controller;
using NB.Core.Controller.DxSampleModelCode;
using NB.Core.Enumerator;
using NB.Core.Model;
using Newtonsoft.Json;

namespace NB.Client.Form
{
    public partial class MainForm : XtraForm
    {
        private Session Session { get; }
        private XPCollection<Task> Tasks { get; }

        public MainForm()
        {
            InitializeComponent();

            if (!File.Exists(SessionController.StringSQLiteConnection))
            {
                using (Session = SessionController.GetSessionSimpleDataLayer())
                {
                    Session.CreateObjectTypeRecords();
                    Session.UpdateSchema();
                }
            }

            Session = SessionController.GetSessionThreadSafeDataLayer();
            Tasks = new XPCollection<Task>(Session);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gridControlTasks.DataSource = Tasks;

            if (gridViewTasks.Columns[nameof(Task.Date)] != null)
            {
                gridViewTasks.Columns[nameof(Task.Date)].DisplayFormat.FormatString = "d";
            }
        }

        private void btnTaskAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = new TaskEdit(Session);
            form.ShowDialog();

            if (form.isSave)
            {
                Tasks.Reload();
                gridViewTasks.FocusedRowHandle = gridViewTasks.LocateByValue(nameof(Task.Oid), form.Task.Oid);
            }
        }

        private void btnTaskEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewTasks.IsEmpty)
            {
                return;
            }

            var task = gridViewTasks.GetRow(gridViewTasks.FocusedRowHandle) as Task;
            if (task != null)
            {
                var form = new TaskEdit(task);
                form.ShowDialog();

                if (form.isSave)
                {
                    gridViewTasks.FocusedRowHandle = gridViewTasks.LocateByValue(nameof(Task.Oid), form.Task.Oid);
                }
            }
        }

        private void btnTaskRemove_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewTasks.IsEmpty)
            {
                return;
            }

            var listTask = new List<Task>();
            var msg = default(string);

            foreach (var focusedRowHandle in gridViewTasks.GetSelectedRows())
            {
                var task = gridViewTasks.GetRow(focusedRowHandle) as Task;

                if (task != null)
                {
                    msg += $"{task}{Environment.NewLine}";
                    listTask.Add(task);
                }
            }

            if (XtraMessageBox.Show($"Вы собираетесь удалить следующие задачи:{Environment.NewLine}{msg}Хотите продолжить?",
                    "Удаление архивных папок",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
            {

                foreach (var task in listTask)
                {
                    EditTask(task, TaskStatus.IsStopped, TaskServerStatus.StopTask);
                    Thread.Sleep(1000);
                }

                Session.Delete(listTask);
            }
        }

        private void gridViewTasks_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs dxMouseEventArgs = e as DXMouseEventArgs;
            GridView gridview = sender as GridView;
            GridHitInfo gridHitInfo = gridview.CalcHitInfo(dxMouseEventArgs.Location);
            if ((gridHitInfo.InRow || gridHitInfo.InRowCell) && dxMouseEventArgs.Button == MouseButtons.Left)
            {
                var task = gridViewTasks.GetRow(gridViewTasks.FocusedRowHandle) as Task;
                if (task != null)
                {
                    var form = new TaskEdit(task);
                    form.ShowDialog();

                    if (form.isSave)
                    {
                        gridViewTasks.FocusedRowHandle = gridViewTasks.LocateByValue(nameof(Task.Oid), form.Task.Oid);
                    }
                }
            }
        }

        private void btnTaskStart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewTasks.IsEmpty)
            {
                return;
            }

            var task = gridViewTasks.GetRow(gridViewTasks.FocusedRowHandle) as Task;

            EditTask(task, TaskStatus.Performed, TaskServerStatus.StartTask);
        }

        private void btnTaskStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewTasks.IsEmpty)
            {
                return;
            }

            var task = gridViewTasks.GetRow(gridViewTasks.FocusedRowHandle) as Task;

            EditTask(task, TaskStatus.IsStopped, TaskServerStatus.StopTask);
        }

        private void EditTask(Task task, TaskStatus taskStatus, TaskServerStatus taskServerStatus)
        {            
            if (task != null)
            {
                if (task.TaskStatus == taskStatus)
                {
                    return;
                }

                task.TaskStatus = taskStatus;
                task.Save();

                try
                {
                    var client = new TcpClient(task.IPAddress, 15000);
                    NetworkStream networkStream = client.GetStream();

                    while (true)
                    {
                        var resolver = new DxSampleModelJsonSerializationContractResolver();
                        var message = $"{(int)taskServerStatus}" + JsonConvert.SerializeObject(task,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                ContractResolver = resolver
                            });

                        byte[] data = Encoding.Unicode.GetBytes(message);
                        networkStream.Write(data, 0, data.Length);

                        if (taskServerStatus == TaskServerStatus.StopTask)
                        {
                            var eventLog = new EventLog(Session)
                            {
                                Date = DateTime.Now,
                                Event = Event.Stop,
                            };

                            task.EventLogs.Add(eventLog);
                            task.Save();

                            return;
                        }

                        data = new byte[64];
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0;
                        do
                        {
                            bytes = networkStream.Read(data, 0, data.Length);
                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }

                        while (networkStream.DataAvailable);

                        message = builder.ToString();

                        if (message.Substring(0, 1).Equals($"{(int)TaskServerStatus.CreatedTask}"))
                        {
                            message = message.Remove(0, 1);
                            if (JsonConvert.DeserializeObject<Task>(message) is Task taskServer)
                            {
                                task.ServerOid = taskServer.Oid;
                                task.TaskStatus = taskServer.TaskStatus;

                                var eventLog = new EventLog(Session)
                                {
                                    Date = DateTime.Now,
                                    Event = Event.Start
                                };

                                task.EventLogs.Add(eventLog);

                                task.Save();
                                return;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnTaskReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewTasks.IsEmpty)
            {
                return;
            }

            var task = gridViewTasks.GetRow(gridViewTasks.FocusedRowHandle) as Task;

            if (task != null)
            {
                var form = new ReportForm(task);
                form.ShowDialog();
            }
        }
    }
}