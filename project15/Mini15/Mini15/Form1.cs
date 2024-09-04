using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini15
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc;
        public Form1()
        {
            
            InitializeComponent();
            // khai bao duong dan file anh 
            HinhGoc = new Bitmap(@"D:\hk2nam3\thigiacmay\tailieu\lena_color.png");
            // hien thi hinh goc
            picBoxHinhGoc.Image = HinhGoc;
        }
        // tao 1 chuong trinh con anh duong bien
        public Bitmap NhandangduongbienSobel(Bitmap HinhGoc, int Nguong)
        {
            int[,] Sx =
            {
                {-1,-2,-1 }, {0,0,0}, {1,2,1}
            };
            int[,] Sy =
            {
                {-1,0,1 }, {-2,0,2}, {-1,0,1}
            };
            // tao 1 anh duong bien 
            Bitmap Anhduongbien = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            {
                for (int x = 1; x < HinhGoc.Width-1; x++)
                    for (int y = 1; y < HinhGoc.Height-1; y++)
                    {
                        int gxx = 0, gyy = 0, gxy = 0, gxR = 0, gxG = 0, gxB = 0, gyR = 0, gyG = 0, gyB = 0;
                        for (int i = x - 1; i <= x + 1; i++)
                            for (int j = y - 1; j <= y + 1; j++)
                            {
                                // tien hanh doc cac diem anh tai i,j
                                Color color = HinhGoc.GetPixel(i, j);
                                int Gr = color.R;
                                int Gg = color.G;
                                int Gb = color.B;

                                gxR += Gr * Sx[i - x + 1, j - y + 1];
                                gxR += Gr * Sy[i - x + 1, j - y + 1];

                                gxG += Gg * Sx[i - x + 1, j - y + 1];
                                gxG += Gg * Sy[i - x + 1, j - y + 1];

                                gxB += Gb * Sx[i - x + 1, j - y + 1];
                                gxB += Gb * Sy[i - x + 1, j - y + 1];
                            }
                        // tien hah nhap ct nhu da hoc
                        gxx = (Math.Abs(gxR) * Math.Abs(gxR)) + (Math.Abs(gxG) * Math.Abs(gxG)) + (Math.Abs(gxB) * Math.Abs(gxB));
                        gyy = (Math.Abs(gyR) * Math.Abs(gyR)) + (Math.Abs(gyG) * Math.Abs(gyG)) + (Math.Abs(gyB) * Math.Abs(gyB));
                        gxy = ((gxR * gyR) + (gxG * gyR) + (gxB * gyB));
                        
                        double theta = 0.5 * Math.Atan2((2 * gxy), (gxx - gyy));
                        double F0 = Math.Sqrt(0.5 * ((gxx + gyy) + (gxx - gyy) * Math.Cos(2 * theta) + 2 * gxy * Math.Sin(2 * theta)));

                        // tien hanh set nguong cua anh 
                        if (F0 <= Nguong)
                            Anhduongbien.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        else
                            Anhduongbien.SetPixel(x, y, Color.FromArgb(255, 255, 255));



                    }
                return Anhduongbien;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte Nguong = (byte)vScrollBar_Nguong.Value;
            label3.Text = Nguong.ToString();
            Bitmap Hinhduongbien = NhandangduongbienSobel(HinhGoc, Nguong);
            picBoxSobel.Image = Hinhduongbien;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    
        
}

