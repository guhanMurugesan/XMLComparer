using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileComparer.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            if (label1.Text.Equals("Select File 1") || label2.Text.Equals("Select File 2"))
                return;
            Driver.Main(label1.Text,label2.Text,label4.Text,textBox1.Text);
            lblResult.Text = "Results saved!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Select File 1";
            label2.Text = "Select File 2";
            label4.Text = "Select Destination Folder";
            lblResult.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
