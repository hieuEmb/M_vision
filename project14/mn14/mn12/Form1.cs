using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mn12
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc = new Bitmap(@"D:\hk2nam3\thigiacmay\tailieu\lena_color.png");
        public Form1()
        {
            InitializeComponent();


            // Khai báo đường dẫn file ảnh gôc
            //Bitmap HinhGoc = new Bitmap(@"C:\Users\ACER\Desktop\c#\lena1_color.jpg");
            // Hiển Thị Hình Gốc
            picBoxHinhGoc.Image = HinhGoc;

        }
        public Bitmap ChuyenSangmucxam(Bitmap HinhGoc)
        {
            Bitmap Hinhmucxam = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            // lay gia tri tung pixel
            for (int x = 0; x< HinhGoc.Width;x++)
                for (int y = 0; y< HinhGoc.Height;y++)
                {
                    Color pixel = HinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);
                    Hinhmucxam.SetPixel(x, y, Color.FromArgb(gray, gray, gray));

                }
            return Hinhmucxam;
        }
        // Tao mot chuong trinh con nhan dang duong bien
        public Bitmap Nhandangduongbien (Bitmap Hinhxam)
        {
            int Nguong = Convert.ToInt16(textBox1.Text);
            int[,] Sx =
            {
                {-1,-2,-1 },
                {0,0,0 },
                {1,2,1 }
            };
            int[,] Sy =
            {
                {-1,0,1 },
                {-2,0,2 },
                {-1,0,1 }
            };
            Bitmap Anhduongbien = new Bitmap(Hinhxam.Width, Hinhxam.Height);
            // dung for de quet
            for (int x = 1; x < Hinhxam.Width-1; x++)
                for (int y = 1; y < Hinhxam.Height-1; y++)
                {
                    int gx = 0, gy = 0;
                    for (int i=x-1;i<=x+1;i++)
                    {
                        for (int j =y-1;j<=y+1;j++)
                        {
                            Color color = Hinhxam.GetPixel(i, j);
                            int Gr = color.R;
                            gx += Gr * Sx[i - x + 1, j - y + 1];
                            gy += Gr * Sy[i - x + 1, j - y + 1];

                        }
                    }
                    int M = Math.Abs(gx) + Math.Abs(gy);
                    if (M <= Nguong)
                        Anhduongbien.SetPixel(x, y, Color.FromArgb(0, 0, 0));// bg
                    else
                        Anhduongbien.SetPixel(x, y, Color.FromArgb(255, 255, 255));// egde

                }
            return Anhduongbien;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap Hinhmucxam = ChuyenSangmucxam(HinhGoc);
            Bitmap Hinhduongbien = Nhandangduongbien(Hinhmucxam);
            picBoxHinhChuyenDoi.Image = Hinhduongbien;

        }
    }
}
