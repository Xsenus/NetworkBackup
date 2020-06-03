using System;
using System.Net.Sockets;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using NB.Core.Enumerator;
using NB.Core.Model;
using Newtonsoft.Json;

namespace NB.Client.Form
{
    public partial class MyExplorerForm : XtraForm
    {
        private NetworkStream NetworkStream { get; }
        public string Path { get; set; }

        private MyExplorerForm()
        {
            InitializeComponent();            
        }

        public MyExplorerForm(NetworkStream networkStream) : this()
        {
            NetworkStream = networkStream;
        }

        private void TaskEdit_Load(object sender, EventArgs e)
        {
            GetFirstTree();
        }

        private void GetFirstTree()
        {
            try
            {
                while (true)
                {
                    var message = String.Format("GetFolderBrowserDialog");
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);

                    data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }

                    while (NetworkStream.DataAvailable);

                    message = builder.ToString();
                    if (JsonConvert.DeserializeObject<MyExplorer>(message) is MyExplorer myExplorer)
                    {
                        CreateColumns(treeListMyExplorer);
                        CreateNodes(treeListMyExplorer, myExplorer);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CreateColumns(TreeList tl)
        {
            tl.BeginUpdate();
            TreeListColumn col1 = tl.Columns.Add();
            col1.Caption = "Путь";
            col1.VisibleIndex = 0;
            tl.EndUpdate();
        }

        private void CreateNodes(TreeList treeList, MyExplorer myExplorer)
        {
            treeList.BeginUnboundLoad();
            foreach (var item in myExplorer.Path)
            {
                treeList.AppendNode(new object[] { item }, null);                
            }
            treeList.EndUnboundLoad();
        }

        private void treeListMyExplorer_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                return;
            }

            try
            {
                while (true)
                {
                    var myExplorerOut = new MyExplorer();
                    myExplorerOut.Root = GetFullPath(e.Node);

                    if (myExplorerOut.Root.LastIndexOf(':') == myExplorerOut.Root.Length - 1)
                    {
                        myExplorerOut.Root = $"{myExplorerOut.Root}\\";
                    }

                    var message = $"{(int)TaskServerStatus.MyExplorerTask}" + JsonConvert.SerializeObject(myExplorerOut);
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = builder.ToString();

                    if (JsonConvert.DeserializeObject<MyExplorer>(message) is MyExplorer myExplorer)
                    {
                        InitFolders(e.Node, myExplorer);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }

        private string GetFullPath(TreeListNode pNode)
        {
            if (pNode.ParentNode == null)
            {
                return pNode.GetValue(0).ToString().Replace("\\", "");
            }
            else
            {
                return GetFullPath(pNode.ParentNode) + "\\" + pNode.GetValue(0);
            }
        }

        private void InitFolders(TreeListNode treeListNode, MyExplorer myExplorer)
        {
            treeListMyExplorer.BeginUnboundLoad();
            foreach (string s in myExplorer.Path)
            {
                try
                {
                    treeListMyExplorer.AppendNode(new object[] { s }, treeListNode); ;
                }
                catch { }
            }
            treeListMyExplorer.EndUnboundLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var node = treeListMyExplorer.FocusedNode;

            if (node != null)
            {
                Path = GetFullPath(node);

                if (Path.LastIndexOf(':') == Path.Length - 1)
                {
                    Path = $"{Path}\\";
                }
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}