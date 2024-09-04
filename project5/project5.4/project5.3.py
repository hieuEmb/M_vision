import cv2
from PIL import Image
import numpy as np
import matplotlib.pyplot as plt

def TinhHistogram(imgPIL):
    # Mỗi pixel có giá trị từ 0-255, nên phải khai báo một mảng có
    # 256 phần tử để chứa số đếm của các pixels có cùng giá trị
    his_R = np.zeros(256)
    his_G = np.zeros(256)
    his_B = np.zeros(256)
    
    for x in range(imgPIL.size[0]):
        for y in range(imgPIL.size[1]):
            # Lấy giá trị xám tại điểm (x,y)
            R, G, B = imgPIL.getpixel((x, y))

            # Tăng số đếm của phần tử thứ R, G, B lên 1
            his_R[R] += 1
            his_G[G] += 1
            his_B[B] += 1

    return his_R, his_G, his_B

def VeBieuDoHistogram(his_R, his_G, his_B):
    trucX = np.arange(256)
    
    plt.figure('Biểu đồ Histogram ảnh màu')
    plt.plot(trucX, his_R, color='red', label='Red')
    plt.plot(trucX, his_G, color='green', label='Green')
    plt.plot(trucX, his_B, color='blue', label='Blue')

    plt.title('Biểu đồ Histogram')
    plt.xlabel('Giá trị mức xám')
    plt.ylabel('Số điểm cùng giá trị mức xám')
    plt.legend()
    plt.show()

# Đường dẫn đến tệp hình ảnh
filehinh = r'D:\hk2nam3\thigiacmay\Project\project1\Project1xla\bird_small.jpg'

# Đọc ảnh màu dùng thư viện PIL
imgPIL = Image.open(filehinh)

# Tính Histogram cho từng kênh màu
his_R, his_G, his_B = TinhHistogram(imgPIL)

# Chuyển ảnh PIL sang OpenCV để hiển thị bằng thư viện cv2
HinhMauCV = np.array(imgPIL)
cv2.imshow('Anh mau', HinhMauCV)

# Hiển thị biểu đồ Histogram cho từng kênh màu
VeBieuDoHistogram(his_R, his_G, his_B)

# Nhấn bất kỳ phím nào để đóng cửa sổ hiển thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()
