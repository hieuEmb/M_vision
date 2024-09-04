using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Tạo một biến chứa đường dẫn nơi lưu hình màu RGB gốc cần xử lý.
            // Lưu ý: cần phải có ký tự @ phía trước để C#.NET biết chuỗi là unicode
            string filehinh= @"D:\hk2nam3\thigiacmay\Project\project1\projectxla1.1xla\lena_color.png";

            // Tạo một biến chứa hình bitmap được load từ file hình.
            Bitmap hinhgoc = new Bitmap(filehinh);

            //gọi nó ra pictureBox1
            pictureBox1.Image = hinhgoc;

            //tiếp tục khai báo 3 bitmap R-G-B
            Bitmap red = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap green = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap blue = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            // Mỗi hình là một ma trận 2 chiều nên dùng tới 2 vòng lặp for để đọc hết các điểm ảnh trong hình.
            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    // Đọc giá trị pixel tại vị trí điểm ảnh (x,y)
                    Color pixel = hinhgoc.GetPixel(x,y);

                    //Mỗi pixel chứa 4 thông tin gồm giá trị màu, R,G,B và giá trị thông tin về độ trong suốt A
                    byte R = pixel.R;// giá trị kênh RED
                    byte G = pixel.G;// giá trị kênh Green
                    byte B = pixel.B;// giá trị kênh Blue
                    byte A = pixel.A;// giá trị độ trong suốt

                    //set giá trị pixel đọc được cho các hình chứa các kênh màu tương ứng R, G, B
                    red.SetPixel(x,y,Color.FromArgb(A, R, 0, 0));
                    green.SetPixel(x, y, Color.FromArgb(A, 0, G, 0));
                    blue.SetPixel(x, y, Color.FromArgb(A, 0, 0, B));

                }
            // Hiển thị 3 kênh màu R, G, B tại các Pixbox đã tạo
            pictureBox2.Image = red; 
            pictureBox3.Image = green; 
            pictureBox4.Image = blue;
        }
    }
}
