using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;


namespace Project1xla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            Image<Bgr, byte> hienthianh = new Image<Bgr, byte>(@"D:\hk2nam3\thigiacmay\Project\project1\Project1xla\bird_small.jpg");
            imageBox2.Image = hienthianh;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void imageBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
