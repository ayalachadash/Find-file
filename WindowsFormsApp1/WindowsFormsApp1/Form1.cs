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
        static string[] arrSuffixChoose = { "txt", "js" };
        Search s = new Search(new Person("ayala", "chadash", 20), arrSuffixChoose);
        public Form1()
        {
            InitializeComponent();

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
            listBox1.Items.Add( "lll");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s.MatchFound += PrintFile;
            s.deepSearch("C:\\המחשב שלי\\לימודים\\c# יד\\final project");
        }
    }
}
