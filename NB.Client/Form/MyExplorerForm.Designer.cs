namespace NB.Client.Form
{
    partial class MyExplorerForm
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.treeListMyExplorer = new DevExpress.XtraTreeList.TreeList();
            this.panelFooter = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeListMyExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(388, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(307, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Ок";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // treeListMyExplorer
            // 
            this.treeListMyExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListMyExplorer.Location = new System.Drawing.Point(0, 0);
            this.treeListMyExplorer.Name = "treeListMyExplorer";
            this.treeListMyExplorer.OptionsBehavior.Editable = false;
            this.treeListMyExplorer.Size = new System.Drawing.Size(475, 308);
            this.treeListMyExplorer.TabIndex = 5;
            this.treeListMyExplorer.RowClick += new DevExpress.XtraTreeList.RowClickEventHandler(this.treeListMyExplorer_RowClick);
            // 
            // panelFooter
            // 
            this.panelFooter.AutoSize = true;
            this.panelFooter.Controls.Add(this.btnCancel);
            this.panelFooter.Controls.Add(this.btnSave);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 273);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(475, 35);
            this.panelFooter.TabIndex = 6;
            // 
            // MyExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 308);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.treeListMyExplorer);
            this.Name = "MyExplorerForm";
            this.Text = "Обзор";
            this.Load += new System.EventHandler(this.TaskEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListMyExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraTreeList.TreeList treeListMyExplorer;
        private DevExpress.XtraEditors.PanelControl panelFooter;
    }
}