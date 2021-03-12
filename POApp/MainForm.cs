using POApp.Interfaces;
using POApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POApp
{
    public partial class MainForm : Form
    {
        public IPOService<IPOTreeNodeValue> POService { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadNodes(IMyTreeNode<IPOTreeNodeValue> rootNode, TreeNodeCollection nodes)
        {
            foreach (var node in rootNode.Children)
            {
                var newTreeNode = nodes.Add(node.Value.Name);

                if (node.Value.Translations != null)
                    newTreeNode.Tag = node.Value.Translations;

                if (node.Children.Count() > 0)
                    LoadNodes(node, newTreeNode.Nodes);
            }
        }

        private void загрузитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (POService == null)
                return;

            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "po files (*.po)|*.po";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            var rootNode = POService.GetMsgctxtTree(fileDialog.FileName);
            LoadNodes(rootNode, treeView.Nodes);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                translationBindingSource.DataSource = null;
                return;
            }

            var translations = e.Node.Tag as List<Translation>;
            translationBindingSource.DataSource = translations;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}
