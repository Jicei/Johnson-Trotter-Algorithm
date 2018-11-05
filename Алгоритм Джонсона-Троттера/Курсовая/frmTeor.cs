using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class frmTeor : Form
    {
        public frmTeor()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = Application.StartupPath;
            string st1 = treeView1.SelectedNode.Text;
            if (st1 == "Коди Грея для перестановок")
                webBrowser1.Navigate(path + "\\texts\\1.htm");
            if (st1 == "Алгоритм Джонсона-Троттера")
                webBrowser1.Navigate(path + "\\texts\\2.htm");
            if (st1 == "Доведення коректності")
                webBrowser1.Navigate(path + "\\texts\\3.htm");
            if (st1 == "Асимптотика")
                webBrowser1.Navigate(path + "\\texts\\4.htm");
            if (st1 == "Порівняння з рекурсивним алгоритмом")
                webBrowser1.Navigate(path + "\\texts\\5.htm");
            if (st1 == "Цікавий факт")
                webBrowser1.Navigate(path + "\\texts\\6.htm");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 thirt_form = new Form1();
            thirt_form.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            thirt_form.ShowDialog();
        }
    }
}
