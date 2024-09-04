import cv2
from PIL import Image
import numpy as np

filehinh = r'C:\Users\Admin\Desktop\Thi_Giac\Bai_10\lena_color.png'

imgPIL = Image.open(filehinh)
# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh, cv2.IMREAD_COLOR)

HinhY = Image.new(imgPIL.mode, imgPIL.size)

width = imgPIL.size[0]
height = imgPIL.size[1]

# Ma trận thay thế để tính Laplacian
matran = np.array([[0,-1,0], [-1, 4, -1], [0, -1, 0]])

# Lặp qua từng pixel trong ảnh
for x in range(1, width - 1):
    for y in range(1, height - 1):
        R, G, B = imgPIL.getpixel((x, y))

        # Tính toán giá trị Laplacian cho từng kênh màu
        blue = 0
        green = 0
        red = 0
        for i in range(x - 1, x + 2):
            for j in range(y - 1, y + 2):
                R1, G1, B1 = imgPIL.getpixel((i, j))
                blue += B1 * matran[i - x + 1, j - y + 1]
                green += G1 * matran[i - x + 1, j - y + 1]
                red += R1 * matran[i - x + 1, j - y + 1]

        # Cập nhật giá trị của pixel trong ảnh kết quả
        HinhY.putpixel((x, y), (int(blue), int(green), int(red)))

sharpened = cv2.add(np.array(img), np.array(HinhY))
AnhY = np.array(HinhY)
# Hiển thị ảnh kết quả
cv2.imshow('Anh Goc', img)
cv2.imshow('Anh Laplacian', AnhY)
cv2.imshow('Anh Ket Hop', sharpened)
cv2.waitKey(0)
cv2.destroyAllWindows()
