import cv2
from PIL import Image
import numpy as np

filehinh = r'D:\hk2nam3\thigiacmay\tailieu\lena_color.png'

imgPIL = Image.open(filehinh)
# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh, cv2.IMREAD_COLOR)

HinhY = Image.new(imgPIL.mode, imgPIL.size)

width = imgPIL.size[0]
height = imgPIL.size[1]

# Lặp qua từng pixel trong ảnh
for x in range(1, width - 1):
    for y in range(1, height - 1):
        R, G, B = imgPIL.getpixel((x, y))
        # Tính toán giá trị Laplacian cho từng kênh màu
        B1 = 0
        G1 = 0
        R1 = 0
        for i in range(x - 1, x + 1):
            for j in range(y - 1, y + 1):
                R, G, B = imgPIL.getpixel((i, j))
        # Tính toán giá trị Laplacian cho từng kênh màu
                blue = (imgPIL.getpixel((x-1, y))[2] + imgPIL.getpixel((x+1, y))[2] +
                        imgPIL.getpixel((x, y-1))[2] + imgPIL.getpixel((x, y+1))[2]) - 4 * (imgPIL.getpixel((x, y))[2])
                green = (imgPIL.getpixel((x-1, y))[1] + imgPIL.getpixel((x+1, y))[1] +
                        imgPIL.getpixel((x, y-1))[1] + imgPIL.getpixel((x, y+1))[1]) - 4 * (imgPIL.getpixel((x, y))[1])
                red = (imgPIL.getpixel((x-1, y))[0] + imgPIL.getpixel((x+1, y))[0] +
                imgPIL.getpixel((x, y-1))[0] + imgPIL.getpixel((x, y+1))[0]) - 4 * (imgPIL.getpixel((x, y))[0])

                B1 = B + (1 * blue)
                G1 = G + (1 * green)
                R1 = R + (1 * red)
        # Cập nhật giá trị của pixel trong ảnh kết quả
        HinhY.putpixel((x, y), (B1, G1, R1))
AnhY = np.array(HinhY)
AnhY = cv2.convertScaleAbs(AnhY)

# Hiển thị ảnh kết quả
cv2.imshow('Anh Goc', img)
cv2.imshow('Anh Laplacian', AnhY)
cv2.waitKey(0)
cv2.destroyAllWindows()
