namespace NB.Client.Form 
{ 
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnTaskAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaskEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaskRemove = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaskStart = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaskStop = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaskReport = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControlTasks = new DevExpress.XtraGrid.GridControl();
            this.gridViewTasks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnOpenCopyDirectory = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ButtonGroupsVertAlign = DevExpress.Utils.VertAlignment.Center;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnTaskAdd,
            this.btnTaskEdit,
            this.btnTaskRemove,
            this.btnTaskStart,
            this.btnTaskStop,
            this.btnTaskReport,
            this.btnOpenCopyDirectory});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1059, 141);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTaskAdd
            // 
            this.btnTaskAdd.Caption = "Добавить";
            this.btnTaskAdd.Id = 2;
            this.btnTaskAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskAdd.ImageOptions.Image")));
            this.btnTaskAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaskAdd.ImageOptions.LargeImage")));
            this.btnTaskAdd.Name = "btnTaskAdd";
            this.btnTaskAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaskAdd_ItemClick);
            // 
            // btnTaskEdit
            // 
            this.btnTaskEdit.Caption = "Редактировать";
            this.btnTaskEdit.Id = 3;
            this.btnTaskEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskEdit.ImageOptions.Image")));
            this.btnTaskEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaskEdit.ImageOptions.LargeImage")));
            this.btnTaskEdit.Name = "btnTaskEdit";
            this.btnTaskEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaskEdit_ItemClick);
            // 
            // btnTaskRemove
            // 
            this.btnTaskRemove.Caption = "Удалить";
            this.btnTaskRemove.Id = 4;
            this.btnTaskRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskRemove.ImageOptions.Image")));
            this.btnTaskRemove.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaskRemove.ImageOptions.LargeImage")));
            this.btnTaskRemove.Name = "btnTaskRemove";
            this.btnTaskRemove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaskRemove_ItemClick);
            // 
            // btnTaskStart
            // 
            this.btnTaskStart.Caption = "Запустить";
            this.btnTaskStart.Id = 5;
            this.btnTaskStart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskStart.ImageOptions.Image")));
            this.btnTaskStart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaskStart.ImageOptions.LargeImage")));
            this.btnTaskStart.Name = "btnTaskStart";
            this.btnTaskStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaskStart_ItemClick);
            // 
            // btnTaskStop
            // 
            this.btnTaskStop.Caption = "Остановить";
            this.btnTaskStop.Id = 6;
            this.btnTaskStop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskStop.ImageOptions.Image")));
            this.btnTaskStop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaskStop.ImageOptions.LargeImage")));
            this.btnTaskStop.Name = "btnTaskStop";
            this.btnTaskStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaskStop_ItemClick);
            // 
            // btnTaskReport
            // 
            this.btnTaskReport.Caption = "Отчет";
            this.btnTaskReport.Id = 7;
            this.btnTaskReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskReport.ImageOptions.Image")));
            this.btnTaskReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaskReport.ImageOptions.LargeImage")));
            this.btnTaskReport.Name = "btnTaskReport";
            this.btnTaskReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaskReport_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Основное меню";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTaskAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTaskEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTaskRemove);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTaskStart);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTaskStop);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnTaskReport);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 561);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1059, 27);
            // 
            // gridControlTasks
            // 
            this.gridControlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTasks.Location = new System.Drawing.Point(0, 141);
            this.gridControlTasks.MainView = this.gridViewTasks;
            this.gridControlTasks.Name = "gridControlTasks";
            this.gridControlTasks.Size = new System.Drawing.Size(1059, 420);
            this.gridControlTasks.TabIndex = 2;
            this.gridControlTasks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTasks});
            // 
            // gridViewTasks
            // 
            this.gridViewTasks.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewTasks.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewTasks.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridViewTasks.GridControl = this.gridControlTasks;
            this.gridViewTasks.Name = "gridViewTasks";
            this.gridViewTasks.OptionsBehavior.Editable = false;
            this.gridViewTasks.OptionsSelection.MultiSelect = true;
            this.gridViewTasks.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewTasks.OptionsView.ShowGroupPanel = false;
            this.gridViewTasks.DoubleClick += new System.EventHandler(this.gridViewTasks_DoubleClick);
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnOpenCopyDirectory);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // btnOpenCopyDirectory
            // 
            this.btnOpenCopyDirectory.Caption = "Открыть каталог сохранения";
            this.btnOpenCopyDirectory.Id = 15;
            this.btnOpenCopyDirectory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenCopyDirectory.ImageOptions.Image")));
            this.btnOpenCopyDirectory.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOpenCopyDirectory.ImageOptions.LargeImage")));
            this.btnOpenCopyDirectory.Name = "btnOpenCopyDirectory";
            this.btnOpenCopyDirectory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenCopyDirectory_ItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 588);
            this.Controls.Add(this.gridControlTasks);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Name = "MainForm";
            this.Text = "Резервное копирование";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnTaskAdd;
        private DevExpress.XtraBars.BarButtonItem btnTaskEdit;
        private DevExpress.XtraBars.BarButtonItem btnTaskRemove;
        private DevExpress.XtraBars.BarButtonItem btnTaskStart;
        private DevExpress.XtraBars.BarButtonItem btnTaskStop;
        private DevExpress.XtraBars.BarButtonItem btnTaskReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraGrid.GridControl gridControlTasks;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTasks;
        private DevExpress.XtraBars.BarButtonItem btnOpenCopyDirectory;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}