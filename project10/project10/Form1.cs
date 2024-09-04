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
            Bitmap HinhGoc = new Bitmap(@"D:\hk2nam3\thigiacmay\Project\project3\lena_color.png");

            // Hiển thị lên picbox
            pictureBox1.Image = HinhGoc;

            // Hiển thị các kênh màu RGB được chuyển đổi từ XYZ
            // Gọi hàm chuyển đổi RGB sang XYZ
            List<Bitmap> xyzChannels = ChuyenHinh_RGB_Sang_YCrCb(HinhGoc);

            // Hàm trả về 3 kênh màu tương ứng giá trị theo thứ tự từ 0-2 là X-Y-Z
            // Bây giờ mình cho hiển thị trên các picture
            pictureBox2.Image = xyzChannels[0];
            pictureBox3.Image = xyzChannels[1];
            pictureBox4.Image = xyzChannels[2];
            pictureBox5.Image = xyzChannels[3];
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private List<Bitmap> ChuyenHinh_RGB_Sang_YCrCb(Bitmap hinhGoc)
        {
            // Tạo một list để chứa 4 kênh ảnh tương ứng C- M- Y- K
            List<Bitmap> YCrCb = new List<Bitmap>();

            // Mỗi kênh trong không gian màu CMYK được hiển thị bởi một hình Bitmap
            Bitmap HinhY = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap HinhCb = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap HinhCr = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap HinhYCbCr = new Bitmap(hinhGoc.Width, hinhGoc.Height);

            for (int x = 0; x < hinhGoc.Width; x++)
            {
                for (int y = 0; y < hinhGoc.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color pixel = hinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    byte Y = (byte)(16 + ((65.738 * R) / 256) + ((129.057 * G) / 256) + ((25.064 * B) / 256));
                    byte Cb = (byte)(128 - ((37.495 * R) / 256) - ((74.494 * G) / 256) + ((112.439 * B) / 256));
                    byte Cr = (byte)(128 + ((112.439 * R) / 256) - ((94.154 * G) / 256) - ((18.285 * B) / 256));


                    // Gán giá trị mức xám vừa tính vào hình mức xám
                    HinhY.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                    HinhCb.SetPixel(x, y, Color.FromArgb(Cb, Cb, Cb));
                    HinhCr.SetPixel(x, y, Color.FromArgb(Cr, Cr, Cr));
                    HinhYCbCr.SetPixel(x, y, Color.FromArgb(Y, Cb, Cr));
                }
            }

            // Add các kình tương ứng vào các kênh màu C-M-Y-K vào list
            YCrCb.Add(HinhY);
            YCrCb.Add(HinhCb);
            YCrCb.Add(HinhCr);
            YCrCb.Add(HinhYCbCr);

            // Hàm trả về một list 4 ảnh Bitmap tương ứng với 4 kênh màu C-M-Y-K
            return YCrCb;
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
        }
    }
}
