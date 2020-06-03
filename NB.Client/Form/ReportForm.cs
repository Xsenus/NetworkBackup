using System;
using DevExpress.XtraEditors;
using NB.Core.Model;

namespace NB.Client.Form
{
    public partial class ReportForm : XtraForm
    {
        private Task Task { get; }

        public ReportForm(Task task)
        {
            InitializeComponent();
            Task = task;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            gridControlEvent.DataSource = Task.EventLogs;

            if (gridViewEvent.Columns[nameof(EventLog.Date)] != null)
            {
                gridViewEvent.Columns[nameof(EventLog.Date)].DisplayFormat.FormatString = "d";
            }
        }
    }
}