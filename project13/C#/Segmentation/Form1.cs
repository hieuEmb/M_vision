using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Segmentation
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc = new Bitmap(@"E:\SUBJECT IN UNI\XLA\lena_color.png");
        public Form1()
        {
            InitializeComponent();
            pictureBox_hinhgoc.Image = HinhGoc;
        }
        private void button_Segmentation_Click(object sender, EventArgs e)
        {

        }
    }
}
