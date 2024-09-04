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



            // Bây giờ gọi các hàm đã viết để vẽ biểu đồ
            double[,] histogram = TinhHistogram(HinhGoc);

            // Chuyển đổi kiểu dữ liệu.
            List<PointPairList> points = ChuyenDoiHistogram(histogram);

            // Vẽ biểu đồ và hiển thị
            zedGraphControl1.GraphPane = BieuDoHistogram(points);
            zedGraphControl1.Refresh();
        }

        /// <summary>
        /// Tính Histogram
        /// </summary>
        /// <param name="HinhMucXam"></param>
        /// <returns></returns>
        private double[,] TinhHistogram (Bitmap bmp)
        {
            // Dùng mảng 2 chiều chứa thông tin Histogram
            // Cho các kênh G-R-B.
            // 3 là số kênh màu cần lưu
            // 256 là cần 256 vị trí tương ứng giá màu từ 0 đến 255
            double[,] histogram = new double[3, 256];
            for (int x = 0; x < bmp.Width; x++)

                for (int y = 0; y < bmp.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color color = bmp.GetPixel(x, y);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    histogram[0, R]++; //histogram của kênh màu Red
                    histogram[1, G]++; //histogram của kênh màu Green
                    histogram[2, B]++; //histogram của kênh màu Blue                                  
            
                }
            return histogram;// Trả mảng 2 chiều chứa thông tin histogram của R-G-B
        }

        private GraphPane BieuDoHistogram(List<PointPairList> histogram)
            {

                // GraphPane là đối tượng biểu đồ trong ZedGrap.
                GraphPane gp = new GraphPane();


                gp.Title.Text = @"Biểu đồ Histogram"; // Tên của biểu đồ
                gp.Rect = new Rectangle(0, 0, 700, 500);// Khung chứa biểu đồ.

                // Thiết lập trục ngang
                gp.XAxis.Title.Text = @"Màu của các điểm ảnh";
                gp.XAxis.Scale.Min = 0;
                gp.XAxis.Scale.Max = 255;
                gp.XAxis.Scale.MajorStep = 5;
                gp.XAxis.Scale.MinorStep = 1;

                // Thiết lập trục đứng
                gp.YAxis.Title.Text = @"Số điểm ảnh có cùng giá trị màu";
                gp.YAxis.Scale.Min = 0;
                gp.YAxis.Scale.Max = 15000; // Số này phải lớn hơn kích thước của ảnh
                gp.YAxis.Scale.MajorStep = 5;
                gp.YAxis.Scale.MinorStep = 1;

                // Dùng dạng biểu đồ bar để biểu diễn
                gp.AddBar("Histogram's Red", histogram[0], Color.Red);
                gp.AddBar("Histogram's Green", histogram[1], Color.Green);
                gp.AddBar("Histogram's Blue", histogram[2], Color.Blue);

                return gp;
            }


            List<PointPairList> ChuyenDoiHistogram(double[,] histogram)
            {
                // Dùng một mảng không cần khai báo trước số lượng phần tử
                // để chứa các chuyển đổi
                List<PointPairList> points = new List<PointPairList>();
                PointPairList redPoints = new PointPairList(); // Chuyển đổi histogram kênh R
                PointPairList greenPoints = new PointPairList(); // Chuyển đổi histogram kênh G
                PointPairList bluePoints = new PointPairList(); // Chuyển đổi histogram kênh B

                for (int i = 0; i < 256; i++)
                {
                    // i tương ứng với trục nằm ngang từ 0-255
                    // histogram [i] tương ứng với trục đứng, là số pixels cùng mức xám
                    redPoints.Add(i, histogram[0, i]); // Chuyển đổi kênh cho R
                    greenPoints.Add(i, histogram[1, i]); // Chuyển đổi kênh cho G
                    bluePoints.Add(i, histogram[2, i]); // Chuyển đổi kênh cho B

                }
                // Sau khi kết thúc vòng for thì thông tin histogram của các kênh G, R, B đã được chuyển
                // thành công, giờ add các kênh vào mảng points để trả về cho hàm
                points.Add(redPoints);
                points.Add(greenPoints);
                points.Add(bluePoints);

                return points;
            }
       
    }
}


