using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils.CommonDialogs;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Design;
using NB.Core.Controller;
using NB.Core.Controller.DxSampleModelCode;
using NB.Core.Enumerator;
using NB.Core.Model;
using Newtonsoft.Json;

namespace NB.Client.Form
{
    public partial class TaskEdit : XtraForm
    {
        private Session Session { get; }
        public Task Task { get; }
        public bool isSave = false;        

        private TaskEdit()
        {
            InitializeComponent();            
        }

        public TaskEdit(Session session) : this()
        {
            Session = session;
            Task = new Task(Session);
        }

        public TaskEdit(Task task) : this()
        {
            Task = task;
            Session = task.Session;
        }

        private NetworkStream GetNetworkStream(string ipAddress, int port)
        {
            try
            {
                var client = new TcpClient(txtIPAddress.Text, 15000);
                NetworkStream networkStream = client.GetStream();
                return networkStream;
            }
            catch (SocketException socketException)
            {
                XtraMessageBox.Show(socketException.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                XtraMessageBox.Show(argumentOutOfRangeException.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void TaskEdit_Load(object sender, EventArgs e)
        {
            txtName.Text = Task.Name;
            txtIPAddress.Text = Task.IPAddress;
            date.DateTime = Task.Date ?? DateTime.Now;
            btnCopyDirectory.EditValue = Task.CopyDirectory;
            btnSaveDirectory.EditValue = Task.SaveDirectory;

            checkIsMonday.Checked = Task.IsMonday;
            checkIsTuesday.Checked = Task.IsTuesday;
            checkIsWednesday.Checked = Task.IsWednesday;
            checkIsThursday.Checked = Task.IsThursday;
            checkIsFriday.Checked = Task.IsFriday;
            checkIsSaturday.Checked = Task.IsSaturday;
            checkIsSunday.Checked = Task.IsSunday;

            checkIsThisPC.Checked = Task.IsThisPC;
        }

        private void btnCopyDirectory_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            var buttonEdit = sender as ButtonEdit;

            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                buttonEdit.EditValue = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIPAddress.Text))
            {
                txtIPAddress.Focus();
            }
            else
            {
                var networkStream = GetNetworkStream(txtIPAddress.Text, 15000);

                if (networkStream is null)
                {
                    return;
                }

                var form = new MyExplorerForm(networkStream);
                form.ShowDialog();

                if (!string.IsNullOrWhiteSpace(form.Path))
                {
                    buttonEdit.EditValue = form.Path;
                }
            }
        }

        private void btnSaveDirectory_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            var buttonEdit = sender as ButtonEdit;

            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                buttonEdit.EditValue = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIPAddress.Text) && !checkIsThisPC.Checked)
            {
                txtIPAddress.Focus();
            }
            else
            {
                if (checkIsThisPC.Checked)
                {
                    using (var xtraFolderBrowserDialog = new XtraFolderBrowserDialog())
                    {
                        xtraFolderBrowserDialog.DialogStyle = FolderBrowserDialogStyle.Wide;
                        if (xtraFolderBrowserDialog.ShowDialog() == DialogResult.OK)
                        {
                            buttonEdit.EditValue = xtraFolderBrowserDialog.SelectedPath;
                        }
                    }
                }
                else
                {
                    var networkStream = GetNetworkStream(txtIPAddress.Text, 15000);

                    if (networkStream is null)
                    {
                        return;
                    }

                    var form = new MyExplorerForm(networkStream);
                    form.ShowDialog();

                    if (!string.IsNullOrWhiteSpace(form.Path))
                    {
                        buttonEdit.EditValue = form.Path;
                    }
                }
            }    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Focus();
                return;
            }

            if (date.EditValue is null || date.DateTime == DateTime.MinValue || date.DateTime == DateTime.MaxValue)
            {
                date.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIPAddress.Text))
            {
                txtIPAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(btnCopyDirectory.Text))
            {
                btnCopyDirectory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(btnSaveDirectory.Text))
            {
                btnSaveDirectory.Focus();
                return;
            }

            Task.Name = txtName.Text;
            Task.IPAddress = txtIPAddress.Text;
            Task.Date = date.DateTime;
            Task.CopyDirectory = btnCopyDirectory.Text;
            Task.SaveDirectory = btnSaveDirectory.Text;

            Task.IsMonday = checkIsMonday.Checked;
            Task.IsTuesday = checkIsTuesday.Checked;
            Task.IsWednesday = checkIsWednesday.Checked;
            Task.IsThursday = checkIsThursday.Checked;
            Task.IsFriday = checkIsFriday.Checked;
            Task.IsSaturday = checkIsSaturday.Checked;
            Task.IsSunday = checkIsSunday.Checked;

            Task.IsThisPC = checkIsThisPC.Checked;

            var eventLog = new EventLog(Session) 
            { 
                Date = DateTime.Now
            };

            if (Task.Oid <= 0)
            {
                eventLog.Event = Event.Creature;
                eventLog.Description = "Создание задачи в клиенте управления";
            }
            else
            {
                eventLog.Event = Event.Edit;
                eventLog.Description = "Изменение задачи в клиенте управления";
            }
            Task.EventLogs.Add(eventLog);
            Task.Save();

            isSave = true;

            if (isSave == true)
            {
                System.Threading.Tasks.Task.Run(() =>
                {
                    SendTask();
                }).ConfigureAwait(false);
            }

            Close();
        }

        private void SendTask()
        {
            try
            {
                var networkStream = GetNetworkStream(txtIPAddress.Text, 15000);

                if (networkStream is null)
                {
                    return;
                }

                while (true)
                {
                    var resolver = new DxSampleModelJsonSerializationContractResolver();
                    var message = $"{(int)TaskServerStatus.GetTask}" + JsonConvert.SerializeObject(Task,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                            ContractResolver = resolver
                        });

                    byte[] data = Encoding.Unicode.GetBytes(message);
                    networkStream.Write(data, 0, data.Length);

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
                        if (JsonConvert.DeserializeObject<Task>(message) is Task task)
                        {
                            using (var sess = SessionController.GetSessionSimpleDataLayer())
                            {
                                var taskEx = sess.GetObjectByKey<Task>(Task.Oid);

                                if (taskEx != null)
                                {
                                    taskEx.ServerOid = task.Oid;
                                    taskEx.TaskStatus = task.TaskStatus;

                                    var eventLog = new EventLog(sess)
                                    {
                                        Date = DateTime.Now,
                                        Event = Event.Start,
                                        Description = "Успешное добавление и старт задачи на сервере"
                                    };

                                    taskEx.EventLogs.Add(eventLog);
                                    taskEx.Save();
                                }
                            }
                            return;
                        }                            
                    }
                }
            }
            catch (Exception)
            {
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}