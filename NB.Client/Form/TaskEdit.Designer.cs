namespace NB.Client.Form
{
    partial class TaskEdit
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
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.gpSettings = new DevExpress.XtraEditors.GroupControl();
            this.lblSaveDirectory = new DevExpress.XtraEditors.LabelControl();
            this.lblCopyDirectory = new DevExpress.XtraEditors.LabelControl();
            this.gpRepeat = new DevExpress.XtraEditors.GroupControl();
            this.checkIsSunday = new DevExpress.XtraEditors.CheckEdit();
            this.checkIsSaturday = new DevExpress.XtraEditors.CheckEdit();
            this.checkIsFriday = new DevExpress.XtraEditors.CheckEdit();
            this.checkIsThursday = new DevExpress.XtraEditors.CheckEdit();
            this.checkIsWednesday = new DevExpress.XtraEditors.CheckEdit();
            this.checkIsTuesday = new DevExpress.XtraEditors.CheckEdit();
            this.checkIsMonday = new DevExpress.XtraEditors.CheckEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.txtIPAddress = new DevExpress.XtraEditors.TextEdit();
            this.lblIPAddress = new DevExpress.XtraEditors.LabelControl();
            this.date = new DevExpress.XtraEditors.DateEdit();
            this.btnCopyDirectory = new DevExpress.XtraEditors.ButtonEdit();
            this.btnSaveDirectory = new DevExpress.XtraEditors.ButtonEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.checkIsThisPC = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSettings)).BeginInit();
            this.gpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpRepeat)).BeginInit();
            this.gpRepeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsSunday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsSaturday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsFriday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsThursday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsWednesday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsTuesday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsMonday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyDirectory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveDirectory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsThisPC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(116, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Наименование задачи:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(143, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(319, 20);
            this.txtName.TabIndex = 2;
            // 
            // gpSettings
            // 
            this.gpSettings.Controls.Add(this.checkIsThisPC);
            this.gpSettings.Controls.Add(this.lblSaveDirectory);
            this.gpSettings.Controls.Add(this.lblCopyDirectory);
            this.gpSettings.Controls.Add(this.gpRepeat);
            this.gpSettings.Controls.Add(this.lblDate);
            this.gpSettings.Controls.Add(this.txtIPAddress);
            this.gpSettings.Controls.Add(this.lblIPAddress);
            this.gpSettings.Controls.Add(this.date);
            this.gpSettings.Controls.Add(this.btnCopyDirectory);
            this.gpSettings.Controls.Add(this.btnSaveDirectory);
            this.gpSettings.Location = new System.Drawing.Point(12, 38);
            this.gpSettings.Name = "gpSettings";
            this.gpSettings.Size = new System.Drawing.Size(450, 253);
            this.gpSettings.TabIndex = 3;
            this.gpSettings.Text = "Параметры";
            // 
            // lblSaveDirectory
            // 
            this.lblSaveDirectory.Location = new System.Drawing.Point(28, 226);
            this.lblSaveDirectory.Name = "lblSaveDirectory";
            this.lblSaveDirectory.Size = new System.Drawing.Size(97, 13);
            this.lblSaveDirectory.TabIndex = 17;
            this.lblSaveDirectory.Text = "Место сохранения:";
            // 
            // lblCopyDirectory
            // 
            this.lblCopyDirectory.Location = new System.Drawing.Point(10, 175);
            this.lblCopyDirectory.Name = "lblCopyDirectory";
            this.lblCopyDirectory.Size = new System.Drawing.Size(115, 13);
            this.lblCopyDirectory.TabIndex = 15;
            this.lblCopyDirectory.Text = "Каталог копирования:";
            // 
            // gpRepeat
            // 
            this.gpRepeat.Controls.Add(this.checkIsSunday);
            this.gpRepeat.Controls.Add(this.checkIsSaturday);
            this.gpRepeat.Controls.Add(this.checkIsFriday);
            this.gpRepeat.Controls.Add(this.checkIsThursday);
            this.gpRepeat.Controls.Add(this.checkIsWednesday);
            this.gpRepeat.Controls.Add(this.checkIsTuesday);
            this.gpRepeat.Controls.Add(this.checkIsMonday);
            this.gpRepeat.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.gpRepeat.Location = new System.Drawing.Point(10, 79);
            this.gpRepeat.Name = "gpRepeat";
            this.gpRepeat.Size = new System.Drawing.Size(430, 80);
            this.gpRepeat.TabIndex = 8;
            this.gpRepeat.Text = "Повторять";
            // 
            // checkIsSunday
            // 
            this.checkIsSunday.Location = new System.Drawing.Point(333, 23);
            this.checkIsSunday.Name = "checkIsSunday";
            this.checkIsSunday.Properties.Caption = "Воскресенье";
            this.checkIsSunday.Size = new System.Drawing.Size(100, 19);
            this.checkIsSunday.TabIndex = 15;
            // 
            // checkIsSaturday
            // 
            this.checkIsSaturday.Location = new System.Drawing.Point(227, 48);
            this.checkIsSaturday.Name = "checkIsSaturday";
            this.checkIsSaturday.Properties.Caption = "Суббота";
            this.checkIsSaturday.Size = new System.Drawing.Size(100, 19);
            this.checkIsSaturday.TabIndex = 14;
            // 
            // checkIsFriday
            // 
            this.checkIsFriday.Location = new System.Drawing.Point(227, 23);
            this.checkIsFriday.Name = "checkIsFriday";
            this.checkIsFriday.Properties.Caption = "Пятница";
            this.checkIsFriday.Size = new System.Drawing.Size(100, 19);
            this.checkIsFriday.TabIndex = 13;
            // 
            // checkIsThursday
            // 
            this.checkIsThursday.Location = new System.Drawing.Point(121, 48);
            this.checkIsThursday.Name = "checkIsThursday";
            this.checkIsThursday.Properties.Caption = "Четверг";
            this.checkIsThursday.Size = new System.Drawing.Size(100, 19);
            this.checkIsThursday.TabIndex = 12;
            // 
            // checkIsWednesday
            // 
            this.checkIsWednesday.Location = new System.Drawing.Point(121, 23);
            this.checkIsWednesday.Name = "checkIsWednesday";
            this.checkIsWednesday.Properties.Caption = "Среда";
            this.checkIsWednesday.Size = new System.Drawing.Size(100, 19);
            this.checkIsWednesday.TabIndex = 11;
            // 
            // checkIsTuesday
            // 
            this.checkIsTuesday.Location = new System.Drawing.Point(6, 48);
            this.checkIsTuesday.Name = "checkIsTuesday";
            this.checkIsTuesday.Properties.Caption = "Вторник";
            this.checkIsTuesday.Size = new System.Drawing.Size(100, 19);
            this.checkIsTuesday.TabIndex = 10;
            // 
            // checkIsMonday
            // 
            this.checkIsMonday.Location = new System.Drawing.Point(6, 23);
            this.checkIsMonday.Name = "checkIsMonday";
            this.checkIsMonday.Properties.Caption = "Понедельник";
            this.checkIsMonday.Size = new System.Drawing.Size(100, 19);
            this.checkIsMonday.TabIndex = 9;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(56, 56);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(69, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Дата начала:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(131, 27);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(309, 20);
            this.txtIPAddress.TabIndex = 5;
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.Location = new System.Drawing.Point(19, 30);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(106, 13);
            this.lblIPAddress.TabIndex = 4;
            this.lblIPAddress.Text = "IP адрес или имя ПК:";
            // 
            // date
            // 
            this.date.EditValue = null;
            this.date.Location = new System.Drawing.Point(131, 53);
            this.date.Name = "date";
            this.date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date.Properties.DisplayFormat.FormatString = "";
            this.date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date.Properties.EditFormat.FormatString = "";
            this.date.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date.Properties.Mask.EditMask = "";
            this.date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.date.Size = new System.Drawing.Size(150, 20);
            this.date.TabIndex = 7;
            // 
            // btnCopyDirectory
            // 
            this.btnCopyDirectory.Location = new System.Drawing.Point(131, 172);
            this.btnCopyDirectory.Name = "btnCopyDirectory";
            this.btnCopyDirectory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnCopyDirectory.Size = new System.Drawing.Size(309, 20);
            this.btnCopyDirectory.TabIndex = 16;
            this.btnCopyDirectory.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnCopyDirectory_ButtonPressed);
            // 
            // btnSaveDirectory
            // 
            this.btnSaveDirectory.Location = new System.Drawing.Point(131, 223);
            this.btnSaveDirectory.Name = "btnSaveDirectory";
            this.btnSaveDirectory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnSaveDirectory.Size = new System.Drawing.Size(309, 20);
            this.btnSaveDirectory.TabIndex = 18;
            this.btnSaveDirectory.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnSaveDirectory_ButtonPressed);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(387, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(306, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Ок";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkIsThisPC
            // 
            this.checkIsThisPC.Location = new System.Drawing.Point(197, 198);
            this.checkIsThisPC.Name = "checkIsThisPC";
            this.checkIsThisPC.Properties.Caption = "Указать место сохранения с текущего ПК";
            this.checkIsThisPC.Size = new System.Drawing.Size(243, 19);
            this.checkIsThisPC.TabIndex = 16;
            // 
            // TaskEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 329);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gpSettings);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "TaskEdit";
            this.Text = "Задача";
            this.Load += new System.EventHandler(this.TaskEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSettings)).EndInit();
            this.gpSettings.ResumeLayout(false);
            this.gpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpRepeat)).EndInit();
            this.gpRepeat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkIsSunday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsSaturday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsFriday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsThursday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsWednesday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsTuesday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsMonday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyDirectory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveDirectory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsThisPC.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.GroupControl gpSettings;
        private DevExpress.XtraEditors.LabelControl lblSaveDirectory;
        private DevExpress.XtraEditors.LabelControl lblCopyDirectory;
        private DevExpress.XtraEditors.GroupControl gpRepeat;
        private DevExpress.XtraEditors.CheckEdit checkIsSunday;
        private DevExpress.XtraEditors.CheckEdit checkIsSaturday;
        private DevExpress.XtraEditors.CheckEdit checkIsFriday;
        private DevExpress.XtraEditors.CheckEdit checkIsThursday;
        private DevExpress.XtraEditors.CheckEdit checkIsWednesday;
        private DevExpress.XtraEditors.CheckEdit checkIsTuesday;
        private DevExpress.XtraEditors.CheckEdit checkIsMonday;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.TextEdit txtIPAddress;
        private DevExpress.XtraEditors.LabelControl lblIPAddress;
        private DevExpress.XtraEditors.DateEdit date;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.ButtonEdit btnCopyDirectory;
        private DevExpress.XtraEditors.ButtonEdit btnSaveDirectory;
        private DevExpress.XtraEditors.CheckEdit checkIsThisPC;
    }
}