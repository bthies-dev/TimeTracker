using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] lineOfContents = File.ReadAllLines("codes.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                comboBox1.Items.Add(tokens[0]);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "csv";
            sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            //sfd.FileName = DateTime.Today.ToString();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                StreamWriter sw = new StreamWriter(File.Create(path));
                foreach (var Item in listBox1.Items)
                {
                    //MessageBox.Show(Item.ToString());
                    sw.WriteLine(Item.ToString());
                }
                sw.Dispose();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Insert(0, comboBox1.SelectedItem.ToString() + ", " + DateTime.Now);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (StreamWriter sw = File.CreateText("output.txt"))
                foreach (var Item in listBox1.Items)
                {
                    sw.WriteLine(Item.ToString());
                }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }
        }
    }
}
