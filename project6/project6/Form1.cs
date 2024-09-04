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

            // Hiển thị các kênh màu CMYK được chuyển đổi từ RGB
            // Gọi hàm chuyển đổi RGB sang CMYK
            List<Bitmap> CMYK = ChuyenHinh_RGB_Sang_CMYK(HinhGoc);

            // Hàm trả về 4 kênh màu tương ứng giá trị theo thứ tự từ 0-3 là C-M-Y-K
            // Bây giờ mình cho hiển thị trên các picture
            pictureBox2.Image = CMYK[0];
            pictureBox3.Image = CMYK[1];
            pictureBox4.Image = CMYK[2];
            pictureBox5.Image = CMYK[3];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private List<Bitmap> ChuyenHinh_RGB_Sang_CMYK(Bitmap hinhGoc)
        {
            // Tạo một list để chứa 4 kênh ảnh tương ứng C- M- Y- K
            List<Bitmap> CMYK = new List<Bitmap>();

            // Mỗi kênh trong không gian màu CMYK được hiển thị bởi một hình Bitmap
            Bitmap Cyan = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap Magenta = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap Yellow = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap Black = new Bitmap(hinhGoc.Width, hinhGoc.Height);

            for (int x = 0; x < hinhGoc.Width; x++)
            {
                for (int y = 0; y < hinhGoc.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color pixel = hinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    // Màu cyan(xanh dương) là kết hợp giữa Green và Blue
                    Cyan.SetPixel(x, y, Color.FromArgb(255, 0, G, B));

                    // Màu Mangenta(màu tím) là kết hợp giữa Red và Blue
                    Magenta.SetPixel(x, y, Color.FromArgb(255, R, 0, B));

                    // Màu Yellow (màu vàng) là kết hợp giữa Green và Red
                    Yellow.SetPixel(x, y, Color.FromArgb(255, R, G, 0));

                    // Màu Black(đen) lấy min(R, G, B)
                    byte K = (Math.Min(R, Math.Min(G, B)));
                    Black.SetPixel(x, y, Color.FromArgb(255, K, K, K));
                }
            }

            // Add các kình tương ứng vào các kênh màu C-M-Y-K vào list
            CMYK.Add(Cyan);
            CMYK.Add(Magenta);
            CMYK.Add(Yellow);
            CMYK.Add(Black);

            // Hàm trả về một list 4 ảnh Bitmap tương ứng với 4 kênh màu C-M-Y-K
            return CMYK;
        }
    }
}
