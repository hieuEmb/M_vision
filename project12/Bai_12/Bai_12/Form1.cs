using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Load ảnh từ file
            Bitmap HinhGoc = new Bitmap(@"D:\hk2nam3\thigiacmay\tailieu\lena_color.png");

            // Hiển thị lên picbox
            pictureBox1.Image = HinhGoc;

            // Tính toán và hiển thị ảnh Laplacian
            Bitmap HinhLaplacian = TinhToanLaplacian(HinhGoc);
            pictureBox2.Image = HinhLaplacian;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Bitmap TinhToanLaplacian(Bitmap imgPIL)
        {
            Bitmap HinhLaplacian = new Bitmap(imgPIL.Width, imgPIL.Height);

            int width = imgPIL.Width;
            int height = imgPIL.Height;

            // Lặp qua từng pixel trong ảnh
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    Color pixelColor = imgPIL.GetPixel(x, y);

                    int B1 = 0;
                    int G1 = 0;
                    int R1 = 0;

                    // Tính toán giá trị Laplacian cho từng kênh màu
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            Color neighborColor = imgPIL.GetPixel(i, j);
                            // Giá trị R, G, B
                            int R = neighborColor.R;
                            int G = neighborColor.G;
                            int B = neighborColor.B;

                            int blue = (imgPIL.GetPixel(x - 1, y).B + imgPIL.GetPixel(x + 1, y).B +
                                        imgPIL.GetPixel(x, y - 1).B + imgPIL.GetPixel(x, y + 1).B) - 4 * imgPIL.GetPixel(x, y).B;
                            int green = (imgPIL.GetPixel(x - 1, y).G + imgPIL.GetPixel(x + 1, y).G +
                                        imgPIL.GetPixel(x, y - 1).G + imgPIL.GetPixel(x, y + 1).G) - 4 * imgPIL.GetPixel(x, y).G;
                            int red = (imgPIL.GetPixel(x - 1, y).R + imgPIL.GetPixel(x + 1, y).R +
                                       imgPIL.GetPixel(x, y - 1).R + imgPIL.GetPixel(x, y + 1).R) - 4 * imgPIL.GetPixel(x, y).R;

                            B1 = B + (-1 * blue);
                            G1 = G + (-1 * green);
                            R1 = R + (-1 * red);
                        }
                    }
                    // Cập nhật giá trị của pixel trong ảnh kết quả
                    // Đảm bảo giá trị màu nằm trong phạm vi 0-255
                    B1 = Math.Max(0, Math.Min(255, B1));
                    G1 = Math.Max(0, Math.Min(255, G1));
                    R1 = Math.Max(0, Math.Min(255, R1));

                    // Cập nhật giá trị của pixel trong ảnh kết quả
                    HinhLaplacian.SetPixel(x, y, Color.FromArgb(R1, G1, B1));
                }
            }
            return HinhLaplacian;
        }
    }
}

