using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.FolderBrowserDialog fbd;
        string path = "";
        static string[] arrSuffixChoose;
        public Form1()
        {
            InitializeComponent();
            int i = 0;
            foreach (CheckBox c in groupBox1.Controls)
            {
                c.Text = Search.arrSuffix[i];
                i++;
            }
        }

        public void PrintFile(string file, string found)
        {
            listBox1.Invoke(new MethodInvoker(() =>
            {
                listBox1.Items.Add(file + " this is found: " + found);
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void fullArrSufixx()
        {
            int i = 0;
            foreach (CheckBox c in groupBox1.Controls)
            {
                if (c.Checked)
                {
                    i++;
                }
            }
            arrSuffixChoose = new string[i];
            i = 0;
            foreach (CheckBox c in groupBox1.Controls)
            {
                if (c.Checked)
                {
                    arrSuffixChoose[i] = c.Text;
                    i++;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            fullArrSufixx();
            Search s = new Search(new Person("ayala", "chadash", 19), arrSuffixChoose);
            s.MatchFound += PrintFile;
            s.deepSearch(path);
            //"C:\\המחשב שלי\\לימודים\\c# יד\\final project"
        }
        private void button3_Click(object sender, EventArgs e)
        {
            fullArrSufixx();
            Search s = new Search(new Product(1, "bear", 5, 5), arrSuffixChoose);
            s.MatchFound += PrintFile;
            s.deepSearch(path);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            fullArrSufixx();
            Search s = new Search(new Animal("dog", "bride", true), arrSuffixChoose);
            s.MatchFound += PrintFile;
            s.deepSearch(path);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fullArrSufixx();
            Search s = new Search(new Person("ayala", "chadash", 19), arrSuffixChoose);
            s.MatchFound += PrintFile;
            s.flatSearch(path);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fullArrSufixx();
            Search s = new Search(new Product(1, "bear", 5, 5), arrSuffixChoose);
            s.MatchFound += PrintFile;
            s.flatSearch(path);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fullArrSufixx();
            Search s = new Search(new Animal("dog", "bride", true), arrSuffixChoose);
            s.MatchFound += PrintFile;
            s.flatSearch(path);
        }
    }
}
