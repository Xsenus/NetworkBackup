using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using NB.Core.Model;

namespace NB.Client.Form
{
    public partial class ReportForm : XtraForm
    {
        private Task Task { get; }
        private XPCollection<EventLog> EventLogs { get; }

        public ReportForm(Task task)
        {
            InitializeComponent();
            Task = task;
            EventLogs = Task.EventLogs;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            gridControlEvent.DataSource = EventLogs;

            if (gridViewEvent.Columns[nameof(EventLog.Date)] != null)
            {
                gridViewEvent.Columns[nameof(EventLog.Date)].DisplayFormat.FormatString = "d";
            }
        }

        private void gridViewEvent_Click(object sender, EventArgs e)
        {
            EventLogs.Reload();
        }
    }
}