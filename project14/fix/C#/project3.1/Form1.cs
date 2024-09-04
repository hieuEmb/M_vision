using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project3._1
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc;
        public Form1()
        {
            InitializeComponent();

            // Load ảnh từ file
            // Cần chuyển biến này thành biến toàn cục (global) để có thể sử dụng cho các hàm khác.
            HinhGoc = new Bitmap(@"D:\hk2nam3\thigiacmay\tailieu\lena_color.png");

            // Hiển thị lên picbox
            picBoxHinhGoc.Image = HinhGoc;
      
            // Tính hình nhị phân và cho hiển thị
            // Giả sử cho ngưỡng là 130
            picBoxHinhNhiPhan.Image = PhatHienBien_Sobel(HinhGoc, 130);
        }


        /// <summary>
        /// Khai báo hàm tính nhị phân
        /// </summary>
        /// <param name="hinhGoc"></param>
        /// <param name="nguong"></param>
        /// <returns></returns>

        // Hàm chuyển ảnh màu thành ảnh mức xám
        private Bitmap ChuyenAnh_MauSangAnh_MucXam(Bitmap hinhGoc)
        {
            Bitmap grayImage = new Bitmap(hinhGoc.Width, hinhGoc.Height);

            for (int x = 0; x < hinhGoc.Width; x++)
            {
                for (int y = 0; y < hinhGoc.Height; y++)
                {
                    Color pixelColor = hinhGoc.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.2126 + pixelColor.G * 0.7152 + pixelColor.B * 0.0722);
                    grayImage.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }

            return grayImage;
        }

        // Hàm thực hiện phát hiện biên bằng phương pháp Sobel
        private Bitmap PhatHienBien_Sobel(Bitmap grayImage, byte nguong)
        {
            Bitmap edgeImage = new Bitmap(grayImage.Width, grayImage.Height);

            for (int x = 1; x < grayImage.Width - 1; x++)
            {
                for (int y = 1; y < grayImage.Height - 1; y++)
                {
                    // Tính gradient gx và gy theo phương pháp Sobel
                    int gx = Math.Abs(grayImage.GetPixel(x + 1, y).R - grayImage.GetPixel(x ,y).R);
                           
                    int gy = Math.Abs(grayImage.GetPixel(x, y + 1).R - grayImage.GetPixel(x, y).R); 

                    // Tính độ lớn của gradient tại điểm ảnh
                    int gradient = gx + gy;

                    // Phân loại điểm ảnh thành cạnh hoặc nền dựa vào ngưỡng
                    if (gradient <= nguong)
                    {
                        // Nếu gradient nhỏ hơn hoặc bằng ngưỡng, điểm ảnh thuộc nền
                        edgeImage.SetPixel(x, y, Color.FromArgb(0, 0, 0)); // Màu đen cho nền
                    }
                    else
                    {
                        // Ngược lại, điểm ảnh thuộc cạnh
                        edgeImage.SetPixel(x, y, Color.FromArgb(255, 255, 255)); // Màu trắng cho cạnh
                    }
                }
            }

            return edgeImage;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Code for Form1_Load event, if needed
        }

        private void lblHinhGoc_Click(object sender, EventArgs e)
        {
            // Code for lblHinhGoc_Click event, if needed
        }

        private void labl1_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBarHinhNhiPhan_ValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị ngưỡng từ giá trị của thanh cuộn
            // Do giá trị của thanh cuộn là int, trong khi ngưỡng là byte
            // nên cần ép kiểu int về byte
            byte nguong = (byte)trackBar_bien.Value;

            // Cho hien thi gia trị ngưỡng
            label_nguong.Text = nguong.ToString(); 
            // Gọi hàm tính ảnh nhị phân và cho hiển thị
            picBoxHinhNhiPhan.Image = PhatHienBien_Sobel(HinhGoc, nguong);
        }
    }
}
