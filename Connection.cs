using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AT
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Universaler.sername = textBox1.Text;
            Universaler.dataname= textBox2.Text;
            Universaler.logname = textBox3.Text;
            Universaler.datapass = textBox4.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}