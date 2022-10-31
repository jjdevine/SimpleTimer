using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTimer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            go();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        }

        private void go()
        {
            int[] tokens = Utils.ParseTime(textBox1.Text);
            new Alarm(tokens[0], tokens[1]);
            this.Hide();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true ;
                go();
                e.Handled = true;
            }
        }
    }
}
