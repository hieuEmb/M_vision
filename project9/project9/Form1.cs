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
            Bitmap HinhGoc = new Bitmap(@"D:\hk2nam3\thigiacmay\Project\Bai9\lena_color.png");

            // Hiển thị lên picbox
            pictureBox1.Image = HinhGoc;

            // Hiển thị các kênh màu RGB được chuyển đổi từ XYZ
            // Gọi hàm chuyển đổi RGB sang XYZ
            List<Bitmap> xyzChannels = ChuyenHinh_RGB_Sang_XYZ(HinhGoc);

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

        private List<Bitmap> ChuyenHinh_RGB_Sang_XYZ(Bitmap hinhGoc)
        {
            // Tạo một list để chứa 3 kênh ảnh tương ứng X- Y- Z
            List<Bitmap> xyzChannels = new List<Bitmap>();

            // Mỗi kênh trong không gian màu XYZ được hiển thị bởi một hình Bitmap
            Bitmap XChannel = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap YChannel = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap ZChannel = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            Bitmap XYZChannel = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            for (int x = 0; x < hinhGoc.Width; x++)
            {
                for (int y = 0; y < hinhGoc.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color pixel = hinhGoc.GetPixel(x, y);
                    double R = pixel.R;
                    double G = pixel.G;
                    double B = pixel.B;

                    double[,] rgbToXyzMatrix = {
                        {0.4124564, 0.3575761, 0.1804375},
                        {0.2126729, 0.7151522, 0.0721750},
                        {0.0193339, 0.1191920, 0.9503041}
                    };

                    // Tính toán giá trị màu sắc XYZ
                    double X = rgbToXyzMatrix[0, 0] * R + rgbToXyzMatrix[0, 1] * G + rgbToXyzMatrix[0, 2] * B;
                    double Y = rgbToXyzMatrix[1, 0] * R + rgbToXyzMatrix[1, 1] * G + rgbToXyzMatrix[1, 2] * B;
                    double Z = rgbToXyzMatrix[2, 0] * R + rgbToXyzMatrix[2, 1] * G + rgbToXyzMatrix[2, 2] * B;

                    // Hiển thị kết quả
                    // Cho hiển thị
                    XChannel.SetPixel(x, y, Color.FromArgb((int)X, (int)X, (int)X));
                    YChannel.SetPixel(x, y, Color.FromArgb((int)Y, (int)Y, (int)Y));
                    ZChannel.SetPixel(x, y, Color.FromArgb((int)Z, (int)Z, (int)Z));
                    XYZChannel.SetPixel(x, y, Color.FromArgb((int)X, (int)Y, (int)Z));

                }
            }

            // Add các kình tương ứng vào các kênh màu X-Y-Z vào list
            xyzChannels.Add(XChannel);
            xyzChannels.Add(YChannel);
            xyzChannels.Add(ZChannel);
            xyzChannels.Add(XYZChannel);
            // Hàm trả về một list 3 ảnh Bitmap tương ứng với 3 kênh màu X-Y-Z
            return xyzChannels;
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
        }
    }
}
