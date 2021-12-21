using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12._21.Salı
{
    public partial class AçılanKutu : UserControl
    {
        public AçılanKutu()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            //panel1.Visible = false;
        }
        private List<string> _data;
        public List<string> Data { get; set; }
        
        public void DataGoster(List<string> data)
        {
            panel1.Controls.Clear();
            Data = data;
            int _top = 10;
            foreach (string item in data)
            {
                panel1.Controls.Add(new Label() {Text=item,Width=200,BackColor=Color.Orange,Top=_top});

                Button btn = new Button() { Text = "x", Width = 30, Left = 200, Top = _top, Tag = item };
                btn.Click += Btn_Click;
                panel1.Controls.Add(btn);
                _top += 22;
            }
            panel1.Height = _top + 15;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Data.Remove(((Button)sender).Tag.ToString());

            DataGoster(Data);
        }
    }
}
