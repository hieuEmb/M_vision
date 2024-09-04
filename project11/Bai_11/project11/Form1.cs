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
            Bitmap HinhGoc = new Bitmap("D:/hk2nam3/thigiacmay/tailieu/lena_color.png");

            // Hiển thị lên picbox
            pictureBox1.Image = HinhGoc;

            // Hiển thị các kênh màu CMYK được chuyển đổi từ RGB
            // Gọi hàm chuyển đổi RGB sang CMYK
            Bitmap SmoothedImage3x3 = ColorImageSmoothing(HinhGoc, 3);

            // Hàm trả về 4 kênh màu tương ứng giá trị theo thứ tự từ 0-3 là C-M-Y-K
            // Bây giờ mình cho hiển thị trên các picture
            pictureBox2.Image = SmoothedImage3x3;

            Bitmap SmoothedImage5x5 = ColorImageSmoothing(HinhGoc, 5);
            pictureBox3.Image = SmoothedImage5x5;

            Bitmap SmoothedImage7x7 = ColorImageSmoothing(HinhGoc, 7);
            pictureBox4.Image = SmoothedImage7x7;

            Bitmap SmoothedImage9x9 = ColorImageSmoothing(HinhGoc, 9);
            pictureBox5.Image = SmoothedImage9x9;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Viết hàm làm mượt ảnh RGB với mặt nạ 3x3
        /// </summary>
        /// <param name="HinhGoc"></param>
        /// <returns></returns>
        private Bitmap ColorImageSmoothing(Bitmap HinhGoc, int maskSize)
        {
            // Tạo một Bitmap mới để chứa ảnh sau khi làm mượt
            Bitmap smoothedImage = new Bitmap(HinhGoc.Width, HinhGoc.Height);

            // Số lượng điểm ảnh trong mặt nạ
            int maskLength = maskSize * maskSize;

            // Số lượng pixel được bỏ qua ở biên để không vượt quá biên của ảnh
            int padding = maskSize / 2;
            

            for (int x = padding; x < HinhGoc.Width - padding; x++)
            {
                for (int y = padding; y < HinhGoc.Height - padding; y++)
                {
                    int Rs = 0, Gs = 0, Bs = 0;

                    // Tiến hành quét các điểm có trong mặt nạ
                    for (int i = x - padding; i <= x + padding; i++)
                    {
                        for (int j = y - padding; j <= y + padding; j++)
                        {
                            Color pixel = HinhGoc.GetPixel(i, j);
                            byte R = pixel.R;
                            byte G = pixel.G;
                            byte B = pixel.B;

                            Rs += R;
                            Gs += G;
                            Bs += B;
                        }
                    }

                    // Tính trung bình cộng cho mỗi kênh theo công thức
                    Rs = (int)(Rs / maskLength);
                    Gs = (int)(Gs / maskLength);
                    Bs = (int)(Bs / maskLength);

                    // Set điểm ảnh làm mượt(làm mờ) vào bitmap
                    smoothedImage.SetPixel(x, y, Color.FromArgb(Rs, Gs, Bs));
                }
            }
            return smoothedImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
