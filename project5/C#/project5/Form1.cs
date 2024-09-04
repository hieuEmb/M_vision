using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace project5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Load ảnh từ file
            Bitmap HinhGoc = new Bitmap(@"D:\hk2nam3\thigiacmay\Project\project1\Project1xla\bird_small.jpg");

            // Hiển thị lên picbox
            pictureBox1.Image = HinhGoc;

            // Tính hình mức xám theo phương pháp Average và cho hiển thị
            pictureBox2.Image = ChuyenHinh_RGB_SangHinh_Xam_Luminance(HinhGoc);

            // Bây giờ gọi các hàm đã viết để vẽ biểu đồ
            double[] histogram = TinhHistogram(new Bitmap(pictureBox2.Image));

            // Chuyển đổi kiểu dữ liệu.
            PointPairList points = ChuyenDoiHistogram(histogram);

            // Vẽ biểu đồ và hiển thị
            zedGraphControl1.GraphPane = BieuDoHistogram(points);
            zedGraphControl1.Refresh();
        }
        /// <summary>
        /// Hình xám Luminance
        /// </summary>
        /// <param name="hinhGoc"></param>
        /// <returns></returns>
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
                    byte gray = (byte)(0.7152 * G + 0.2126 * R + 0.0722 * B);

                    // Gán giá trị mức xám vừa tính vào hình mức xám
                    HinhMucXam.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return HinhMucXam;
        }
        /// <summary>
        /// Tính Histogram
        /// </summary>
        /// <param name="HinhMucXam"></param>
        /// <returns></returns>
        private double[] TinhHistogram(Bitmap HinhMucXam)
        {
            // Mỗi pixel mức xám có giá trị từ 0-255, do vậy ta cần khai báo một mảng
            // có 256 phần tử dùng để chứa số đếm của các pixels có cùng mức xám trong ảnh.
            // Chúng ta nên dùng kiểu double vì tổng số đếm có thể rất lớn, phụ thuộc vào kích thước ảnh
            double[] histogram = new double[256];
            for (int x = 0; x < HinhMucXam.Width; x++)

                for (int y = 0; y < HinhMucXam.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color color = HinhMucXam.GetPixel(x, y);
                    byte gray = color.R;// Trong hình mức xám giá trị 3 kênh giống nhau

                    // Giá trị gray tính ra cũng chính là phần tử thứ gray trong mảng histogram
                    // đã khai báo. Sẽ tăng số đếm của phần tử gray lên 1

                    histogram[gray]++;
                }
            return histogram;
        }

        private GraphPane BieuDoHistogram(PointPairList histogram)
        {

            // GraphPane là đối tượng biểu đồ trong ZedGrap.
            GraphPane gp = new GraphPane();


            gp.Title.Text = @"Biểu đồ Histogram"; // Tên của biểu đồ
            gp.Rect = new Rectangle(0, 0, 700, 500);// Khung chứa biểu đồ.

            // Thiết lập trục ngang
            gp.XAxis.Title.Text = @"Giá trị mức xám của các điểm ảnh";
            gp.XAxis.Scale.Min = 0;
            gp.XAxis.Scale.Max = 255;
            gp.XAxis.Scale.MajorStep = 5;
            gp.XAxis.Scale.MinorStep = 1;

            // Thiết lập trục đứng
            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng mức xám";
            gp.YAxis.Scale.Min = 0;
            gp.YAxis.Scale.Max = 15000; // Số này phải lớn hơn kích thước của ảnh
            gp.YAxis.Scale.MajorStep = 5;
            gp.YAxis.Scale.MinorStep = 1;

            // Dùng dạng biểu đồ bar để biểu diễn
            gp.AddBar("Histogram", histogram, Color.OrangeRed);

            return gp;
        }
        PointPairList ChuyenDoiHistogram(double[] histogram)
        {
            // Dùng một mảng không cần khai báo trước số lượng phần tử
            // để chứa các chuyển đổi
            PointPairList Points = new PointPairList(); // Chuyển đổi histogram kênh R
           

            for (int i = 0; i < 256; i++)
            {
                // i tương ứng với trục nằm ngang từ 0-255
                // histogram [i] tương ứng với trục đứng, là số pixels cùng mức xám
                Points.Add(i, histogram[i]); // Chuyển đổi kênh cho R
               

            }
            // Sau khi kết thúc vòng for thì thông tin histogram của các kênh G, R, B đã được chuyển
            // thành công, giờ add các kênh vào mảng points để trả về cho hàm
           
            return Points;
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
