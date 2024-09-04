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
        public Form1()
        {
            InitializeComponent();

            // Load ảnh từ file
            Bitmap HinhGoc = new Bitmap(@"D:\hk2nam3\thigiacmay\Project\project1\Project1xla\bird_small.jpg");

            // Hiển thị lên picbox
            picBoxHinhGoc.Image = HinhGoc;

            // Tính hình mức xám theo phương pháp Lighness và cho hiển thị
            picBoxHinhXam.Image = ChuyenHinh_RGB_SangHinh_Xam_Lightness(HinhGoc);

            // Tính hình mức xám theo phương pháp Average và cho hiển thị
            picBoxHinhXamAverage.Image = ChuyenHinh_RGB_SangHinh_Xam_Average(HinhGoc);

            // Tính hình mức xám theo phương pháp Average và cho hiển thị
            picBoxHinhXamLuminanc.Image = ChuyenHinh_RGB_SangHinh_Xam_Luminance(HinhGoc);
        }

        /// <summary>
        /// Khai báo hàm tính toán mức xám theo phương pháp Lightness
        /// </summary>
        private Bitmap ChuyenHinh_RGB_SangHinh_Xam_Lightness(Bitmap hinhGoc)
        {
            Bitmap HinhMucXam = new Bitmap(hinhGoc.Width, hinhGoc.Height);

            for (int x = 0; x < hinhGoc.Width; x++)
            {
                for (int y = 0; y < hinhGoc.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color pixel = hinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    // Tính giá trị mức xám cho điểm ảnh tại (x, y) theo phương pháp Lightness
                    byte max = Math.Max(R, Math.Max(G, B));
                    byte min = Math.Min(R, Math.Min(G, B));
                    byte gray = (byte)((max + min) / 2);

                    // Gán giá trị mức xám vừa tính vào hình mức xám
                    HinhMucXam.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return HinhMucXam;
        }

        /// <summary>
        /// Khai bao ham tinh muc xam theo phuong phap trung binh
        /// </summary>
        private Bitmap ChuyenHinh_RGB_SangHinh_Xam_Average(Bitmap hinhGoc)
        {
            Bitmap HinhMucXam = new Bitmap(hinhGoc.Width, hinhGoc.Height);

            for (int x = 0; x < hinhGoc.Width; x++)
            {
                for (int y = 0; y < hinhGoc.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color pixel = hinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    // Tính giá trị mức xám cho điểm ảnh tại (x, y) theo phương pháp Average
                    byte gray = (byte)((G + R + B) / 3);

                    // Gán giá trị mức xám vừa tính vào hình mức xám
                    HinhMucXam.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return HinhMucXam;
        }




        private Bitmap ChuyenHinh_RGB_SangHinh_Xam_Luminance(Bitmap hinhGoc)
        {
            Bitmap HinhMucXam = new Bitmap(hinhGoc.Width, hinhGoc.Height);

            for (int x = 0; x < hinhGoc.Width; x++)
            {
                for (int y = 0; y < hinhGoc.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color pixel = hinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    // Tính giá trị mức xám cho điểm ảnh tại (x, y) theo phương pháp Luminace
                    byte gray = (byte)(0.7152*G + 0.2126*R + 0.0722*B);

                    // Gán giá trị mức xám vừa tính vào hình mức xám
                    HinhMucXam.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return HinhMucXam;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Code for Form1_Load event, if needed
        }

        private void lblHinhGoc_Click(object sender, EventArgs e)
        {
            // Code for lblHinhGoc_Click event, if needed
        }
    }
}
