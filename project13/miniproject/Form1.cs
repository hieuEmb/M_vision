using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniproject
{
    public partial class Form1 : Form
    {
        Bitmap Hinhgoc = new Bitmap(@"D:\hk2nam3\thigiacmay\tailieu\lena_color.png");
        public Form1()
        {
            InitializeComponent();
            // Khai bao duong dan file anh
           
            picBox_Goc.Image = Hinhgoc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lay du lieu tu cac text box va chuyen du lieu sang so;
            int X1 = Convert.ToInt16(textBoxX1.Text);
            int X2 = Convert.ToInt16(textBoxX2.Text);
            int Y1 = Convert.ToInt16(textBoxY1.Text);
            int Y2 = Convert.ToInt16(textBoxY2.Text);
            int Nguong = Convert.ToInt16(textBoxNguong.Text);
            double Rtb = 0, Gtb = 0, Btb = 0;
            // Tinh vecto trung binh
            for (int x=X1; x<=X2;x++)
                for (int y=Y1;y<=Y2;y++)
                {
                    // Tien hanh quet cac diem x va y
                    Color pixel = Hinhgoc.GetPixel(x, y);
                    Rtb += pixel.R; // Lay gia tri mau red
                    Gtb += pixel.G; // Lay gia tri mau green
                    Btb += pixel.B; // Lay gia tri mau blue
                }
            double S = ((X2 - X1 + 1) * (Y2 - Y1 + 1));
            Rtb = Rtb / S;
            Gtb = Gtb / S;
            Btb = Btb / S;
            // Tien hanh tao mot anh Segmention 
            Bitmap Segmentation = new Bitmap(Hinhgoc.Width, Hinhgoc.Height);
            for ( int x=0; x<Hinhgoc.Width;x++)
                for (int y=0; y<Hinhgoc.Height;y++)
                {
                    // Tien hanh quet cac diem anh tai x va y
                    Color pixel2 = Hinhgoc.GetPixel(x, y);
                    double R2 = pixel2.R; // Lay gia tri mau red 2
                    double G2 = pixel2.G; // Lay gia tri mau green 2
                    double B2 = pixel2.B; // Lay gia tri mau blue 2
                    double D = Math.Sqrt(Math.Pow(R2 - Rtb, 2) + Math.Pow(G2 - Gtb, 2) + Math.Pow(B2 - Btb, 2));

                    if ((int)D < Nguong)
                        Segmentation.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    else
                        Segmentation.SetPixel(x, y, Color.FromArgb((Int32)R2, (Int32)G2, (Int32)B2));


                }
            pictureBox1.Image = Segmentation;
        }
    }
}
