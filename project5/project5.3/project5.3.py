import cv2
from PIL import Image
import numpy as np
import matplotlib.pyplot as plt


def Chuyendoianhmucxam_RGB_sanganhxam_Luminance(imgPIL):
    # Tạo một ảnh có cùng kích thước và mode với ảnh imgPIL
    # Ảnh này dùng để chứa kết quả chuyển đổi RGB sang Grayscale
    average = Image.new(imgPIL.mode, imgPIL.size)

    # Lấy kích thước của ảnh từ imPIL
    width = average.size[0]
    height = average.size[1]

    # Dùng 2 vòng for để quét toàn bộ pixel
    for x in range(width):
        for y in range(height):
            # Lấy giá trị điểm ảnh tại vị trí (x,y)
            R, G, B = imgPIL.getpixel((x, y))

            # Công thức chuyển đổi điểm ảnh màu RGB thành
            # điểm ảnh mức xám dùng phương phương Luminance
            gray = np.uint8(0.2126 * R + 0.7152 * G + 0.0722 * B)
            # Gán giá trị mức xám vừa tính cho ảnh xám
            average.putpixel((x, y), (gray, gray, gray))
    
    return average


def TinhHistogram(HinhXamPil):
    # Mỗi pixel có giá trị từ 0-255, nên phải khai báo một mảng có
    # 256 phần tử để chứa số đếm của các pixels có cùng giá trị
    his = np.zeros(256)

    for x in range(HinhXamPil.size[0]):
        for y in range(HinhXamPil.size[1]):
            # Lấy giá trị xám tại điểm (x,y)
            gR, _, _ = HinhXamPil.getpixel((x, y))

            # Giá trị gray tính ra cũng chính là phần tử thứ gray
            # trong mảng his đã khai báo trên, sẽ tăng số đếm
            # của phần tử thứ gray lên 1
            his[gR] += 1

    return his


def VeBieuDoHistogram(his):
    trucX = np.arange(256)
    plt.figure('Biểu đồ Histogram ảnh xám')
    plt.plot(trucX, his, color='orange')
    plt.title('Biểu đồ Histogram')
    plt.xlabel('Giá trị mức xám')
    plt.ylabel('Số điểm cùng giá trị mức xám')
    plt.show()


# Khai báo đường dẫn file hình
filehinh = r'D:\hk2nam3\thigiacmay\Project\project1\Project1xla\bird_small.jpg'

# Đọc ảnh màu dùng thư viện PIL. Ảnh PIL này chúng ta sẽ dùng
imgPIL = Image.open(filehinh)

# Chuyển sang ảnh mức xám
HinhXamPil = Chuyendoianhmucxam_RGB_sanganhxam_Luminance(imgPIL)

# Tính Histogram
his = TinhHistogram(HinhXamPil)

# Chuyển ảnh PIL sang OpenCV để hiển thị bằng thư viện cv2
HinhXamCV = np.array(HinhXamPil)
cv2.imshow('Anh muc xam dung Luminance', HinhXamCV )

# Hiển thị biểu đồ Histogram
VeBieuDoHistogram(his)

# Bấm phím bất kỳ để đóng cửa sổ hiển thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()
