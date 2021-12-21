using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12._21.Salı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnGit_Click(object sender, EventArgs e)
        {
            SayfayaGit(comboBox1.Text);
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SayfayaGit(comboBox1.Text);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }
        }
        private void SayfayaGit(string strUrl)
        {
            webBrowser1.Navigate(strUrl);
            if(!(comboBox1.Items.Contains(strUrl)))
            comboBox1.Items.Add(strUrl);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DosyadanYükle();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboBox1.Items.Count > 0)
                DosyayaKaydet();
        }
        private void DosyayaKaydet()
        {
            StreamWriter sw = new StreamWriter("url.dat");
            foreach (string item in comboBox1.Items)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }
        private void DosyadanYükle()
        {

            if (File.Exists("url.dat"))
            {
                StreamReader sr = new StreamReader("url.dat");
                while (!sr.EndOfStream)
                {
                    comboBox1.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> sehirler = new List<string>(){ "İstanbul", "Ankara", "Bursa","İzmir" };
            açılanKutu1.DataGoster(sehirler);
        }
    }
}
