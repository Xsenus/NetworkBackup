namespace NB.Client.Form
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControlEvent = new DevExpress.XtraGrid.GridControl();
            this.gridViewEvent = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlEvent
            // 
            this.gridControlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEvent.Location = new System.Drawing.Point(0, 0);
            this.gridControlEvent.MainView = this.gridViewEvent;
            this.gridControlEvent.Name = "gridControlEvent";
            this.gridControlEvent.Size = new System.Drawing.Size(899, 451);
            this.gridControlEvent.TabIndex = 3;
            this.gridControlEvent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEvent});
            // 
            // gridViewEvent
            // 
            this.gridViewEvent.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewEvent.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewEvent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridViewEvent.GridControl = this.gridControlEvent;
            this.gridViewEvent.Name = "gridViewEvent";
            this.gridViewEvent.OptionsBehavior.Editable = false;
            this.gridViewEvent.OptionsSelection.MultiSelect = true;
            this.gridViewEvent.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewEvent.OptionsView.ShowGroupPanel = false;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 451);
            this.Controls.Add(this.gridControlEvent);
            this.Name = "ReportForm";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlEvent;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEvent;
    }
}