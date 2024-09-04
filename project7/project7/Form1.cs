using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace project6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Load ảnh từ file
            Bitmap HinhGoc = new Bitmap(@"D:\hk2nam3\thigiacmay\Project\Bai_7\lena_color.png");

            // Hiển thị lên picbox
            pictureBox1.Image = HinhGoc;

            // Hiển thị các kênh màu CMYK được chuyển đổi từ RGB
            // Gọi hàm chuyển đổi RGB sang CMYK
            List<Bitmap> HSI = ChuyenHinh_RGB_Sang_HSI(HinhGoc);

            // Hàm trả về 4 kênh màu tương ứng giá trị theo thứ tự từ 0-3 là C-M-Y-K
            // Bây giờ mình cho hiển thị trên các picture
            pictureBox2.Image = HSI[0];
            pictureBox3.Image = HSI[1];
            pictureBox4.Image = HSI[2];
            pictureBox5.Image = HSI[3];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private List<Bitmap> ChuyenHinh_RGB_Sang_HSI(Bitmap hinhGoc)
        {
            // Tạo một list để chứa 4 kênh ảnh tương ứng C- M- Y- K
            List<Bitmap> HSI = new List<Bitmap>();

            // Mỗi kênh trong không gian màu CMYK được hiển thị bởi một hình Bitmap
            Bitmap Hue = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap Staturation = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap Intensity = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap HSIImg = new Bitmap(hinhGoc.Width, hinhGoc.Height);

            for (int x = 0; x < hinhGoc.Width; x++)
            {
                for (int y = 0; y < hinhGoc.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color pixel = hinhGoc.GetPixel(x, y);
                    double R = pixel.R;
                    double G = pixel.G;
                    double B = pixel.B;

                    // Dựa theo công thức
                    // t1 là phần tử số của công thức
                    double t1 = ((R - G) + (R - B)) / 2;

                    // t2 là phần mẫu số của công thức tính góc theta
                    double t2 = Math.Sqrt((R - G) * (R - G) + (R - B) * (G - B));

                    //
                    double theta = Math.Acos(t1 / t2);

                    double H = 0;
                    if (B <= G)
                        H = theta;
                    else
                        H = 2 * Math.PI - theta;

                    H = H * 180 / Math.PI;

                    double S = 1 - (3 * Math.Min(R, Math.Min(G, B))) / (R + G + B);
                    //S=S*255;

                    double I = (R + G + B) / 3;

                    // Cho hiển thị
                    Hue.SetPixel(x, y, Color.FromArgb((byte)H, (byte)H, (byte)H));
                    Staturation.SetPixel(x, y, Color.FromArgb((byte)(S * 255), (byte)(S * 255), (byte)(S * 255)));
                    Intensity.SetPixel(x, y, Color.FromArgb((byte)I, (byte)I, (byte)I));
                    HSIImg.SetPixel(x, y, Color.FromArgb((byte)H, (byte)(S*255), (byte)I));
                }
            }

            // Add các kình tương ứng vào các kênh màu C-M-Y-K vào list
            HSI.Add(Hue);
            HSI.Add(Staturation);
            HSI.Add(Intensity);
            HSI.Add(HSIImg);
            // Hàm trả về một list 4 ảnh Bitmap tương ứng với 4 kênh màu C-M-Y-K
            return HSI;
        }
        private void lbl2_Click(object sender, EventArgs e)
        {

        }
    }
}
